using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public int? UserRolesUserId { get; set; }

    public int? UserRolesUserIdroleId { get; set; }

    public virtual User? UserRolesUser { get; set; }

    public virtual Role? UserRolesUserIdrole { get; set; }
}
