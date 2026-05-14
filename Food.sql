-- Thêm dữ liệu món ăn Hàn Quốc vào bảng dbo.Foods
INSERT INTO dbo.Categories (TenDanhMuc)
VALUES (N'Món cơm'), (N'Món mì'), (N'Món nướng'), (N'Món canh') , (N'Món chiên');
go
INSERT INTO dbo.Foods (TenMon, Gia, DanhMucId, HinhAnh, TrangThai)
VALUES 
(N'Cơm Trộn Bibimbap', 85000.00, 1, 'bibimbap.jpg', 1),
(N'Bánh Gạo Cay Tteokbokki', 55000.00, 2, 'tteokbokki.jpg', 1),
(N'Thịt Nướng BBQ Hàn Quốc', 25000.00, 3, 'korean_bbq.jpg', 1),
(N'Mì Tương Đen Jajangmyeon', 75000.00, 2, 'jajangmyeon.jpg', 1),
(N'Canh Kim Chi Đậu Phụ', 65000.00, 4, 'kimchi_soup.jpg', 1),
(N'Gà Rán Sốt Cay', 120000.00, 3, 'korean_fried_chicken.jpg', 1),
(N'Cơm Cuộn Kimbap', 45000.00, 1, 'kimbap.jpg', 1);