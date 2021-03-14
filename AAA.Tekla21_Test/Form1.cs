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
    public partial class f_Main : Form
    {
        TSM.Model model; //Глобальная переменная модели.
        public f_Main()
        {
            InitializeComponent(); //Инициализация формы.
        }
        private bool InitializeConnection()
        {
            TSM.Model _model = new TSM.Model(); //Создаем переменную локальной модели.
            if(_model.GetConnectionStatus()) //Проверка подключения.
            {
                model = _model; // Передаем локальную модель, глобальной.
                return true;
            }
            else
            {
                return false;
            }
        }
        private void f_Main_Load(object sender, EventArgs e) //Момент загрузки формы.
        {
            if(!InitializeConnection()) //Проверяем подключение.
            {
                MessageBox.Show("Нет подключения"); //Если InitializeConnection true  то выдаем сообщение "Нет подключения" и закрываем программу.
                this.Close();
            }
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            Excel excel = new Excel(fileName, 1);
            string result = excel.ReadCell(7, 7);
        }
        private void b_Create_Click(object sender, EventArgs e) // При нажатии кнопки создать вызывается метод построения пользовательского компанента.
        {
            DialogResult res = openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            Excel excel = new Excel(fileName, 1);
            Supports support = new Supports(); //Инициализируем экземпляр класса.
            int count = 0;//Щетчик для циклла.
            int step = 0;//Шаг по Х.
            for (int i = 0; excel.ReadCell(i,1) != ""; i++) //Выполнять пока i,1 ячейка не станет пустой.
            {
                string profile = excel.ReadCell(i, 5) ; //Обращение к столбику с профилем.
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
                if(Y1 == 6000)
                {
                    step += 2000;
                }
                if(Y1 == 6000)
                {
                    count = 0;
                }
                int Z1 = 0; // Констаната.
                int Z2 = 0;
                count++;
                support.TR31(A, B, C, material, profile, X1, Y1, Z1, X2, Y2, Z2); //Функция принимающая все параметры.

                model.CommitChanges();//Применить изминения.

            }
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
