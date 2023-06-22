using System;
using System.Collections.Generic;

namespace QL_LKMT.Models;

public partial class Khachhang
{
    public int IdKhachhang { get; set; }

    public string? Email { get; set; }

    public string? Matkhau { get; set; }

    public string Ten { get; set; } = null!;

    public string? Sodienthoai { get; set; }

    public string? Diachi { get; set; }

    public DateTime Ngaytao { get; set; }

    public DateTime Ngaycapnhat { get; set; }

    public virtual ICollection<Phuongthucthanhtoan> Phuongthucthanhtoans { get; } = new List<Phuongthucthanhtoan>();
}
