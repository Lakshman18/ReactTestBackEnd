using System;
using System.Collections.Generic;

namespace APP.BLL.Models;

public partial class ClassRoomModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    //public ICollection<StudentModel> Students { get; set; } = new List<StudentModel>();
}
