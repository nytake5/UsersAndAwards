using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_User
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public User()
        {}

        public User(string name, DateTime date, int age)
        {
            this.Name = name;
            this.DateOfBirth = date;
            this.Age = age;
        }
        public override string ToString()
        {
            return $"{Id} {Name} {DateOfBirth.ToShortDateString()} {Age}";
        }

    }
}
