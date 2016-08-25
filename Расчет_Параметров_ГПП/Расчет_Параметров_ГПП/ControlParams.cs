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

namespace Расчет_Параметров_ГПП
{
    public partial class ControlParams : Form
    {
        public ControlParams()
        {
            InitializeComponent();
        }


        //Метод для экспорта в EXCEL
        private void ExportToExcel()
        {
            ExcelPS.Application exApp = new ExcelPS.Application();
            exApp.Workbooks.Add();
            exApp.Visible = true;
            Worksheet workSheet = (Worksheet)exApp.ActiveSheet;

            workSheet.Cells[1, 1] = "Операция";
            workSheet.Cells[1, 2] = "Наименование";
            workSheet.Cells[1, 3] = "Метод / Оборудование";
            workSheet.Cells[1, 4] = "Частота проверки образца";
            
            int rowExcel = 2;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                workSheet.Cells[rowExcel, "A"] = dataGridView1.Rows[i].Cells["Operation"].Value;
                workSheet.Cells[rowExcel, "B"] = dataGridView1.Rows[i].Cells["Name"].Value;
                workSheet.Cells[rowExcel, "C"] = dataGridView1.Rows[i].Cells["Method"].Value;
                workSheet.Cells[rowExcel, "D"] = dataGridView1.Rows[i].Cells["Proverka"].Value;
               
                ++rowExcel;
            }

        }
        private void ControlParams_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Operation", "Операция");
            dataGridView1.Columns.Add("Name", "Наименование");
            dataGridView1.Columns.Add("Method", "Метод / Оборудование");
            dataGridView1.Columns.Add("Proverka", "Частота проверки образца");

            dataGridView1.Rows.Add("Раскрой материала", "Размер заготовки; Толщина фольги", "Измерение размера; Прибор для замера толщины", "Каждая заготовка");
            dataGridView1.Rows.Add("Сверление", "Диаметр отверстия; Замасливание отверстий", "Калибровочный щуп; Визуальный осмотр", "Каждая заготовка");
            dataGridView1.Rows.Add("Очистка", "Плоская поверхность; Шероховатость", "Визуальный осмотр", "Каждая заготовка");
            dataGridView1.Rows.Add("Первичная металлизация отверстий", "Прямая металлизация; Анализ раствора; Толщина меди", "Визуальный осмотр; Омметр; Калориметр", "Каждая заготовка");
            dataGridView1.Rows.Add("Основная металлизация", "Напряжение и ток в ванне; Анализ электролита", "Вольтметр; Амперметр; Калориметр; Металлографический анализ", "Каждая заготовка");
            dataGridView1.Rows.Add("Травление", "Параметры рисунка проводников; Протравы; Подтравливание; Нависание", "Визуальный осмотр; Микроскоп; Металлографический анализ", "Каждая заготовка");
            dataGridView1.Rows.Add("Печатная схема", "Обрыв или короткое замыкание", "Электрический тестер; Визуальный осмотр", "Каждая заготовка");
            dataGridView1.Rows.Add("Паяльная маска", "Включения; Паста в отверстии; Цвет; Паста на контактной площадке", "Визуальный осмотр", "Каждая заготовка");
            dataGridView1.Rows.Add("Контактные покрытия", "Зачистка меди; Толщина; Разрыв или короткое замыкание; Инородный материал в покрытии; Свинец в золочении", "Визуальный осмотр Рентгеноспектральный анализ", "Каждая заготовка");
            dataGridView1.Rows.Add("Маркировка", "Четкость маркировки", "Визуальный осмотр", "Каждая заготовка");
            dataGridView1.Rows.Add("Обработка по контуру", "Размер; Дефекты края; Шероховатость края", "Инструмент для измерения размера; Визуальный осмотр", "Каждая заготовка");
            dataGridView1.Rows.Add("Скрайбирование", "Конфигурация скрайбирования; Глубина скрайбирования", "Визуальный осмотр", "Каждая заготовка");
            dataGridView1.Rows.Add("Контроль отверстий", "Наличие всех отверстий; Качество металлизации; Совмещение; Диаметр отверстия", "Счетчик отверстий; Металлографический анализ; Калибры для отверстий", "Каждая заготовка");
            dataGridView1.Rows.Add("Упаковка и отправка", "Имя заказчика, Номер заказа; Проверка содержимого поставки; Количество", "Визуальный осмотр; Проверка количества", "Каждая заготовка");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}
