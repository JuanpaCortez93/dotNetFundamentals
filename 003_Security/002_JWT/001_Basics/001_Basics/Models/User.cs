using System;
using System.Collections.Generic;

namespace _001_Basics.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Upassword { get; set; }

    public virtual ICollection<RefreshTokenHistorial> RefreshTokenHistorials { get; set; } = new List<RefreshTokenHistorial>();
}
