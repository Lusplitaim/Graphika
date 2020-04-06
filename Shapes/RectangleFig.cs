using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Graphika.Shapes
{
    class RectangleFigure: Figure
    {
        public override Shape DrawShape(int X1, int Y1, int X2, int Y2)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = Math.Abs(Y2 - Y1);
            rectangle.Width = Math.Abs(X2 - X1);

            return rectangle;
        }
    }
}
