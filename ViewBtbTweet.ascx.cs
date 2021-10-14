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
using BiteTheBullet.BtbTweet.Twitter;
using DotNetNuke.UI.Modules;
using System.Dynamic;

namespace BiteTheBullet.Modules.BtbTweet
{
    public partial class ViewBtbTweet : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var settingsData = new BtbTweetSettings(this.TabModuleId);
                RenderTemplate(settingsData.Template);
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        protected void RenderTemplate(string scriptName= null)
        {
            if(scriptName == null)
            {
                scriptName = "AngularTemplate.cshtml";
            }

            dynamic model = new ExpandoObject();
            model.Page = this.Page;

            phOutput.Controls.Add(RenderRazorScript(this,
                                                scriptName,
                                                model));
        }

        /// <summary>
        /// renders a razor script using the DNNRazorEngine and generates a Literal
        /// control holding the data. This method allows model data to be passed to the
        /// script
        /// </summary>
        /// <param name="moduleControl"></param>
        /// <param name="scriptFile"></param>
        /// <param name="modelData"></param>
        /// <returns></returns>
        private static LiteralControl RenderRazorScript(IModuleControl moduleControl,
                                                    string scriptFile,
                                                    ExpandoObject modelData = null)
        {
            return new LiteralControl(RazorUtility.RenderRazorScript(moduleControl, scriptFile, modelData));
        }

    }
}