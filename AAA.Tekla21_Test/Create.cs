using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSM = Tekla.Structures.Model;
using TS = Tekla.Structures;
using _Excel = Microsoft.Office.Interop.Excel;

namespace AAA.Plugin.Supports
{
    class Create
    {
        TSM.Model model = new TSM.Model();
        public void Supports(string fileName)
        {
            Excel excel = new Excel(fileName, 1);
            Supports support = new Supports(); //Инициализируем экземпляр класса.
            int count = 0;//Щетчик для циклла.
            int step = 0;//Шаг по Х.
            for (int i = 0; excel.ReadCell(i, 1) != ""; i++) //Выполнять пока i,1 ячейка не станет пустой.
            {
                string type = excel.ReadCell(i, 1);
                string profile = excel.ReadCell(i, 5); //Обращение к столбику с профилем.
                int material = Int32.Parse(excel.ReadCell(i, 2)); // Обращение к столбику с классом материала.
                string a = excel.ReadCell(i, 7); //Обращение к столбику А.
                int A = Int32.Parse(a); // Приведение к int типу.
                string b = excel.ReadCell(i, 8);
                int B = Int32.Parse(b);
                string c = excel.ReadCell(i, 9);
                int C = Int32.Parse(c);
                int Y1 = 0 + (count * 500); // координата У с шагом 500 счетчик обновляется по достижению 6000.
                int Y2 = 100 + (count * 500);
                int X1 = 0 + step; // Х + шаг 2000 по достижению У 6000.
                int X2 = 0 + step;
                if (Y1 == 6000)
                {
                    step += 2000;
                }
                if (Y1 == 6000)
                {
                    count = 0;
                }
                int Z1 = 0; // Констаната.
                int Z2 = 0;
                count++;
                switch (type)
                {
                    case "TR31":
                        support.TR31(A, B, C, material, profile, X1, Y1, Z1, X2, Y2, Z2); //Функция принимающая все параметры.
                        model.CommitChanges();//Применить изминения.
                        break;
                    case "TR34":
                        support.TR34(A, B, C, material, profile, X1, Y1, Z1, X2, Y2, Z2); //Функция принимающая все параметры.
                        model.CommitChanges();//Применить изминения.
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
