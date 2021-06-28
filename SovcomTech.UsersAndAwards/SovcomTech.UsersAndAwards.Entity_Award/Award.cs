using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovcomTech.UsersAndAwards.Entity_Award
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Award() { }

        public Award(string title)
        {
            this.Title = title;
        }
        public override string ToString()
        {
            return $"{Id} {Title}";
        }
    }
}
