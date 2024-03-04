using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Net_webApp.Models
{
    public class KhachHang
    {
        //1. id
        //2. Tên Khách Hàng
        //3. Số Điện Thoại
        //4. Địa Chỉ Nhận Hàng
        //5. Email
        //6. Giới Tính : Nam/ Nữ
        public int Id { get; set; }
        public string TenkhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChiNhanHang {  get; set; }
        public string Email {  get; set; }
        public  string GioiTinh {  get; set; }

    }
}