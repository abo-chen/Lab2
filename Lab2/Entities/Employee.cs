using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    public class Employee
    {
        private string id;
        private string name;
        private string address;
        private string phone;
        private long sin;
        private string birthday;
        private string department;

        public string Id { get => id; }
        public string Name { get => name; }
        //public string Address { get => address; }
        //public string Phone { get => phone; }
        //public long Sin { get => sin; }
        //public string Birthday { get => birthday; }
        //public string Department { get => department; }
        public virtual double Pay { get { return 0; } }

        public Employee(string id, string name, string address, string phone, long sin, string birthday, string department)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthday = birthday;
            this.department = department;
        }
    }
}