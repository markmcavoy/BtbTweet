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
    /// <summary>
    /// Summary description for Twitter
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Twitter : System.Web.Services.WebService
    {

        [WebMethod]
        public TwitterInfo[] LoadTweets(int portalId, int tabModuleId)
        {
            var settings = new BtbTweetSettings(tabModuleId);
            var service = new TwitterService(new DnnCacheProvider());

            IList<TwitterInfo> results = null;

            if (settings.TweetQueryMode == BtbTweetSettings.QueryMode.Search
                        && !string.IsNullOrEmpty(settings.Query))
            {
                results = service.DoSearch(settings.Query, settings.FeedCount);
            }
            else if (settings.TweetQueryMode == BtbTweetSettings.QueryMode.UserTimeline
                && !string.IsNullOrEmpty(settings.Username))
            {
                results = service.UserTimeLine(settings.Username, settings.FeedCount);
            }


            if (results == null)
            {
                return null;
            }
            else
            {
                return results.ToArray();
            }
            //return RenderTemplate(portalId, 
            //                        tabModuleId, 
            //                        settings.Template, 
            //                        results);
        }
        
        //delete me
        /// <summary>
        /// render the template with the data
        /// </summary>
        /// <param name="portalId"></param>
        /// <param name="tabModuleId"></param>
        /// <param name="templateFile"></param>
        /// <param name="tweets"></param>
        /// <param name="viewBag"></param>
        /// <returns></returns>
        //protected string RenderTemplate(int portalId, int tabModuleId, string templateFile, IList<TwitterInfo> tweets, dynamic viewBag = null)
        //{
        //    if (tweets == null)
        //        return string.Empty;

            

        //    //add in some common DNN and CV objects into the
        //    //viewbag

        //    //todo: MM razor merge the viewbag with the data we are going to push into the object
        //    if (viewBag == null)
        //    {
        //        viewBag = new ExpandoObject();
        //    }

        //    viewBag.PortalId = portalId;
        //    viewBag.TabModuleId = tabModuleId;

        //    templateFile = "~/DesktopModules/BtbTweet/Templates/" + templateFile;

        //    var rm = RazorService.Instance();
        //    var t = rm.ExecuteUrl(templateFile, tweets, viewBag);

        //    return t.Result;
        //}
    }
}
