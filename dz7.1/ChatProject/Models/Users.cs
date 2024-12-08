using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz7._1.ChatProject.Models
{
    internal class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Messages> ToMessages { get; set; }
        public virtual ICollection<Messages> FromMessages { get; set; }
    }
}
