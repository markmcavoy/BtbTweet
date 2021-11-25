using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BiteTheBullet.BtbTweet.Components;
using BiteTheBullet.BtbTweet.Twitter;
using System.Dynamic;

namespace BiteTheBullet.BtbTweet.WebServices
{
    //    /// <summary>
    //    /// Summary description for Twitter
    //    /// </summary>
    //    [WebService(Namespace = "http://tempuri.org/")]
    //    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //    [System.ComponentModel.ToolboxItem(false)]
    //    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //    [System.Web.Script.Services.ScriptService]
    //    public class Twitter : System.Web.Services.WebService
    //    {

    //        [WebMethod]
    //        public TwitterInfo[] LoadTweets(int portalId, int tabModuleId)
    //        {
    //            var settings = new BtbTweetSettings(tabModuleId);
    //            var service = new TwitterService(new DnnCacheProvider());

    //            IList<TwitterInfo> results = null;

    //            if (settings.TweetQueryMode == BtbTweetSettings.QueryMode.Search
    //                        && !string.IsNullOrEmpty(settings.Query))
    //            {
    //                results = service.DoSearch(settings.Query, settings.FeedCount);
    //            }
    //            else if (settings.TweetQueryMode == BtbTweetSettings.QueryMode.UserTimeline
    //                && !string.IsNullOrEmpty(settings.Username))
    //            {
    //                results = service.UserTimeLine(settings.Username, settings.FeedCount);
    //            }


    //            if (results == null)
    //            {
    //                return null;
    //            }
    //            else
    //            {
    //                return results.ToArray();
    //            }
    //        }


    //    }
}
