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
        string fileName;
        public void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            string _fileName = openFileDialog1.FileName; //Локальная переменная
            fileName = _fileName;//Глобальная переменная
        }
        public void b_Create_Click(object sender, EventArgs e) // При нажатии кнопки создать вызывается метод построения пользовательского компанента.
        {
            Create support = new Create();
            support.Supports(fileName);
            model.CommitChanges();//Применить изминения.
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
