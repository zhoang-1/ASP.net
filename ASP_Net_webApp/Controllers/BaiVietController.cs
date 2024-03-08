using ASP_Net_webApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Net_webApp.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: BaiViet
        public ActionResult DanhSach()
        {
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            return View(db.BaiViets.ToList());
        }
        public ActionResult ThemMoi()
        {
            return View(new BaiViet());
        }
        [HttpPost]
        public ActionResult ThemMoi(BaiViet model)
        {
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            if (string.IsNullOrEmpty(model.TenBaiViet)){
                ModelState.AddModelError("","Tên Bài Viết Không Được Để Trống");
                return View(model);
            }
            db.BaiViets.Add(model);
            db.SaveChanges();


            return RedirectToAction("DanhSach");
        }

        // Các Bước Nhúng ckEditor 
        //1. tải bộ plugin vào project
        //2. Kéo file JS vào Layout
        //3. Thay đổi input Nội Dung textarea có đặt id cho input
        //4. viết tiếp input cho textarea

    }
}