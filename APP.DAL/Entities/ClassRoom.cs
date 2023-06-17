using System;
using System.Collections.Generic;

namespace APP.DAL.Entities;

public partial class ClassRoom
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AllocateClassRoom> AllocateClassRooms { get; set; } = new List<AllocateClassRoom>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
