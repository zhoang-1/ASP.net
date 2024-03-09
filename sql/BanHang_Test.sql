Create Database BanHang_Test
use BanHang_Test
Go
alter proc spDanhSachKhachHang @fitter nvarchar(100) ,@idLoaKh int
as begin 
select kh.ID, kh.TenKhachHang, kh.SoDienThoai,
kh.DiaChi,loai.TenPhanLoai as PhanLoai
from KhachHang kh
inner join LoaiKhachHang loai on kh.idLoaiKhachHang = loai.ID
where (kh.TenKhachHang like N'%'+ @fitter + '%' or kh.SoDienThoai like N'%'+ @fitter + '%')
	   and (loai.ID = @idLoaKh or @idLoaKh is null)
end

exec spDanhSachKhachHang N'a' , 1