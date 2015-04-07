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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;


namespace SpringWs.AppService
{
    public class AppService : IAppService
    {
        #region 返回状态码
        const int SUCCESS = 0;//成功
        const int FAILED= 0;//失败
        #endregion

        #region 测试
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        public string Test()
        {
            return "abc";
        }
        /// <summary>
        /// 获取指定ID的Person信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetPersonInfo(int id, out PersonInfo info)
        {
            //此处为测试，id不做处理
            info = new PersonInfo();
            info.ID = 1;
            info.Name = "张三";
            info.Sex = "男";

            return SUCCESS;
        }
        /// <summary>
        /// 查询Person列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetPersonList(PersonSearch search, out List<PersonInfo> list)
        {
            //此处为测试，search不做处理

            list = new List<PersonInfo>();
            for (int i = 0; i < search.PageSize; i++)
            {
                PersonInfo info = new PersonInfo();
                info.ID = i;
                info.Name = "Name" + i.ToString();
                info.Sex = "男";
                list.Add(info);
            }
            return SUCCESS;
        }
        #endregion

    }

    /// <summary>
    /// Person类
    /// </summary>
    public class PersonInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }
    /// <summary>
    /// Person搜索类
    /// </summary>
    public class PersonSearch : Search
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }
    /// <summary>
    /// 搜索基类
    /// </summary>
    public class Search
    {
        //页大小
        public int PageSize { get; set; }
        //页索引
        public int PageIndex { get; set; }
        //排序
        public int OrderKey { get; set; }
    }
}
