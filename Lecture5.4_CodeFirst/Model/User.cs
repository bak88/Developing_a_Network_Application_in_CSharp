using Lecture5._4_CodeFirst.Model;
using System;
using System.Collections.Generic;


namespace Lecture5._4_CodeFirst
{
    public partial class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

        public GenderId GenderId { get; set; }

        public virtual Gender Gender { get; set; }
    }
}