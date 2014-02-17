using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace Ember.Web
{
    public static class ScriptManagerExtensions
    {
        public static void LoadScripts(this ScriptManager scriptManager, Page page)
        {
            var virtualPath = ConfigurationManager.AppSettings["ScriptManifestPath"];

            var manifestPath = HttpContext.Current.Server.MapPath(virtualPath);
            
            var root = XElement.Load(manifestPath);

            foreach (var item in scriptManager.Scripts)
            {
                var scriptName = Path.GetFileNameWithoutExtension(item.Path);

                if (scriptName != null)
                {
                    var element = root.Elements("script").FirstOrDefault(s =>
                        String.Equals(s.Attribute("name").Value, scriptName,
                            StringComparison.CurrentCultureIgnoreCase));

                    if (element != null)
                    {
                        item.Path += String.Format("?{0}", element.Attribute("v"));
                    }
                }
            }

        }
    }
}
