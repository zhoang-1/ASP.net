using ASP_Net_webApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ASP_Net_webApp.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult DanhSach()
        {
            return View(staticDonHang.dsDonHang);
        }
        public ActionResult ThemDonHang()
        {
            return View(new DonHang());
        }
        [HttpPost]
        public ActionResult ThemDonHang(DonHang model)
        {
            staticDonHang.dsDonHang.Add(model);
            return RedirectToAction("DanhSach");
        }

        public ActionResult CapNhatDonHang(int idDonHang)
        {
            var updateModel = staticDonHang.dsDonHang.SingleOrDefault(m => m.ID == idDonHang);
            return View(updateModel);
        }
        [HttpPost]
        public ActionResult CapNhatDonHang(DonHang model)
        {
            var updateModel = staticDonHang.dsDonHang.SingleOrDefault(m => m.ID == model.ID);
            updateModel.NgayDatHang = model.NgayDatHang;
            updateModel.SoDienThoai = model.SoDienThoai;
            updateModel.DiaChiGiaoHang = model.DiaChiGiaoHang;
            updateModel.TenKhachHang = model.TenKhachHang;
            return RedirectToAction("DanhSach");
        }

        public ActionResult XoaDonHang (int idDonHang)
        {
            var updateModel = staticDonHang.dsDonHang.SingleOrDefault(m => m.ID == idDonHang);
            staticDonHang.dsDonHang.Remove(updateModel);
            return RedirectToAction("DanhSach");
        }


        // Chi Tiết DƠn Hàng
        public ActionResult ChiTiet(int idDonHang)
        {
            var updateModel = staticDonHang.dsDonHang.SingleOrDefault(m => m.ID == idDonHang);
            return View(updateModel);
        }

        public ActionResult ThemChiTiet(int idDonHang)
        {
            ViewBag.idDonHang = idDonHang;
            return View(new MayTinh());
        }
        [HttpPost]
        public ActionResult ThemChiTiet(MayTinh model , int idDonHang)
        {
            var updateModel = staticDonHang.dsDonHang.SingleOrDefault(m => m.ID == idDonHang);
            updateModel.MayTinhDatMua.Add(model);
            return RedirectToAction("ChiTiet", new {idDonHang = idDonHang});
        }

        //CapNhat
        public ActionResult CapNhatChiTiet(int idDonHang, string maMay)
        {
            var updateModel = staticDonHang.dsDonHang.SingleOrDefault(m => m.ID == idDonHang);
            var mayTinhCanSua = updateModel.MayTinhDatMua.SingleOrDefault(m=> m.MaMay == maMay);
            ViewBag.idDonHang = idDonHang;
            return View(mayTinhCanSua);
        }
        [HttpPost]
        public ActionResult CapNhatChiTiet(MayTinh model, int idDonHang)
        {
            var updateModel = staticDonHang.dsDonHang.SingleOrDefault(m => m.ID == idDonHang);
            var mayTinhCanSua = updateModel.MayTinhDatMua.SingleOrDefault(m => m.MaMay == model.MaMay);
            mayTinhCanSua.DongMay = model.DongMay;
            mayTinhCanSua.GiaBan = model.GiaBan;
            mayTinhCanSua.HangSanXuat = model.HangSanXuat;
            mayTinhCanSua.NgaySanXuat = model.NgaySanXuat;

            return RedirectToAction("ChiTiet", new { idDonHang = idDonHang });
        }
        public ActionResult XoaChiTiet(int idDonHang, string maMay)
        {
            var updateModel = staticDonHang.dsDonHang.SingleOrDefault(m => m.ID == idDonHang);
            var mayTinhCanSua = updateModel.MayTinhDatMua.SingleOrDefault(m => m.MaMay == maMay);
            updateModel.MayTinhDatMua.Remove(mayTinhCanSua);
            return RedirectToAction("ChiTiet", new { idDonHang = idDonHang });
        }
    }
}