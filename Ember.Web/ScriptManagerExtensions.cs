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
        public static void LoadScripts(this ScriptManager scriptManager)
        {
            var manifest = new ScriptManifest();

            foreach (var item in scriptManager.Scripts)
            {
                manifest.AddScriptVersion(item);
            }
        }

    }
}
