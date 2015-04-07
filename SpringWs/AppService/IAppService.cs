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
using System.Collections.Generic;
namespace SpringWs.AppService
{
    public interface IAppService
    {
        #region 测试
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        string Test();
        /// <summary>
        /// 获取指定ID的Person信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetPersonInfo(int id, out PersonInfo info);
        /// <summary>
        /// 查询Person列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetPersonList(PersonSearch search, out List<PersonInfo> list);
        #endregion

    }

   
}
