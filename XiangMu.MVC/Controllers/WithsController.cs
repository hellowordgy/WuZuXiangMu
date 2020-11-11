using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiangMu.MVC.DAL;
using XiangMu.MVC.Model;

namespace XiangMu.MVC.Controllers
{
    public class WithsController : Controller
    {
        // GET: Withs
        public ActionResult WithsIndex()
        {
            string sql = $"select * from Withs";
            var dt = DBHelper.GetToList<Withs>(sql);
            return View(dt.ToList());
        }
        public ActionResult WithsCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WithsCreates(Withs withs,HttpPostedFileBase file)
        {
            //上传图片，保存到本地img
            string filename = Path.GetFileName(file.FileName);
            string path = Request.MapPath("/img/");
            string fullname = Path.Combine(path, filename);
            file.SaveAs(fullname);
            withs.WImg = filename;
            string sql = $"insert into Withs(WName,WNative,WIdentity,WPhone,WSite,WRemark,WImg) values('{withs.WName}','{withs.WNative}','{withs.WIdentity}','{withs.WPhone}','{withs.WSite}','{withs.WRemark}','{withs.WImg}')";
            DBHelper.ExecuteNonQuery(sql);
            return RedirectToAction("WithsIndex");
        }
        public ActionResult WithsDelete(Guid ID)
        {
            string sql = $"delete from Withs where ID='{ID}'";
            DBHelper.ExecuteNonQuery(sql);
            return RedirectToAction("WithsIndex");
        }
        //反填
        public ActionResult WithsEdit(Guid ID)
        {

            string sql = $"select * from Withs where ID='{ID}'";
            Withs s = DBHelper.Get<Withs>(sql);
            return View(s);
        }
        //修改方法
        public ActionResult WithsEdits(Withs withs, HttpPostedFileBase file)
        {
            //上传图片，保存到本地img
            string filename = Path.GetFileName(file.FileName);
            string path = Request.MapPath("/img/");
            string fullname = Path.Combine(path, filename);
            file.SaveAs(fullname);
            withs.WImg = filename;
            string sql = $"update Withs set WName='{withs.WName}',WNative='{withs.WNative}',WIdentity='{withs.WIdentity}',WPhone='{withs.WPhone}',WSite='{withs.WSite}',WRemark='{withs.WRemark}' ,WImg ='{withs.WImg}'where ID='{withs.ID}'";
            DBHelper.ExecuteNonQuery(sql);
            return RedirectToAction("WithsIndex");
        }
    }
}
