using System;
using System.Collections.Generic;

// Lop cha: Product
public class Product
{
    public string TenSanPham { get; set; }
    public decimal Gia { get; set; }
    public string MoTa { get; set; }
    public int SoLuong { get; set; }

    public Product(string tenSanPham, decimal gia, string moTa, int soLuong)
    {
        TenSanPham = tenSanPham;
        Gia = gia;
        MoTa = moTa;
        SoLuong = soLuong;
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Ten san pham: {TenSanPham}, Gia: {Gia}, Mo ta: {MoTa}, So luong: {SoLuong}");
    }
}

// Lop con: Electronic
public class Electronic : Product
{
    public int BaoHanhThang { get; set; }

    public Electronic(string tenSanPham, decimal gia, string moTa, int soLuong, int baoHanhThang)
        : base(tenSanPham, gia, moTa, soLuong)
    {
        BaoHanhThang = baoHanhThang;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Bao hanh: {BaoHanhThang} thang");
    }
}

// Lop con: Clothing
public class Clothing : Product
{
    public string KichThuoc { get; set; }
    public string MauSac { get; set; }

    public Clothing(string tenSanPham, decimal gia, string moTa, int soLuong, string kichThuoc, string mauSac)
        : base(tenSanPham, gia, moTa, soLuong)
    {
        KichThuoc = kichThuoc;
        MauSac = mauSac;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Kich thuoc: {KichThuoc}, Mau sac: {MauSac}");
    }
}

// Lop con: Food
public class Food : Product
{
    public DateTime NgayHetHan { get; set; }

    public Food(string tenSanPham, decimal gia, string moTa, int soLuong, DateTime ngayHetHan)
        : base(tenSanPham, gia, moTa, soLuong)
    {
        NgayHetHan = ngayHetHan;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Ngay het han: {NgayHetHan.ToShortDateString()}");
    }
}

// Lop gio hang: ShoppingCart
public class ShoppingCart
{
    public List<Product> DanhSachSanPham { get; set; }

    public ShoppingCart()
    {
        DanhSachSanPham = new List<Product>();
    }

    public void ThemSanPham(Product sanPham)
    {
        DanhSachSanPham.Add(sanPham);
    }

    public void XoaSanPham(Product sanPham)
    {
        DanhSachSanPham.Remove(sanPham);
    }

    public decimal TinhTongGiaTri()
    {
        decimal tongGiaTri = 0;
        foreach (var sanPham in DanhSachSanPham)
        {
            tongGiaTri += sanPham.Gia * sanPham.SoLuong;
        }
        return tongGiaTri;
    }

    public void HienThiGioHang()
    {
        foreach (var sanPham in DanhSachSanPham)
        {
            sanPham.HienThiThongTin();
        }
    }
}

// Chuong trinh chinh
public class Program
{
    public static void Main(string[] args)
    {
        // Tao mot so san pham mau
        var laptop = new Electronic("Laptop", 1500, "Laptop hieu suat cao", 1, 24);
        var ao = new Clothing("Ao", 50, "Ao cotton", 2, "L", "Xanh");
        var tao = new Food("Tao", 1, "Tao tuoi", 10, DateTime.Now.AddDays(7));

        // Tao gio hang va them san pham vao gio
        var gioHang = new ShoppingCart();
        gioHang.ThemSanPham(laptop);
        gioHang.ThemSanPham(ao);
        gioHang.ThemSanPham(tao);

        // Hien thi danh sach san pham trong gio hang
        Console.WriteLine("Cac san pham trong gio hang:");
        gioHang.HienThiGioHang();

        // Tinh tong gia tri don hang
        Console.WriteLine($"Tong gia tri: {gioHang.TinhTongGiaTri()}");
    }
}
