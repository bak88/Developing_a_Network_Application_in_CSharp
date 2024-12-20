﻿using System;
using System.Collections.Generic;

namespace Lecture5._3.Model;

public partial class Message
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Message1 { get; set; } = null!;

    public virtual User? User { get; set; }
}
