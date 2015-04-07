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
using System.Web.Services;
using AopAlliance.Intercept;


namespace SpringWs.AppService
{
    public class AuthenticationAdvice : IMethodInterceptor // IMethodBeforeAdvice can be used too
    {
        static string[] op = { };
       

        [WebMethod(EnableSession = true)]
        public object Invoke(IMethodInvocation invocation)
        {
            // Check if we are using it in a Web Service
            if (HttpContext.Current == null)
            {
                throw new InvalidOperationException("This advice should be applied to a Web Service.");
            }

            String name = invocation.Method.Name;
            if (Array.IndexOf<string>(op, name) < 0)
            {
                return invocation.Proceed();
            }

            // Authentication
            AuthenticationSoapHeader ash = HttpContext.Current.Items["AuthenticationSoapHeader"] as AuthenticationSoapHeader;
            if (ash == null || string.IsNullOrEmpty(ash.Token))
            {
                //throw new UnauthorizedAccessException("未授权的访问!");
                return -9999;
            }

            #region 
            ////检查是否过期
            //DataTable dtToken = mainService.GetDataByKey("T_AppToken", "Token", ash.Token);
            //if (dtToken.Rows.Count != 1)
            //{
            //    //throw new UnauthorizedAccessException("未授权的访问!");
            //    return RT.ILLEGAL_ACCESS;
            //}
            //DateTime activityTime = Convert.ToDateTime(dtToken.Rows[0]["RefreshTime"]);
            //TimeSpan ts = DateTime.Now - activityTime;
            //if (ts.TotalHours > 12)
            //{
            //    //throw new UnauthorizedAccessException("登录超时!");
            //    return RT.ILLEGAL_ACCESS;
            //}
            //else
            //{
            //    //刷新时间
            //    dtToken.Rows[0]["RefreshTime"] = DateTime.Now;
            //    mainService.UpdateDataTable(dtToken);
            //}
            #endregion

            return invocation.Proceed();
        }
    }
}
