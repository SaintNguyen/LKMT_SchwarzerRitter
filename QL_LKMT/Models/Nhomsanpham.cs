using System;
using System.Collections.Generic;

namespace QL_LKMT.Models;

public partial class Nhomsanpham
{
    public string IdNhom { get; set; } = null!;

    public string Tennhom { get; set; } = null!;

    public DateTime Ngaytao { get; set; }

    public DateTime Ngaycapnhat { get; set; }

    public virtual ICollection<Loaisanpham> Loaisanphams { get; } = new List<Loaisanpham>();

    public virtual ICollection<Thuonghieu> Thuonghieus { get; } = new List<Thuonghieu>();
}
