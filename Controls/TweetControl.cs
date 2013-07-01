/*
 * BtbTweet - DotNetNuke module to display tweets from Twitter in a module.
Copyright (C) 2013 Mark McAvoy

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiteTheBullet.BtbTweet.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TweetControl runat=server></{0}:TweetControl>")]
    public class TweetControl : WebControl
    {
        int avatarSize = 32;

        /// <summary>
        /// get/set the class of the contain which will hold the tweets
        /// </summary>
        public new string CssClass
        {
            get;
            set;
        }

        /// <summary>
        /// holds the username(s) to return twitter feeds for.
        /// </summary>
        /// <remarks>separate username with a comma</remarks>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// get/set the number of twitter feeds to display in the page
        /// </summary>
        /// <remarks>Default value is 10 tweets</remarks>
        public int FeedCount
        {
            get;
            set;
        }

        /// <summary>
        /// get/set the query used to search for tweets
        /// </summary>
        public string SearchTerm
        {
            get;
            set;
        }

        /// <summary>
        /// get/set the size of the avatar to display against each tweet
        /// </summary>
        /// <remarks>Set the value to 0 to have the avatars turned off. The
        /// maximum size that can be used is 48.</remarks>
        public int AvatarSize
        {
            get
            {
                return avatarSize;
            }
            set
            {
                if (value > 48)
                    avatarSize = 48;
                else
                    avatarSize = value;
            }
        }

        /// <summary>
        /// Get/set the path to the js file to load
        /// </summary>
        /// <remarks>If this is not set the default path is used.
        /// "~/js/jquery.tweet.js</remarks>
        public string JavascriptPath
        {
            get;
            set;
        }

        /// <summary>
        /// get/set the caption to display while loading the tweets from twitter
        /// </summary>
        public string LoadingTweetsCaption
        {
            get;
            set;
        }

        /// <summary>
        /// readonly property to return the usernames in a format for the
        /// jscript library.
        /// </summary>
        /// <remarks>these values come from the username property</remarks>
        private string TweetUsername
        {
            get
            {
                StringBuilder builder = new StringBuilder();

                if (!string.IsNullOrEmpty(Username))
                {
                    string[] names = Username.Split(',');

                    builder.Append("[");

                    foreach (string name in names)
                    {
                        builder.AppendFormat("\"{0}\",", name.Trim());
                    }

                    //remove trailing ","
                    builder.Remove(builder.Length - 1, 1);
                    builder.Append("]");
                }
                else
                    builder.Append("\"\"");

                return builder.ToString();
            }
        }


        /// <summary>
        /// readonly property to create the correct search term
        /// </summary>
        /// <remarks>this is required since if we have a SearchTerm and Username setting we need
        /// to create a speically constructed query for twitter to return the correct
        /// search results</remarks>
        private string TweetSearchTerm
        {
            get
            {
                if (String.IsNullOrEmpty(SearchTerm))
                    return null;
                else if (String.IsNullOrEmpty(Username))
                    return string.Format("\"{0}\"", SearchTerm);
                else
                {
                    //before username and query have valid parameters we need to create
                    //the correct query to get the data back
                    string[] usernames = Username.Split(',');

                    StringBuilder builder = new StringBuilder();
                    builder.Append('"');
                    foreach (string username in usernames)
                    {
                        builder.AppendFormat("from:{0} OR ", username);
                    }

                    builder.Remove(builder.Length - 3, 3);
                    builder.Append(SearchTerm);
                    builder.Append('"');

                    return builder.ToString();
                }
            }
        }

        /// <summary>
        /// Loads the tweet jquery plugin to the page
        /// </summary>
        /// <returns></returns>
        private string LoadScript()
        {
            string tweetScript;
            string tweetScriptPath;

            if (string.IsNullOrEmpty(JavascriptPath))
            {
                tweetScript = "jquery.tweet.js";
                tweetScriptPath = Page.ResolveUrl(string.Format("~/js/{0}", tweetScript));
            }
            else
                tweetScriptPath = JavascriptPath;

            StringBuilder buffer = new StringBuilder();
            buffer.AppendFormat("<script type=\"text/javascript\" src=\"{0}\"></script>", tweetScriptPath);
            return buffer.ToString();
        }

        /// <summary>
        /// Creates the script block used to load the parameters into the
        /// script
        /// </summary>
        /// <returns></returns>
        private string TweetScript()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<script type=\"text/javascript\">");

            builder.AppendFormat("var settings{0} = {{", CssClass);

            //if(string.IsNullOrEmpty(SearchTerm))
                builder.AppendFormat(" username: {0},\r\n", TweetUsername);

            builder.AppendLine(" join_text: \"auto\",");
            builder.AppendFormat("avatar_size: {0},\r\n", AvatarSize == 0 ? "null" : AvatarSize.ToString());
            builder.AppendFormat("count: {0},\r\n", FeedCount <= 0 | FeedCount > 100 ? 10 : FeedCount);
            builder.AppendLine("auto_join_text_default: \"\",");
            builder.AppendLine("auto_join_text_ed: \"\",");
            builder.AppendLine("auto_join_text_ing: \"\",");
            builder.AppendLine("auto_join_text_reply: \"\",");
            builder.AppendLine("auto_join_text_url: \"\",");

            if (string.IsNullOrEmpty(LoadingTweetsCaption))
                builder.AppendLine("loading_text: \"loading tweets...\",");
            else
                builder.AppendFormat("loading_text: \"{0}\",\r\n", LoadingTweetsCaption);

            builder.AppendFormat("query: {0}}};\r\n", TweetSearchTerm ?? "null");

            builder.AppendLine("jQuery(document).ready(function(){");
            builder.AppendFormat("jQuery(\".{0}\").tweet(settings{0});\r\n", CssClass);

            builder.AppendFormat("jQuery(\".{0}Link\").click(function(){{\r\n", CssClass);
            builder.AppendFormat("jQuery(\".{0}\").empty();", CssClass);
            builder.AppendFormat("jQuery(\".{0}\").tweet(settings{0});\r\n", CssClass);
            builder.AppendLine("return false;");
            builder.AppendLine("});");

            builder.AppendLine("});");
            builder.AppendLine("</script>");

            return builder.ToString();
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(LoadScript());
            output.Write("<div class=\"{0} tweet\"></div>", CssClass);
            output.Write("<div><a class=\"{0}Link\" href=\"#\">Refresh</a></div>", CssClass);
            output.Write(TweetScript());
        }
    }
}
