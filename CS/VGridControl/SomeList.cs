using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E4423
{
    public class SomeList
    {
        public SomeList() { }
        public SomeList(int _number, string _name, string _something)
        {
            Number = _number;
            Name = _name;
            Something = _something;
        
        }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Something { get; set; }
    }
}
