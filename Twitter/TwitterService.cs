using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq;
using DotNetNuke.Instrumentation;
using System.Dynamic;

namespace BiteTheBullet.BtbTweet.Twitter
{
    public class TwitterService
    {
        const string consumer_key = "V6mKpi2LAm1oTIsGGsBUQ";
        const string consumer_secret = "FzhCA53keMgWz8RG7mOG1BeCNsgEUs1n0DPR4JWdCoI";

        protected static readonly DnnLogger Log = DnnLogger.GetLogger("BiteTheBullet.BtbTweet.Twitter.TwitterService");

        ICacheProvider cacheProvider;

        public TwitterService(ICacheProvider cacheProvider)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            this.cacheProvider = cacheProvider;
        }

        /// <summary>
        /// generate a bearer token we can use to make requests with
        /// </summary>
        /// <returns></returns>
        public string GenerateBearerToken()
        {
            if (cacheProvider != null && !string.IsNullOrEmpty(cacheProvider.GetBearer()))
            {
                return cacheProvider.GetBearer();
            }

            var basicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", consumer_key, consumer_secret)));

            Uri address = new Uri("https://api.twitter.com/oauth2/token");

            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.Headers.Add("Authorization", "Basic " + basicAuth);
            
            byte[] byteData = UTF8Encoding.UTF8.GetBytes("grant_type=client_credentials".ToString());

            request.ContentLength = byteData.Length;

            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                var data = reader.ReadToEnd();
                Log.DebugFormat("Oath response: {0}", data);

                dynamic json = JsonConvert.DeserializeObject(data);

                if (cacheProvider != null)
                    cacheProvider.SetBearer(json.access_token.Value);

                return json.access_token;
            } 
        }

        public IList<TwitterInfo> UserTimeLine(string username, int count)
        {
            if (cacheProvider != null && cacheProvider.GetUserTimeline(username, count) != null)
                return cacheProvider.GetUserTimeline(username, count);

            Uri address = new Uri(string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count={1}", HttpUtility.UrlEncode(username), count));

            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + GenerateBearerToken());

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                var data = reader.ReadToEnd();
                Log.DebugFormat("User timeline data:{0}", data);

                var json = JsonConvert.DeserializeObject<IList<TwitterResponseDto>>(data);
                var twitterResult = new List<TwitterInfo>();

                foreach (var item in json)
                {

                    twitterResult.Add(new TwitterInfo()
                    {
                        StatusId = item.id,
                        Created = ParseTwitterDate(item.created_at),
                        Text = item.text,
                        ProfileImage = item.user.profile_image_url,
                        ProfileName = item.user.name,
                        HashTags = item.entities?.hashtags?.Select(h => h.text)?.ToArray(),
                        TwitterUsername = item.user.screen_name,
                        RetweetCount = item.retweet_count,
                        FavouriteCount = item.favorite_count
                    });
                }

                if (cacheProvider != null)
                    cacheProvider.SetUserTimeline(username, count, twitterResult);

                return twitterResult;

            }
        }

        public IList<TwitterInfo> DoSearch(string queryTerm, int count)
        {
            if (cacheProvider != null && cacheProvider.GetSearchResults(queryTerm, count) != null)
                return cacheProvider.GetSearchResults(queryTerm, count);

            Uri address = new Uri(string.Format("https://api.twitter.com/1.1/search/tweets.json?q={0}&count={1}", HttpUtility.UrlEncode(queryTerm), count));

            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + GenerateBearerToken());

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                //dynamic json = JsonConvert.DeserializeObject(reader.ReadToEnd());
                //return json.access_token;
                dynamic json = JsonConvert.DeserializeObject(reader.ReadToEnd());
                var twitterResult = new List<TwitterInfo>();

                foreach (var item in json.statuses)
                {
                    twitterResult.Add(new TwitterInfo() 
                    {
                        StatusId = long.Parse(item.id_str.Value),
                        Created = ParseTwitterDate(item.created_at.Value),
                        Text = item.text.Value,
                        ProfileImage = item.user.profile_image_url.Value,
                        ProfileName = item.user.name.Value
                    });
                }

                if (cacheProvider != null)
                    cacheProvider.SetSearchResults(queryTerm, count, twitterResult);

                return twitterResult;

            }
        }

        private DateTime ParseTwitterDate(string dateString)
        {
            return DateTime.ParseExact(dateString, "ddd MMM dd HH:mm:ss zzzz yyyy", new CultureInfo("en-US"));
        }
    }
}