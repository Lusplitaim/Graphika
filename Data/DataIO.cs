using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Shapes;
using System.Xml;
using System.Windows.Markup;
using Graphika.Shapes;

namespace Graphika.Data
{
    // Класс для реализации сериализации/десериализации.
    class DataIO
    {
        // Путь к файлу.
        private readonly string PATH;

        public DataIO(string path)
        {
            PATH = path;
        }

        public List<Shape> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return null;
            }
            List<Shape> readerLoad = new List<Shape>();
            using (var stream = File.OpenText(PATH))
            {
                while (!(stream.EndOfStream))
                {
                    StringReader stringReader = new StringReader(stream.ReadLine());
                    XmlReader xmlReader = XmlReader.Create(stringReader);
                    Shape shape = (Shape)XamlReader.Load(xmlReader);
                    readerLoad.Add(shape);
                }
            }
            return readerLoad;
        }

        public void SaveData(FigureList figureList, bool append = false)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                foreach (Shape obj in figureList.ObjectList)
                {
                    string savedShape = XamlWriter.Save(obj);
                    writer.WriteLine(savedShape);
                }
            }
        }
    }
}
