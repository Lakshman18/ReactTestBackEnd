using System;
using System.Collections.Generic;

namespace APP.BLL.Models;

public partial class StudentModel
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public int? Age { get; set; }

    public int? ClassRoomId { get; set; }

    ////public ClassRoomModel? ClassRoom { get; set; }
}
