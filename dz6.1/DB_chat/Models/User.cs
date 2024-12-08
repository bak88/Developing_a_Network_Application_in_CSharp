﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz6._1.DB_chat.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Message> ToMessages { get; set; } = new List<Message>();
        public virtual ICollection<Message> FromMessages { get; set; } = new List<Message>();
    }
}