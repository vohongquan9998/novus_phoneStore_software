
create database QUANLYDIENTHOAI


CREATE TABLE KHACHHANG(
	 MAKH varchar(30) not null, 
	 TENKH nvarchar(40),
	 DIACHI nvarchar(50),
	 SODT varchar(12),
	 LOAIKH nvarchar(20),
	 constraint pk_kh primary key(MAKH)
)
----------------------------------------------- NHANVIEN
CREATE TABLE NHANVIEN(
	 MANV varchar(30) not null, 
	 HOTEN nvarchar(40),
	 SODT varchar(12),
	 NGVL date 
	 constraint pk_nv primary key(MANV)
)
ALTER TABLE NHANVIEN ADD Ngaysinh date
ALTER TABLE NHANVIEN ADD Gt bit
ALTER TABLE NHANVIEN ADD DIACHI nvarchar(MAX)
ALTER TABLE NHANVIEN ADD Chucvu nvarchar(50)
-------
---------------------------------------- dienthoai
CREATE TABLE DIENTHOAI(
	 MASP varchar(10) not null,
	 TENSP nvarchar(40),
	 BAOHANH varchar(10),
	 DUNGLUONG int,
	 XUATSU nvarchar(40),
	 CHITIET nvarchar(Max),
	 TRANGTHAI bit,
	 DONGIA float,
	 MAKM varchar(10),
	 MAKHO varchar(10),
	 constraint pk_sp primary key(MASP) 
)
ALTER TABLE DIENTHOAI ADD Hinhanh image

CREATE TABLE CTMAU(
	MAMAU varchar(10),
	MASP varchar(10),
	SLMAU int
	constraint pk_ctmau primary key(MAMAU,MASP)
)

CREATE TABLE MAU(
	MAMAU varchar(10),
	TENMAU nvarchar(40),	
	constraint pk_mau primary key(MAMAU) 
)

----------------------------------------------- NCC
CREATE TABLE NHACUNGCAP(
	MANCC varchar(10) not null,
	TENNCC nvarchar(40),
	DIACHI nvarchar(100),
	constraint pk_ncc primary key(MANCC)
)
----------------------------------------------- PN
CREATE TABLE PHIEUNHAP
(
	MAPHIEUNHAP varchar(10) not null,
	MANCC varchar(10) not null,
	MAKHO varchar(10),
	SOLUONG int,
	NGAYLAP date,
	NGAYGIAO date,
	constraint pk_phn primary key(MAPHIEUNHAP)
)

----------------------------------------------- KHO
CREATE TABLE KHO(
	MAKHO varchar(10) not null,
	constraint pk_kho primary key(MAKHO)
)
ALTER TABLE KHO ADD Tongsl int
----------------------------------------------- KHUYEN MAI
CREATE TABLE KHUYENMAI(
	MAKM varchar(10) not null,
	NOIDUNG nvarchar(100),
	LOAIKHUYENMAI nvarchar(30),
	GIAMGIA float,
	constraint pk_km primary key(MAKM)

)

----------------------------------------------- HOADON
CREATE TABLE HOADON(
	 SOHD int not null,
	 NGAYLAPHD date,
	 MAKH varchar(10),
	 MANV varchar(10),
	 TRIGIA money,
	 constraint pk_hd primary key(SOHD)
)
----------------------------------------------- CTHD
CREATE TABLE CTHD(
	 SOHD int,
	 MASP varchar(10),
	 SL int,
	 constraint pk_cthd primary key(SOHD,MASP)
)
CREATE TABLE USERS(
	 ID int identity(1,1) primary key,
	 TenTK nvarchar(150),
	 MatKhau varchar(50),
	 RoleID int,
	 MAKH varchar(30),
	 MANV varchar(30)
)

CREATE TABLE ROLES(
	ID int identity(1,1) primary key,
	Mota nvarchar(100)
)
--ALTER TABLE USERS ADD MAKH varchar(30)
--ALTER TABLE USERS ADD MANV varchar(30)

--DROP TABLE USERS

CREATE TABLE ADS(
	IDQC varchar(10) PRIMARY KEY,
	TENCTY nvarchar(50),
	Hinhanh image,
	thamkhao nvarchar(MAX),
	ngaybatdau date,
	ngayketthuc date,
	hethan bit
)
--DROP TABLE QUANGCAO

CREATE TABLE DONDATHANG(
	SODDH varchar(20) not null,
	NgayDatHang date,
	NgayGiaoHang date,
	Trigia float,
	Dagiao bit,
	MAKH varchar(30)
	constraint pk_DDH primary key(SODDH)
)
CREATE TABLE CTDDH(
	SODDH varchar(20) not null,
	MASP varchar(10),
	SOLUONG int,
	HinhthucTT nvarchar(50),
	constraint pk_ctddh primary key(SODDH,MASP)
)



--CREATE TABLE BACKGROUND(
--	DuongDanhinh varchar(100)
--)


ALTER TABLE DIENTHOAI ADD CONSTRAINT fk01_DT_KM FOREIGN KEY(MAKM) REFERENCES KHUYENMAI(MAKM)
ALTER TABLE DIENTHOAI ADD CONSTRAINT fk02_DT_KHO FOREIGN KEY(MAKHO) REFERENCES KHO(MAKHO)

ALTER TABLE KHO ADD CONSTRAINT fk01_KHO_PHIEUNHAP FOREIGN KEY(MAPHIEUNHAP) REFERENCES PHIEUNHAP(MAPHIEUNHAP)

ALTER TABLE PHIEUNHAP ADD CONSTRAINT fk01_PN_MANCC FOREIGN KEY(MANCC) REFERENCES NHACUNGCAP(MANCC)
ALTER TABLE PHIEUNHAP ADD CONSTRAINT fk02_PN_MANKHO FOREIGN KEY(MAKHO) REFERENCES KHO(MAKHO)
-- Khoa ngoai cho bang HOADON
ALTER TABLE HOADON ADD CONSTRAINT fk01_HD_KH FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
ALTER TABLE HOADON ADD CONSTRAINT fk02_HD_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
-- Khoa ngoai cho bang CTHD
ALTER TABLE CTHD ADD CONSTRAINT fk01_CTHD_HD FOREIGN KEY(SOHD) REFERENCES HOADON(SOHD)
ALTER TABLE CTHD ADD CONSTRAINT fk02_CTHD_SP FOREIGN KEY(MASP) REFERENCES DIENTHOAI(MASP)

ALTER TABLE CTMAU ADD CONSTRAINT fk01_CTMAU FOREIGN KEY(MAMAU) REFERENCES MAU(MAMAU)
ALTER TABLE CTMAU ADD CONSTRAINT fk02_CTMAU_SP FOREIGN KEY(MASP) REFERENCES DIENTHOAI(MASP)

ALTER TABLE USERS ADD CONSTRAINT fk_roleid FOREIGN KEY(RoleID) REFERENCES ROLE(ID)
ALTER TABLE USERS ADD CONSTRAINT fk_makh FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
ALTER TABLE USERS ADD CONSTRAINT fk_manv FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE DONDATHANG ADD CONSTRAINT fk01_makh FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)

ALTER TABLE CTDDH ADD CONSTRAINT fk01_masp FOREIGN KEY(MASP) REFERENCES DIENTHOAI(MASP)
ALTER TABLE CTDDH ADD CONSTRAINT fk02_soddh FOREIGN KEY(SODDH) REFERENCES DONDATHANG(SODDH)


--DROP
--ALTER TABLE DIENTHOAI DROP COLUMN MAMAU
--ALTER TABLE DIENTHOAI DROP CONSTRAINT FK01_DT_KM
--ALTER TABLE DIENTHOAI DROP CONSTRAINT FK02_DT_KHO
--ALTER TABLE KHO DROP CONSTRAINT FK01_KHO_PHIEUNHAP
--ALTER TABLE PHIEUNHAP DROP CONSTRAINT FK01_PN_MANCC
--ALTER TABLE HOADON DROP CONSTRAINT FK01_HD_KH
--ALTER TABLE HOADON DROP CONSTRAINT FK02_HD_NV
--ALTER TABLE CTHD DROP CONSTRAINT FK01_CTHD_HD
--ALTER TABLE CTHD DROP CONSTRAINT FK02_CTHD_SP
--ALTER TABLE USERS DROP CONSTRAINT fk_makh
-----------------------------------------------------
-----------------------------------------------------
set dateformat dmy
-------------------------------
-- KHACHHANG
insert into khachhang values('KH01',N'Nguyễn Văn Ân',N'731 Trần Hung Dao, Q5, TpHCM','8823451',N'Cá nhân')
insert into khachhang values('KH02',N'Trần Ngọc Han',N'23/5 Nguyễn Trãi, Q5, TpHCM','908256478',N'Cá nhân')
insert into khachhang values('KH03',N'Trần Ngọc Linh',N'45 Nguyễn Cảnh Chân, Q1, TpHCM','938776266',N'Cá nhân')
insert into khachhang values('KH04',N'Trần Minh Long',N'50/34 Lê Dai Hanh, Q10, TpHCM','917325476',N'Cá nhân')
insert into khachhang values('KH05',N'Lê Nhật Minh',N'34 Trương Định, Q3, TpHCM','8246108',N'Cá nhân')
insert into khachhang values('KH06',N'Lê Hoai Thuong',N'227 Nguyễn Văn Cừ, Q5, TpHCM','8631738',N'Cá nhân')
insert into khachhang values('KH07',N'Nguyễn Văn Tam',N'32/3 Trần Binh Trong, Q5, TpHCM','916783565',N'Cá nhân')
insert into khachhang values('KH08',N'Phan Thi Thanh',N'45/2 An Dương Vương, Q5, TpHCM','938435756',N'Cá nhân')
insert into khachhang values('KH09',N'Lê Ha Vinh',N'873 Lê Hồng Phong, Q5, TpHCM','8654763',N'Cá nhân')
insert into khachhang values('KH10',N'Ha Duy Lap',N'34/34B Nguyễn Trãi, Q1, TpHCM','8768904',N'Cá nhân')
insert into khachhang values('KH11',N'Ha Minh Đức',N'12/34/A223, QBìnhThạnh, TpHCM','8768904',N'Doanh Nghiệp')
insert into khachhang values('KH12',N'Bùi Thị Ngò',N'37/20B Nguyễn Trãi, Q1, TpHCM','8768904',N'Doanh Nghiệp')
 
--------------------------------- NHANVIEN
insert into nhanvien values('NV01',N'Nguyễn Văn Bé','927345678','13/04/2006','13/04/1977',1,'Manager')
insert into nhanvien values('NV02',N'Lê Phi Yến','987567390','21/04/2006','13/04/1977',0,'Staff')
insert into nhanvien values('NV03',N'Nguyễn Văn Bảo','997047382','27/04/2006','13/04/1977',1,'Staff')
insert into nhanvien values('NV04',N'Ngô Thanh Tuấn','913758498','24/06/2006','13/04/1977',1,'Staff')
insert into nhanvien values('NV05',N'Nguyễn Thị Trúc','918590387','20/07/2006','13/04/1977',0,'Staff')
 

----------------------------------------KHO

insert into kho values('K01',0)
insert into kho values('K02',0)
insert into kho values('K03',0)


-------------------------------------------PHIEU NHAP
insert into PHIEUNHAP values('PN01','HH01',30,'20/07/2010','30/07/2010','K01')
insert into PHIEUNHAP values('PN02','FPT01',15,'20/07/2010','30/07/2010','K02')
insert into PHIEUNHAP values('PN03','HH01',43,'20/07/2010','30/07/2010','K01')
insert into PHIEUNHAP values('PN04','HH01',56,'20/07/2010','30/07/2010','K01')
insert into PHIEUNHAP values('PN05','FPT01',12,'20/07/2010','30/07/2010','K02')
insert into PHIEUNHAP values('PN06','HH01',55,'20/07/2010','30/07/2010','K01')

insert into PHIEUNHAP values('PN07','HH01',123,'20/07/2010','30/07/2010','K01')
insert into PHIEUNHAP values('PN08','FPT01',66,'20/07/2010','30/07/2010','K02')
insert into PHIEUNHAP values('PN09','HH01',44,'20/07/2010','30/07/2010','K01')

insert into PHIEUNHAP values('PN10','HH01',35,'20/07/2010','30/07/2010','K01')
insert into PHIEUNHAP values('PN11','FPT01',212,'20/07/2010','30/07/2010','K02')
insert into PHIEUNHAP values('PN12','HH01',42,'20/07/2010','30/07/2010','K01')

insert into PHIEUNHAP values('PN13','HH01',315,'20/07/2010','30/07/2010','K03')
insert into PHIEUNHAP values('PN14','FPT01',255,'20/07/2010','30/07/2010','K03')
insert into PHIEUNHAP values('PN15','HH01',242,'20/07/2010','30/07/2010','K03')
--------------------------------------NCC 

insert into nhacungcap values('FPT01','FPT-SHOP','TP.HCM')
insert into nhacungcap values('HH01','Hoang Ha','TP.HCM')
insert into nhacungcap values('Tgdd01','The gioi di dong','TP.HCM')

-------------------------------------KHUYENMAI

insert into KHUYENMAI values('KM01',N'Chưa có chương trình cho món hàng này',N'Không KM',0)
insert into KHUYENMAI values('KM02',N'Giảm 500.000Đ giá trị đơn hàng',N'Giảm giá',500000)
insert into KHUYENMAI values('KM03',N'Tặng 1 AirPod khi mua 1 Iphone 12 128GB/256GB',N'Tặng',0)
insert into KHUYENMAI values('KM04',N'Giảm 1.500.000Đ giá trị đơn hàng',N'Giảm giá',1500000)

---------------MAU

insert into MAU values('M01',N'Đỏ')
insert into MAU values('M02',N'Vàng')
insert into MAU values('M03',N'Xanh biển')
insert into MAU values('M04',N'Xanh lá mạ')
insert into MAU values('M05',N'Gold')
insert into MAU values('M06',N'Bạc')
insert into MAU values('M07',N'Đen')
insert into MAU values('M08',N'Trắng')
insert into MAU values('M09',N'Hồng')
insert into MAU values('M10',N'Kem')

delete from MAU
--------------------------------- dienthoai

insert into dienthoai values('OP01',N'OPPO A93',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành:Android 10,RAM:8 GB,Chip:MediaTek Helio P95,PinSạc:4000mAh',1,5990000,'KM01','K01',null)
insert into dienthoai values('OP02',N'OPPO Reno 5',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành:Android 11,RAM:8 GB,Chip:Snapdragon 720G,PinSạc:4310mAh',1,8690000,'KM02','K01',null)
insert into dienthoai values('OP03',N'OPPO A94',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành:Android 11,RAM:8 GB,Chip:MediaTek Helio P95,PinSạc:4310mAh',1,7690000,'KM02','K01',null)
insert into dienthoai values('OP04',N'OPPO Find X3 Pro',N'1 Năm',256,N'Việt Nam',N'Hệ điều hành:Android 11,RAM:12 GB,Chip:Snapdragon 888,PinSạc:4500mAh',0,26990000,'KM01','K01',null)
insert into dienthoai values('VS01',N'Vsmart Aris',N'1 Năm',64,N'Việt Nam',N'Hệ điều hành:Android 10,RAM:6 GB,Chip:Snapdragon 730,PinSạc:4000mAh',1,5990000,'KM01','K01',null)
insert into dienthoai values('VS02',N'Vsmart Live',N'1 Năm',64,N'Việt Nam',N'Hệ điều hành:Android 10,RAM:6 GB,Chip:Snapdragon 675,PinSạc:5000mAh',1,4090000,'KM01','K01',null)
insert into dienthoai values('VS03',N'Vsmart Joy 4',N'1 Năm',64,N'Việt Nam',N'Hệ điều hành:Android 10,RAM:6 GB,Chip:Snapdragon 665,PinSạc:5000mAh',1,3840000,'KM01','K02',null)
insert into dienthoai values('IP01',N'iPhone SE 128GB',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành:iOS 14,RAM:3 GB,Chip:Chip Apple A13 Bionic,PinSạc:1821mAh',1,12490000,'KM01','K01',null)
insert into dienthoai values('IP02',N'iPhone SE 256GB',N'1 Năm',256,N'Việt Nam',N'Hệ điều hành:iOS 14,RAM:3 GB,Chip:Chip Apple A13 Bionic,PinSạc:1821mAh',1,14490000,'KM04','K02',null)
insert into dienthoai values('IP03',N'iPhone XR 128GB',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành: iOS 14,RAM:3 GB,Chip:Chip Apple A12 Bionic,PinSạc:2942mAh',1,15490000,'KM04','K01',null)
insert into dienthoai values('IP04',N'iPhone 11 64GB',N'1 Năm',64,N'Việt Nam',N'Hệ điều hành: iOS 14,RAM:4 GB,Chip:Chip Apple A13 Bionic,PinSạc:3110mAh',1,16490000,'KM04','K01',null)
insert into dienthoai values('IP05',N'iPhone 11 128GB',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành: iOS 14,RAM:4 GB,Chip:Chip Apple A13 Bionic,PinSạc:3110mAh',1,19990000,'KM04','K02',null)
insert into dienthoai values('IP06',N'iPhone 12 mini 128GB',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành: iOS 14,RAM:4 GB,Chip:Chip Apple A14 Bionic,PinSạc:2227mAh',1,19490000,'KM03','K01',null)
insert into dienthoai values('IP07',N'iPhone 12 Pro 256GB',N'1 Năm',256,N'Việt Nam',N'Hệ điều hành: iOS 14,RAM:6 GB,Chip:Chip Apple A14 Bionic,PinSạc:2815mAh',1,28690000,'KM03','K02',null)
insert into dienthoai values('SS01',N'Samsung Galaxy A2',N'1 Năm',32,N'Việt Nam',N'Hệ điều hành: Android 10,RAM:3 GB,Chip:Chip MediaTek MT6739W,PinSạc:5000mAh',1,2370000,'KM02','K01',null)
insert into dienthoai values('SS02',N'Samsung Galaxy A12',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành: Android 10,RAM:4 GB,Chip:Chip MediaTek Helio G35,PinSạc:5000mAh',1,4270000,'KM04','K02',null)
insert into dienthoai values('SS03',N'Samsung Galaxy A11',N'1 Năm',32,N'Việt Nam',N'Hệ điều hành: Android 10,RAM:3 GB,Chip:Snapdragon 450,PinSạc:4000mAh',1,2990000,'KM04','K01',null)
insert into dienthoai values('SS04',N'Samsung Galaxy A32',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành: Android 10,RAM:6 GB,Chip:Chip MediaTek Helio G80,PinSạc:5000mAh',1,6490000,'KM04','K01',null)
insert into dienthoai values('SS05',N'Samsung Galaxy Note 10',N'1 Năm',128,N'Việt Nam',N'Hệ điều hành: Android 10,RAM:8 GB,Chip:Chip Exynos 9810,PinSạc:4500mAh',1,10490000,'KM04','K02',null)
insert into dienthoai values('SS06',N'Samsung Galaxy Note 20',N'1 Năm',256,N'Việt Nam',N'Hệ điều hành: Android 10,RAM:8 GB,Chip:Chip Exynos 990,PinSạc:4300mAh',1,15990000,'KM04','K01',null)
insert into dienthoai values('SS07',N'Samsung Galaxy S21+ 5G 256GB',N'1 Năm',256,N'Việt Nam',N'Hệ điều hành: Android 11,RAM:8 GB,Chip:Chip Chip Exynos 2100,PinSạc:4800mAh',1,20990000,'KM04','K02',null)
insert into dienthoai values('SS08',N'Samsung Galaxy S21 Ultra 5G 256GB',N'1 Năm',256,N'Việt Nam',N'Hệ điều hành: Android 11,RAM:12 GB,Chip:Chip Chip Exynos 2100,PinSạc:5000mAh',1,25990000,'KM04','K01',null)
insert into dienthoai values('SS09',N'Samsung Galaxy Note 21 Ultra 5G',N'1 Năm',256,N'Việt Nam',N'Hệ điều hành: Android 11,RAM:12 GB,Chip:Chip Chip Exynos 990,PinSạc:4500mAh',1,32990000,'KM04','K02',null)
-----------------------------CTMAU
insert into CTMAU values('M01','OP01')
insert into CTMAU values('M01','OP02')
insert into CTMAU values('M01','OP03')
insert into CTMAU values('M01','OP04')
insert into CTMAU values('M01','IP01')
insert into CTMAU values('M01','IP02')
insert into CTMAU values('M01','IP03')
insert into CTMAU values('M01','IP04')
insert into CTMAU values('M02','SS05')
insert into CTMAU values('M02','IP04')
insert into CTMAU values('M03','SS09')
insert into CTMAU values('M04','SS04')
insert into CTMAU values('M05','VS03')

insert into CTMAU values('M01','IP06')
insert into CTMAU values('M02','IP07')
insert into CTMAU values('M03','IP05')
insert into CTMAU values('M05','SS01')
insert into CTMAU values('M04','SS02')
insert into CTMAU values('M07','SS03')
insert into CTMAU values('M10','SS04')
insert into CTMAU values('M09','SS06')
insert into CTMAU values('M07','SS07')
insert into CTMAU values('M05','SS08')
insert into CTMAU values('M02','VS01')
insert into CTMAU values('M01','VS02')

insert into CTMAU values('M03','IP06')
insert into CTMAU values('M01','IP07')
insert into CTMAU values('M05','IP05')
insert into CTMAU values('M06','SS01')
insert into CTMAU values('M10','SS02')
insert into CTMAU values('M09','SS03')
insert into CTMAU values('M01','SS04')
insert into CTMAU values('M04','SS06')
insert into CTMAU values('M06','SS07')
insert into CTMAU values('M04','SS08')
insert into CTMAU values('M01','VS01')
insert into CTMAU values('M08','VS02')


--------------------------------- HOADON
insert into hoadon values(3001,'23/07/2006','KH01','NV01',0)
insert into hoadon values(3002,'12/08/2006','KH01','NV02',0)
insert into hoadon values(3003,'23/08/2006','KH02','NV01',0)
insert into hoadon values(3004,'01/09/2006','KH02','NV01',0)
insert into hoadon values(3005,'20/10/2006','KH01','NV02',0)
insert into hoadon values(3006,'16/10/2006','KH01','NV03',0)
insert into hoadon values(3007,'28/10/2006','KH03','NV03',0)
insert into hoadon values(3008,'28/10/2006','KH01','NV03',0)
insert into hoadon values(3009,'28/10/2006','KH03','NV04',0)
insert into hoadon values(3010,'01/11/2006','KH01','NV01',0)
insert into hoadon values(3011,'04/11/2006','KH04','NV03',0)
insert into hoadon values(3012,'30/11/2006','KH05','NV03',0)
insert into hoadon values(3013,'12/12/2006','KH06','NV01',0)
insert into hoadon values(3014,'31/12/2006','KH03','NV02',0)
insert into hoadon values(3015,'01/01/2007','KH06','NV01',0)
insert into hoadon values(3016,'01/01/2007','KH07','NV02',0)
insert into hoadon values(3017,'02/01/2007','KH08','NV03',0)
insert into hoadon values(3018,'13/01/2007','KH08','NV03',0)
insert into hoadon values(3019,'13/01/2007','KH01','NV03',0)
insert into hoadon values(3020,'14/01/2007','KH09','NV04',0)
insert into hoadon values(3021,'16/01/2007','KH10','NV03',0)
insert into hoadon values(3022,'16/01/2007','KH04','NV03',0)
insert into hoadon values(3023,'17/01/2007','KH06','NV01',0)
insert into hoadon values(3024,'04/06/2021','KH02','NV02',0)
insert into hoadon values(3025,'07/05/2021 ','KH04','NV03',0)
insert into hoadon values(3026,'17/07/2020','KH06','NV01',0)
insert into hoadon values(3027,'05/06/2021','KH02','NV02',0)
 
--------------------------------- CTHD
insert into cthd values(3001,'IP02',10)
insert into cthd values(3001,'SS01',5)
insert into cthd values(3001,'OP01',5)
insert into cthd values(3001,'OP02',10)
insert into cthd values(3001,'SS08',10)
insert into cthd values(3002,'OP04',20)
insert into cthd values(3002,'SN01',20)
insert into cthd values(3002,'SN02',20)
insert into cthd values(3003,'SN03',10)
insert into cthd values(3004,'IP01',20)
insert into cthd values(3004,'IP02',10)
insert into cthd values(3004,'IP03',10)
insert into cthd values(3004,'IP04',10)
insert into cthd values(3005,'IP05',50)
insert into cthd values(3005,'IP06',50)
insert into cthd values(3006,'IP07',20)
insert into cthd values(3006,'SS01',30)
insert into cthd values(3006,'SS02',10)
insert into cthd values(3007,'SS03',10)
insert into cthd values(3008,'SS04',8)
insert into cthd values(3009,'SS05',10)
insert into cthd values(3010,'IP07',50)
insert into cthd values(3010,'SS07',50)
insert into cthd values(3010,'SS08',300)
insert into cthd values(3010,'SS04',50)
insert into cthd values(3010,'IP03',300)
insert into cthd values(3011,'SS06',50)
insert into cthd values(3012,'SS07',3)
insert into cthd values(3013,'SS08',5)
insert into cthd values(3014,'OP02',80)
insert into cthd values(3014,'SN02',300)
insert into cthd values(3014,'OP04',60)
insert into cthd values(3014,'SN01',50)
insert into cthd values(3015,'SN02',30)
insert into cthd values(3015,'SN03',7)
insert into cthd values(3016,'IP01',5)
insert into cthd values(3017,'IP02',1)
insert into cthd values(3017,'IP03',1)
insert into cthd values(3017,'IP04',5)
insert into cthd values(3018,'SS04',6)
insert into cthd values(3019,'SS05',1)
insert into cthd values(3019,'SS06',2)
insert into cthd values(3020,'SS07',10)
insert into cthd values(3021,'SS08',5)
insert into cthd values(3021,'IP01',7)
insert into cthd values(3021,'IP02',10)
insert into cthd values(3022,'SS07',1)
insert into cthd values(3023,'SS04',6)
insert into cthd values(3024,'IP02',3)
insert into cthd values(3025,'SS07',1)
insert into cthd values(3026,'SS04',6)
insert into cthd values(3027,'SS04',6)


insert into dondathang values('DDH10001','23/07/2020','30/07/2020',0,1,'KH01')
insert into dondathang values('DDH10002','12/08/2020','18/08/2020',0,1,'KH01')
insert into dondathang values('DDH10003','23/08/2020','23/08/2020',0,1,'KH02')
insert into dondathang values('DDH10004','01/09/2020','06/09/2020',0,1,'KH02')
insert into dondathang values('DDH10005','20/10/2020','28/10/2020',0,1,'KH01')
insert into dondathang values('DDH10006','16/10/2020','26/10/2020',0,1,'KH01')
insert into dondathang values('DDH10007','28/10/2020','05/11/2020',0,1,'KH03')
insert into dondathang values('DDH10008','28/10/2020','05/11/2020',0,1,'KH01')
insert into dondathang values('DDH10009','28/10/2020','05/11/2020',0,1,'KH03')
insert into dondathang values('DDH10010','01/11/2020','09/11/2020',0,1,'KH01')
insert into dondathang values('DDH10011','04/11/2020','07/11/2020',0,1,'KH04')
insert into dondathang values('DDH10012','30/11/2020','10/12/2020',0,1,'KH05')
insert into dondathang values('DDH10013','12/12/2020','19/12/2020',0,1,'KH06')
insert into dondathang values('DDH10014','31/12/2020','10/01/2021',0,1,'KH03')
insert into dondathang values('DDH10015','01/01/2020','08/01/2020',0,1,'KH06')
insert into dondathang values('DDH10016','01/01/2020','10/01/2020',0,1,'KH07')
insert into dondathang values('DDH10017','02/01/2020','08/01/2020',0,1,'KH08')
insert into dondathang values('DDH10018','13/01/2020','20/01/2020',0,1,'KH08')
insert into dondathang values('DDH10019','13/01/2020','20/01/2020',0,1,'KH01')
insert into dondathang values('DDH10020','14/01/2020','24/01/2020',0,1,'KH09')
insert into dondathang values('DDH10021','16/01/2020','25/01/2020',0,1,'KH10')
insert into dondathang values('DDH10022','16/01/2020','25/01/2020',0,1,'KH04')
insert into dondathang values('DDH10023','17/01/2020','25/01/2020',0,1,'KH06')
insert into dondathang values('DDH10024','04/06/2021','10/06/2020',0,1,'KH02')
insert into dondathang values('DDH10025','10/06/2021','15/06/2020',0,0,'KH04')
insert into dondathang values('DDH10026','06/06/2021','11/06/2020',0,0,'KH06')
insert into dondathang values('DDH10027','04/06/2021','10/06/2020',0,0,'KH02')



insert into CTDDH values('DDH10001','IP02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10001','SS01',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10001','OP01',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10001','OP02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10001','SS08',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10002','OP04',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10002','SN01',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10002','SN02',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10003','SN03',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10003','IP01',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10004','IP02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10004','IP03',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10004','IP04',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10004','IP05',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10005','IP06',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10005','IP07',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10006','SS01',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10006','SS02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10007','SS03',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10008','SS04',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10008','SS05',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10009','IP07',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10010','SS07',3,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10010','SS08',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10010','SS04',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10011','IP03',3,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10012','SS06',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10012','SS07',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10013','SS08',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10013','OP02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10014','SN02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10015','OP04',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10016','SN01',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10016','SN02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10016','SN03',2,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10017','IP01',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10017','IP02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10017','IP03',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10017','IP04',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10020','IP04',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10020','IP02',1,N'Thanh Toán khi nhận hàng')

insert into CTDDH values('DDH10025','IP01',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10026','IP02',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10027','IP03',1,N'Thanh Toán khi nhận hàng')
insert into CTDDH values('DDH10027','IP04',1,N'Thanh Toán khi nhận hàng')

insert into ROLES(Mota) VALUES ('Administrator')
insert into ROLES(Mota) VALUES ('User')



insert into USERS(Tentk,MatKhau,RoleID,MANV) VALUES('ADMIN',CONVERT(VARCHAR(32),HASHBYTES('MD5','123'),2),1,'NV01')
insert into USERS(Tentk,MatKhau,RoleID,MAKH) VALUES('jass123',CONVERT(VARCHAR(32),HASHBYTES('MD5','123'),2),2,'KH01')
--
--

insert into ADS values('QC01',N'CTY ABC-XYZ',null,'www.lazada.vn','23/05/2020','23/08/2023',0)
insert into ADS values('QC02',N'CTY HEHEHE',null,'www.shoppee.vn','23/05/2020','23/07/2025',0)
insert into ADS values('QC03',N'CTY Oaaa',null,'www.Oaaa.vn','23/05/2020','23/03/2020',1)

DELETE FROM CTMAU WHERE MAMAU = 'M08' AND MASP ='VS02'
SELECT * FROM USERS WHERE TenTK = 'admin' AND MatKhau = 'admin'

seLect * from USERS
seLect * from DIENTHOAI 
seLect * from KHACHHANG
seLect * from NHANVIEN
seLect * from HOADON
seLect * from CTHD
seLect * from KHUYENMAI

seLect * from DONDATHANG
seLect * from CTDDH

DBCC CHECKIDENT (USERS, RESEED, 5)

----
----
----Store Produce
----
----

CREATE PROCEDURE [dbo].[selectThongTinDT] @masp varchar(10)

AS
	SELECT * FROM DIENTHOAI WHERE MASP = @masp
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_ctmau] @mamau varchar(10),@masp varchar(10)

AS
	INSERT INTO CTMAU VALUES(@mamau,@masp)
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_cthd] 
@sohd int,
@tensp nvarchar(40),
@sl int

AS
	DECLARE @masp varchar(10) set @masp = (SELECT MASP FROM DIENTHOAI WHERE TENSP = @tensp)
	INSERT INTO CTHD VALUES(@sohd,@masp,@sl)
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_ChangeAccount] @col varchar(50),@makh varchar(30)


AS
	IF(@col = 'tenkh')
		BEGIN
			SELECT TENKH FROM KHACHHANG WHERE MAKH = @makh
		END
	IF(@col = 'DC')
		BEGIN
			SELECT DIACHI FROM KHACHHANG WHERE MAKH = @makh
		END
	IF(@col = 'sodt')
		BEGIN
			SELECT SODT FROM KHACHHANG WHERE MAKH = @makh
		END
	IF(@col = 'loaikh')
		BEGIN
			SELECT LOAIKH FROM KHACHHANG WHERE MAKH = @makh
		END
	IF(@col = 'password')
		BEGIN
			SELECT MatKhau FROM USERS WHERE TenTK = @makh
		END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_changePass] @mkmoi varchar(50),@tentk varchar(50),@mkcu varchar(50)

AS
	UPDATE USERS SET MatKhau = @mkmoi 
	WHERE TenTK = @tentk AND MatKhau = @mkcu
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_CheckAdminOrUser] @tentk Nvarchar(150)

AS
	SELECT RoleID FROM USERS WHERE TenTK = @tentk
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_checkExist] @tenbang varchar(50),@ma varchar(30)

AS
	IF(@tenbang = 'DIENTHOAI')
		BEGIN
				SELECT COUNT(*) FROM DIENTHOAI WHERE MASP = @ma
		END
	IF(@tenbang = 'KHACHHANG')
		BEGIN
				SELECT COUNT(*) FROM KHACHHANG WHERE MAKH = @ma
		END
	IF(@tenbang = 'KHUYENMAI')
		BEGIN
				SELECT COUNT(*) FROM KHUYENMAI WHERE MAKM = @ma
		END
	IF(@tenbang = 'USER')
		BEGIN
				SELECT COUNT(*) FROM USERS WHERE ID = @ma
		END
	IF(@tenbang = 'HOADON_MAKH')
		BEGIN
				SELECT COUNT(*) FROM HOADON WHERE MAKH = @ma
		END
	IF(@tenbang = 'ADS')
		BEGIN
				SELECT COUNT(*) FROM ADS WHERE IDQC = @ma
		END
	IF(@tenbang = 'KHO')
		BEGIN
				SELECT COUNT(*) FROM KHO WHERE MAKHO = @ma
		END
	IF(@tenbang = 'PN')
		BEGIN
				SELECT COUNT(*) FROM PHIEUNHAP WHERE MAPHIEUNHAP = @ma
		END
	IF(@tenbang = 'PN_CHECK')
		BEGIN
				SELECT COUNT(*) FROM PHIEUNHAP WHERE PHIEUNHAP.MAKHO = @ma
		END
	IF(@tenbang = 'NCC')
		BEGIN
				SELECT COUNT(*) FROM NHACUNGCAP WHERE MANCC = @ma
		END
	IF(@tenbang = 'PN_CHECK_NCC')
		BEGIN
				SELECT COUNT(*) FROM PHIEUNHAP WHERE PHIEUNHAP.MANCC = @ma
		END
	IF(@tenbang = 'KH_CHECK_HOADON')
		BEGIN
				SELECT COUNT(*) FROM HOADON WHERE HOADON.MAKH = @ma
		END
	IF(@tenbang = 'KH_CHECK_HOADON')
		BEGIN
				SELECT COUNT(*) FROM CTHD,HOADON WHERE HOADON.MAKH = @ma AND CTHD.SOHD = HOADON.SOHD
		END
	IF(@tenbang = 'KH_CHECK_DDH')
		BEGIN
				SELECT COUNT(*) FROM CTDDH,DONDATHANG WHERE DONDATHANG.MAKH = @ma AND CTDDH.SODDH = DONDATHANG.SODDH
		END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_checkQL] @tentk varchar(50),@pass varchar(50),@loaicv nvarchar(50)

AS
	SELECT * FROM USERS,NHANVIEN
	WHERE TenTK = @tentk AND MatKhau = @pass
	AND Chucvu = @loaicv AND USERS.MANV = NHANVIEN.MANV
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_checkSOHD]@tenbang varchar(50),@makh varchar(30)

AS
	IF(@tenbang = 'CTHD')
		BEGIN
			SELECT CTHD.SOHD
			FROM CTHD,HOADON
			WHERE HOADON.SOHD = CTHD.SOHD
			AND HOADON.MAKH = @makh
		END
	IF(@tenbang = 'CTDDH')
		BEGIN
			SELECT CTDDH.SODDH
			FROM CTDDH,DONDATHANG
			WHERE CTDDH.SODDH = DONDATHANG.SODDH
			AND DONDATHANG.MAKH = @makh
		END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_checkUser] @tentk varchar(25)

AS
	SELECT COUNT(*) FROM USERS WHERE TenTK = @tentk
	
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_delete] @tenbang nvarchar(50),@ma varchar(50)

AS
	BEGIN
		if(@tenbang = 'USERS')
			BEGIN
				DELETE FROM USERS WHERE TenTK = @ma
			END
		if(@tenbang = 'DIENTHOAI')
			BEGIN
				DELETE FROM DIENTHOAI WHERE MASP = @ma
			END
		if(@tenbang = 'CTHD_MADT')
			BEGIN
				DELETE FROM CTHD WHERE MASP = @ma
			END
		if(@tenbang = 'KHACHHANG')
			BEGIN
				DELETE FROM KHACHHANG WHERE MAKH = @ma
			END
		if(@tenbang = 'HOADON_KH')
			BEGIN
				DELETE FROM HOADON WHERE MAKH = @ma
			END
		if(@tenbang = 'CTHD_KH_HOADON')
			BEGIN
				DELETE FROM CTHD WHERE SOHD = @ma
			END
		if(@tenbang = 'DDH_KH')
			BEGIN
				DELETE FROM DONDATHANG WHERE MAKH = @ma
			END
		if(@tenbang = 'CTHD_KH_DDH')
			BEGIN
				DELETE FROM CTHD WHERE SOHD = @ma
			END
		if(@tenbang = 'USER_MAKH')
			BEGIN
				DELETE FROM USERS WHERE MAKH = @ma
			END
		if(@tenbang = 'KHUYENMAI')
			BEGIN
				DELETE FROM KHUYENMAI WHERE MAKM = @ma
			END
		if(@tenbang = 'ADS')
			BEGIN
				DELETE FROM ADS WHERE IDQC = @ma
			END
		if(@tenbang = 'PN')
			BEGIN
				DELETE FROM PHIEUNHAP WHERE MAPHIEUNHAP = @ma
			END
		if(@tenbang = 'KHO')
			BEGIN
				DELETE FROM KHO WHERE MAKHO = @ma
			END
		if(@tenbang = 'KHO_PN')
			BEGIN
				DELETE FROM PHIEUNHAP WHERE MAKHO = @ma
			END
		if(@tenbang = 'NCC')
			BEGIN
				DELETE FROM NHACUNGCAP WHERE MANCC = @ma
			END
		if(@tenbang = 'NCC_PN')
			BEGIN
				DELETE FROM PHIEUNHAP WHERE MANCC = @ma
			END

	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_deleteCTMAU] @mamau varchar(10),@masp varchar(10)

AS
	DELETE FROM CTMAU WHERE MAMAU = @mamau AND MASP = @masp 
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_dienthoai] 
@Store varchar(50),
@masp varchar(10),
@tensp nvarchar(40),
@baohanh varchar(40),
@dungluong int,
@xuatxu nvarchar(40),
@chitiet nvarchar(max),
@trangthai bit,
@dongia float,
@makm varchar(10),
@makho varchar(10),
@hinhanh image

AS
	BEGIN
		IF(@Store = 'INSERT')
			BEGIN
				INSERT INTO DIENTHOAI 
				VALUES(@masp,@tensp,@baohanh,@dungluong,@xuatxu,@chitiet,@trangthai,@dongia,@makm,@makho,@hinhanh)
			END
		IF(@Store = 'UPDATE')
			BEGIN
				UPDATE DIENTHOAI 
				SET TENSP = @tensp,BAOHANH = @baohanh,
				DUNGLUONG=@dungluong,
				XUATSU = @xuatxu,
				CHITIET = @chitiet,
				TRANGTHAI = @trangthai,
				DONGIA = @dongia,
				MAKM = @makm,
				MAKHO = @makho ,
				Hinhanh = @hinhanh
				WHERE MASP = @masp
			END

	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_hoadon]
@sohd int,
@ngaylaphd date,
@makh nvarchar(30),
@manv nvarchar(30)

AS	
	INSERT INTO HOADON VALUES(@sohd,@ngaylaphd,@makh,@manv,0)
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_khachhang] 
@store varchar(30),
@makh varchar(30),
@tenkh nvarchar(40),
@diachi nvarchar(50),
@sodt varchar(12),
@loaikh nvarchar(20)


AS
	BEGIN
		IF(@store = 'INSERT')
			BEGIN
				INSERT INTO KHACHHANG VALUES(@makh,@tenkh,@diachi,@sodt,@loaikh)
			END
		IF(@store = 'UPDATE')
			BEGIN
				UPDATE KHACHHANG SET TENKH = @tenkh,DIACHI = @diachi,SODT = @sodt,LOAIKH = @loaikh
				WHERE MAKH  =@makh
			END
	END		
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_kho] @makho varchar(10),@tongsl int

AS
	INSERT INTO KHO VALUES(@makho,@tongsl)
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_khuyenmai] @store nvarchar(50),@makm varchar(10),@noidung nvarchar(100),@loaikm nvarchar(30),@giamgia float

AS
	BEGIN
		IF(@store = 'INSERT')
			BEGIN
				INSERT INTO KHUYENMAI VALUES(@makm,@noidung,@loaikm,@giamgia)
			END
		IF(@store = 'UPDATE')
			BEGIN
				UPDATE KHUYENMAI SET NOIDUNG = @noidung,LOAIKHUYENMAI = @loaikm,GIAMGIA = @giamgia
				WHERE MAKM = @makm
			END

	END
	
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_login] @tentk nvarchar(50),@pass nvarchar(50)

AS
	BEGIN
		SELECT * FROM USERS WHERE TenTK = @tentk AND MatKhau = @pass
	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_maxSOHD]

AS
	SELECT MAX(SOHD)+1 FROM HOADON
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_nhacungcap] @store varchar(40),@mancc varchar(10),@ncc nvarchar(40),@dc nvarchar(100)

AS
	IF(@store = 'INSERT')
		BEGIN
			INSERT INTO NHACUNGCAP VALUES(@mancc,@ncc,@dc)
		END
	IF(@store = 'UPDATE')
		BEGIN
			UPDATE NHACUNGCAP SET TENNCC = @ncc,DIACHI = @dc
			WHERE MANCC = @mancc
		END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_nhanvien]@store nvarchar(50), @manv varchar(30),@tennv nvarchar(40),@sdt varchar(12),@ngayvl date,@ngaysinh date,@gt bit,@chucvu nvarchar(50),@diachi nvarchar(MAX)

AS
	BEGIN
		IF(@store = 'INSERT')
			BEGIN
				INSERT INTO NHANVIEN VALUES(@manv,@tennv,@sdt,@ngayvl,@ngaysinh,@gt,@chucvu,@diachi)
			END
	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_phieunhap]
@store varchar(10),
@mapn varchar(10),
@mancc varchar(10),
@soluong int,
@ngaylap date,
@ngaygiao date,
@makho varchar(10)

AS
	IF(@store = 'INSERT')
		BEGIN
			INSERT INTO PHIEUNHAP VALUES(@mapn,@mancc,@soluong,@ngaylap,@ngaygiao,@makho)
		END
	IF(@store = 'UPDATE')
		BEGIN
			UPDATE PHIEUNHAP 
			SET MANCC = @mancc,SOLUONG = @soluong,NGAYLAP = @ngaylap,NGAYGIAO = @ngaygiao,MAKHO=@makho
			WHERE MAPHIEUNHAP = @mapn
		END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_quangcao] @store nvarchar(50),@id varchar(10),@tencty nvarchar(50),@hinhanh image,@thamkhao nvarchar(MAX),@ngaybatdau date,@ngayketthuc date,@hethan bit

AS
	IF(@store = 'INSERT')
		BEGIN
			INSERT INTO ADS VALUES (@id,@tencty,@hinhanh,@thamkhao,@ngaybatdau,@ngayketthuc,@hethan)
		END
	IF(@store = 'UPDATE')
		BEGIN
			UPDATE ADS SET TENCTY = @tencty,Hinhanh = @hinhanh,thamkhao =@thamkhao,ngaybatdau=@ngaybatdau,ngayketthuc=@ngayketthuc,hethan = @hethan WHERE IDQC = @id
		END

RETURN 0

--

CREATE PROCEDURE [dbo].[sp_search] @tenbang nvarchar(50),@loaitk nvarchar(50),@giatri nvarchar(50)

AS
	BEGIN
		IF(@tenbang = 'DIENTHOAI')
			BEGIN
				IF(@loaitk = 'MASP')
					BEGIN
						SELECT CONCAT(DIENTHOAI.MASP,'-',MAU.MAMAU) AS [Mã điện thoại],				
						CONCAT(TENSP,' - ',MAU.TENMAU) AS[Dòng điện thoại],
						BAOHANH AS[Bảo hành],
						DUNGLUONG AS[Dung lượng],
						XUATSU AS[Xuất xứ],
						MAU.TENMAU AS[Tên màu],
						CHITIET AS[Cấu hình],
						CASE WHEN TRANGTHAI = 'true' THEN N'Còn hàng' ELSE N'Hết hàng' END AS[Trạng thái],
						DONGIA AS[Đơn giá bán],
						DIENTHOAI.MAKM AS[Mã khuyến mãi],
						KHUYENMAI.NOIDUNG AS[Nội dung],
						MAKHO AS[Mã kho],
						Hinhanh AS[Hình ảnh]
						FROM DIENTHOAI,KHUYENMAI,MAU,CTMAU
						WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND DIENTHOAI.MASP = CTMAU.MASP
						AND CTMAU.MAMAU = MAU.MAMAU
						AND DIENTHOAI.MASP LIKE '%'+@giatri+'%'
						ORDER BY DIENTHOAI.MASP ASC					
					END
				IF(@loaitk = 'TENSP')
					BEGIN
						SELECT CONCAT(DIENTHOAI.MASP,'-',MAU.MAMAU) AS [Mã điện thoại],				
						CONCAT(TENSP,' - ',MAU.TENMAU) AS[Dòng điện thoại],
						BAOHANH AS[Bảo hành],
						DUNGLUONG AS[Dung lượng],
						XUATSU AS[Xuất xứ],
						MAU.TENMAU AS[Tên màu],
						CHITIET AS[Cấu hình],
						CASE WHEN TRANGTHAI = 'true' THEN N'Còn hàng' ELSE N'Hết hàng' END AS[Trạng thái],
						DONGIA AS[Đơn giá bán],
						DIENTHOAI.MAKM AS[Mã khuyến mãi],
						KHUYENMAI.NOIDUNG AS[Nội dung],
						MAKHO AS[Mã kho],
						Hinhanh AS[Hình ảnh]
						FROM DIENTHOAI,KHUYENMAI,MAU,CTMAU
						WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND DIENTHOAI.MASP = CTMAU.MASP
						AND CTMAU.MAMAU = MAU.MAMAU
						AND TENSP LIKE '%'+@giatri+'%'
						ORDER BY DIENTHOAI.MASP ASC	
					END
				IF(@loaitk = 'DUNGLUONG')
					BEGIN
						SELECT CONCAT(DIENTHOAI.MASP,'-',MAU.MAMAU) AS [Mã điện thoại],				
						CONCAT(TENSP,' - ',MAU.TENMAU) AS[Dòng điện thoại],
						BAOHANH AS[Bảo hành],
						DUNGLUONG AS[Dung lượng],
						XUATSU AS[Xuất xứ],
						MAU.TENMAU AS[Tên màu],
						CHITIET AS[Cấu hình],
						CASE WHEN TRANGTHAI = 'true' THEN N'Còn hàng' ELSE N'Hết hàng' END AS[Trạng thái],
						DONGIA AS[Đơn giá bán],
						DIENTHOAI.MAKM AS[Mã khuyến mãi],
						KHUYENMAI.NOIDUNG AS[Nội dung],
						MAKHO AS[Mã kho],
						Hinhanh AS[Hình ảnh]
						FROM DIENTHOAI,KHUYENMAI,MAU,CTMAU
						WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND DIENTHOAI.MASP = CTMAU.MASP
						AND CTMAU.MAMAU = MAU.MAMAU
						AND DUNGLUONG LIKE '%'+@giatri+'%'
						ORDER BY DIENTHOAI.MASP ASC	
					END
				IF(@loaitk = 'DONGIA')
					BEGIN
						SELECT MASP AS [Mã điện thoại],				
						TENSP AS[Dòng điện thoại],
						BAOHANH AS[Bảo hành],
						DUNGLUONG AS[Dung lượng],
						XUATSU AS[Xuất xứ],
						CHITIET AS[Cấu hình],
						TRANGTHAI AS[Còn hàng],
						DONGIA AS[Đơn giá bán],
						MAKM AS[Mã khuyến mãi],
						MAKHO AS[Mã kho]
						FROM DIENTHOAI WHERE DONGIA > @giatri
					END
				IF(@loaitk = 'MENU_TENSP')
					BEGIN
						SELECT Hinhanh,
						CONCAT(N'Tên sản phẩm: ',TENSP),
						CONCAT(N'Bảo hành:',BAOHANH),
						CONCAT(N'Dung lượng:',DUNGLUONG),
						CONCAT(N'Giá:',CAST(DONGIA AS bigint)),
						CONCAT(N'Khuyến mãi:',KHUYENMAI.NOIDUNG),
						MASP
						FROM DIENTHOAI,KHUYENMAI
						WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM 
						AND TENSP LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'MENU_CAUHINH')
					BEGIN
						SELECT Hinhanh,
						CONCAT(N'Tên sản phẩm: ',TENSP),
						CONCAT(N'Bảo hành:',BAOHANH),
						CONCAT(N'Dung lượng:',DUNGLUONG),
						CONCAT(N'Giá:',CAST(DONGIA AS bigint)),
						CONCAT(N'Khuyến mãi:',KHUYENMAI.NOIDUNG),
						MASP
						FROM DIENTHOAI,KHUYENMAI
						WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM 
						AND CHITIET LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'MENU_DUNGLUONG')
					BEGIN
						SELECT Hinhanh,
						CONCAT(N'Tên sản phẩm: ',TENSP),
						CONCAT(N'Bảo hành:',BAOHANH),
						CONCAT(N'Dung lượng:',DUNGLUONG),
						CONCAT(N'Giá:',CAST(DONGIA AS bigint)),
						CONCAT(N'Khuyến mãi:',KHUYENMAI.NOIDUNG),
						MASP
						FROM DIENTHOAI,KHUYENMAI
						WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM 
						AND DUNGLUONG LIKE '%'+@giatri+'%'
					END
			END
		IF(@tenbang = 'KHACHHANG')
			BEGIN
				IF(@loaitk = 'MAKH')
					BEGIN
						SELECT MAKH AS[Mã khách hàng],
						TENKH AS[Họ tên KH],
						DIACHI AS[Địa chỉ],
						SODT AS[Số đt],
						LOAIKH AS[Loại KH] FROM KHACHHANG WHERE MAKH LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'TENKH')
					BEGIN
						SELECT MAKH AS[Mã khách hàng],
						TENKH AS[Họ tên KH],
						DIACHI AS[Địa chỉ],
						SODT AS[Số đt],
						LOAIKH AS[Loại KH] 
						FROM KHACHHANG WHERE TENKH LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'DIACHI')
					BEGIN
						SELECT MAKH AS[Mã khách hàng],
						TENKH AS[Họ tên KH],
						DIACHI AS[Địa chỉ],
						SODT AS[Số đt],
						LOAIKH AS[Loại KH] 
						FROM KHACHHANG WHERE DIACHI LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'LOAIKH')
					BEGIN
						SELECT MAKH AS[Mã khách hàng],
						TENKH AS[Họ tên KH],
						DIACHI AS[Địa chỉ],
						SODT AS[Số đt],
						LOAIKH AS[Loại KH]
						FROM KHACHHANG WHERE LOAIKH LIKE '%'+@giatri+'%'
					END
			END
		IF(@tenbang = 'NHANVIEN')
			BEGIN
				IF(@loaitk = 'MANV')
					BEGIN
						SELECT MANV AS[Mã nhân viên],
						HOTEN AS[Họ tên NV],
						SODT AS[Số đt],
						CONVERT(VARCHAR(10),NGVL,103) AS[Ngày vào làm],
						DIACHI AS[Địa chỉ],
						CONVERT(int,ROUND(DATEDIFF(DAY,Ngaysinh,GETDATE())/365.25,0)) AS[Tuổi],
						CONVERT(VARCHAR(10),Ngaysinh,103) AS[Ngày sinh],
						CASE WHEN Gt = 'true' THEN N'Nam' ELSE N'Nữ' END AS[Giới tính],
						Chucvu AS[Chức vụ]
						FROM NHANVIEN WHERE MANV LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'TENNV')
					BEGIN
						SELECT MANV AS[Mã nhân viên],
						HOTEN AS[Họ tên NV],
						SODT AS[Số đt],
						CONVERT(VARCHAR(10),NGVL,103) AS[Ngày vào làm],
						DIACHI AS[Địa chỉ],
						CONVERT(VARCHAR(10),Ngaysinh,103) AS[Ngày sinh],
						CASE WHEN Gt = 'true' THEN N'Nam' ELSE N'Nữ' END AS[Giới tính],
						Chucvu AS[Chức vụ]
						FROM NHANVIEN WHERE HOTEN LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'CHUCVU')
					BEGIN
						SELECT MANV AS[Mã nhân viên],
						HOTEN AS[Họ tên NV],
						SODT AS[Số đt],
						CONVERT(VARCHAR(10),NGVL,103) AS[Ngày vào làm],
						DIACHI AS[Địa chỉ],
						CONVERT(VARCHAR(10),Ngaysinh,103) AS[Ngày sinh],
						CASE WHEN Gt = 'true' THEN N'Nam' ELSE N'Nữ' END AS[Giới tính],
						Chucvu AS[Chức vụ]
						FROM NHANVIEN WHERE Chucvu LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'NGAYVL')
					BEGIN
						SELECT MANV AS[Mã nhân viên],
						HOTEN AS[Họ tên NV],
						SODT AS[Số đt],
						CONVERT(VARCHAR(10),NGVL,103) AS[Ngày vào làm],
						DIACHI AS[Địa chỉ],
						CONVERT(VARCHAR(10),Ngaysinh,103) AS[Ngày sinh],
						CASE WHEN Gt = 'true' THEN N'Nam' ELSE N'Nữ' END AS[Giới tính],
						Chucvu AS[Chức vụ]
						FROM NHANVIEN WHERE NGVL LIKE '%'+@giatri+'%'
					END
			END
		IF(@tenbang = 'KHUYENMAI')
			BEGIN
				IF(@loaitk = 'MAKM')
					BEGIN
						SELECT MAKM AS [Mã khuyến mãi],
						NOIDUNG AS[Nội dung],
						LOAIKHUYENMAI AS[Phân loại],
						GIAMGIA AS[Giảm giá]  
						FROM KHUYENMAI WHERE MAKM LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'LOAIKM')
					BEGIN
						SELECT MAKM AS [Mã khuyến mãi],
						NOIDUNG AS[Nội dung],
						LOAIKHUYENMAI AS[Phân loại],
						GIAMGIA AS[Giảm giá]
						FROM KHUYENMAI WHERE LOAIKHUYENMAI LIKE '%'+@giatri+'%'
					END
			END
		IF(@tenbang = 'KHO')
			BEGIN
				IF(@loaitk = 'MAKHO')
					BEGIN
						SELECT KHO.MAKHO AS[Mã kho],SUM(PHIEUNHAP.SOLUONG) AS[Số lượng lưu trữ]
						FROM KHO,PHIEUNHAP
						WHERE KHO.MAKHO = PHIEUNHAP.MAKHO
						AND KHO.MAKHO LIKE '%'+@giatri+'%'
						GROUP BY KHO.MAKHO 
					END
				IF(@loaitk = 'TONGSL')
					BEGIN
						SELECT MAKHO AS[Mã kho],
						Tongsl AS[Số lượng lưu trữ]
						FROM KHO WHERE Tongsl > @giatri
					END
			END
		IF(@tenbang = 'PHIEUNHAP')
			BEGIN
				IF(@loaitk = 'MAPHIEUNHAP')
					BEGIN
						SELECT MAPHIEUNHAP AS[Mã phiếu nhập],
						MANCC AS[Mã nhà cung cấp],
						SOLUONG AS[Số lượng],
						NGAYLAP AS[Ngày lập],
						NGAYGIAO AS[Ngày giao],
						MAKHO AS[Mã kho]
						FROM PHIEUNHAP WHERE MAPHIEUNHAP LIKE '%'+@giatri+'%'
					END
			END
		IF(@tenbang = 'HOADON')
			BEGIN
				IF(@loaitk = 'SOHOADON_HD')
					BEGIN
						SELECT HOADON.SOHD AS[Số hoá đơn],
						NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.MAKH AS[Mã khách hàng],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.MANV AS[Mã nhân viên],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SUM(CTHD.SL*DIENTHOAI.DONGIA) AS [Trị giá]
						FROM HOADON,KHACHHANG,NHANVIEN,CTHD,DIENTHOAI
						WHERE HOADON.MAKH = KHACHHANG.MAKH 
						AND HOADON.MANV = NHANVIEN.MANV
						AND HOADON.SOHD = CTHD.SOHD
						AND CTHD.MASP = DIENTHOAI.MASP
						GROUP BY HOADON.SOHD,NGAYLAPHD,KHACHHANG.MAKH,KHACHHANG.TENKH,NHANVIEN.MANV,NHANVIEN.HOTEN
						HAVING HOADON.SOHD LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'TENKH')
					BEGIN
						SELECT HOADON.SOHD AS[Số hoá đơn],
						NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.MAKH AS[Mã khách hàng],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.MANV AS[Mã nhân viên],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SUM(CTHD.SL*DIENTHOAI.DONGIA) AS [Trị giá]
						FROM HOADON,KHACHHANG,NHANVIEN,CTHD,DIENTHOAI
						WHERE HOADON.MAKH = KHACHHANG.MAKH 
						AND HOADON.MANV = NHANVIEN.MANV
						AND HOADON.SOHD = CTHD.SOHD
						AND CTHD.MASP = DIENTHOAI.MASP
						GROUP BY HOADON.SOHD,NGAYLAPHD,KHACHHANG.MAKH,KHACHHANG.TENKH,NHANVIEN.MANV,NHANVIEN.HOTEN
						HAVING KHACHHANG.TENKH LIKE '%'+@giatri+'%'
					END
					IF(@loaitk = 'TENNV')
					BEGIN
						SELECT HOADON.SOHD AS[Số hoá đơn],
						NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.MAKH AS[Mã khách hàng],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.MANV AS[Mã nhân viên],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SUM(CTHD.SL*DIENTHOAI.DONGIA) AS [Trị giá]
						FROM HOADON,KHACHHANG,NHANVIEN,CTHD,DIENTHOAI
						WHERE HOADON.MAKH = KHACHHANG.MAKH 
						AND HOADON.MANV = NHANVIEN.MANV
						AND HOADON.SOHD = CTHD.SOHD
						AND CTHD.MASP = DIENTHOAI.MASP
						GROUP BY HOADON.SOHD,NGAYLAPHD,KHACHHANG.MAKH,KHACHHANG.TENKH,NHANVIEN.MANV,NHANVIEN.HOTEN
						HAVING NHANVIEN.HOTEN LIKE '%'+@giatri+'%'
					END
			END
		IF(@tenbang = 'CTHD')
			BEGIN
				IF(@loaitk = 'SOHOADON_CTHD')
					BEGIN
						SELECT CTHD.SOHD  AS[Số hoá đơn],
						CTHD.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						HOADON.NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SL AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
						FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN ,KHUYENMAI
						WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
						AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
						AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND CTHD.SOHD LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'TENKH_CTHD')
					BEGIN
						SELECT CTHD.SOHD  AS[Số hoá đơn],
						CTHD.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						HOADON.NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SL AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
						FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN ,KHUYENMAI
						WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
						AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
						AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND KHACHHANG.TENKH LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'TENNV_CTHD')
					BEGIN
						SELECT CTHD.SOHD  AS[Số hoá đơn],
						CTHD.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						HOADON.NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SL AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
						FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN ,KHUYENMAI
						WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
						AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
						AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND NHANVIEN.HOTEN LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'MADT_CTHD')
					BEGIN
						SELECT CTHD.SOHD  AS[Số hoá đơn],
						CTHD.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						HOADON.NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SL AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
						FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN ,KHUYENMAI
						WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
						AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
						AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND CTHD.MASP LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'TENDT_CTHD')
					BEGIN
						SELECT CTHD.SOHD  AS[Số hoá đơn],
						CTHD.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						HOADON.NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SL AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
						FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN ,KHUYENMAI
						WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
						AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
						AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND DIENTHOAI.TENSP LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'SL_CTHD')
					BEGIN
						SELECT CTHD.SOHD  AS[Số hoá đơn],
						CTHD.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						HOADON.NGAYLAPHD AS[Ngày lập HĐ],
						KHACHHANG.TENKH AS[Tên khách hàng],
						NHANVIEN.HOTEN AS[Tên nhân viên],
						SL AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
						FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN ,KHUYENMAI
						WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
						AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
						AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND SL > @giatri
					END
			END
		IF(@tenbang = 'DDH')
			BEGIN
				IF(@loaitk = 'SODDH')
					BEGIN
						SELECT DONDATHANG.SODDH AS[Số đơn đặt hàng],
						NgayDatHang AS[Ngày đặt hàng],
						NgayGiaoHang AS[Ngày giao hàng],
						KHACHHANG.MAKH AS[Mã khách hàng],
						TENKH AS[Tên khách hàng],
						Dagiao AS[Đã giao hàng],
						SUM(CTDDH.SOLUONG*DIENTHOAI.DONGIA) AS[Tổng trị giá]
						FROM DONDATHANG,KHACHHANG,CTDDH,DIENTHOAI
						WHERE DONDATHANG.MAKH = KHACHHANG.MAKH
						AND DONDATHANG.SODDH = CTDDH.SODDH
						AND CTDDH.MASP = DIENTHOAI.MASP
						GROUP BY DONDATHANG.SODDH,KHACHHANG.MAKH,NgayDatHang,NgayGiaoHang,Dagiao,KHACHHANG.TENKH
						HAVING DONDATHANG.SODDH LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'TENKH')
					BEGIN
						SELECT DONDATHANG.SODDH AS[Số đơn đặt hàng],
						NgayDatHang AS[Ngày đặt hàng],
						NgayGiaoHang AS[Ngày giao hàng],
						KHACHHANG.MAKH AS[Mã khách hàng],
						TENKH AS[Tên khách hàng],
						Dagiao AS[Đã giao hàng],
						SUM(CTDDH.SOLUONG*DIENTHOAI.DONGIA) AS[Tổng trị giá]
						FROM DONDATHANG,KHACHHANG,CTDDH,DIENTHOAI
						WHERE DONDATHANG.MAKH = KHACHHANG.MAKH
						AND DONDATHANG.SODDH = CTDDH.SODDH
						AND CTDDH.MASP = DIENTHOAI.MASP
						GROUP BY DONDATHANG.SODDH,KHACHHANG.MAKH,NgayDatHang,NgayGiaoHang,Dagiao,KHACHHANG.TENKH
						HAVING KHACHHANG.TENKH LIKE '%'+@giatri+'%'
					END				
			END
		IF(@tenbang = 'CTDDH')
				BEGIN
					IF(@loaitk = 'SODDH')
					BEGIN
						SELECT CTDDH.SODDH AS[Số đơn đặt hàng],
						CTDDH.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						DONDATHANG.NgayDatHang AS[Ngày Ngày đặt hàng],
						DONDATHANG.NgayGiaoHang AS[Ngày giao hàng],
						DONDATHANG.MAKH AS[Mã khách hàng],
						KHACHHANG.TENKH AS[Tên khách hàng],
						HinhthucTT AS[Hình thức thanh toán],
						SOLUONG AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*SOLUONG) AS[Thành tiền]
						FROM CTDDH,DONDATHANG,DIENTHOAI,KHACHHANG,KHUYENMAI
						WHERE CTDDH.SODDH = DONDATHANG.SODDH
						AND DONDATHANG.MAKH = KHACHHANG.MAKH
						AND CTDDH.MASP = DIENTHOAI.MASP AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND CTDDH.SODDH LIKE '%'+@giatri+'%'
					END
					IF(@loaitk = 'TENKH')
					BEGIN
						SELECT CTDDH.SODDH AS[Số đơn đặt hàng],
						CTDDH.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						DONDATHANG.NgayDatHang AS[Ngày Ngày đặt hàng],
						DONDATHANG.NgayGiaoHang AS[Ngày giao hàng],
						DONDATHANG.MAKH AS[Mã khách hàng],
						KHACHHANG.TENKH AS[Tên khách hàng],
						HinhthucTT AS[Hình thức thanh toán],
						SOLUONG AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*SOLUONG) AS[Thành tiền]
						FROM CTDDH,DONDATHANG,DIENTHOAI,KHACHHANG,KHUYENMAI
						WHERE CTDDH.SODDH = DONDATHANG.SODDH
						AND DONDATHANG.MAKH = KHACHHANG.MAKH
						AND CTDDH.MASP = DIENTHOAI.MASP AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND KHACHHANG.TENKH LIKE '%'+@giatri+'%'
					END
					IF(@loaitk = 'TENSP')
					BEGIN
						SELECT CTDDH.SODDH AS[Số đơn đặt hàng],
						CTDDH.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						DONDATHANG.NgayDatHang AS[Ngày Ngày đặt hàng],
						DONDATHANG.NgayGiaoHang AS[Ngày giao hàng],
						DONDATHANG.MAKH AS[Mã khách hàng],
						KHACHHANG.TENKH AS[Tên khách hàng],
						HinhthucTT AS[Hình thức thanh toán],
						SOLUONG AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*SOLUONG) AS[Thành tiền]
						FROM CTDDH,DONDATHANG,DIENTHOAI,KHACHHANG,KHUYENMAI
						WHERE CTDDH.SODDH = DONDATHANG.SODDH
						AND DONDATHANG.MAKH = KHACHHANG.MAKH
						AND CTDDH.MASP = DIENTHOAI.MASP AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND DIENTHOAI.TENSP LIKE '%'+@giatri+'%'
					END
					IF(@loaitk = 'HINHTHUCTT')
					BEGIN
						SELECT CTDDH.SODDH AS[Số đơn đặt hàng],
						CTDDH.MASP AS[Mã sản phẩm],
						DIENTHOAI.TENSP AS[Tên sản phẩm],
						DONDATHANG.NgayDatHang AS[Ngày Ngày đặt hàng],
						DONDATHANG.NgayGiaoHang AS[Ngày giao hàng],
						DONDATHANG.MAKH AS[Mã khách hàng],
						KHACHHANG.TENKH AS[Tên khách hàng],
						HinhthucTT AS[Hình thức thanh toán],
						SOLUONG AS[Số lượng],
						DIENTHOAI.DONGIA AS[Đơn giá],
						((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*SOLUONG) AS[Thành tiền]
						FROM CTDDH,DONDATHANG,DIENTHOAI,KHACHHANG,KHUYENMAI
						WHERE CTDDH.SODDH = DONDATHANG.SODDH
						AND DONDATHANG.MAKH = KHACHHANG.MAKH
						AND CTDDH.MASP = DIENTHOAI.MASP AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
						AND HinhthucTT LIKE '%'+@giatri+'%'
					END
				END
		IF(@tenbang = 'ADS')
			BEGIN
				IF(@loaitk = 'ID')
					BEGIN
						SELECT IDQC AS[Mã công ty],
						TENCTY AS[Tên công ty],
						thamkhao AS[Đường dẫn tham khảo],
						ngaybatdau AS[Ngày bắt đầu],
						ngayketthuc AS[Ngày kết thúc],
						hethan AS[Hết hạn],
						Hinhanh AS[Hình ảnh]
						FROM ADS
						WHERE IDQC LIKE '%'+@giatri+'%'
					END
				IF(@loaitk = 'TENCTY')
					BEGIN
						SELECT IDQC AS[Mã công ty],
						TENCTY AS[Tên công ty],
						thamkhao AS[Đường dẫn tham khảo],
						ngaybatdau AS[Ngày bắt đầu],
						ngayketthuc AS[Ngày kết thúc],
						hethan AS[Hết hạn],
						Hinhanh AS[Hình ảnh]
						FROM ADS
						WHERE TENCTY LIKE '%'+@giatri+'%'
					END

			END
	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_searchBigInt] @tenbang nvarchar(50),@giatriMin bigint ,@giatriMax bigint 
AS
		BEGIN
				SELECT HOADON.SOHD AS[Số hoá đơn],
				NGAYLAPHD AS[Ngày lập HĐ],
				KHACHHANG.MAKH AS[Mã khách hàng],
				KHACHHANG.TENKH AS[Tên khách hàng],
				NHANVIEN.MANV AS[Mã nhân viên],
				NHANVIEN.HOTEN AS[Tên nhân viên],
				SUM(CTHD.SL*DIENTHOAI.DONGIA) AS [Trị giá]
				FROM HOADON,KHACHHANG,NHANVIEN,CTHD,DIENTHOAI
				WHERE HOADON.MAKH = KHACHHANG.MAKH 
				AND HOADON.MANV = NHANVIEN.MANV
				AND HOADON.SOHD = CTHD.SOHD
				AND CTHD.MASP = DIENTHOAI.MASP
				GROUP BY HOADON.SOHD,NGAYLAPHD,KHACHHANG.MAKH,KHACHHANG.TENKH,NHANVIEN.MANV,NHANVIEN.HOTEN
				HAVING SUM(CTHD.SL*DIENTHOAI.DONGIA) >= @giatriMin AND SUM(CTHD.SL*DIENTHOAI.DONGIA) <= @giatriMax
			END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_searchBool] @tenbang nvarchar(50),@giatri bit

AS
	BEGIN
	IF(@tenbang = 'DDH')
		BEGIN
				SELECT DONDATHANG.SODDH AS[Số đơn đặt hàng],
				NgayDatHang AS[Ngày đặt hàng],
				NgayGiaoHang AS[Ngày giao hàng],
				KHACHHANG.MAKH AS[Mã khách hàng],
				TENKH AS[Tên khách hàng],
				Dagiao AS[Đã giao hàng],
				SUM(CTDDH.SOLUONG*DIENTHOAI.DONGIA) AS[Tổng trị giá]
				FROM DONDATHANG,KHACHHANG,CTDDH,DIENTHOAI
				WHERE DONDATHANG.MAKH = KHACHHANG.MAKH
				AND DONDATHANG.SODDH = CTDDH.SODDH
				AND CTDDH.MASP = DIENTHOAI.MASP
				GROUP BY DONDATHANG.SODDH,KHACHHANG.MAKH,NgayDatHang,NgayGiaoHang,Dagiao,KHACHHANG.TENKH
				HAVING Dagiao = @giatri
		END
	IF(@tenbang = 'DIENTHOAI')
		BEGIN
				SELECT CONCAT(DIENTHOAI.MASP,'-',MAU.MAMAU) AS [Mã điện thoại],				
				CONCAT(TENSP,' - ',MAU.TENMAU) AS[Dòng điện thoại],
				BAOHANH AS[Bảo hành],
				DUNGLUONG AS[Dung lượng],
				XUATSU AS[Xuất xứ],
				MAU.TENMAU AS[Tên màu],
				CHITIET AS[Cấu hình],
				TRANGTHAI AS[Còn hàng],
				DONGIA AS[Đơn giá bán],
				DIENTHOAI.MAKM AS[Mã khuyến mãi],
				KHUYENMAI.NOIDUNG AS[Nội dung],
				MAKHO AS[Mã kho],
				Hinhanh AS[Hình ảnh]
				FROM DIENTHOAI,KHUYENMAI,MAU,CTMAU
				WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
				AND DIENTHOAI.MASP = CTMAU.MASP
				AND CTMAU.MAMAU = MAU.MAMAU
				AND TRANGTHAI = @giatri
				ORDER BY DIENTHOAI.MASP ASC	
		END
	IF(@tenbang = 'ADS')
			BEGIN
				SELECT IDQC AS[STT],
				TENCTY AS[Tên công ty],
				thamkhao AS[Đường dẫn tham khảo],
				ngaybatdau AS[Ngày bắt đầu],
				ngayketthuc AS[Ngày kết thúc],
				hethan AS[Hết hạn],
				Hinhanh AS[Hình ảnh]
				FROM ADS
				WHERE hethan = @giatri
			END
	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_searchDate]@tenbang nvarchar(50), @minDate date,@maxDate date

AS
	BEGIN
		IF(@tenbang = 'HOADON')
			BEGIN
				SELECT HOADON.SOHD AS[Số hoá đơn],
				NGAYLAPHD AS[Ngày lập HĐ],
				KHACHHANG.MAKH AS[Mã khách hàng],
				KHACHHANG.TENKH AS[Tên khách hàng],
				NHANVIEN.MANV AS[Mã nhân viên],
				NHANVIEN.HOTEN AS[Tên nhân viên],
				SUM(CTHD.SL*DIENTHOAI.DONGIA) AS [Trị giá]
				FROM HOADON,KHACHHANG,NHANVIEN,CTHD,DIENTHOAI
				WHERE HOADON.MAKH = KHACHHANG.MAKH 
				AND HOADON.MANV = NHANVIEN.MANV
				AND HOADON.SOHD = CTHD.SOHD
				AND CTHD.MASP = DIENTHOAI.MASP
				GROUP BY HOADON.SOHD,NGAYLAPHD,KHACHHANG.MAKH,KHACHHANG.TENKH,NHANVIEN.MANV,NHANVIEN.HOTEN
				HAVING NGAYLAPHD >= @minDate AND NGAYLAPHD <= @maxDate
			END
		IF(@tenbang = 'CTHD')
			BEGIN
				SELECT CTHD.SOHD  AS[Số hoá đơn],
				CTHD.MASP AS[Mã sản phẩm],
				DIENTHOAI.TENSP AS[Tên sản phẩm],
				HOADON.NGAYLAPHD AS[Ngày lập HĐ],
				KHACHHANG.TENKH AS[Tên khách hàng],
				NHANVIEN.HOTEN AS[Tên nhân viên],
				SL AS[Số lượng],
				DIENTHOAI.DONGIA AS[Đơn giá],
				((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
				FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN ,KHUYENMAI
				WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
				AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
				AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
				AND HOADON.NGAYLAPHD >= @minDate AND HOADON.NGAYLAPHD <= @maxDate
			END
		IF(@tenbang = 'DDH')
			BEGIN
				SELECT DONDATHANG.SODDH AS[Số đơn đặt hàng],
				NgayDatHang AS[Ngày đặt hàng],
				NgayGiaoHang AS[Ngày giao hàng],
				KHACHHANG.MAKH AS[Mã khách hàng],
				TENKH AS[Tên khách hàng],
				Dagiao AS[Đã giao hàng],
				SUM(CTDDH.SOLUONG*DIENTHOAI.DONGIA) AS[Tổng trị giá]
				FROM DONDATHANG,KHACHHANG,CTDDH,DIENTHOAI
				WHERE DONDATHANG.MAKH = KHACHHANG.MAKH
				AND DONDATHANG.SODDH = CTDDH.SODDH
				AND CTDDH.MASP = DIENTHOAI.MASP
				GROUP BY DONDATHANG.SODDH,KHACHHANG.MAKH,NgayDatHang,NgayGiaoHang,Dagiao,KHACHHANG.TENKH
				HAVING NgayDatHang>=@minDate AND NgayDatHang<=@maxDate 
			END
		IF(@tenbang = 'CTDDH')
			BEGIN
				SELECT CTDDH.SODDH AS[Số đơn đặt hàng],
				CTDDH.MASP AS[Mã sản phẩm],
				DIENTHOAI.TENSP AS[Tên sản phẩm],
				DONDATHANG.NgayDatHang AS[Ngày Ngày đặt hàng],
				DONDATHANG.NgayGiaoHang AS[Ngày giao hàng],
				DONDATHANG.MAKH AS[Mã khách hàng],
				KHACHHANG.TENKH AS[Tên khách hàng],
				HinhthucTT AS[Hình thức thanh toán],
				SOLUONG AS[Số lượng],
				DIENTHOAI.DONGIA AS[Đơn giá],
				((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*SOLUONG) AS[Thành tiền]
				FROM CTDDH,DONDATHANG,DIENTHOAI,KHACHHANG,KHUYENMAI
				WHERE CTDDH.SODDH = DONDATHANG.SODDH
				AND DONDATHANG.MAKH = KHACHHANG.MAKH
				AND CTDDH.MASP = DIENTHOAI.MASP
				AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
				AND NgayDatHang>=@minDate AND NgayDatHang<=@maxDate 
			END
	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_searchSLPN]@tenbang nvarchar(50), @giatriMin int ,@giatriMax int

AS
	BEGIN
		IF(@tenbang = 'PHIEUNHAP')
			BEGIN
				SELECT MAPHIEUNHAP AS[Mã phiếu nhập],
				MANCC AS[Mã nhà cung cấp],
				SOLUONG AS[Số lượng],
				NGAYLAP AS[Ngày lập],
				NGAYGIAO AS[Ngày giao],
				MAKHO AS[Mã kho]
				FROM PHIEUNHAP WHERE SOLUONG >= @giatriMin AND SOLUONG <= @giatriMax
			END
		IF(@tenbang = 'HOADON_TRIGIA')
			BEGIN
				SELECT HOADON.SOHD AS[Số hoá đơn],
				NGAYLAPHD AS[Ngày lập HĐ],
				KHACHHANG.MAKH AS[Mã khách hàng],
				KHACHHANG.TENKH AS[Tên khách hàng],
				NHANVIEN.MANV AS[Mã nhân viên],
				NHANVIEN.HOTEN AS[Tên nhân viên],
				SUM(CTHD.SL*DIENTHOAI.DONGIA) AS [Trị giá]
				FROM HOADON,KHACHHANG,NHANVIEN,CTHD,DIENTHOAI
				WHERE HOADON.MAKH = KHACHHANG.MAKH 
				AND HOADON.MANV = NHANVIEN.MANV
				AND HOADON.SOHD = CTHD.SOHD
				AND CTHD.MASP = DIENTHOAI.MASP
				GROUP BY HOADON.SOHD,NGAYLAPHD,KHACHHANG.MAKH,KHACHHANG.TENKH,NHANVIEN.MANV,NHANVIEN.HOTEN
				HAVING SUM(CTHD.SL*DIENTHOAI.DONGIA) >= @giatriMin AND SUM(CTHD.SL*DIENTHOAI.DONGIA) <= @giatriMax
			END
		IF(@tenbang = 'DIENTHOAI_DONGIA')
			BEGIN
				SELECT CONCAT(DIENTHOAI.MASP,'-',MAU.MAMAU) AS [Mã điện thoại],				
				CONCAT(TENSP,' - ',MAU.TENMAU) AS[Dòng điện thoại],
				BAOHANH AS[Bảo hành],
				DUNGLUONG AS[Dung lượng],
				XUATSU AS[Xuất xứ],
				MAU.TENMAU AS[Tên màu],
				CHITIET AS[Cấu hình],
				TRANGTHAI AS[Còn hàng],
				DONGIA AS[Đơn giá bán],
				DIENTHOAI.MAKM AS[Mã khuyến mãi],
				KHUYENMAI.NOIDUNG AS[Nội dung],
				MAKHO AS[Mã kho],
				Hinhanh AS[Hình ảnh]
				FROM DIENTHOAI,KHUYENMAI,MAU,CTMAU
				WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
				AND DIENTHOAI.MASP = CTMAU.MASP
				AND CTMAU.MAMAU = MAU.MAMAU
				AND CAST(DONGIA AS bigint) >= @giatriMin AND CAST(DONGIA AS bigint) <=@giatriMax
				ORDER BY DIENTHOAI.MASP ASC	
			END
		IF(@tenbang = 'CTHD_THANHTIEN')
			BEGIN
				SELECT CTHD.SOHD  AS[Số hoá đơn],
				CTHD.MASP AS[Mã sản phẩm],
				DIENTHOAI.TENSP AS[Tên sản phẩm],
				HOADON.NGAYLAPHD AS[Ngày lập HĐ],
				KHACHHANG.TENKH AS[Tên khách hàng],
				NHANVIEN.HOTEN AS[Tên nhân viên],
				SL AS[Số lượng],
				DIENTHOAI.DONGIA AS[Đơn giá],
				((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
				FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN,KHUYENMAI
				WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
				AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
				AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
				AND (DIENTHOAI.DONGIA * SL) >= @giatriMin AND (DIENTHOAI.DONGIA * SL) <=@giatriMax
			END
		IF(@tenbang = 'DDH_TRIGIA')
			BEGIN
				SELECT DONDATHANG.SODDH AS[Số đơn đặt hàng],
				NgayDatHang AS[Ngày đặt hàng],
				NgayGiaoHang AS[Ngày giao hàng],
				KHACHHANG.MAKH AS[Mã khách hàng],
				TENKH AS[Tên khách hàng],
				Dagiao AS[Đã giao hàng],
				SUM(CTDDH.SOLUONG*DIENTHOAI.DONGIA) AS[Tổng trị giá]
				FROM DONDATHANG,KHACHHANG,CTDDH,DIENTHOAI
				WHERE DONDATHANG.MAKH = KHACHHANG.MAKH
				AND DONDATHANG.SODDH = CTDDH.SODDH
				AND CTDDH.MASP = DIENTHOAI.MASP
				GROUP BY DONDATHANG.SODDH,KHACHHANG.MAKH,NgayDatHang,NgayGiaoHang,Dagiao,KHACHHANG.TENKH
				HAVING SUM(CTDDH.SOLUONG*DIENTHOAI.DONGIA)>=@giatriMin AND SUM(CTDDH.SOLUONG*DIENTHOAI.DONGIA)<=@giatriMax
			END
		IF(@tenbang = 'CTDDH_THANHTIEN')
			BEGIN
				SELECT CTDDH.SODDH AS[Số đơn đặt hàng],
				CTDDH.MASP AS[Mã sản phẩm],
				DIENTHOAI.TENSP AS[Tên sản phẩm],
				DONDATHANG.NgayDatHang AS[Ngày Ngày đặt hàng],
				DONDATHANG.NgayGiaoHang AS[Ngày giao hàng],
				DONDATHANG.MAKH AS[Mã khách hàng],
				KHACHHANG.TENKH AS[Tên khách hàng],
				HinhthucTT AS[Hình thức thanh toán],
				SOLUONG AS[Số lượng],
				DIENTHOAI.DONGIA AS[Đơn giá],
				((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*SOLUONG) AS[Thành tiền]
				FROM CTDDH,DONDATHANG,DIENTHOAI,KHACHHANG,KHUYENMAI
				WHERE CTDDH.SODDH = DONDATHANG.SODDH
				AND DONDATHANG.MAKH = KHACHHANG.MAKH
				AND CTDDH.MASP = DIENTHOAI.MASP AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
				AND (DIENTHOAI.DONGIA*SOLUONG)>=@giatriMin AND (DIENTHOAI.DONGIA*SOLUONG)<=@giatriMax
			END
			IF(@tenbang = 'MENU_DONGIA')
					BEGIN
						SELECT Hinhanh,
						CONCAT(N'Tên sản phẩm: ',TENSP),
						CONCAT(N'Bảo hành:',BAOHANH),
						CONCAT(N'Dung lượng:',DUNGLUONG),
						CONCAT(N'Giá:',CAST(DONGIA AS bigint)),
						CONCAT(N'Khuyến mãi:',KHUYENMAI.NOIDUNG)
						FROM DIENTHOAI,KHUYENMAI
						WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM 
						AND DONGIA >=@giatriMin 
						AND DONGIA <=@giatriMax
					END
	END

RETURN 0

--

CREATE PROCEDURE [dbo].[sp_searchUser] @ma varchar(50),@mota varchar(100)

AS
	BEGIN
		SELECT USERS.ID,
		TenTK AS[Tên tài khoản],
		ROLES.Mota AS [Loại người dùng],
		MAKH AS[Mã khách hàng],
		MANV AS[Mã nhân viên]
		FROM USERS,ROLES
		WHERE TenTK LIKE '%'+@ma+'%'
		AND ROLES.Mota LIKE '%'+@mota+'%'
		AND USERS.RoleID = ROLES.ID
	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_select] @tenbang nvarchar(50)

AS
	BEGIN
		DECLARE @SQL NVARCHAR(4000) SET @SQL=''
		SET @SQL = @SQL + 'SELECT * FROM '+@tenbang
		EXEC(@SQL)
	END

RETURN 0

--

CREATE PROCEDURE [dbo].[sp_select_CTHD_MAIN] 

AS
	BEGIN
		SELECT CTHD.SOHD  AS[Số hoá đơn],
		CTHD.MASP AS[Mã sản phẩm],
		DIENTHOAI.TENSP AS[Tên sản phẩm],
		HOADON.NGAYLAPHD AS[Ngày lập HĐ],
		KHACHHANG.TENKH AS[Tên khách hàng],
		NHANVIEN.HOTEN AS[Tên nhân viên],
		SL AS[Số lượng],
		DIENTHOAI.DONGIA AS[Đơn giá],
		((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL) AS[Thành tiền]
		FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN,KHUYENMAI
		WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
		AND HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV
		AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
		ORDER BY HOADON.NGAYLAPHD DESC

	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_selectAll] @tenbang nvarchar(50)

AS
	BEGIN
		IF(@tenbang = 'KHUYENMAI')
			BEGIN
				SELECT MAKM AS [Mã khuyến mãi],
				NOIDUNG AS[Nội dung],
				LOAIKHUYENMAI AS[Phân loại],
				GIAMGIA AS[Giảm giá] 
				FROM KHUYENMAI
			END
		IF(@tenbang = 'KHUYENMAI_MAIN')
			BEGIN
				SELECT NOIDUNG AS[Nội dung]
				FROM KHUYENMAI
				WHERE NOIDUNG != N'Chưa có chương trình' 
			END
		IF(@tenbang = 'DT_HD')
			SELECT * FROM DIENTHOAI
		IF(@tenbang = 'DIENTHOAI')
			BEGIN
				SELECT CONCAT(DIENTHOAI.MASP,'-',MAU.MAMAU) AS [Mã điện thoại],				
				CONCAT(TENSP,' - ',MAU.TENMAU) AS[Dòng điện thoại],
				BAOHANH AS[Bảo hành],
				DUNGLUONG AS[Dung lượng],
				XUATSU AS[Xuất xứ],
				MAU.TENMAU AS[Tên màu],
				CHITIET AS[Cấu hình],
				CASE WHEN TRANGTHAI = 'true' THEN N'Còn hàng' ELSE N'Hết hàng' END AS[Trạng thái],
				CONCAT(CAST(DONGIA AS bigint),N'VNĐ') AS[Đơn giá bán],
				DIENTHOAI.MAKM AS[Mã khuyến mãi],
				KHUYENMAI.NOIDUNG AS[Nội dung],
				MAKHO AS[Mã kho],
				Hinhanh AS[Hình ảnh],
				CTMAU.MAMAU
				FROM DIENTHOAI,KHUYENMAI,MAU,CTMAU
				WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
				AND DIENTHOAI.MASP = CTMAU.MASP
				AND CTMAU.MAMAU = MAU.MAMAU
				ORDER BY DIENTHOAI.MASP ASC
			END
		IF(@tenbang = 'DIENTHOAI_2')
			BEGIN
				SELECT CONCAT(DIENTHOAI.MASP,'-',MAU.MAMAU) AS [Mã điện thoại],					
				CONCAT(TENSP,' - ',MAU.TENMAU) AS[Dòng điện thoại],
				BAOHANH AS[Bảo hành],
				DUNGLUONG AS[Dung lượng],
				XUATSU AS[Xuất xứ],
				MAU.TENMAU AS[Tên màu],
				CHITIET AS[Cấu hình],
				CASE WHEN TRANGTHAI = 'true' THEN N'Còn hàng' ELSE N'Hết hàng' END AS[Trạng thái],
				CONCAT(CAST(DONGIA AS bigint),N'VNĐ') AS[Đơn giá bán],
				DIENTHOAI.MAKM AS[Mã khuyến mãi],
				KHUYENMAI.NOIDUNG AS[Nội dung],
				MAKHO AS[Mã kho]
				FROM DIENTHOAI,KHUYENMAI,MAU,CTMAU
				WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
				AND DIENTHOAI.MASP = CTMAU.MASP
				AND CTMAU.MAMAU = MAU.MAMAU
				ORDER BY DIENTHOAI.MASP ASC
			END
		IF(@tenbang = 'KHACHHANG')
			BEGIN
				SELECT KHACHHANG.MAKH AS[Mã khách hàng],
				TENKH AS[Họ tên KH],
				DIACHI AS[Địa chỉ],
				SODT AS[Số đt],
				LOAIKH AS[Loại KH]
				FROM KHACHHANG
			END
		IF(@tenbang = 'NHANVIEN')
			BEGIN
			
				SELECT MANV AS[Mã nhân viên],
				HOTEN AS[Họ tên NV],
				SODT AS[Số đt],
				CONVERT(VARCHAR(10),NGVL,103) AS[Ngày vào làm],
				DIACHI AS[Địa chỉ],
				CONVERT(int,ROUND(DATEDIFF(DAY,Ngaysinh,GETDATE())/365.25,0)) AS[Tuổi],
				CONVERT(VARCHAR(10),Ngaysinh,103) AS[Ngày sinh],
				CASE WHEN Gt = 'true' THEN N'Nam' ELSE N'Nữ' END AS[Giới tính],
				Chucvu AS[Chức vụ]
				FROM NHANVIEN
			END
		IF(@tenbang = 'KHO')
			BEGIN
				SELECT KHO.MAKHO AS[Mã kho],
				SUM(PHIEUNHAP.SOLUONG) AS[Tổng số lượng] 
				FROM KHO,PHIEUNHAP
				WHERE KHO.MAKHO = PHIEUNHAP.MAKHO
				GROUP BY KHO.MAKHO
			END
		IF(@tenbang = 'KHO_MAKHO')
			BEGIN
				SELECT KHO.MAKHO AS[Mã kho]
				FROM KHO
			END
		IF(@tenbang = 'MAU')
			BEGIN
				SELECT * 
				FROM MAU
			END
		IF(@tenbang = 'PHIEUNHAP')
			BEGIN
				SELECT MAPHIEUNHAP AS[Mã phiếu nhập],
				TENNCC AS[Tên nhà cung cấp],
				SOLUONG AS[Số lượng],
				CONVERT(Varchar(12),NGAYLAP,103) AS[Ngày lập],
				CONVERT(Varchar(12),NGAYGIAO,103) AS[Ngày giao],
				MAKHO AS[Mã kho]
				FROM PHIEUNHAP,NHACUNGCAP
				WHERE PHIEUNHAP.MANCC = NHACUNGCAP.MANCC
			END
		IF(@tenbang = 'NHACUNGCAP')
			BEGIN
				SELECT MANCC AS[Mã nhà cung cấp],
				TENNCC AS[Nhà cung cấp],
				DIACHI AS[Địa chỉ]
				FROM NHACUNGCAP				
			END
		IF(@tenbang = 'HOADON')
			BEGIN
				SELECT HOADON.SOHD AS[Số hoá đơn],
				CONVERT(Varchar(12),NGAYLAPHD,103) AS[Ngày lập HĐ],
				KHACHHANG.MAKH AS[Mã khách hàng],
				KHACHHANG.TENKH AS[Tên khách hàng],
				NHANVIEN.MANV AS[Mã nhân viên],
				NHANVIEN.HOTEN AS[Tên nhân viên],
				CONCAT(CAST(SUM(CTHD.SL*DIENTHOAI.DONGIA)AS bigint),N'VNĐ') AS [Trị giá]
				FROM HOADON,KHACHHANG,NHANVIEN,CTHD,DIENTHOAI
				WHERE HOADON.MAKH = KHACHHANG.MAKH 
				AND HOADON.MANV = NHANVIEN.MANV
				AND HOADON.SOHD = CTHD.SOHD
				AND CTHD.MASP = DIENTHOAI.MASP
				GROUP BY HOADON.SOHD,NGAYLAPHD,KHACHHANG.MAKH,KHACHHANG.TENKH,NHANVIEN.MANV,NHANVIEN.HOTEN
			END
		IF(@tenbang = 'CTHD')
			BEGIN
				SELECT CTHD.SOHD  AS[Số hoá đơn],
				CTHD.MASP AS[Mã sản phẩm],
				DIENTHOAI.TENSP AS[Tên sản phẩm],
				CONVERT(Varchar(12),HOADON.NGAYLAPHD,103) AS[Ngày lập HĐ],
				KHACHHANG.TENKH AS[Tên khách hàng],
				NHANVIEN.HOTEN AS[Tên nhân viên],
				SL AS[Số lượng],
				CONCAT(CAST(DIENTHOAI.DONGIA AS bigint),N'VNĐ') AS[Đơn giá],
				CONCAT(CAST(((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*CTHD.SL)AS bigint),N'VNĐ') AS[Thành tiền]
				FROM CTHD,DIENTHOAI,HOADON,KHACHHANG,NHANVIEN,KHUYENMAI
				WHERE CTHD.MASP = DIENTHOAI.MASP AND CTHD.SOHD = HOADON.SOHD
				AND HOADON.MAKH = KHACHHANG.MAKH 
				AND HOADON.MANV = NHANVIEN.MANV
				AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
			END
		IF(@tenbang = 'DDH')
			BEGIN
				SELECT DONDATHANG.SODDH AS[Số đơn đặt hàng],
				CONVERT(VARCHAR(12),DONDATHANG.NgayDatHang,103) AS[Ngày đặt hàng],
				CONVERT(VARCHAR(12),DONDATHANG.NgayGiaoHang,103) AS[Ngày giao hàng],
				KHACHHANG.MAKH AS[Mã khách hàng],
				TENKH AS[Tên khách hàng],
				CASE WHEN Dagiao = 'true' Then N'Đã giao hàng' ELSE N'Chưa giao hàng' END AS[Đã giao hàng],
				CONCAT(CAST(SUM(CTDDH.SOLUONG*DIENTHOAI.DONGIA)AS bigint),N'VNĐ') AS[Tổng trị giá]
				FROM DONDATHANG,KHACHHANG,CTDDH,DIENTHOAI
				WHERE DONDATHANG.MAKH = KHACHHANG.MAKH
				AND DONDATHANG.SODDH = CTDDH.SODDH
				AND CTDDH.MASP = DIENTHOAI.MASP
				GROUP BY DONDATHANG.SODDH,KHACHHANG.MAKH,NgayDatHang,NgayGiaoHang,Dagiao,KHACHHANG.TENKH
			END
		IF(@tenbang = 'CTDDH')
			BEGIN
				SELECT CTDDH.SODDH AS[Số đơn đặt hàng],
				CTDDH.MASP AS[Mã sản phẩm],
				DIENTHOAI.TENSP AS[Tên sản phẩm],
				CONVERT(VARCHAR(12),DONDATHANG.NgayDatHang,103) AS[Ngày đặt hàng],
				CONVERT(VARCHAR(12),DONDATHANG.NgayGiaoHang,103) AS[Ngày giao hàng],
				DONDATHANG.MAKH AS[Mã khách hàng],
				KHACHHANG.TENKH AS[Tên khách hàng],
				HinhthucTT AS[Hình thức thanh toán],
				SOLUONG AS[Số lượng],
				CONCAT(CAST((DIENTHOAI.DONGIA) AS Bigint),N'VNĐ') AS[Đơn giá],
				CONCAT(CAST(((DIENTHOAI.DONGIA-KHUYENMAI.GIAMGIA)*SOLUONG)AS bigint),N'VNĐ') AS[Thành tiền]
				FROM CTDDH,DONDATHANG,DIENTHOAI,KHACHHANG,KHUYENMAI
				WHERE CTDDH.SODDH = DONDATHANG.SODDH
				AND DONDATHANG.MAKH = KHACHHANG.MAKH
				AND CTDDH.MASP = DIENTHOAI.MASP
				AND DIENTHOAI.MAKM = KHUYENMAI.MAKM
			END
		IF(@tenbang = 'QUANGCAO')
			BEGIN
				SELECT IDQC AS[Mã công ty],
				TENCTY AS[Tên công ty],
				thamkhao AS[Đường dẫn tham khảo],
				ngaybatdau AS[Ngày bắt đầu],
				ngayketthuc AS[Ngày kết thúc],
				hethan AS[Hết hạn],
				Hinhanh AS[Hình ảnh]
				FROM ADS
			END
		IF(@tenbang = 'DIENTHOAI_MENU')
			BEGIN
				SELECT Hinhanh,
				CONCAT(N'Tên sản phẩm: ',TENSP),
				CONCAT(N'Bảo hành:',BAOHANH),
				CONCAT(N'Dung lượng:',DUNGLUONG),
				CONCAT(N'Giá:',CAST(DONGIA AS bigint)),
				CONCAT(N'Khuyến mãi:',KHUYENMAI.NOIDUNG),
				MASP
				FROM DIENTHOAI,KHUYENMAI
				WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
			END
		IF(@tenbang = 'DIENTHOAI_MENU_ASC')
			BEGIN
				SELECT Hinhanh,
				CONCAT(N'Tên sản phẩm: ',TENSP),
				CONCAT(N'Bảo hành:',BAOHANH),
				CONCAT(N'Dung lượng:',DUNGLUONG),
				CONCAT(N'Giá:',CAST(DONGIA AS bigint)),
				CONCAT(N'Khuyến mãi:',KHUYENMAI.NOIDUNG),
				MASP
				FROM DIENTHOAI,KHUYENMAI
				WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
				ORDER BY DONGIA ASC
			END		
		IF(@tenbang = 'DIENTHOAI_MENU_DESC')
			BEGIN
				SELECT Hinhanh,
				CONCAT(N'Tên sản phẩm: ',TENSP),
				CONCAT(N'Bảo hành:',BAOHANH),
				CONCAT(N'Dung lượng:',DUNGLUONG),
				CONCAT(N'Giá:',CAST(DONGIA AS bigint)),
				CONCAT(N'Khuyến mãi:',KHUYENMAI.NOIDUNG),
				MASP
				FROM DIENTHOAI,KHUYENMAI
				WHERE DIENTHOAI.MAKM = KHUYENMAI.MAKM
				ORDER BY DONGIA DESC
			END	
	END
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_selectHD] @makh varchar(30)

AS
	SELECT SOHD FROM HOADON WHERE MAKH = @makh
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_selectImgADS]

AS
		SELECT thamkhao,Hinhanh FROM ADS
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_selectKho_tongSL] 

AS
		SELECT SUM(PHIEUNHAP.SOLUONG)
		FROM KHO,PHIEUNHAP
		WHERE KHO.MAKHO = PHIEUNHAP.MAKHO
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_selectUser] @roleid int

AS
	SELECT USERS.ID,
	TenTK AS[Tên tài khoản],
	ROLES.Mota AS [Loại người dùng],
	CASE WHEN MAKH IS NULL THEN '***' ELSE MAKH END AS[Mã khách hàng],
	CASE WHEN MANV IS NULL THEN '***' ELSE MANV END AS[Mã nhân viên]
	FROM USERS,ROLES
	WHERE RoleID = @roleid
	AND USERS.RoleID = ROLES.ID
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_UpdateAdminToUser] @tentk nvarchar(150),@makh varchar(30)

AS
	UPDATE USERS SET RoleID = 2,MAKH = @makh,MANV = null WHERE TenTK = @tentk
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_updateMota] @tentk varchar(50),@roleid int,@manv varchar(30)

AS
	UPDATE USERS SET RoleID = @roleid,MAKH = null,MANV = @manv WHERE TenTK = @tentk
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_updateRoleIdAdminToUser] @tentk varchar(50),@roleid int,@makh varchar(30)

AS
	UPDATE USERS SET RoleID = @roleid,MAKH = @makh,MANV = null WHERE TenTK = @tentk
RETURN 0

--

CREATE PROCEDURE [dbo].[sp_User]@store varchar(50),@tentk nvarchar(150),@matkhau varchar(50),@roleid int,@makh varchar(30)

AS
	BEGIN
	IF(@store = 'INSERT')
		BEGIN
			INSERT INTO USERS(TenTK,MatKhau,RoleID,MAKH,MANV) VALUES(@tentk,@matkhau,@roleid,@makh,null);
		END
	IF(@store = 'UPDATE')
		BEGIN
			UPDATE USERS SET MatKhau = @matkhau , RoleID = @roleid WHERE TenTK = @tentk
		END
	END
RETURN 0