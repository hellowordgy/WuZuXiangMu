using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XiangMu.MVC.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        //登录
        public ActionResult ClientDeng()
        {
            return View();
        }
        //注册
        public ActionResult ClientAdd()
        {
            return View();
        }
        //主页面
        public ActionResult Zhuye()
        {
            return View();
        }
    }
}