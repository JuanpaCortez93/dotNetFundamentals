using System;
using System.Collections.Generic;

namespace _001_Basics.Models;

public partial class RefreshTokenHistorial
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Token { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual User? User { get; set; }
}
