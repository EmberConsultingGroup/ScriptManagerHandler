using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace Ember.Web
{
    public class ScriptManifest
    {
        private readonly XElement root;

        public ScriptManifest()
        {
            var virtualPath = ConfigurationManager.AppSettings["ScriptManifestPath"];
            var manifestPath = HttpContext.Current.Server.MapPath(virtualPath);
            root = XElement.Load(manifestPath);
        }
        public void AddScriptVersion(ScriptReference script)
        {
            var scriptName = Path.GetFileNameWithoutExtension(script.Path);

            if (scriptName != null)
            {
                var element = root.Elements("script").FirstOrDefault(s =>
                    String.Equals(s.Attribute("name").Value, scriptName,
                        StringComparison.CurrentCultureIgnoreCase));

                if (element != null)
                {
                    script.Path += String.Format("?{0}", element.Attribute("v"));
                }
            }
        }

    }
}
