using System;
using System.Collections.Generic;

namespace QL_LKMT.Models;

public partial class Phuongthucthanhtoan
{
    public int IdThanhtoan { get; set; }

    public string? Tenthanhtoan { get; set; }

    public int? IdKhachhang { get; set; }

    public string? IdSanpham { get; set; }

    public virtual Khachhang? IdKhachhangNavigation { get; set; }

    public virtual Sanpham? IdSanphamNavigation { get; set; }
}
