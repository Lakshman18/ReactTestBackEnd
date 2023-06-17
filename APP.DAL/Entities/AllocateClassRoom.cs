using System;
using System.Collections.Generic;

namespace APP.DAL.Entities;

public partial class AllocateClassRoom
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int ClassRoomId { get; set; }

    public virtual ClassRoom ClassRoom { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
