using System;
using System.Collections.Generic;

namespace APP.DAL.Entities;

public partial class Student
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

    public virtual ClassRoom? ClassRoom { get; set; }
}
