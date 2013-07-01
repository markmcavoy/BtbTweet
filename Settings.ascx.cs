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

namespace BiteTheBullet.Modules.BtbTweet
{
    public partial class Settings : ModuleSettingsBase
    {

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

                    txtUsername.Text = settingsData.Username ?? "";
                    txtQuery.Text = settingsData.Query ?? "";
                    txtCount.Text = settingsData.FeedCount.ToString();
                    txtAvatarSize.Text = settingsData.AvatarSize.ToString();                    
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
                int avatarSize = 32;

                Int32.TryParse(txtCount.Text, out feedCount);
                Int32.TryParse(txtAvatarSize.Text, out avatarSize);

                BtbTweetSettings settingsData = new BtbTweetSettings(this.TabModuleId);
                settingsData.Username = txtUsername.Text;
                settingsData.Query = txtQuery.Text;
                settingsData.FeedCount = feedCount;
                settingsData.AvatarSize = avatarSize;

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}