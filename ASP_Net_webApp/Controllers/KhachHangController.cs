using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Net_webApp.Models;

namespace ASP_Net_webApp.Controllers
{
    public class KhachHangController : Controller
    {
        public ActionResult DanhSach(string fitter, int? idLoaKh)
        {
            // 1. Lấy Danh Sách Dữ Liệu trong bảng
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            /*List<KhachHang> danhSachKhachHang = db.KhachHangs.Where(m => m.TenKhachHang.ToLower().Contains(fitter) == true ||
            m.SoDienThoai.ToLower().Contains(fitter)).ToList();*/
            /*List<KhachHang> danhSachKhachHang = (from m in db.KhachHangs
                                                 join loaiKH in db.LoaiKhachHangs on m.idLoaiKhachHang equals loaiKH.ID
                                                 where (m.TenKhachHang.ToLower().Contains(fitter.ToLower()) == true
                                                || m.SoDienThoai.Contains(fitter) == true)
                                                & (loaiKH.ID == idLoaKh | idLoaKh == null )
                                                select m
                                                ).ToList();*/

            List<spDanhSachKhachHang_Result> dsKH = db.spDanhSachKhachHang(fitter, idLoaKh).ToList();
            ViewBag.Fitter = fitter;
            ViewBag.idLoaKh = idLoaKh;
            return View(dsKH);
        }
       public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(KhachHang model)
        {
            //2. them moi ban ghi
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            db.KhachHangs.Add(model);
            //3. lưu lại thay dổi
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
        public ActionResult CapNhat (int id)
        {
            // Tìm đối tươngj
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            //KhachHang model = db.KhachHangs.SingleOrDefault(m => m.ID == id);
            KhachHang model = db.KhachHangs.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult CapNhat(KhachHang model )
        {
            // Tìm đối tươngj
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            //KhachHang addKhachHang = db.KhachHangs.SingleOrDefault(m => m.ID == model.ID);
            var updateModel = db.KhachHangs.Find(model.ID);
            updateModel.TenKhachHang = model.TenKhachHang;
            updateModel.DiaChi = model.DiaChi;
            updateModel.SoDienThoai = model.SoDienThoai;
            updateModel.idLoaiKhachHang = model.idLoaiKhachHang;
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
        public ActionResult XoaKhachHang(int id)
        {
            // Tìm đối tươngj
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            //KhachHang model = db.KhachHangs.SingleOrDefault(m => m.ID == id);
            var updateModel = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(updateModel);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult XoaKhachHangTheoNhom(int idLoaiKhachHang)
        {
            //1. xóa dữ liệu bảng gốc cần xóa: Loại Khách hàng
            BanHang_TestEntities1 db = new BanHang_TestEntities1();
            var modelLoaiKhachHang = db.LoaiKhachHangs.Find(idLoaiKhachHang);
            db.LoaiKhachHangs.Remove(modelLoaiKhachHang);
            db.SaveChanges();
            // xóa bảng con liên quan: Khách Hàng : Xoa Luôn các Khách Hàng Thuộc Nhóm đó
            var danhSachKhachHangThuocNhom =db.KhachHangs.Where(m => m.idLoaiKhachHang == idLoaiKhachHang).ToList();
            db.KhachHangs.RemoveRange(danhSachKhachHangThuocNhom);
            db.SaveChanges();

            // xóa lẻ 
            foreach(var KhachHang in danhSachKhachHangThuocNhom)
            {
                if(KhachHang.DiaChi == "TN")
                {
                    db.KhachHangs.Remove(KhachHang);
                }
            }
            db.SaveChanges();
            return RedirectToAction("DanhSach");


        }

    }
}