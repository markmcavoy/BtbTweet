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
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using BiteTheBullet.BtbTweet.Components;
using System.IO;
using System.Linq;
using BiteTheBullet.BtbTweet.WebServices;
using BiteTheBullet.BtbTweet.Twitter;
using System.Web.UI.WebControls;

namespace BiteTheBullet.Modules.BtbTweet
{
    public partial class Settings : ModuleSettingsBase
    {

        protected void Page_Load(object sender, EventArgs args)
        {
            if (!IsPostBack)
            {
                var path = Server.MapPath(RazorUtility.TEMPLATE_PATH);
                var files = Directory.GetFiles(path);

                ddlTemplates.DataSource = files
                                            .Select(f => Path.GetFileName(f))
                                            .ToList();
                ddlTemplates.DataBind();

            }
        }

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    BtbTweetSettings settingsData = new BtbTweetSettings(this.TabModuleId);

                    txtQuery.Text = settingsData.Query ?? "";
                    txtUsername.Text = settingsData.Username;
                    
                    if (settingsData.TweetQueryMode == BtbTweetSettings.QueryMode.Search)
                        rbSearch.Checked = true;
                    else
                        rbUserTimeline.Checked = true;

                    txtCount.Text = settingsData.FeedCount.ToString();
                    ddlTemplates.SelectedValue = settingsData.Template;

                    if(txtUsername.Text != "")
                    {
                        var tweets = new Twitter().LoadTweets(PortalId, TabModuleId);

                        ddlPinnedTweet.DataSource = tweets.Select(i => i.Text).ToList();

                        ddlPinnedTweet.DataBind();

                        ddlPinnedTweet.SelectedValue = settingsData.PinnedTweet;

                        ddlPinnedTweet.Items.Insert(0, new ListItem("No Pinned Tweet"));
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
                int feedCount = 10;

                Int32.TryParse(txtCount.Text, out feedCount);

                BtbTweetSettings settingsData = new BtbTweetSettings(this.TabModuleId);
                settingsData.Query = txtQuery.Text;
                settingsData.FeedCount = feedCount;
                settingsData.Username = txtUsername.Text;
                settingsData.TweetQueryMode = rbSearch.Checked ? BtbTweetSettings.QueryMode.Search : BtbTweetSettings.QueryMode.UserTimeline;
                settingsData.Template = ddlTemplates.SelectedValue;
                settingsData.PinnedTweet = ddlPinnedTweet.SelectedValue;
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}