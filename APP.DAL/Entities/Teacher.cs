using System;
using System.Collections.Generic;

namespace APP.DAL.Entities;

public partial class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<AllocateClassRoom> AllocateClassRooms { get; set; } = new List<AllocateClassRoom>();

    public virtual ICollection<AllocateSubject> AllocateSubjects { get; set; } = new List<AllocateSubject>();
}
