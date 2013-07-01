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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Framework;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using BiteTheBullet.BtbTweet.Components;

namespace BiteTheBullet.Modules.BtbTweet
{
    public partial class ViewBtbTweet : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
#if !DNN4
                jQuery.RequestRegistration();
#endif

                BtbTweetSettings settings = new BtbTweetSettings(this.TabModuleId);

                Tweet.CssClass = string.Format("BtbTweet{0}", TabModuleId);
                Tweet.Username = settings.Username;
                Tweet.SearchTerm = settings.Query;
                Tweet.AvatarSize = settings.AvatarSize;
                Tweet.FeedCount = settings.FeedCount;
                Tweet.LoadingTweetsCaption = Localization.GetString("LoadTweets", LocalResourceFile);

                //if the username and query are null we should set a default username so that
                //the module will load something, for now we'll load #dotnetnuke as search
                if (string.IsNullOrEmpty(Tweet.Username) && string.IsNullOrEmpty(Tweet.SearchTerm))
                {
                    Tweet.SearchTerm = "#dotnetnuke";
                }


                Tweet.JavascriptPath = Page.ResolveUrl("~/DesktopModules/BtbTweet/js/jquery.tweet.js");
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

    }
}