using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Net_webApp.Models
{
    public class DonHang
    {
        // 1. Id Don Hang ;kiểu Số
        public int ID { get; set; }
        // Tên Khách Hàng
        public string TenKhachHang { get; set; }
        //Số điện thoại
        public string SoDienThoai { get; set; }
        //Địa Chỉ Giao hàng
        public string DiaChiGiaoHang { get; set; }
        //Ngày Đặt Hàng
        public DateTime? NgayDatHang { get; set; }

        // Danh Sách Máy Tính Đặt Mua
        
        public List<MayTinh> MayTinhDatMua = new List<MayTinh>();

        //Bước 1 : tạo class Đơn hàng 
        //bước 2: tạo trang danh sách dơn hàng
        //bước 3 : tạo form Thêm, sửa, Xóa đơn hàng
        //bước 4: tạo trang chi tiết đơn hàng
        //bước 5 : Thêm sản Phẩm đặt mua cho đơn hàng
        //bước 6 : sửa , xóa chi tiết đơn hàng
    }
}