using System;
using System.Collections.Generic;

namespace QL_LKMT.Models;

public partial class Sanpham
{
    public string IdSanpham { get; set; } = null!;

    public string Tensanpham { get; set; } = null!;

    public string IdLoai { get; set; } = null!;

    public decimal Gia { get; set; }

    public int IdThuonghieu { get; set; }

    public int Baohanh { get; set; }

    public int Khuyenmai { get; set; }

    public string Hinh { get; set; } = null!;

    public string? Mota { get; set; }

    public DateTime Ngaytao { get; set; }

    public DateTime Ngaycapnhat { get; set; }

    public int IdThanhtoan { get; set; }

    public virtual Loaisanpham IdLoaiNavigation { get; set; } = null!;

    public virtual Thuonghieu IdThuonghieuNavigation { get; set; } = null!;

    public virtual ICollection<Phuongthucthanhtoan> Phuongthucthanhtoans { get; } = new List<Phuongthucthanhtoan>();
}
