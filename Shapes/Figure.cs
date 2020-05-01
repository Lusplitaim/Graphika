using System.Windows.Shapes;

namespace Graphika.Shapes
{
    abstract class Figure
    {
        public abstract Shape DrawShape(int X1, int Y1, int X2, int Y2, int Addit);
    }
}
