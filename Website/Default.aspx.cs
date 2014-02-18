using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Ember.Web;

namespace Website
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager1.ResolveScriptReference += ScriptManager1_ResolveScriptReference;
        }

        //void ScriptManager1_ResolveScriptReference(object sender, ScriptReferenceEventArgs e)
        //{
        //    var manifest = new ScriptManifest();
        //    manifest.AddScriptVersion(e.Script);
        //}

    }
}