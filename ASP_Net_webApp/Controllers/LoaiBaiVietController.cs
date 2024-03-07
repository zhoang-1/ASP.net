using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Net_webApp.Models;


namespace ASP_Net_webApp.Controllers
{
    public class LoaiBaiVietController : Controller
    {
        // GET: LoaiBaiViet
        public ActionResult DanhSach()
        {
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            //List<LoaiBaiViet> listLoaiBV = db.LoaiBaiViets.ToList();
            //return View(listLoaiBV);
            return View(db.LoaiBaiViets.ToList());
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(LoaiBaiViet model)
        {
           
            if (string.IsNullOrEmpty(model.TenLoai) == true)
            {
                ModelState.AddModelError("", "Thiếu Thông Tin Tên loại !");
                return View(model);
            }
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            try
            {
                db.LoaiBaiViets.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", ex.InnerException.Message);
                return View(model);
            }
        }
        public ActionResult CapNhat(int id)
        {
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            var model = db.LoaiBaiViets.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult CapNhat(LoaiBaiViet model)
        {
            if (string.IsNullOrEmpty(model.TenLoai) == true)
            {
                ModelState.AddModelError("", "Thiếu Thông Tin Tên loại !");
                return View(model);
            }
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            var updateModel = db.LoaiBaiViets.Find(model.ID);
            try
            {
                updateModel.TenLoai = model.TenLoai;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        public ActionResult Xoa(int id)
        {
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            var model = db.LoaiBaiViets.Find(id);
            db.LoaiBaiViets.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
    }
}