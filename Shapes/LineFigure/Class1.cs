using System;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphika.Shapes
{
    class LineFigure : IFigure
    {
        public Shape DrawShape(int X1, int Y1, int X2, int Y2, int Addit)
        {
            Line line = new Line();
            line.StrokeThickness = Addit;

            // Четвертая четверть.
            if ((X2 >= X1) && (Y2 >= Y1))
            {
                InkCanvas.SetTop(line, Y1);
                InkCanvas.SetLeft(line, X1);
                line.X1 = 0;
                line.Y1 = 0;
                line.X2 = Math.Abs(X2 - X1);
                line.Y2 = Math.Abs(Y2 - Y1);
            }
            // Первая четверть.
            if (((X2 - X1) >= 0) && ((Y2 - Y1) < 0))
            {
                InkCanvas.SetTop(line, Y2);
                InkCanvas.SetLeft(line, X1);
                Y1 -= Y2;
                X2 -= X1;
                line.X1 = 0;
                line.Y1 = Y1;
                line.X2 = X2;
                line.Y2 = 0;
            }
            // Вторая четверть.
            if (((X2 - X1) < 0) && ((Y2 - Y1) < 0))
            {
                int tmp = X1;
                X1 = X2;
                X2 = tmp;
                tmp = Y1;
                Y1 = Y2;
                Y2 = tmp;
                InkCanvas.SetTop(line, Y1);
                InkCanvas.SetLeft(line, X1);
                line.X1 = 0;
                line.Y1 = 0;
                line.X2 = Math.Abs(X2 - X1);
                line.Y2 = Math.Abs(Y2 - Y1);
            }
            // Третья четверть.
            if (((X2 - X1) < 0) && ((Y2 - Y1) >= 0))
            {
                InkCanvas.SetTop(line, Y1);
                InkCanvas.SetLeft(line, X2);
                X1 -= X2;
                Y2 -= Y1;
                line.X1 = X1;
                line.Y1 = 0;
                line.X2 = 0;
                line.Y2 = Y2;
            }

            return line;
        }
    }
}
