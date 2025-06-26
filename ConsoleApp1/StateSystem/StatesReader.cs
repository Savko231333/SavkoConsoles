using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1.StateSystem
{
    partial class StatesReader
    {
        public bool ReadState(string statePath, out State? state)
        {
            FileStream fileStream = new FileStream(statePath, FileMode.Open);
            XmlReader xmlReader = XmlReader.Create(fileStream);
            TextLine line = new TextLine();
            TextBox textBox = new TextBox();

            xmlReader.MoveToContent();

            if (xmlReader.Name != "State")
                throw new ArgumentException("Неверный тип файла");

            string? statename = xmlReader.GetAttribute("Name");
            string fileName = Path.GetFileName(statePath);

            if (string.IsNullOrEmpty(statename))
            {
                throw new ArgumentException($"Ошибка при загрузке атрибутов Name файла {fileName}");
            }

            do
            {
                if (!xmlReader.Read())
                    throw new ArgumentException("Не удалось прочитать файл");

                if (xmlReader.NodeType == XmlNodeType.EndElement
                    && xmlReader.Name == "State")
                {
                    break;
                }

                if (xmlReader.NodeType == XmlNodeType.EndElement)
                    continue;

                if (xmlReader.Name == "TextLine")
                {
                    string? message = xmlReader.GetAttribute("Message");

                    if (string.IsNullOrEmpty(message))
                    {
                        throw new ArgumentException($"Ошибка при загрузке атрибутов Message файла {fileName}");
                    }

                    line = new TextLine(message);
                }
                if (xmlReader.Name == "TextBox")
                {
                    string? message = xmlReader.GetAttribute("Message");

                    if (string.IsNullOrEmpty(message))
                    {
                        throw new ArgumentException($"Ошибка при загрузке атрибутов Message файла {fileName}");
                    }

                    if (!bool.TryParse(xmlReader.GetAttribute("SkipLine"), out bool skipline))
                    {
                        skipline = false;
                    }

                    textBox = new TextBox(message, skipline);
                }
            }
            while (!xmlReader.EOF);

            int i = 0;
            while (i != 10)
            {
                ++i;
                System.Console.WriteLine($"Начинаем {i}");
                Thread.Sleep(1000);
            }
            state = new State(statename, line, textBox);
            return true;
        }
    }
}
