﻿using System;
using System.Collections.Generic;

namespace APP.DAL.Entities;

public partial class AllocateSubject
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
