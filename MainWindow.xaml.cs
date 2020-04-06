using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Reflection;
using System.Windows.Shapes;
using Graphika.Shapes;
using Graphika.Data;

namespace Graphika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Список объектов, сохраняемых в файл
        private FigureList figureList;

        // Список объектов, доступных для рисования
        private List<string> figureModeList = new List<string>() { "Ellipse", "Rectangle", "Line"};

        // Вспомогательный объект сериализации/десериализации.
        private DataIO dataIO;

        // Путь к файлу (процесс сериализации).
        private readonly string PATH = $"{Environment.CurrentDirectory}\\Data.xaml";

        public MainWindow()
        {
            InitializeComponent();
            ClrPcker_Background.SelectedColor = Colors.Black;
            FigureComboList.ItemsSource = figureModeList;
            FigureComboList.SelectedIndex = 0;
        }

        private void CreateShape(object sender, RoutedEventArgs e)
        {
            try
            {
                string chosenFigureMode = (string)FigureComboList.SelectedItem;
                chosenFigureMode = "Graphika.Shapes." + chosenFigureMode + "Figure";
                Type type = Type.GetType(chosenFigureMode);

                Object newFigure = Activator.CreateInstance(type);

                int X1 = Convert.ToInt32(X1Edit.Text);
                int X2 = Convert.ToInt32(X2Edit.Text);
                int Y1 = Convert.ToInt32(Y1Edit.Text);
                int Y2 = Convert.ToInt32(Y2Edit.Text);
          
                // Объект, вносимый в список
                Object newFigureShape = new Object();
                MethodInfo method = type.GetMethod("DrawShape");
                // Создание выбранного объекта
                newFigureShape = method.Invoke(newFigure, new Object[] { X1, Y1, X2, Y2 });

                Color color = (Color)ColorConverter.ConvertFromString(ClrPcker_Background.SelectedColorText);
                SolidColorBrush brush = new SolidColorBrush(color);

                // Работа со свойствами созданной фигуры.
                type = Type.GetType("System.Windows.Shapes.Shape, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"); 

                PropertyInfo prop = type.GetProperty("Fill");        
                prop.SetValue(newFigureShape, brush);

                prop = type.GetProperty("Stroke");
                prop.SetValue(newFigureShape, brush);

                figureList.ObjectList.Add((Shape)newFigureShape);
                FigureField.Children.Add((Shape)newFigureShape);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataIO = new DataIO(PATH);
            figureList = new FigureList();
            figureList.ObjectList = new List<Shape>();
            try
            {
                figureList.ObjectList = dataIO.LoadData();
                if (!(figureList.ObjectList.Count == 0))
                {
                    foreach (Shape obj in figureList.ObjectList)
                    {
                        FigureField.Children.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closed(object sender, EventArgs e) 
        {
            try
            {
                figureList.ObjectList.Clear();
                foreach (Shape obj in FigureField.Children)
                {
                    figureList.ObjectList.Add(obj);
                }

                dataIO.SaveData(figureList);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                Close();
            }
        }
    }

}
