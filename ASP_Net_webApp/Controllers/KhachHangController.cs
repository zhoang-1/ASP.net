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
        public ActionResult DanhSach()
        {
            return View(DanhSachKhachHang.dsKhachHang);
        }
        public ActionResult ThemMoi()
        {
            return View(new KhachHang { Id = 0});
        }
        [HttpPost]
        public ActionResult ThemMoi(KhachHang model)
        {
            if (model.Id == 0 )
            {
                ModelState.AddModelError("", "id Phai > 0");
                return View(model);

            }
            DanhSachKhachHang.dsKhachHang.Add(model);
            return RedirectToAction("DanhSach");
        }

    }
}