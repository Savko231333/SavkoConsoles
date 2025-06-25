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
            StateIn stateIn = new StateIn();
            StateOut stateOut = new StateOut();

            xmlReader.MoveToContent();

            if (xmlReader.Name != "State")
                throw new ArgumentException("Неверный тип файла");

            string? statename = xmlReader.GetAttribute("Name");

            if (!string.IsNullOrEmpty(statename))
            {
                System.Console.WriteLine("Успешная загрузка названия");
            }
            else
            {
                System.Console.WriteLine("Ошибка при загрузке атрибутов названия");
                state = null;
                return false;
            }

            do
            {
                if (!xmlReader.Read())
                    throw new ArgumentException("Ошибочка");

                if (xmlReader.NodeType == XmlNodeType.EndElement
                    && xmlReader.Name == "State")
                {
                    break;
                }

                if (xmlReader.NodeType == XmlNodeType.EndElement)
                    continue;

                if (xmlReader.Name == "Out")
                {
                    string? message = xmlReader.GetAttribute("Message");
                    if (!String.IsNullOrEmpty(message))
                    {
                        System.Console.WriteLine("Успешная загрузка атрибутов Message класса StateOut");
                    }
                    else
                    {
                        System.Console.WriteLine("Ошибка при загрузке атрибутов Message класса StateOut");
                        state = null;
                        return false;
                    }

                    if (bool.TryParse(xmlReader.GetAttribute("SkipLine"), out bool skipline))
                    {
                        System.Console.WriteLine("Успешная загрузка атрибутов SkipLine класса StateOut");
                    }
                    else
                    {
                        System.Console.WriteLine("Ошибка при загрузке атрибутов SkipLine класса StateOut");
                        state = null;
                        return false;
                    }
                    stateOut = new StateOut(message, skipline);
                }
                if (xmlReader.Name == "In")
                {
                    string? message = xmlReader.GetAttribute("Message");
                    if (!string.IsNullOrEmpty(message))
                    {
                        System.Console.WriteLine("Успешная загрузка атрибутов Message класса StateIn");
                    }
                    else
                    {
                        System.Console.WriteLine("Ошибка при загрузке атрибутов Message класса StateIn");
                        Thread.Sleep(5000);
                        state = null;
                        return false;
                    }
                    bool skipline;
                    if (Boolean.TryParse(xmlReader.GetAttribute("SkipLine"), out skipline))
                    {
                        System.Console.WriteLine("Успешная загрузка атрибутов SkipLine класса StateIn");
                    }
                    else
                    {
                        System.Console.WriteLine("Ошибка при загрузке атрибутов SkipLine класса StateIn");
                        Thread.Sleep(5000);
                        state = null;
                        return false;
                    }
                    stateIn = new StateIn(message, skipline);
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
            state = new State(statename, stateOut, stateIn);
            return true;
        }
    }
}
