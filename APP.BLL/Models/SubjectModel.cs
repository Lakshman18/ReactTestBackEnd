using APP.DAL.Entities;
using System;
using System.Collections.Generic;

namespace APP.BLL.Models;

public partial class SubjectModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
     public  ICollection<AllocateSubjectModel> AllocateSubjects { get; set; } = new List<AllocateSubjectModel>();
}
