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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

namespace BiteTheBullet.BtbTweet.Components
{
    /// <summary>
    /// Provides strong typed access to settings used by module
    /// </summary>
    public class BtbTweetSettings
    {
        ModuleController controller;
        int tabModuleId;

        public enum QueryMode
        {
            UserTimeline,
            Search
        }

        public BtbTweetSettings(int tabModuleId)
        {
            controller = new ModuleController();
            this.tabModuleId = tabModuleId;
        }

        protected T ReadSetting<T>(string settingName, T defaultValue)
        {
            Hashtable settings = controller.GetTabModuleSettings(this.tabModuleId);

            T ret = default(T);

            if (settings.ContainsKey(settingName))
            {
                System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                try
                {
                    ret = (T)tc.ConvertFrom(settings[settingName]);
                }
                catch
                {
                    ret = defaultValue;
                }
            }
            else
                ret = defaultValue;

            return ret;
        }

        protected void WriteSetting(string settingName, string value)
        {
            controller.UpdateTabModuleSetting(this.tabModuleId, settingName, value);
        }

        #region public properties

        /// <summary>
        /// get/set the tweet query mode
        /// </summary>
        public QueryMode TweetQueryMode
        {
            get { return ReadSetting<QueryMode>("TweetQueryMode", QueryMode.Search); }
            set { WriteSetting("TweetQueryMode", value.ToString()); }
        }

        /// <summary>
        /// get/set the usernames to return the tweets for.
        /// </summary>
        /// <remarks>multiple users should be separated with a comma</remarks>
        public string Username
        {
            get { return ReadSetting<string>("username", null); }
            set { WriteSetting("username", value); }
        }

        /// <summary>
        /// get/set the number of tweets to return
        /// </summary>
        /// <remarks>this should be a value between 1 and 100</remarks>
        public int FeedCount
        {
            get { return ReadSetting<int>("feedCount", 10); }
            set { WriteSetting("feedCount", value.ToString()); }
        }

        /// <summary>
        /// get/set the query terms
        /// </summary>
        public string Query
        {
            get { return ReadSetting<string>("query", null); }
            set { WriteSetting("query", value); }
        }

        /// <summary>
        /// get/set the template file
        /// </summary>
        public string Template
        {
            get { return ReadSetting<string>("template", "AngularTemplate.cshtml"); }
            set { WriteSetting("template", value); }
        }

        /// <summary>
        /// get/set avatar size
        /// </summary>
        /// <remarks>0 to 48 to pixels range</remarks>
        [Obsolete]
        public int AvatarSize
        {
            get { return ReadSetting<int>("avatarSize", 32); }
            set { WriteSetting("avatarSize", value.ToString()); }
        }



        #endregion
    }
}
