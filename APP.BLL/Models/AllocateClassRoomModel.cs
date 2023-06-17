using System;
using System.Collections.Generic;

namespace APP.BLL.Models;

public partial class AllocateClassRoomModel
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int ClassRoomId { get; set; }

}
