using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Square: Rectangle, IPrint
    {
        public Square(double yourlength)
        {
            _length1 = _length2 = yourlength;
        }
        public override string ToString()
        {
            return "Длина стороны: " + _length1.ToString() + "; Площадь: " + area.ToString() + ";";
        }
    }
}
