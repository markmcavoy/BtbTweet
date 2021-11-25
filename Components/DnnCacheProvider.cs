using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiteTheBullet.BtbTweet.Twitter;
using DotNetNuke.Common.Utilities;

namespace BiteTheBullet.BtbTweet.Components
{
    public class DnnCacheProvider : ICacheProvider
    {
        public string GetBearer()
        {
            return DataCache.GetCache<string>("BTB_TWEET_BEARER_TOKEN");
        }

        public void SetBearer(string bearerToken)
        {
            DataCache.SetCache("BTB_TWEET_BEARER_TOKEN", bearerToken, DateTime.Now.AddHours(24));
        }

        public IList<TwitterInfo> GetSearchResults(string query, int count)
        {
            string key = string.Format("BTB_TWEET_SEARCH_DATA_{0}_{1}", query, count);
            return DataCache.GetCache<IList<TwitterInfo>>(key);
        }

        public void SetSearchResults(string query, int count, IList<TwitterInfo> results)
        {
            string key = string.Format("BTB_TWEET_SEARCH_DATA_{0}_{1}", query, count);
            DataCache.SetCache(key, results, DateTime.Now.AddMinutes(15));
        }


        public IList<TwitterInfo> GetUserTimeline(string username, int count)
        {
            string key = string.Format("BTB_TWEET_USER_DATA_{0}_{1}", username, count);
            return DataCache.GetCache<IList<TwitterInfo>>(key);
        }

        public void SetUserTimeline(string username, int count, IList<TwitterInfo> results)
        {
            string key = string.Format("BTB_TWEET_USER_DATA_{0}_{1}", username, count);
            DataCache.SetCache(key, results, DateTime.Now.AddMinutes(15));
        }

        public void SetUserTimeline(string v, List<TwitterInfo> twitterResult)
        {
            throw new NotImplementedException();
        }

        public void GetTwitterMedia(long id)
        {
            throw new NotImplementedException();
        }
    }
}