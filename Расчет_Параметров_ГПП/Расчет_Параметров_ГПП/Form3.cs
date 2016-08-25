using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ExcelPS = Microsoft.Office.Interop.Excel;
//using System.Drawing.Text;
//using MyFont = System.Drawing.Font;

namespace Расчет_Параметров_ГПП
{
    public partial class Help_Form : Form
    {

        //MyFont myFont;
        public Help_Form()
        {
           InitializeComponent();
          /* FontLoad();
           textBox1.Font = myFont;
           richTextBox1.Font = myFont;*/
        }


       /* //Загрузка шрифта
        private void FontLoad()
        {
            PrivateFontCollection custom_font = new PrivateFontCollection();
            custom_font.AddFontFile("Micra-Normal_.ttf");
            myFont = new MyFont(custom_font.Families[0], 7);
        }*/


        //Метод для экспорта в EXCEL
        private void ExportToExcel()
        {
            ExcelPS.Application exApp = new ExcelPS.Application();
            exApp.Workbooks.Add();
            exApp.Visible = true;
            Worksheet workSheet = (Worksheet)exApp.ActiveSheet;

            workSheet.Cells[1, 1] = "Технологические возможности";
            workSheet.Cells[1, 2] = "Типовые";
            workSheet.Cells[1, 3] = "Усложненные";

            int rowExcel = 2;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                workSheet.Cells[rowExcel, "A"] = dataGridView1.Rows[i].Cells["Tech_Name"].Value;
                workSheet.Cells[rowExcel, "B"] = dataGridView1.Rows[i].Cells["Typical"].Value;
                workSheet.Cells[rowExcel, "C"] = dataGridView1.Rows[i].Cells["Hard"].Value;

                ++rowExcel;
            }
        }

        private void Help_Form_Load(object sender, EventArgs e)
        {
            

            dataGridView1.Columns.Add("Tech_Name", "Технологические возможности");
            dataGridView1.Columns.Add("Typical", "Типовые");
            dataGridView1.Columns.Add("Hard", "Усложненные");

            dataGridView1.Rows.Add("Количество слоев", "от 2 до 8", "до 32");
            dataGridView1.Rows.Add("Толщина платы, мм", "0,5...2,0", "2,0...8,0");
            dataGridView1.Rows.Add("Максимальный размер платы, мм", "300 x 400", "800 x 1100");
            dataGridView1.Rows.Add("Соотношение диаметра металлизированного отверстия к толщине платы", "1 к 8", "1 к 10");
            dataGridView1.Rows.Add("Минимальная ширина проводника и зазора, мм", "0,150", "0,100");
            dataGridView1.Rows.Add("Минимальный медный ободок отверстия (от внутреннего диаметра), мм", "0,150", "0,125");
            dataGridView1.Rows.Add("Минимальный диаметр сквозного отверстия, мм", "0,30", "0,20");
            dataGridView1.Rows.Add("Допуск на толщину платы", "+/- 10%", "+/- 10%");
            dataGridView1.Rows.Add("Допуск на размер платы, мм", "+/- 0,100", "+/- 0,100");
            dataGridView1.Rows.Add("Допуск на диаметр металлизированного отверстия, мм", "+/- 0,100", "+/- 0,076");
            dataGridView1.Rows.Add("Допуск на диаметр не металлизированного отверстия, мм", "+/- 0,100", "+/- 0,058");
            dataGridView1.Rows.Add("Допуск на ширину проводника", "+/- 30%", "+/- 25%");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}
