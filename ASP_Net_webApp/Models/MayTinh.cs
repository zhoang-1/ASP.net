using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Net_webApp.Models
{
    public class MayTinh
    {
        // - Tạo Một Class MayTinh gồm các thuộc tính 
        // 1. MaMay: là một máy có 10 chữ số
        //2. tên dòng máy: vd Asus *555 
        //3. giá bán: 50000000vnđ
        //4.Ngày sản suất: Ngày/Tháng/Năm
        //5. Hãng sản suất: Asus, Dell, Apple
        public string MaMay { get; set; }
        public string DongMay { get; set; }
        public double GiaBan { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public string HangSanXuat { get; set; }

        public List<MayTinh> KhoiTao5May()
        {
            List<MayTinh> DanhSachMayTinh =new List<MayTinh>();

            DanhSachMayTinh.Add(new MayTinh
            {
                MaMay = "0000000001",
                DongMay = "Asus x555",
                GiaBan = 15000000,
                NgaySanXuat = new DateTime(2020, 1, 22),
                HangSanXuat = "Asus"
            });
            DanhSachMayTinh.Add(new MayTinh
            {
                MaMay = "0000000002",
                DongMay = "Dell latitude",
                GiaBan = 20000000,
                NgaySanXuat = new DateTime(2020, 1, 22),
                HangSanXuat = "Dell"
            });
            DanhSachMayTinh.Add(new MayTinh
            {
                MaMay = "0000000003",
                DongMay = "Asus Rog",
                GiaBan = 16000000,
                NgaySanXuat = new DateTime(2020, 1, 22),
                HangSanXuat = "Asus"
            });
            DanhSachMayTinh.Add(new MayTinh
            {
                MaMay = "0000000004",
                DongMay = "lenova ThinkPad",
                GiaBan = 10000000,
                NgaySanXuat = new DateTime(2020, 5, 22),
                HangSanXuat = "Lenovo"
            });
            DanhSachMayTinh.Add(new MayTinh
            {
                MaMay = "0000000005",
                DongMay = "HP",
                GiaBan = 19000000,
                NgaySanXuat = new DateTime(2020, 5, 22),
                HangSanXuat = "HP"
            });
            return DanhSachMayTinh;
        }
    }
}