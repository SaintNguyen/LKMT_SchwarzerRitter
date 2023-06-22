using System;
using System.Collections.Generic;

namespace QL_LKMT.Models;

public partial class Thuonghieu
{
    public int IdThuonghieu { get; set; }

    public string? IdNhom { get; set; }

    public string Tenthuonghieu { get; set; } = null!;

    public DateTime Ngaytao { get; set; }

    public DateTime Ngaycapnhat { get; set; }

    public virtual Nhomsanpham? IdNhomNavigation { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; } = new List<Sanpham>();
}
