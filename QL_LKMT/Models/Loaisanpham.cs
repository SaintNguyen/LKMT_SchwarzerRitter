using System;
using System.Collections.Generic;

namespace QL_LKMT.Models;

public partial class Loaisanpham
{
    public string IdLoai { get; set; } = null!;

    public string IdNhom { get; set; } = null!;

    public string Tenloai { get; set; } = null!;

    public DateTime Ngaytao { get; set; }

    public DateTime Ngaycapnhat { get; set; }

    public virtual Nhomsanpham IdNhomNavigation { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; } = new List<Sanpham>();
}
