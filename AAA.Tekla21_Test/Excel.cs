using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace AAA.Plugin.Supports
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }
        
        public string ReadCell(int r, int c)
        {
            r++;
            c++;
            if (ws.Cells[r,c].Value2 != null)
                {
                string res = ws.Cells[r, c].Value2.ToString();
                return res;
                }
            else
            {
                return "";
            }
        }
    }
}
