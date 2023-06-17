using System;
using System.Collections.Generic;

namespace APP.BLL.Models;

public partial class TeacherModel
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Email { get; set; } = null!;
}
