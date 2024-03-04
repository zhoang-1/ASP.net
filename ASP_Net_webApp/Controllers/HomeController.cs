using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Net_webApp.Helper;
using ASP_Net_webApp.Models;

namespace ASP_Net_webApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View(DanhSanhMayTinh.ListMayTinh);
        }
        public ActionResult HaiMayGiaThap()
        {
            var ds2may = new MayTinh().KhoiTao5May().OrderBy(m=>m.GiaBan).Take(2).ToList();
            return View(ds2may);
        }
        public ActionResult LocCacHangAsus()
        {
            return View(new MayTinh().KhoiTao5May().Where(m => m.HangSanXuat == "Asus" ).ToList());
        }

        public ActionResult ThemMoiMayTinh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LuuThemMoiMayTinh(string maMay, string dongMay , double giaBan, DateTime ngaySanXuat , string hangSanXuat)
        {
            //xử Lý Lưu
            DanhSanhMayTinh.ListMayTinh.Add(new MayTinh()
            {
                MaMay = maMay,
                DongMay = dongMay,
                GiaBan = giaBan,
                NgaySanXuat = ngaySanXuat,
                HangSanXuat= hangSanXuat
            });
            return RedirectToAction("Index");
        }
        public ActionResult  ThemMoi2()
        {
            return View(new MayTinh() { GiaBan = 0 , NgaySanXuat = DateTime.Now});
        }
        [HttpPost]
        public ActionResult ThemMoi2(MayTinh model)
        {
            //xử Lý Lưu
            //cach1
            /*DanhSanhMayTinh.ListMayTinh.Add(new MayTinh()
            {
                MaMay = model.MaMay,
                DongMay = model.DongMay,
                GiaBan = model.GiaBan,
                NgaySanXuat = model.NgaySanXuat,
                HangSanXuat = model.HangSanXuat
            });*/
            // bao error
            if (ModelState.IsValid == true)
            {
                //cach 2
                DanhSanhMayTinh.ListMayTinh.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                //thong baoloi
                ModelState.AddModelError("", "Ban Chua nhap du lieu");
                return View(model);
            }
        }

    }
}