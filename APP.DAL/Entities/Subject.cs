using System;
using System.Collections.Generic;

namespace APP.DAL.Entities;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AllocateSubject> AllocateSubjects { get; set; } = new List<AllocateSubject>();
}
