using System;
using System.Windows.Shapes;

namespace Graphika.Shapes
{
    class RectangleFigure: Figure
    {
        public override Shape DrawShape(int X1, int Y1, int X2, int Y2, int Addit)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = Math.Abs(Y2 - Y1);
            rectangle.Width = Math.Abs(X2 - X1);
            rectangle.StrokeThickness = Addit;

            return rectangle;
        }
    }
}
