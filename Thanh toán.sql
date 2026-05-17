CREATE PROCEDURE sp_ThanhToanHoaDon
    @MaBan INT,
    @TongTien FLOAT -- Nếu bạn muốn lưu lại tổng tiền lúc thanh toán
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Cập nhật trạng thái Hóa đơn của bàn đó thành Đã thanh toán (Trạng thái = 1)
        UPDATE HoaDon
        SET TrangThai = 1, 
            NgayThanhToan = GETDATE(),
            TongTien = @TongTien
        WHERE MaBan = @MaBan AND TrangThai = 0; -- Chỉ cập nhật hóa đơn chưa thanh toán của bàn đó

        -- 2. Cập nhật trạng thái Bàn thành trống (Trạng thái = 0 hoặc 'Trống')
        UPDATE Ban
        SET TrangThai = 0 
        WHERE MaBan = @MaBan;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END