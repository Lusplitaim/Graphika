using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Threading.Tasks;

namespace Graphika.Shapes
{
    abstract class Figure
    {
        public abstract Shape DrawShape(int X1, int Y1, int X2, int Y2);
    }
}
