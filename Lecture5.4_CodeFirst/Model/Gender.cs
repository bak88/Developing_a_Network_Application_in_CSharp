using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture5._4_CodeFirst.Model
{
    public partial class Gender
    {
        public GenderId GenderId { get; set; }

        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
