using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometricCalculator.Shapes
{
    public interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
        
    }
}