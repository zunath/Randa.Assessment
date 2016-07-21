using System;
using System.Web;
using System.Web.Optimization;

namespace Randa.Assessment.App
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}