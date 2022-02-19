CREATE DATABASE	QuanLySieuThi
GO

USE QuanLySieuThi
GO

set dateformat dmy
go
create table LoaiHang
(
	MaLH integer not null primary key ,
	TenLH nvarchar(100),	
)
go
create table MatHang
(
	MaMH NCHAR(10) not null primary key ,
	TenMH nvarchar(100),
	NgaySX datetime,
	GiaMua float not null,
	GiaBan float not null,
	NgayNhap smalldatetime,
	MaLH int

	foreign key (MaLH) references LoaiHang(MaLH)
)
go
create table ChucVu
(
	MaCV int not null primary key,
	TenCV nvarchar(100)
)
create table Nhanvien
(
	MaNV int not null primary key,
	HoTen nvarchar(100),
	NgaySinh date,
	CMND nvarchar(100),
	DiaChi nvarchar(100),
	SoDienThoai nvarchar(100),
	NgayVaoLam date,
	Luong float,
	MaCV int

	foreign key (MaCV) references ChucVu(MaCV)
)
go
create table HoaDon
(
	MaHD int not null primary key,
	NgayLap datetime not null,
	SoLuong int,
	TongTienTra float not null,
	MaMH NCHAR(10)

	foreign key (MaMH) references MatHang(MaMH)
)
go
create table NCC
(
	MaNCC int primary key not null,
	TenNCC nvarchar(50) ,
	DiaChi nvarchar(100),
	DienThoai nchar(50)
)
go
create table KHTT
(
	MaKH int not null primary key,
	HoTen nvarchar(100),
	DiaChi nvarchar(100),
	NgayCapThe datetime,
	NgayMuaGanNhat datetime,
	DiemThuong int
)
-----------thêm loại mặt hàng
insert into LoaiHang values (1,N'Đồ uống giải khát')
insert into LoaiHang values (2,N'Đồ ăn nhanh')
insert into LoaiHang values (3,N'Mặt hàng gia vị')
insert into LoaiHang values (4,N'Thực phẩm đóng hộp')
go
----------thêm mặt hàng
insert into MatHang values ('01',N'Bia','12/03/2020','12000','15000','18/12/2020',1)
insert into MatHang values ('02',N'7-Up','16/07/2020','10000','14000','18/12/2020',1)
insert into MatHang values ('03',N'Bột canh','12/03/2020','12000','15000','18/12/2020',3)
insert into MatHang values ('04',N'Mì tôm','12/03/2020','12000','15000','18/12/2020',2)
insert into MatHang values ('05',N'Xúc xính','12/03/2020','12000','15000','18/12/2020',4)
go

--------------thêm chức vụ
insert into ChucVu values (1,N'Quản lý')
insert into ChucVu values (2,N'Nhân viên')
go
-------------thêm nhân viên
insert into Nhanvien values (001,N'Nguyễn Thanh Bảo','17/05/1999','215384987',N'135/2,Phạm Văn Đồng,Thủ Đức,Quận 9','012903192','02/03/2019',400000,1)
insert into Nhanvien values (002,N'Nguyễn Thanh An','17/05/1999','215384987',N'135/2,Phạm Văn Đồng,Thủ Đức,Quận 9','012903192','02/03/2019',200000,2)
insert into Nhanvien values (003,N'Phạm Anh Thư','17/05/1999','215384987',N'135/2,Phạm Văn Đồng,Thủ Đức,Quận 9','012903192','02/03/2019',200000,2)
insert into Nhanvien values (004,N'Trần Bá Đạo','17/05/1999','215384987',N'135/2,Phạm Văn Đồng,Thủ Đức,Quận 9','012903192','02/03/2019',200000,2)
insert into Nhanvien values (005,N'Huỳnh Thanh Đao','17/05/1999','215384987',N'135/2,Phạm Văn Đồng,Thủ Đức,Quận 9','012903192','02/03/2019',200000,2)
insert into Nhanvien values (006,N'Bao Thanh Thiên','17/05/1999','215384987',N'135/2,Phạm Văn Đồng,Thủ Đức,Quận 9','012903192','02/03/2019',400000,1)
insert into Nhanvien values (007,N'Trần Anh Minh','17/05/1999','215384987',N'135/2,Phạm Văn Đồng,Thủ Đức,Quận 9','012903192','02/03/2019',200000,2)
insert into Nhanvien values (008,N'Nguyễn Thị Hoa','17/05/1999','215384987',N'135/2,Phạm Văn Đồng,Thủ Đức,Quận 9','012903192','02/03/2019',400000,1)
go
----------------thêm hóa đơn
insert into HoaDon values (01,'12/03/2020',5,15000,'01')
insert into HoaDon values (02,'15/04/2020',3,15000,'01')
insert into HoaDon values (03,'25/09/2020',1,15000,'03')
go
---------thêm nhà cung cấp
insert into NCC values (01,N'Huỳnh Văn A',N'111 Kha Vạn Cân,Thủ Đức,TPHCM','8192328723')
insert into NCC values (02,N'Huỳnh Văn B',N'111 Kha Vạn Cân,Thủ Đức,TPHCM','8192328723')
insert into NCC values (03,N'Huỳnh Văn C',N'111 Kha Vạn Cân,Thủ Đức,TPHCM','8192328723')
go
--------------------thêm khách hàng thân thiết
insert into KHTT values (1,N'Nguyễn Thanh A',N'135/2,Đỗ Xuân Hợp,Thủ Đức,Quận 9','22/03/2019','16/12/2020',15)
insert into KHTT values (2,N'Nguyễn Thanh Hoa',N'135/2,Đỗ Xuân Hợp,Thủ Đức,Quận 9','12/05/2019','4/11/2020',2)
insert into KHTT values (3,N'Nguyễn Thị Thắm',N'135/2,Đỗ Xuân Hợp,Thủ Đức,Quận 9','10/09/2019','1/12/2020',7)
go