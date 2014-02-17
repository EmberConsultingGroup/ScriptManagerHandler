using System;
using System.Web;
using System.Web.UI;

namespace Ember.Web
{
    public class ScriptLoaderHttpModule : IHttpModule
    {
        public void Dispose()
        {
            // Nothing to dispose
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        private void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var page = HttpContext.Current.Handler as Page;

            if (page != null)
            {
                page.Init += page_Init;
            }
        }

        private void page_Init(object sender, EventArgs e)
        {
            var page = sender as Page;

            if (page != null)
            {
                var sm = ScriptManager.GetCurrent(page);

                if (sm != null)
                {
                    sm.LoadScripts(page);
                }
            }
        }
    }
}
