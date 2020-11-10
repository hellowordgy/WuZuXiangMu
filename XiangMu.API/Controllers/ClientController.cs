using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XiangMu.API.DAL;
using XiangMu.API.Models;

namespace XiangMu.API.Controllers
{
    //客户表控制器
    public class ClientController : ApiController
    {
        //注册
        [HttpPost]
        [Route("zhuce")]
        public IHttpActionResult ADDClient(Client c)
        {
            string sql = $"insert into  Client(CAccount,Cpwd) values('{c.CAccount}','{c.Cpwd}')";
            int i = DBHelper.ExecuteNonQuery(sql);
            return Json(new {
                mag = i > 0 ? "注册成功":"注册失败"
            }); 
        }
        //登录
        [HttpPost]
        [Route("denglu")]
        public IHttpActionResult ClientDeng(Client c)
        {

            string sql = $"select Count(*) from Client where CAccount='{c.CAccount} 'and Cpwd='{c.Cpwd}'";
            DataTable dt = DBHelper.GetTable(sql);
            return Json(new { msg = dt != null ? "登录成功" : "登录失败,账号或密码错误" });
        }
    }
}
