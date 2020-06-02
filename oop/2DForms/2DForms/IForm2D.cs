using System;
using System.Collections.Generic;
using System.Text;

namespace _2DForms
{
    interface IForm2D
    {
        string Name { get; }
        double Area();
        double Perimeter();
    }
}
