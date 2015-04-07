using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SpringWs.AppService
{
    public abstract class SecureWebService // : WebService (optional)
    {
        public AuthenticationSoapHeader AuthenticationHeader
        {
            get { return HttpContext.Current.Items["AuthenticationSoapHeader"] as AuthenticationSoapHeader; }
            set { HttpContext.Current.Items["AuthenticationSoapHeader"] = value; }
        }

        public SecureWebService()
        {
        }
    }
}
