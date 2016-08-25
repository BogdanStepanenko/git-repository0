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
using MyFont = System.Drawing.Font;
using ExcelPS = Microsoft.Office.Interop.Excel;



namespace Расчет_Параметров_ГПП
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        //Итератор номера по порядку для таблицы результатов
        int idgv = 1;

        //Итератор числа кликов для графика
        int Num_r = 0;


        // Переменные для рассчета пленочной индуктивности
        string form_spiral = "Круглая";
        double K;
        double K1;
        double ro3;
        int D_inside = 2;
        double D_outside;

        //Метод для экспорта в EXCEL
        private void ExportToExcel() 
        {
            ExcelPS.Application exApp = new ExcelPS.Application();
            exApp.Workbooks.Add();
            exApp.Visible = true;
            Worksheet workSheet = (Worksheet)exApp.ActiveSheet;

            workSheet.Cells[1, 1] = "Номер расчета";
            workSheet.Cells[1, 2] = "Описание";
            workSheet.Cells[1, 3] = "Условное обозначение";
            workSheet.Cells[1, 4] = "Результат";
            workSheet.Cells[1, 5] = "Единицы измерения";
            workSheet.Cells[1, 6] = "Применяемый материал";
            workSheet.Cells[1, 7] = "Параметр";
            workSheet.Cells[1, 8] = "Значение";
           
            int rowExcel = 2;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                workSheet.Cells[rowExcel, "A"] = dataGridView1.Rows[i].Cells["ID"].Value;
                workSheet.Cells[rowExcel, "B"] = dataGridView1.Rows[i].Cells["What"].Value;
                workSheet.Cells[rowExcel, "C"] = dataGridView1.Rows[i].Cells["UO"].Value;
                workSheet.Cells[rowExcel, "D"] = dataGridView1.Rows[i].Cells["Result"].Value;
                workSheet.Cells[rowExcel, "E"] = dataGridView1.Rows[i].Cells["CI"].Value;
                workSheet.Cells[rowExcel, "F"] = dataGridView1.Rows[i].Cells["Matherial"].Value;
                workSheet.Cells[rowExcel, "G"] = dataGridView1.Rows[i].Cells["Matherial_Value"].Value;
                workSheet.Cells[rowExcel, "H"] = dataGridView1.Rows[i].Cells["HM"].Value;

                ++rowExcel;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.ShowDialog();

            this.Text = "Flexible PCB Designer";
            button1.Text = "Рассчитать";
            button2.Text = "Рассчитать";
            button3.Text = "Рассчитать";
            label1.Text = "Толщина слоя меди";
            label2.Text = "Толщина диэлектрика";
            label3.Text = "Деформация меди*";
            label4.Text = "мкм";
            label5.Text = "мкм";
            label6.Text = "%";
            label7.Text = null;
            label7.Text = "*Допустимые величины деформации меди: \n \n - отожженная фольга = 16% \n - гальванически нанесенная фольга = 11% \n - гибкие растяжения при установке = 10% \n - динамически гибкие растяжения = 0,3% \n - постоянно динамически гибкие растяжения = 0,1%";
            label8.Text = null;
            label16.Text = null;
            label25.Text = null;
            label35.Text = null;
            label36.Text = null;
            label47.Text = null;
            label48.Text = null;
            label53.Text = null;
            label60.Text = null;
            label73.Text = null;
            label74.Text = null;
            label75.Text = null;
            label76.Text = null;
            label82.Text = null;
            label83.Text = null;
            label94.Text = null;
            label96.Text = null;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox24.Text = "0";
            textBox25.Text = "0";
            groupBox15.Enabled = false;
            label53.Enabled = false;
            groupBox1.TabIndex = 0;

            // DataGridView

            dataGridView1.Columns.Add("ID", "Номер расчета");
            dataGridView1.Columns.Add("What", "Описание");
            dataGridView1.Columns.Add("UO", "Условное обозначение");
            dataGridView1.Columns.Add("Result", "Результат");
            dataGridView1.Columns.Add("CI", "Единицы измерения");
            dataGridView1.Columns.Add("Matherial", "Применяемый материал");
            dataGridView1.Columns.Add("Matherial_Value", "Дополнительный параметр");
            dataGridView1.Columns.Add("HM", "Значение");

            //SortMode - OFF
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //PictureBox
            pictureBox1.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_00.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\базовый_материал.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_04.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_004.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_05.jpg");
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_06.jpg");
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_07.png");
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_08.jpg");
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_09.jpg");
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\Flexible_PCB_Designer.png");
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_004.png");
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;

            //ComboBox
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;

            //RadioButton
            radioButton1.Text = "Односторонняя ГПП";
            radioButton2.Text = "Двусторонняя ГПП";

            //TabControl
            tabControl1.TabPages[0].Text = "Радиус перегиба ГПП";
            tabControl1.TabPages[1].Text = "Падение напряжения в проводнике";
            tabControl1.TabPages[2].Text = "Паразитная емкость";
            tabControl1.TabPages[3].Text = "Рассеиваемая мощность ГПП";
            tabControl1.TabPages[4].Text = "Таблица результатов";
            tabControl1.TabPages[5].Text = "Индуктивность";
            tabControl1.TabPages[6].Text = "Межслойная емкость";
            tabControl1.TabPages[7].Text = "Конструкция пленочной индуктивности";
            tabControl1.TabPages[8].Text = "Акустические свойства";
            tabControl1.TabPages[9].Text = "Нейтральная линия ГПП";
            tabControl1.TabPages[10].Text = "Сопротивление";
            
            //Всплывающая подсказка при экспорте в Excel
            toolTip1.SetToolTip(button5, "Экспорт таблицы в MS Excel");
            toolTip1.IsBalloon = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox1:
            Single c;
            // Преобразование из строковой переменной в int32:
            bool Число_ли1 = Single.TryParse(
                        textBox1.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out c);

            // Второй параметр - это разрешенный стиль числа (Integer, 
            // шестнадцатиричное число, экспоненциальный вид числа и прочее).
            // Третий параметр форматирует значения на основе текущего языка
            // и региональных параметров из Панели управления - Язык и
            // региональные стандарты число допустимого формата: метод
            // возвращает значение в переменную "c"
            if (Число_ли1 == false || textBox1.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                return; // - выход из процедуры или Return
            }

            /////////////////////////////////////////////////////////

            // TextBox2:
            Single D;
            // Преобразование из строковой переменной в int32:
            bool Число_ли2 = Single.TryParse(
                        textBox2.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out D);
            if (Число_ли2 == false || textBox2.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                return; // - выход из процедуры или Return
            }

            /////////////////////////////////////////////////////////////

            // TextBox3:
            Single ev;
            // Преобразование из строковой переменной в int32:
            bool Число_ли3 = Single.TryParse(
                        textBox3.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out ev);
            if (Число_ли3 == false || textBox3.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                return; // - выход из процедуры или Return
            }

            if (radioButton1.Checked)
            {
                // RadioButton1
                // Расчет радиуса изгиба односторонней ГПП
                pictureBox1.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_01.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Single r = (c * (100 - ev) / (2 * ev)) - D;

                string l11 = "Минимальный радиус изгиба для односторонней ГПП";
                string l12 = "Rдгпп";
                string l13 = "мкм";
                string l14 = "-";
                string l15 = "-";
                string l16 = "-";

                // Result > 0
                if (r > 0)
                {
                    label8.Text = Convert.ToString(String.Format("Минимальный радиус изгиба для \nодносторонней гибкой печатной платы: \n Rогпп = {0:F5} мкм", r));
                    dataGridView1.Rows.Add(idgv++, l11, l12, r, l13, l14, l15, l16);
                }
                else
                {
                    MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            if (radioButton2.Checked)
            {
                // RadioButton2 
                // Расчет радиуса изгиба двусторонней ГПП
                this.pictureBox1.Image = Image.FromFile(@"C:\Users\probook\Documents\Visual Studio 2013\Projects\Расчет_Параметров_ГПП\Расчет_Параметров_ГПП\img_02.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Single r1 = ((D + c) * (100 - ev)) / ev - D;
                string l21 = "Минимальный радиус изгиба для двусторонней ГПП";
                string l22 = "Rдгпп";
                string l23 = "мкм";
                string l24 = "-";
                string l25 = "-";
                string l26 = "-";

                if (r1 > 0)
                {
                    label8.Text = Convert.ToString(String.Format("Минимальный радиус изгиба для \nдвусторонней гибкой печатной платы: \n Rдгпп = {0:F5} мкм", r1));
                    dataGridView1.Rows.Add(idgv++, l21, l22, r1, l23, l24, l25, l26);
                }
                else
                {
                    MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



                                                   // Конец первой вкладки  




        private void button2_Click(object sender, EventArgs e)
        {

            //Показать checkBox
            checkBox1.Visible = true;

            // TextBox4:
            Single Im;
            // Преобразование из строковой переменной в int32:
            bool Число_ли4 = Single.TryParse(
                        textBox4.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Im);

            if (Число_ли4 == false || textBox4.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox5:
            Single b;
            // Преобразование из строковой переменной в int32:
            bool Число_ли5 = Single.TryParse(
                        textBox5.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out b);
            if (Число_ли5 == false || textBox5.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox6:
            Single t;
            // Преобразование из строковой переменной в int32:
            bool Число_ли6 = Single.TryParse(
                        textBox6.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out t);
            if (Число_ли6 == false || textBox6.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                return; // - выход из процедуры или Return
            }
            
            //Закрыть картинку
            pictureBox4.Visible = false;

           
            Double ro = 0.0172;
            string param_name = "Медь холоднокатанная отожженная";

            /* if (radioButton3.Checked)
            {
                ro = 0.0172;
            }
            */

            if (radioButton4.Checked)
            {
                ro = 0.028;
                param_name = "Химическая медь";
            }
            if (radioButton5.Checked)
            {
                ro = 0.0177;
                param_name = "Медь электролитическая";
            }
            if (radioButton6.Checked)
            {
                ro = 0.75;
                param_name = "Никелевая сталь";
            }
            if (radioButton7.Checked)
            {
                ro = 0.0433;
                param_name = "Алюминий";
            }
            if (radioButton8.Checked)
            {
                ro = 0.08;
                param_name = "Бериллиевая бронза";
            }
            
            
            Double U = (ro * Im * 0.001) / (b * t);
            string l31 = "Допустимое падение напряжения в проводнике";
            string l32 = "Uпад";
            string l33 = "мВ/м";
            string l34 = param_name;
            string l35 = "Удельное сопротивление (Ом*мм/м)";

            if (U > 0)
            {
                label16.Text = Convert.ToString(String.Format("Допустимое падение напряжения в проводнике: \n Uпад = {0:F5} мВ/м", U));
                dataGridView1.Rows.Add(idgv++, l31, l32, U, l33, l34, l35, ro);

                // Итератор номера расчета
                Num_r++;

                // График
                chart1.Series[0].Points.AddXY(Num_r, U);
                chart1.Series[0].ToolTip = "Расчет №#VALX, Uпад = #VALY";
                
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Вид диаграмы в зависимости от нажатия checkBoxa

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }

            if (checkBox1.Checked == false)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }


                                                  // Конец второй вкладки  





        private void button3_Click(object sender, EventArgs e)
        {

            // TextBox7:
            Single lpp;
            // Преобразование из строковой переменной в int32:
            bool Число_ли7 = Single.TryParse(
                        textBox7.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out lpp);

            if (Число_ли7 == false || textBox7.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox8:
            Single sl;
            // Преобразование из строковой переменной в int32:
            bool Число_ли8 = Single.TryParse(
                        textBox8.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out sl);
            if (Число_ли8 == false || textBox8.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox9:
            Single wpp;
            // Преобразование из строковой переменной в int32:
            bool Число_ли9 = Single.TryParse(
                        textBox9.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out wpp);
            if (Число_ли9 == false || textBox9.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox10:
            Single hpp;
            // Преобразование из строковой переменной в int32:
            bool Число_ли10 = Single.TryParse(
                        textBox10.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out hpp);
            if (Число_ли10 == false || textBox10.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                return; // - выход из процедуры или Return
            }

            // Выбор базового материала для рассчета паразитной емкости
            Double epron = 3.2;
            string param_name2 = "Полиэфир Mylar";

            /* if (radioButton22.Checked)
             {
                 epron = 3.2;
             }*/

            if (radioButton21.Checked)
            {
                epron = 3.5;
                param_name2 = "Полиимид Kapton";

            }
            if (radioButton20.Checked)
            {
                epron = 2.9;
                param_name2 = "Полиэтилен нафталат";
            }
            if (radioButton19.Checked)
            {
                epron = 2.9;
                param_name2 = "Жидкокристаллический полимер";
            }
            if (radioButton18.Checked)
            {
                epron = 2;
                param_name2 = "Фторэтиленпропилен";
            }
            if (radioButton13.Checked)
            {
                epron = 2.5;
                param_name2 = "Политетрафторэтилен";
            }
            if (radioButton14.Checked)
            {
                epron = 4.7;
                param_name2 = "Поливинилхлорид";
            }
            if (radioButton15.Checked)
            {
                epron = 2;
                param_name2 = "Арамидная бумага";
            }
            if (radioButton16.Checked)
            {
                epron = 4.7;
                param_name2 = "FR-4 STANDART";
            }
            if (radioButton17.Checked)
            {
                epron = 4.7;
                param_name2 = "FR-4 с наполнителем";
            }
            if (radioButton23.Checked)
            {
                epron = 3.8;
                param_name2 = "Цианатный полиэфир";
            }
            if (radioButton24.Checked)
            {
                epron = 3.7;
                param_name2 = "APPE";
            }
            if (radioButton25.Checked)
            {
                epron = 4.7;
                param_name2 = "CEM-1";
            }
            if (radioButton26.Checked)
            {
                epron = 5;
                param_name2 = "FR-2";
            }
            if (radioButton27.Checked)
            {
                epron = 3.5;
                param_name2 = "ПМ-1";
            }
            if (radioButton28.Checked)
            {
                epron = 3.5;
                param_name2 = "ФДИ-А";
            }

                      
            Double Cpar = (0.12 * epron * lpp) /  Math.Log((2 * sl) / (wpp + hpp));
            string l41 = "Паразитная емкость между двумя соседними печатными проводниками";
            string l42 = "Спар";
            string l43 = "пФ";
            string l44 = param_name2;
            string l45 = "Диэлектрическая проницаемость (1 кГц)";
            // string l46 = epron

            if (Cpar > 0)
            {
                label25.Text = Convert.ToString(String.Format("Паразитная емкость между двумя соседними печатными проводниками: \n Спар = {0:F5} пФ", Cpar));
                dataGridView1.Rows.Add(idgv++, l41, l42, Cpar, l43, l44, l45, epron);
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        


                                                        // Конец третьей вкладки  





        private void button4_Click(object sender, EventArgs e)
        {

            // TextBox11:
            Single Upwr;
            // Преобразование из строковой переменной в int32:
            bool Число_ли11 = Single.TryParse(
                        textBox11.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Upwr);

            if (Число_ли11 == false || textBox11.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                numericUpDown1.Value = 1;
                return; // - выход из процедуры или Return
            }

            // TextBox12:
            Single Sm;
            // Преобразование из строковой переменной в int32:
            bool Число_ли12 = Single.TryParse(
                        textBox12.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Sm);
            if (Число_ли12 == false || textBox12.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                numericUpDown1.Value = 1;
                return; // - выход из процедуры или Return
            }

            // TextBox13:
            Single Tpp;
            // Преобразование из строковой переменной в int32:
            bool Число_ли13 = Single.TryParse(
                        textBox13.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Tpp);
            if (Число_ли13 == false || textBox13.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                numericUpDown1.Value = 1;
                return; // - выход из процедуры или Return
            }


            // Диэлектрическая проницаемость
            string n = comboBox1.Text;
            Double epron2 = 3.2;
            Double tgp = 0.005;
            //
            // Выбор базового материала для собственной емкости и мощности потерь
            if (n == "Полиэфир Mylar")
             {
                 epron2 = 3.2;
                 tgp = 0.005;
             }

            if (n == "Полиимид Kapton")
            {
                epron2 = 3.5;
                tgp = 0.003;
            }
            if (n == "Полиэтилен нафталат")
            {
                epron2 = 2.9;
                tgp = 0.004;
            }
            if (n == "Жидкокристаллический полимер")
            {
                epron2 = 2.9;
                tgp = 0.003;
            }
            if (n == "Фторэтиленпропилен")
            {
                epron2 = 2;
                tgp = 0.0002;
            }
            if (n == "Политетрафторэтилен")
            {
                epron2 = 2.5;
                tgp = 0.0002;
            }
            if (n == "Поливинилхлорид")
            {
                epron2 = 4.7;
                tgp = 0.093;
            }
            if (n == "Арамидная бумага")
            {
                epron2 = 2;
                tgp = 0.007;
            }
            if (n == "FR-4 STANDART")
            {
                epron2 = 4.7;
                tgp = 0.025;
            }
            if (n == "FR-4 с наполнителем")
            {
                epron2 = 4.7;
                tgp = 0.023;
            }
            if (n == "Цианатный полиэфир")
            {
                epron2 = 3.8;
                tgp = 0.008;
            }
            if (n == "APPE")
            {
                epron2 = 3.7;
                tgp = 0.005;
            }
            if (n == "CEM-1")
            {
                epron2 = 4.7;
                tgp = 0.031;
            }
            if (n == "FR-2")
            {
                epron2 = 5;
                tgp = 0.05;
            }
            if (n == "ПМ-1")
            {
                epron2 = 3.5;
                tgp = 0.003;
            }
            if (n == "ФДИ-А")
            {
                epron2 = 3.5;
                tgp = 0.003;
            }


            int f = (int) numericUpDown1.Value;

            //Собственная емкость
            Double C4 = (0.009 * epron2 * Sm) / (Tpp * 1000);
            string l51 = "Собственная емкость ГПП";
            string l52 = "С";
            string l53 = "пФ";
            string l54 = n;
            string l55 = "Диэлектрическая проницаемость (1 кГц)";
            string l56 = "Tg угла потерь (1 кГц)";

            if (C4 > 0)
            {
                label35.Text = Convert.ToString(String.Format("Собственная емкость ГПП: \n С = {0:F5} пФ", C4));
               dataGridView1.Rows.Add(idgv++, l51, l52, C4, l53, l54, l55, epron2);
               dataGridView1.Rows.Add(idgv++, l51, l52, C4, l53, l54, l56, tgp);
            }
             else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Мощность потерь

            if (numericUpDown1.Value != 0)
            {

                Double Pp = 2 * Math.PI * f * C4 * Upwr * tgp;
                string l61 = "Мощность потерь ГПП";
                string l62 = "Pп";
                string l63 = "мкВт";
                string l64 = n;
                string l65 = "Указанная частота (МГц)";

                if (Pp > 0)
                {
                    label36.Text = Convert.ToString(String.Format("Мощность потерь ГПП: \n Pп = {0:F5} мкВт", Pp));
                    dataGridView1.Rows.Add(idgv++, l61, l62, Pp, l63, l64, l65, f);
                }
                else
                {
                    MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                 else
                {
                     label36.Text = "Расчет не был произведен, \n поскольку частота тока не указана";
                }
        }



                                                    // Конец четвертой вкладки




        

        private void button7_Click(object sender, EventArgs e)
        {
            
            int f2 = (int)numericUpDown2.Value;

           
            //Индуктивность проводника

            // TextBox14:
            Single lpr;
            // Преобразование из строковой переменной в int32:
            bool Число_ли14 = Single.TryParse(
                        textBox14.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out lpr);

            if (Число_ли14 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                
                numericUpDown2.Value = 1;
                return; // - выход из процедуры или Return
            }

            // TextBox15:
            Single wpr;
            // Преобразование из строковой переменной в int32:
            bool Число_ли15 = Single.TryParse(
                        textBox15.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out wpr);
            if (Число_ли15 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                
                numericUpDown2.Value = 1;
                return; // - выход из процедуры или Return
            }

            // TextBox16:
            Single t_provodnika;
            // Преобразование из строковой переменной в int32:
            bool Число_ли16 = Single.TryParse(
                        textBox16.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out t_provodnika);
            if (Число_ли16 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
               
                numericUpDown1.Value = 1;
                return; // - выход из процедуры или Return
            }



            //Индуктивность металлизированного отверстия

            // TextBox17:
            Single d_otverstiya;
            // Преобразование из строковой переменной в int32:
            bool Число_ли17 = Single.TryParse(
                        textBox17.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out d_otverstiya);
            if (Число_ли17 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                textBox17.Clear();
                textBox18.Clear();

                return; // - выход из процедуры или Return
            }
 
                // TextBox18:
                Single h_layers;
                // Преобразование из строковой переменной в int32:
                bool Число_ли18 = Single.TryParse(
                            textBox18.Text,
                            System.Globalization.NumberStyles.Number,
                            System.Globalization.NumberFormatInfo.CurrentInfo,
                            out h_layers);
                if (Число_ли18 == false)
                {
                    // Если пользователь ввел не число:
                    MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    textBox17.Clear();
                    textBox18.Clear();

                    return; // - выход из процедуры или Return
                }


            // Индуктивность отверстия
                if (radioButton30.Checked)
                {

                    Double Lm = ((h_layers * 0.001) / 5) * (1 + Math.Log((4 * h_layers * 0.001) / (d_otverstiya * 0.001)));
                    string l91 = "Индуктивность переходного отверстия";
                    string l92 = "Lм";
                    string l93 = "нГн";
                    string l94 = "-";
                    string l95 = "-";
                    string l96 = "-";
                    


                    if (Lm >= 0)
                    {
                        label53.Text = Convert.ToString(String.Format("Индуктивность переходного отверстия: \n Lм = {0:F5} нГн", Lm));
                        dataGridView1.Rows.Add(idgv++, l91, l92, Lm, l93, l94, l95, l96);
                    }
                    else
                    {
                        MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }



            // Индуктивность проводника
            if (radioButton29.Checked)
               {
        
            Double Lprov = (0.0002 * lpr) * (Math.Log(2 * lpr / (wpr + t_provodnika)) + 0.2235 * (wpr + t_provodnika / lpr) + 0.5);
            string l71 = "Паразитная индуктивность проводника";
            string l72 = "Lпп";
            string l73 = "мкГн";
            string l74 = "-";
            string l75 = "-";
            string l76 = "-";
            

            if (Lprov >= 0)
            {

                label47.Text = Convert.ToString(String.Format("Паразитная индуктивность проводника: \n Lпп = {0:F5} мкГн", Lprov));
                dataGridView1.Rows.Add(idgv++, l71, l72, Lprov, l73, l74, l75, l76);
            }

            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

                // Если частота тока указана - расчет реактивного сопротивления индуктивности
            if (numericUpDown2.Value != 0)
            {
                if (Lprov >= 0)
                {
                    Double react_resist = 2 * Math.PI * f2 * Lprov;
                    string l81 = "Реактивное сопротивление индуктивности проводника";
                    string l82 = "Lx";
                    string l83 = "Ом";
                    string l84 = "-";
                    string l85 = "Указанная частота (МГц)";

                    label48.Text = Convert.ToString(String.Format("Реактивное сопротивление индуктивности проводника: \n Lx = {0:F5} Ом", react_resist));
                    dataGridView1.Rows.Add(idgv++, l81, l82, react_resist, l83, l84, l85, f2);

                }
                else
                {
                    MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                label48.Text = "Расчет не был произведен, \n поскольку частота тока не указана";
            }
        }

    }


        // Выбор узла расчета для индуктивности проводника
        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {

            groupBox9.Enabled = true;
            textBox14.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            groupBox10.Enabled = false;
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            label53.Text = null;
            label47.Enabled = true;
            label48.Enabled = true;
        }


        // Выбор узла расчета для индуктивности металлизированного отверстия
        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {

            groupBox10.Enabled = true;
            textBox17.Enabled = true;
            textBox18.Enabled = true;
            groupBox9.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox14.Text = "0";
            textBox15.Text = "0";
            textBox16.Text = "0";
            textBox17.Clear();
            textBox18.Clear();
            label47.Text = null;
            label48.Text = null;
            label53.Enabled = true;

        }



                                                    // Конец пятой вкладки






        // Межслойная емкость
        private void button8_Click(object sender, EventArgs e)
        {

            // TextBox19:
            Single wprl;
            // Преобразование из строковой переменной в int32:
            bool Число_ли19 = Single.TryParse(
                        textBox19.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out wprl);

            if (Число_ли19 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox20:
            Single lprl;
            // Преобразование из строковой переменной в int32:
            bool Число_ли20 = Single.TryParse(
                        textBox20.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out lprl);
            if (Число_ли20 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox21:
            Single d_out_layer_c;
            // Преобразование из строковой переменной в int32:
            bool Число_ли21 = Single.TryParse(
                        textBox21.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out d_out_layer_c);
            if (Число_ли21 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                return; // - выход из процедуры или Return
            }

            
            // Диэлектрическая проницаемость
            string n2 = comboBox2.Text;
            Double epron3 = 3.2;
            
            // Выбор базового материала для межслойной емкости
            if (n2 == "Полиэфир Mylar")
            {
                epron3 = 3.2;
                
            }

            if (n2 == "Полиимид Kapton")
            {
                epron3 = 3.5;
                
            }
            if (n2 == "Полиэтилен нафталат")
            {
                epron3 = 2.9;
                
            }
            if (n2 == "Жидкокристаллический полимер")
            {
                epron3 = 2.9;
                
            }
            if (n2 == "Фторэтиленпропилен")
            {
                epron3 = 2;
                
            }
            if (n2 == "Политетрафторэтилен")
            {
                epron3 = 2.5;
                
            }
            if (n2 == "Поливинилхлорид")
            {
                epron3 = 4.7;
                
            }
            if (n2 == "Арамидная бумага")
            {
                epron3 = 2;
                
            }
            if (n2 == "FR-4 STANDART")
            {
                epron3 = 4.7;
                
            }
            if (n2 == "FR-4 с наполнителем")
            {
                epron3 = 4.7;
                
            }
            if (n2 == "Цианатный полиэфир")
            {
                epron3 = 3.8;
                
            }
            if (n2 == "APPE")
            {
                epron3 = 3.7;
                
            }
            if (n2 == "CEM-1")
            {
                epron3 = 4.7;
                
            }
            if (n2 == "FR-2")
            {
                epron3 = 5;
                
            }
            if (n2 == "ПМ-1")
            {
                epron3 = 3.5;
                
            }
            if (n2 == "ФДИ-А")
            {
                epron3 = 3.5;
                
            }

            //Межслойная емкость
            Double Cml = (0.0085 * epron3) * ((wprl * lprl) / d_out_layer_c);
            string l101 = "Межслойная емкость";
            string l102 = "Сml";
            string l103 = "пФ";
            string l104 = n2;
            string l105 = "Диэлектрическая проницаемость (1 кГц)";

            if (Cml > 0)
            {
                label60.Text = Convert.ToString(String.Format("Межслойная емкость ГПП: \n Сml = {0:F5} пФ", Cml));
                dataGridView1.Rows.Add(idgv++, l101, l102, Cml, l103, l104, l105, epron3);
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        
                                                    // Конец шестой вкладки




        private void button10_Click(object sender, EventArgs e)
        {
            //Выбранные значения частоты и материала
            double f_current = (double)numericUpDown3.Value;
            string n3 = (string)comboBox3.SelectedItem;

            // Проверка введеных значений и их конвертация
            // TextBox22:
            Single ind;
            // Преобразование из строковой переменной в int32:
            bool Число_ли22 = Single.TryParse(
                        textBox22.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out ind);

            if (Число_ли22 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();
                textBox25.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox23:
            Single Q;
            // Преобразование из строковой переменной в int32:
            bool Число_ли23 = Single.TryParse(
                        textBox23.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Q);
            if (Число_ли23 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();
                textBox25.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox24:
            Single A;
            // Преобразование из строковой переменной в int32:
            bool Число_ли24 = Single.TryParse(
                        textBox24.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out A);
            if (Число_ли24 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();
                textBox25.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox25:
            Single B;
            // Преобразование из строковой переменной в int32:
            bool Число_ли25 = Single.TryParse(
                        textBox25.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out B);
            if (Число_ли25 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();
                textBox25.Clear();
                return; // - выход из процедуры или Return
            }        

            // Выбор фольги

            //Медь
            if (n3 == "Медь")
            {
                K1 = 0.39;
                ro3 = 0.017;
            }

            //Алюминий
            if (n3 == "Алюминий")
            {
                K1 = 0.51;
                ro3 = 0.029;
            }

            //Серебро
            if (n3 == "Серебро")
            {
                K1 = 0.37;
                ro3 = 0.016;
            }
            

            // Выбор вида спирали

            //Круглая спираль
            if (radioButton31.Checked)
            {
                form_spiral = "Круглая"; 
                K = 0.1;
                D_outside = 8.1;

                groupBox14.Enabled = true;
                groupBox15.Enabled = false;
                textBox24.Text = "0";
                textBox25.Text = "0";

            }

            //Квадратная спираль
            if (radioButton32.Checked)
            {
                form_spiral = "Прямоугольная"; 
                D_outside = (2 / Math.Sqrt(Math.PI)) * Math.Sqrt(A * B);
                K = 0.05 * ((D_outside/D_inside)-3);

                groupBox14.Enabled = true;
                groupBox15.Enabled = true;
                textBox24.Enabled = true;
                textBox25.Enabled = true;
            }

             // 1)Шаг спирали
            double t_sp = K * Math.Sqrt(Math.Pow(D_inside, 3) / ind); 

            string l111 = "Шаг спирали";
            string l112 = "t";
            string l113 = "мм";
            string l114 = n3;
            string l115 = "Коэффициент материала пленки";

            if (t_sp > 0)
            {
                label73.Text = String.Format("Шаг спирали проводника: t = {0:F5} мм", t_sp);
                dataGridView1.Rows.Add(idgv++, l111, l112, t_sp, l113, l114, l115, K1);
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //РАЗОБРАТЬСЯ С СИСТЕМАМИ ИЗМЕРЕНИЯ (см, мм, мкм)
                   
            // 2)Толщина проводника
            double d_width_prov = 2 * (K1 * (Math.Sqrt((299792458 / (f_current * 1000000)))) * 0.1);

            string l121 = "Толщина проводника";
            string l122 = "d";
            string l123 = "мм";
            string l124 = n3;
            string l125 = "Указанная частота (МГц)";

            if (d_width_prov > 0)
            {
                label74.Text = String.Format("Толщина проводника: d = {0:F5} мм", d_width_prov);
                dataGridView1.Rows.Add(idgv++, l121, l122, d_width_prov, l123, l124, l125, f_current);
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            


            // 3)Ширина витка
            double b_width_vitka = 1.5 * ((ro3 * t_sp * ((Math.Pow (D_outside, 2) / Math.Pow(D_inside, 2)) - 1) * Q * 0.1) / (16 * f_current * D_inside * Math.Pow (K, 2) * d_width_prov));

            string l131 = "Ширина витка";
            string l132 = "b";
            string l133 = "мм";
            string l134 = n3;
            string l135 = "Удельное сопротивление (Ом*мм/м)";

            if (b_width_vitka > 0 && b_width_vitka < t_sp)
            {
                label75.Text = String.Format("Ширина витка: b = {0:F5} мм", b_width_vitka);
                dataGridView1.Rows.Add(idgv++, l131, l132, b_width_vitka, l133, l134, l135, ro3);
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            


            // 4)Число витков
            double N_vitkov = (D_outside - D_inside) / (2 * t_sp);

            string l141 = "Число витков";
            string l142 = "N";
            string l143 = "шт";
            string l144 = n3;
            string l145 = "Форма спирали";

            if (N_vitkov > 0)
            {
                label76.Text = String.Format("Число витков: N = {0:F0} ", N_vitkov);
                dataGridView1.Rows.Add(idgv++, l141, l142, N_vitkov, l143, l144, l145, form_spiral);                                
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


            
        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {
            groupBox14.Enabled = true;
            groupBox15.Enabled = false;
            textBox22.Enabled = true;
            textBox23.Enabled = true;
            textBox24.Enabled = false;
            textBox25.Enabled = false;
            textBox24.Text = "0";
            textBox25.Text = "0";
        }

        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {
            groupBox14.Enabled = true;
            groupBox15.Enabled = true;
            textBox22.Enabled = true;
            textBox23.Enabled = true;
            textBox24.Enabled = true;
            textBox25.Enabled = true;
            textBox24.Clear();
            textBox25.Clear();
        }



                                                     // Конец седьмой вкладки





        private void button12_Click_1(object sender, EventArgs e)
        {

            //Коэффициент Пуассона и скорость поперечных колебаний
            double Puasson = 0.345;
            int V_width = 2298;
            string param_name4 = "Медь холоднокатанная отожженая";

            if (radioButton38.Checked)
            {
                param_name4 = "Медь холоднокатанная отожженая";//
                Puasson = 0.345;
                V_width = 2298;
            }
            if (radioButton39.Checked)
            {
                param_name4 = "Химическая медь";
                Puasson = 0.31;
                V_width = 2260;
            }
            if (radioButton40.Checked)
            {
                param_name4 = "Медь электролитическая";
                Puasson = 0.33;
                V_width = 2300;
            }
            if (radioButton41.Checked)
            {
                param_name4 = "Никелевая сталь";
                Puasson = 0.33;
                V_width = 2960;
            }
            if (radioButton42.Checked)
            {
                param_name4 = "Алюминий";//
                Puasson = 0.348;
                V_width = 3110;
            }
            if (radioButton43.Checked)
            {
                param_name4 = "Бериллиевая бронза";
                Puasson = 0.325;
                V_width = 2500;
            }
            

                // Расчет скорости распространения поверхностных волн
                double Vr = (0.87 + (1.12 * Puasson * V_width)) / (1 + Puasson);

                string l151 = "Скорость распространения поверхностных волн";
                string l152 = "Vr";
                string l153 = "м/с";
                string l154 =  param_name4;
                string l155 = "Скорость поперечных колебаний (м/с)";

                    label82.Text = String.Format("Скорость распространения поверхностных колебаний: \n Vr = {0:F5} м/с", Vr);
                    label83.Text = String.Format("Скорость распространения поперечных колебаний: \n Vt = {0:F0} м/с", V_width);
                    dataGridView1.Rows.Add(idgv++, l151, l152, Vr, l153, l154, l155, V_width);
                
        }



                                                      // Конец восьмой вкладки





        private void button13_Click(object sender, EventArgs e)
        {

            // TextBox27:
            Single Ha;
            // Преобразование из строковой переменной в int32:
            bool Число_ли27 = Single.TryParse(
                        textBox27.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Ha);
            if (Число_ли27 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox27.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox28:
            Single Hp;
            // Преобразование из строковой переменной в int32:
            bool Число_ли28 = Single.TryParse(
                        textBox28.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Hp);
            if (Число_ли28 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox28.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox29:
            Single Ba;
            // Преобразование из строковой переменной в int32:
            bool Число_ли29 = Single.TryParse(
                        textBox29.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Ba);
            if (Число_ли29 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox29.Clear();
                return; // - выход из процедуры или Return
            }

            // TextBox30:
            Single Bp;
            // Преобразование из строковой переменной в int32:
            bool Число_ли30 = Single.TryParse(
                        textBox30.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out Bp);
            if (Число_ли30 == false)
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox30.Clear();
                return; // - выход из процедуры или Return
            }

            double Ea = 1.1;
            double Ep = 1.6;
            string n4 = (string)comboBox4.SelectedItem; //проводник
            string n5 = (string)comboBox5.SelectedItem; // базовый материал

            //Материал проводника
            if (n4 == "Медь холоднокатанная отожженная")
            {
                Ea = 1.1;
            }
            if (n4 == "Химическая медь")
            {
                Ea = 1.12;
            }
            if (n4 == "Медь электролитическая")
            {
                Ea = 1.25;
            }
            if (n4 == "Никелевая сталь")
            {
                Ea = 2.5;
            }
            if (n4 == "Алюминий")
            {
                Ea = 0.69;
            }
            if (n4 == "Бериллиевая бронза")
            {
                Ea = 1.05;
            }
            
            //Базовый материал
            if (n5 == "Полиэфир Mylar")
            {
                Ep = 1.6;
            }
            if (n5 == "Полиимид Kapton")
            {
                Ep = 3.2;
            }
            if (n5 == "Полиэтилен нафталат")
            {
                Ep = 1.98;
            }
            if (n5 == "Фторопласт")
            {
                Ep = 3.1;
            }
            if (n5 == "Поливинилхлорид")
            {
                Ep = 2.7;
            }
            if (n5 == "Арамидная бумага")
            {
                Ep = 2.1;
            }
            if (n5 == "FR-4 STANDART")
            {
                Ep = 2.3;
            }
            if (n5 == "ПМ-1")
            {
                Ep = 1.2;
            }
            if (n5 == "ФДИ-А")
            {
                Ep = 3.2;
            }

            //Расчет нейтральной линии
            double ha = (((Ea * Ba * Math.Pow(Ha, 2)) / 2) + (Ep * Hp * Bp * Ha) + (Ep * Bp * Math.Pow(Hp, 2))) / ((Ea * Ba * Ha) + (Ep * Bp * Hp));

            if (ha > 0)
            {
                string l161 = "Значение нейтральной линии ГПП";
                string l162 = "ha";
                string l163 = "мкм";
                string l164 = n4;
                string l165 = "Базовый материал ГПП";

                label94.Text = String.Format("Значение нейтральной линии ГПП: \n ha = {0:F5} мкм", ha);

                dataGridView1.Rows.Add(idgv++, l161, l162, ha, l163, l164, l165, n5);
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


                                                
            
                                                      // Конец девятой вкладки





        private void button14_Click(object sender, EventArgs e)
        {

            //Показать checkBox
            checkBox2.Visible = true;

            //Закрыть картинку
            pictureBox11.Visible = false;

            // TextBox26:
            Single rl_provodnika;
            // Преобразование из строковой переменной в int32:
            bool Число_ли26 = Single.TryParse(
                        textBox26.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out rl_provodnika);

            if (Число_ли26 == false || textBox26.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox26.Clear();
                textBox31.Clear();
                textBox32.Clear();
                
                return; // - выход из процедуры или Return
            }

            // TextBox31:
            Single r_width_provodnika;
            // Преобразование из строковой переменной в int32:
            bool Число_ли31 = Single.TryParse(
                        textBox31.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out r_width_provodnika);
            if (Число_ли31 == false || textBox31.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox26.Clear();
                textBox31.Clear();
                textBox32.Clear();
                
                return; // - выход из процедуры или Return
            }

            // TextBox32:
            Single r_tolshina_provodnika;
            // Преобразование из строковой переменной в int32:
            bool Число_ли32 = Single.TryParse(
                        textBox32.Text,
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.NumberFormatInfo.CurrentInfo,
                        out r_tolshina_provodnika);
            if (Число_ли32 == false || textBox32.Text == "")
            {
                // Если пользователь ввел не число:
                MessageBox.Show("Заполните необходимые поля числовыми значениями \n \n Обратите внимание, в качестве разделителя целой и вещественной доли числа необходимо использовать символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox26.Clear();
                textBox31.Clear();
                textBox32.Clear();
               
                return; // - выход из процедуры или Return
            }


            
            string n6 = comboBox6.Text;
            Double ro6 = 0.0172;

            //Материал проводника
            if (n6 == "Медь холоднокатанная отожженная")
            {
               ro6 = 0.0172;
            }
            if (n6 == "Химическая медь")
            {
                ro6 = 0.028;
            }
            if (n6 == "Медь электролитическая")
            {
                ro6 = 0.0177;
            }
            if (n6 == "Никелевая сталь")
            {
                ro6 = 0.75;
            }
            if (n6 == "Алюминий")
            {
                ro6 = 0.0433;
            }
            if (n6 == "Бериллиевая бронза")
            {
                ro6 = 0.08;
            }

           // Расчет сопротивления печатного проводника

            Double Rpp = ro6 * rl_provodnika / (r_width_provodnika * r_tolshina_provodnika);

            if (Rpp > 0)
            {
                string l171 = "Сопротивление печатного проводника";
                string l172 = "Rпп";
                string l173 = "Ом";
                string l174 = n6;
                string l175 = "Удельное сопротивление (Ом*мм/м)";

                label96.Text = String.Format("Сопротивление печатного проводника: \n Rпп = {0:F5} Ом", Rpp);

                dataGridView1.Rows.Add(idgv++, l171, l172, Rpp, l173, l174, l175, ro6);

                // Итератор номера расчета
                Num_r++;

                // График
                chart2.Series[0].Points.AddXY(Num_r, Rpp);
                chart2.Series[0].ToolTip = "Расчет №#VALX, Rпп = #VALY";
            }
            else
            {
                MessageBox.Show("Указаны не корректные данные для рассчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Вид диаграмы в зависимости от нажатия checkBoxa
        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }

            if (checkBox2.Checked == false)
            {
                chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }

        
        // Экспорт в Excel
        private void button5_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
                var MBox = MessageBox.Show("Данные о результатах вычислений будут удалены. \n Очистить таблицу?",
                    "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (MBox == DialogResult.No)
                {
                    return;
                }

                if (MBox == DialogResult.Yes)
                {
                    dataGridView1.Rows.Clear();
                }
            
        }

        // Метод для вывода таблицы на печать
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView1.Size.Width + 10, dataGridView1.Size.Height + 10);
            dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        // Вывод таблицы на печать
        private void button9_Click(object sender, EventArgs e)
        {
            printDocument1.Print(); 
        }


        // Вызов справки
        private void button11_Click(object sender, EventArgs e)
        {
            PDF_Reader pdf_read = new PDF_Reader();
            pdf_read.Show();
        }


        // МЕНЮ

        // Справка
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDF_Reader pdf_read = new PDF_Reader();
            pdf_read.Show();
        }

        // Выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  
        private void таблицаРезультатовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;                          
        }

        private void падениеНапряженияВПроводникеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void паразитнаяЕмкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void рассеиваемаяМощностьГППToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void паразитнаяИндуктивностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void межслойнаяЕмкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        private void радиусПерегибаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void нейтральнаяЛинияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage11;
        }

        private void конструкцияПленочнойИндуктивностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage8;
        }

        private void сопротивлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage9;
        }

        private void акустическиеСвойстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage10;
        }

        private void технологическиеПараметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help_Form helper = new Help_Form();
            helper.Show();
        }

        private void методыКонтроляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlParams contr_params = new ControlParams();
            contr_params.Show();
        }

        private void структураГППToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_PCB_Struct f_PCB_Struct = new F_PCB_Struct();
            f_PCB_Struct.Show();
        }
    }
}