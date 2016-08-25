using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Расчет_Параметров_ГПП
{
    public partial class F_PCB_Struct : Form
    {
        public F_PCB_Struct()
        {
            InitializeComponent();
        }

        //Сумма толщины ГПП
        decimal f_PCB_width;

        private void F_PCB_Struct_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            label30.Text = "";
            button2.Enabled = false;


            groupBox2.Text = "TOP";
            groupBox3.Text = "";
            groupBox4.Text = "";
            groupBox5.Text = "";

            label76.Text = "TOP";
            label77.Text = "";
            label78.Text = "";
            label79.Text = "";

            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

            numericUpDown11.Value = 0;
            numericUpDown10.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown21.Value = 0;
            numericUpDown20.Value = 0;
            numericUpDown19.Value = 0;
            numericUpDown18.Value = 0;
            numericUpDown17.Value = 0;
            numericUpDown16.Value = 0;
            numericUpDown15.Value = 0;
            numericUpDown14.Value = 0;
            numericUpDown13.Value = 0;
            numericUpDown12.Value = 0;
        }

            //Доступ к последующим слоям в зависимости от значения
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 1)
            {
                groupBox2.Text = "TOP";
                groupBox3.Text = "";
                groupBox4.Text = "";
                groupBox5.Text = "";

                label76.Text = "TOP";
                label77.Text = "";
                label78.Text = "";
                label79.Text = "";

                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;

                numericUpDown11.Value = 0;
                numericUpDown10.Value = 0;
                numericUpDown9.Value = 0;
                numericUpDown8.Value = 0;
                numericUpDown7.Value = 0;
                numericUpDown21.Value = 0;
                numericUpDown20.Value = 0;
                numericUpDown19.Value = 0;
                numericUpDown18.Value = 0;
                numericUpDown17.Value = 0;
                numericUpDown16.Value = 0;
                numericUpDown15.Value = 0;
                numericUpDown14.Value = 0;
                numericUpDown13.Value = 0;
                numericUpDown12.Value = 0;
            }

            if (numericUpDown1.Value == 2)
            {
                groupBox2.Text = "TOP";
                groupBox3.Text = "BOT";
                groupBox4.Text = "";
                groupBox5.Text = "";

                label76.Text = "TOP";
                label77.Text = "BOT";
                label78.Text = "";
                label79.Text = "";

                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;

                numericUpDown21.Value = 0;
                numericUpDown20.Value = 0;
                numericUpDown19.Value = 0;
                numericUpDown18.Value = 0;
                numericUpDown17.Value = 0;
                numericUpDown16.Value = 0;
                numericUpDown15.Value = 0;
                numericUpDown14.Value = 0;
                numericUpDown13.Value = 0;
                numericUpDown12.Value = 0;
            }

            if (numericUpDown1.Value == 3)
            {
                groupBox2.Text = "TOP";
                groupBox3.Text = "INT1";
                groupBox4.Text = "BOT";
                groupBox5.Text = "";

                label76.Text = "TOP";
                label77.Text = "INT1";
                label78.Text = "BOT";
                label79.Text = "";

                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                groupBox5.Visible = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = false;

                numericUpDown16.Value = 0;
                numericUpDown15.Value = 0;
                numericUpDown14.Value = 0;
                numericUpDown13.Value = 0;
                numericUpDown12.Value = 0;
            }

            if (numericUpDown1.Value == 4)
            {
                groupBox2.Text = "TOP";
                groupBox3.Text = "INT1";
                groupBox4.Text = "INT2";
                groupBox5.Text = "BOT";

                label76.Text = "TOP";
                label77.Text = "INT1";
                label78.Text = "INT2";
                label79.Text = "BOT";

                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                groupBox5.Visible = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;
            }
        }

        //Кнопка "Принять"
        private void button1_Click(object sender, EventArgs e)
        {

            if (numericUpDown1.Value == 1)
            {
                groupBox2.Text = "";
                groupBox3.Text = "";
                groupBox4.Text = "";
                groupBox5.Text = "";
                f_PCB_width = numericUpDown2.Value + numericUpDown3.Value + numericUpDown4.Value + numericUpDown5.Value + numericUpDown6.Value;        
            }
            if (numericUpDown1.Value == 2)
            {
                groupBox2.Text = "TOP";
                groupBox3.Text = "BOT";
                groupBox4.Text = "";
                groupBox5.Text = "";
                f_PCB_width = numericUpDown2.Value + numericUpDown3.Value + numericUpDown4.Value + numericUpDown5.Value + numericUpDown6.Value + numericUpDown7.Value + numericUpDown8.Value + numericUpDown9.Value + numericUpDown10.Value + numericUpDown11.Value;
            }
            if (numericUpDown1.Value == 3)
            {
                groupBox2.Text = "TOP";
                groupBox3.Text = "INT1";
                groupBox4.Text = "BOT";
                groupBox5.Text = "";
                f_PCB_width = numericUpDown2.Value + numericUpDown3.Value + numericUpDown4.Value + numericUpDown5.Value + numericUpDown6.Value + numericUpDown7.Value + numericUpDown8.Value + numericUpDown9.Value + numericUpDown10.Value + numericUpDown11.Value + numericUpDown17.Value + numericUpDown18.Value + numericUpDown19.Value + numericUpDown20.Value + numericUpDown21.Value;
            }
            if (numericUpDown1.Value == 4)
            {
                groupBox2.Text = "TOP";
                groupBox3.Text = "INT1";
                groupBox4.Text = "INT2";
                groupBox5.Text = "BOT";
                f_PCB_width = numericUpDown2.Value + numericUpDown3.Value + numericUpDown4.Value + numericUpDown5.Value + numericUpDown6.Value + numericUpDown7.Value + numericUpDown8.Value + numericUpDown9.Value + numericUpDown10.Value + numericUpDown11.Value + numericUpDown12.Value + numericUpDown13.Value + numericUpDown14.Value + numericUpDown15.Value + numericUpDown16.Value + numericUpDown17.Value + numericUpDown18.Value + numericUpDown19.Value + numericUpDown20.Value + numericUpDown21.Value;
            }


            //Проверяем, не отрицательная ли толщина ГПП
            if (f_PCB_width >= 0)
            {
                label30.Text = String.Format("Суммарная толщина ГПП = {0} мкм", f_PCB_width);
            }

            //Визуализация 
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
            button2.Enabled = true;

            //LEGEND
            //Проводник
            System.Drawing.Pen myPen1;
            myPen1 = new System.Drawing.Pen(System.Drawing.Color.OrangeRed, 10);
            System.Drawing.Graphics formGraphics1 = panel2.CreateGraphics();
            formGraphics1.DrawLine(myPen1, 247, 34, 550, 34);
            myPen1.Dispose();
            formGraphics1.Dispose();

            //Базовый
            System.Drawing.Pen myPen2;
            myPen2 = new System.Drawing.Pen(System.Drawing.Color.Yellow, 10);
            System.Drawing.Graphics formGraphics2 = panel2.CreateGraphics();
            formGraphics2.DrawLine(myPen2, 247, 71, 550, 71);
            myPen2.Dispose();
            formGraphics2.Dispose();

            //Адгезив
            System.Drawing.Pen myPen3;
            myPen3 = new System.Drawing.Pen(System.Drawing.Color.Blue, 10);
            System.Drawing.Graphics formGraphics3 = panel2.CreateGraphics();
            formGraphics3.DrawLine(myPen3, 247, 110, 550, 110);
            myPen3.Dispose();
            formGraphics3.Dispose();

            //Препрег
            System.Drawing.Pen myPen4;
            myPen4 = new System.Drawing.Pen(System.Drawing.Color.Red, 10);
            System.Drawing.Graphics formGraphics4 = panel2.CreateGraphics();
            formGraphics4.DrawLine(myPen4, 247, 145, 550, 145);
            myPen4.Dispose();
            formGraphics4.Dispose();

            //Маска
            System.Drawing.Pen myPen5;
            myPen5 = new System.Drawing.Pen(System.Drawing.Color.Green, 10);
            System.Drawing.Graphics formGraphics5 = panel2.CreateGraphics();
            formGraphics5.DrawLine(myPen5, 247, 184, 550, 184);
            myPen5.Dispose();
            formGraphics5.Dispose();


            //Визуализация выбранных параметров
            //Получаем название типа слоя

            //Проводники
            string n1 = (string)comboBox1.SelectedItem;
            string n2 = (string)comboBox10.SelectedItem;
            string n3 = (string)comboBox20.SelectedItem;
            string n4 = (string)comboBox15.SelectedItem;

            //Материалы
            string n5 = (string)comboBox2.SelectedItem;
            string n6 = (string)comboBox9.SelectedItem;
            string n7 = (string)comboBox19.SelectedItem;
            string n8 = (string)comboBox14.SelectedItem;

            //Адгезивы
            string n9 = (string)comboBox4.SelectedItem;
            string n10 = (string)comboBox8.SelectedItem;
            string n11 = (string)comboBox18.SelectedItem;
            string n12 = (string)comboBox13.SelectedItem;

            //Препреги
            string n13 = (string)comboBox3.SelectedItem;
            string n14 = (string)comboBox7.SelectedItem;
            string n15 = (string)comboBox17.SelectedItem;
            string n16 = (string)comboBox12.SelectedItem;

            //Маски
            string n17 = (string)comboBox5.SelectedItem;
            string n18 = (string)comboBox6.SelectedItem;
            string n19 = (string)comboBox16.SelectedItem;
            string n20 = (string)comboBox11.SelectedItem;

            //Блок визуализации проводника первого слоя МАГИЯ, НЕ ТРОГАТЬ!!!!!!!!!! Их 20 штук :( 
            //ПРОВОДНИКИ:
            //Проводник 1
            if (n1 != "Отсутствует" && n1 != "Проводник" && comboBox1.Text != "" && numericUpDown2.Value != 0)
            {
                label36.Text = n1;
                label56.Text = String.Format("{0} мкм", numericUpDown2.Value);

                System.Drawing.Pen p1;
                p1 = new System.Drawing.Pen(System.Drawing.Color.OrangeRed, 10);
                System.Drawing.Graphics visual1 = panel1.CreateGraphics();
                visual1.DrawLine(p1, 247, 27, 550, 27);
                p1.Dispose();
                visual1.Dispose();
            }
            //Проводник 2
            if (n2 != "Отсутствует" && n2 != "Проводник" && comboBox10.Text != "" && numericUpDown11.Value != 0)
            {
                label41.Text = n2;
                label61.Text = String.Format("{0} мкм", numericUpDown11.Value);

                System.Drawing.Pen p2;
                p2 = new System.Drawing.Pen(System.Drawing.Color.OrangeRed, 10);
                System.Drawing.Graphics visual2 = panel1.CreateGraphics();
                visual2.DrawLine(p2, 247, 92, 550, 92);
                p2.Dispose();
                visual2.Dispose();
            }
            //Проводник 3
            if (n3 != "Отсутствует" && n3 != "Проводник" && comboBox20.Text != "" && numericUpDown21.Value != 0)
            {
                label46.Text = n3;
                label66.Text = String.Format("{0} мкм", numericUpDown21.Value);

                System.Drawing.Pen p3;
                p3 = new System.Drawing.Pen(System.Drawing.Color.OrangeRed, 10);
                System.Drawing.Graphics visual3 = panel1.CreateGraphics();
                visual3.DrawLine(p3, 247, 157, 550, 157);
                p3.Dispose();
                visual3.Dispose();
            }
            //Проводник 4
            if (n4 != "Отсутствует" && n4 != "Проводник" && comboBox15.Text != "" && numericUpDown16.Value != 0)
            {
                label51.Text = n4;
                label71.Text = String.Format("{0} мкм", numericUpDown16.Value);

                System.Drawing.Pen p4;
                p4 = new System.Drawing.Pen(System.Drawing.Color.OrangeRed, 10);
                System.Drawing.Graphics visual4 = panel1.CreateGraphics();
                visual4.DrawLine(p4, 247, 222, 550, 222);
                p4.Dispose();
                visual4.Dispose();
            }
            
            //МАТЕРИАЛЫ:
            //Материал1
            if (n5 != "Отсутствует" && n5 != "Базовый" && comboBox2.Text != "" && numericUpDown3.Value != 0)
            {
                label37.Text = n5;
                label57.Text = String.Format("{0} мкм", numericUpDown3.Value);

                System.Drawing.Pen p5;
                p5 = new System.Drawing.Pen(System.Drawing.Color.Yellow, 10);
                System.Drawing.Graphics visual5 = panel1.CreateGraphics();
                visual5.DrawLine(p5, 247, 40, 550, 40);
                p5.Dispose();
                visual5.Dispose();
            }
            //Материал2
            if (n6 != "Отсутствует" && n6 != "Базовый" && comboBox9.Text != "" && numericUpDown10.Value != 0)
            {
                label42.Text = n6;
                label62.Text = String.Format("{0} мкм", numericUpDown10.Value);

                System.Drawing.Pen p6;
                p6 = new System.Drawing.Pen(System.Drawing.Color.Yellow, 10);
                System.Drawing.Graphics visual6 = panel1.CreateGraphics();
                visual6.DrawLine(p6, 247, 105, 550, 105);
                p6.Dispose();
                visual6.Dispose();
            }
            //Материал3
            if (n7 != "Отсутствует" && n7 != "Базовый" && comboBox19.Text != "" && numericUpDown20.Value != 0)
            {
                label47.Text = n7;
                label67.Text = String.Format("{0} мкм", numericUpDown20.Value);

                System.Drawing.Pen p7;
                p7 = new System.Drawing.Pen(System.Drawing.Color.Yellow, 10);
                System.Drawing.Graphics visual7 = panel1.CreateGraphics();
                visual7.DrawLine(p7, 247, 170, 550, 170);
                p7.Dispose();
                visual7.Dispose();
            }
            //Материал4
            if (n8 != "Отсутствует" && n8 != "Базовый" && comboBox14.Text != "" && numericUpDown15.Value != 0)
            {
                label52.Text = n8;
                label72.Text = String.Format("{0} мкм", numericUpDown15.Value);

                System.Drawing.Pen p8;
                p8 = new System.Drawing.Pen(System.Drawing.Color.Yellow, 10);
                System.Drawing.Graphics visual8 = panel1.CreateGraphics();
                visual8.DrawLine(p8, 247, 235, 550, 235);
                p8.Dispose();
                visual8.Dispose();
            }

            //АДГЕЗИВЫ:
            //Адгезив1
            if (n9 != "Отсутствует" && n9 != "Адгезив" && comboBox4.Text != "" && numericUpDown4.Value != 0)
            {
                label38.Text = n9;
                label58.Text = String.Format("{0} мкм", numericUpDown4.Value);

                System.Drawing.Pen p9;
                p9 = new System.Drawing.Pen(System.Drawing.Color.Blue, 10);
                System.Drawing.Graphics visual9 = panel1.CreateGraphics();
                visual9.DrawLine(p9, 247, 53, 550, 53);
                p9.Dispose();
                visual9.Dispose();
            }
            //Адгезив2
            if (n10 != "Отсутствует" && n10 != "Адгезив" && comboBox8.Text != "" && numericUpDown9.Value != 0)
            {
                label43.Text = n10;
                label63.Text = String.Format("{0} мкм", numericUpDown9.Value);

                System.Drawing.Pen p10;
                p10 = new System.Drawing.Pen(System.Drawing.Color.Blue, 10);
                System.Drawing.Graphics visual10 = panel1.CreateGraphics();
                visual10.DrawLine(p10, 247, 118, 550, 118);
                p10.Dispose();
                visual10.Dispose();
            }
            //Адгезив3
            if (n11 != "Отсутствует" && n11 != "Адгезив" && comboBox18.Text != "" && numericUpDown19.Value != 0)
            {
                label48.Text = n11;
                label68.Text = String.Format("{0} мкм", numericUpDown19.Value);

                System.Drawing.Pen p11;
                p11 = new System.Drawing.Pen(System.Drawing.Color.Blue, 10);
                System.Drawing.Graphics visual11 = panel1.CreateGraphics();
                visual11.DrawLine(p11, 247, 183, 550, 183);
                p11.Dispose();
                visual11.Dispose();
            }
            //Адгезив4
            if (n12 != "Отсутствует" && n12 != "Адгезив" && comboBox13.Text != "" && numericUpDown14.Value != 0)
            {
                label53.Text = n12;
                label73.Text = String.Format("{0} мкм", numericUpDown14.Value);

                System.Drawing.Pen p12;
                p12 = new System.Drawing.Pen(System.Drawing.Color.Blue, 10);
                System.Drawing.Graphics visual12 = panel1.CreateGraphics();
                visual12.DrawLine(p12, 247, 248, 550, 248);
                p12.Dispose();
                visual12.Dispose();
            }

            //ПРЕПРЕГИ:
            //Препрег1
            if (n13 != "Отсутствует" && n13 != "Препрег" && comboBox3.Text != "" && numericUpDown5.Value != 0)
            {
                label39.Text = n13;
                label59.Text = String.Format("{0} мкм", numericUpDown5.Value);

                System.Drawing.Pen p13;
                p13 = new System.Drawing.Pen(System.Drawing.Color.Red, 10);
                System.Drawing.Graphics visual13 = panel1.CreateGraphics();
                visual13.DrawLine(p13, 247, 66, 550, 66);
                p13.Dispose();
                visual13.Dispose();
            }
            //Препрег2
            if (n14 != "Отсутствует" && n14 != "Препрег" && comboBox7.Text != "" && numericUpDown8.Value != 0)
            {
                label44.Text = n14;
                label64.Text = String.Format("{0} мкм", numericUpDown8.Value);

                System.Drawing.Pen p14;
                p14 = new System.Drawing.Pen(System.Drawing.Color.Red, 10);
                System.Drawing.Graphics visual14 = panel1.CreateGraphics();
                visual14.DrawLine(p14, 247, 130, 550, 130);
                p14.Dispose();
                visual14.Dispose();
            }
            //Препрег3
            if (n15 != "Отсутствует" && n15 != "Препрег" && comboBox17.Text != "" && numericUpDown18.Value != 0)
            {
                label49.Text = n15;
                label69.Text = String.Format("{0} мкм", numericUpDown18.Value);

                System.Drawing.Pen p15;
                p15 = new System.Drawing.Pen(System.Drawing.Color.Red, 10);
                System.Drawing.Graphics visual15 = panel1.CreateGraphics();
                visual15.DrawLine(p15, 247, 196, 550, 196);
                p15.Dispose();
                visual15.Dispose();
            }
            //Препрег4
            if (n16 != "Отсутствует" && n16 != "Препрег" && comboBox12.Text != "" && numericUpDown13.Value != 0)
            {
                label54.Text = n16;
                label74.Text = String.Format("{0} мкм", numericUpDown13.Value);

                System.Drawing.Pen p16;
                p16 = new System.Drawing.Pen(System.Drawing.Color.Red, 10);
                System.Drawing.Graphics visual16 = panel1.CreateGraphics();
                visual16.DrawLine(p16, 247, 261, 550, 261);
                p16.Dispose();
                visual16.Dispose();
            }
            //МАСКИ:
            //Маска1
            if (n17 != "Отсутствует" && n17 != "Маска" && comboBox5.Text != "" && numericUpDown6.Value != 0)
            {
                label40.Text = n17;
                label60.Text = String.Format("{0} мкм", numericUpDown6.Value);

                System.Drawing.Pen p17;
                p17 = new System.Drawing.Pen(System.Drawing.Color.Green, 10);
                System.Drawing.Graphics visual17 = panel1.CreateGraphics();
                visual17.DrawLine(p17, 247, 79, 550, 79);
                p17.Dispose();
                visual17.Dispose();
            }
            //Маска2
            if (n18 != "Отсутствует" && n18 != "Маска" && comboBox6.Text != "" && numericUpDown7.Value != 0)
            {
                label45.Text = n18;
                label65.Text = String.Format("{0} мкм", numericUpDown7.Value);

                System.Drawing.Pen p18;
                p18 = new System.Drawing.Pen(System.Drawing.Color.Green, 10);
                System.Drawing.Graphics visual18 = panel1.CreateGraphics();
                visual18.DrawLine(p18, 247, 143, 550, 143);
                p18.Dispose();
                visual18.Dispose();
            }
            //Маска3
            if (n19 != "Отсутствует" && n19 != "Маска" && comboBox16.Text != "" && numericUpDown17.Value != 0)
            {
                label50.Text = n19;
                label70.Text = String.Format("{0} мкм", numericUpDown17.Value);

                System.Drawing.Pen p19;
                p19 = new System.Drawing.Pen(System.Drawing.Color.Green, 10);
                System.Drawing.Graphics visual19 = panel1.CreateGraphics();
                visual19.DrawLine(p19, 247, 209, 550, 209);
                p19.Dispose();
                visual19.Dispose();
            }
            //Маска4
            if (n20 != "Отсутствует" && n20 != "Маска" && comboBox11.Text != "" && numericUpDown12.Value != 0)
            {
                label55.Text = n20;
                label75.Text = String.Format("{0} мкм", numericUpDown12.Value);

                System.Drawing.Pen p20;
                p20 = new System.Drawing.Pen(System.Drawing.Color.Green, 10);
                System.Drawing.Graphics visual20 = panel1.CreateGraphics();
                visual20.DrawLine(p20, 247, 274, 550, 274);
                p20.Dispose();
                visual20.Dispose();
            }




            // Если указано базовое значение элементов ComboBox - ничего не выводим!
            if (comboBox1.Text == "Проводник" || numericUpDown2.Value == 0) 
            {
                label36.Text = "";
                label56.Text = "";
            }
            if (comboBox10.Text == "Проводник" || numericUpDown11.Value == 0)
            {
                label41.Text = "";
                label61.Text = "";
            }
            if (comboBox20.Text == "Проводник" || numericUpDown21.Value == 0)
            {
                label46.Text = "";
                label66.Text = "";
            }
            if (comboBox15.Text == "Проводник" || numericUpDown16.Value == 0)
            {
                label51.Text = "";
                label71.Text = "";
            }

            if (comboBox2.Text == "Базовый" || numericUpDown3.Value == 0)
            {
                label37.Text = "";
                label57.Text = "";
            }
            if (comboBox9.Text == "Базовый" || numericUpDown10.Value == 0)
            {
                label42.Text = "";
                label62.Text = "";
            }
            if (comboBox19.Text == "Базовый" || numericUpDown20.Value == 0)
            {
                label47.Text = "";
                label67.Text = "";
            }
            if (comboBox14.Text == "Базовый" || numericUpDown15.Value == 0)
            {
                label52.Text = "";
                label72.Text = "";
            }

            if (comboBox4.Text == "Адгезив" || numericUpDown4.Value == 0)   
            {
                label38.Text = "";
                label58.Text = "";
            }
            if (comboBox8.Text == "Адгезив" || numericUpDown9.Value == 0)
             {
                label43.Text = "";
                label63.Text = "";
             }
            if (comboBox18.Text == "Адгезив" || numericUpDown19.Value == 0)
            {
                label48.Text = "";
                label68.Text = "";
            }
            if (comboBox13.Text == "Адгезив" || numericUpDown14.Value == 0)
            {
                label53.Text = "";
                label73.Text = "";
            }

            if (comboBox3.Text == "Препрег" || numericUpDown5.Value == 0)   
            {
                label39.Text = "";
                label59.Text = "";
            }
            if (comboBox7.Text == "Препрег" || numericUpDown8.Value == 0)
            {
                label44.Text = "";
                label64.Text = "";
            }
            if (comboBox17.Text == "Препрег" || numericUpDown18.Value == 0)
            {
                label49.Text = "";
                label69.Text = "";
            }
            if (comboBox12.Text == "Препрег" || numericUpDown13.Value == 0)
            {
                label54.Text = "";
                label74.Text = "";
            }

            if (comboBox5.Text == "Маска" || numericUpDown6.Value == 0)     
            {
                label40.Text = "";
                label60.Text = "";
            }
            if (comboBox6.Text == "Маска" || numericUpDown7.Value == 0)
            {
                label45.Text = "";
                label65.Text = "";
            }
            if (comboBox16.Text == "Маска" || numericUpDown17.Value == 0)
            {
                label50.Text = "";
                label70.Text = "";
            }
            if (comboBox11.Text == "Маска" || numericUpDown12.Value == 0)
            {
                label55.Text = "";
                label75.Text = "";
            }

            label1.Visible = false;
            numericUpDown1.Visible = false;

        }

        //Кнопка "Вернуться"
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            numericUpDown1.Visible = true;

            panel1.Refresh();
            panel1.Visible = false;
            panel2.Visible = false;

           // button1.Enabled = true;
            button2.Enabled = false;


            if (numericUpDown1.Value == 1)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
            }
            if (numericUpDown1.Value == 2)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
            }
            if (numericUpDown1.Value == 3)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                groupBox5.Visible = false;
            }
            if (numericUpDown1.Value == 4)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                groupBox5.Visible = true;
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PDF_Reader pdf_read = new PDF_Reader();
            pdf_read.Show();
        }
    }
}