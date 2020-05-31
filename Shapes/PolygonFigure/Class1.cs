using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Graphika.Shapes
{
    class PolygonFigure : IFigure
    {
        public Shape DrawShape(int X1, int Y1, int X2, int Y2, int Addit)
        {
            // Значение параметра Addit по умолчанию.
            int AdditDefaul = 100;
            if (Addit == 0)
            {
                System.Windows.MessageBox.Show("Параметр Addit должен быть больше нуля." +
                    " Параметру присвоено значение " + AdditDefaul + ".");
                Addit = AdditDefaul;
            }

            var polygon = new Polygon();

            PointCollection pointList = new PointCollection();
            Point point = new Point(X1, 0);
            pointList.Add(point);
            point = new Point(Y1, 0);
            pointList.Add(point);
            point = new Point(X2, Addit);
            pointList.Add(point);
            point = new Point(Y2, Addit);
            pointList.Add(point);

            polygon.Points = pointList;
            return polygon;
        }
    }
}
