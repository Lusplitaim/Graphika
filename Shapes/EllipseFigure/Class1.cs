using System;
using System.Windows.Shapes;

namespace Graphika.Shapes
{
    public class EllipseFigure: IFigure
    {
        public Shape DrawShape(int X1, int Y1, int X2, int Y2, int Addit)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = Math.Abs(Y2 - Y1);
            ellipse.Width = Math.Abs(X2 - X1);
            ellipse.StrokeThickness = Addit;

            return ellipse;
        }
    }
}
