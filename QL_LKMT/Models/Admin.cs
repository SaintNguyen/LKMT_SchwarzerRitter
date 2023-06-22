using System;
using System.Collections.Generic;

namespace QL_LKMT.Models;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public string Email { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public string Sodienthoai { get; set; } = null!;
}
