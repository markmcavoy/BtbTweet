using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.UI.Modules;
using DotNetNuke.Web.Razor;
using System.IO;
using System.Dynamic;
using DotNetNuke.Instrumentation;
using DotNetNuke.Services.Exceptions;
using System.Threading;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Portals;

namespace BiteTheBullet.BtbTweet.Components
{
    public class RazorUtility
    {
        public const string TEMPLATE_PATH = "~/DesktopModules/BtbTweet/Templates/";

        /// <summary>
        /// renders a razor script using the DNNRazorEngine and generates a string
        /// holding the data. This method allows model data to be passed to the
        /// script
        /// </summary>
        /// <param name="moduleControl"></param>
        /// <param name="scriptFile"></param>
        /// <param name="modelData"></param>
        /// <returns></returns>
        public static string RenderRazorScript(IModuleControl moduleControl,
                                                    string scriptFile,
                                                    ExpandoObject modelData)
        {
            try
            {

                string templateBasePath = TEMPLATE_PATH + "{0}";


                var razorScriptFile = string.Format(templateBasePath,
                                                    scriptFile);

                //if we have a null value for the IModuleControl
                //we should just attempt to load something


                //now just render the output using the engine
                RazorEngine engine;

                if (moduleControl != null)
                {
                    engine = new RazorEngine(razorScriptFile,
                                                    moduleControl.ModuleContext,
                                                    moduleControl.LocalResourceFile);
                }
                else
                {
                    engine = new RazorEngine(razorScriptFile,
                                                    null,
                                                    "");
                }

                StringWriter stringWriter = new StringWriter();
                engine.Render<dynamic>(stringWriter, modelData);

                DnnLog.Debug("Completed rendering script:{0}", scriptFile);

                return HttpUtility.HtmlDecode(stringWriter.ToString());
            }
            catch (Exception ex)
            {
                DnnLog.Error(ex);
                Exceptions.LogException(ex);

                return "Error rendering razor script";
            }
        }
    }
}