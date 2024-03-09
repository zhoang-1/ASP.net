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
        [ValidateInput(false)]
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

        public ActionResult Edit(int id)
        {
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            var updateModel = db.BaiViets.Find(id);
            return View(updateModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(BaiViet model)
        {
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            var updateModel = db.BaiViets.Find(model.ID);
            if (string.IsNullOrEmpty(model.TenBaiViet))
            {
                ModelState.AddModelError("", "Tên Bài Viết Không Được Để Trống");
                return View(model);
            }
            updateModel.TenBaiViet = model.TenBaiViet;
            updateModel.MoTa = model.MoTa;
            updateModel.NgayViet = model.NgayViet;
            updateModel.NguoiViet = model.NguoiViet;
            updateModel.NoiDung = model.NoiDung;
            updateModel.HinhAnh = model.HinhAnh;
            updateModel.HienThi = model.HienThi;
            updateModel.ThuTu = model.ThuTu;
            updateModel.idBaiViet = model.idBaiViet;
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
        public ActionResult Delete(int id)
        {
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            var updateModel = db.BaiViets.Find(id);
            db.BaiViets.Remove(updateModel);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
        // Sử Dụng CkFinder
        // Bước 1: Tải Bộ plugin và cho Project
        // Bước 2: Kéo JS Vào Layout
        // Bước 3: Thêm Dll Vào thư Viện project
        // Bước 4: Cấu Hình
        // Bước 5: Sử Dụng
    }
}