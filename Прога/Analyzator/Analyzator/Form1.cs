using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyzator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button_analyze_Click(object sender, EventArgs e)
        {
            listBox_massiv.Items.Clear();

            int position = 0;
            label4.Visible = true;
            label5.Visible = false;
            result.Visible = false;

            try
            {
                string resStr = Validator.OperatorValidator(TextBox_InputOperator.Text.ToLower(), ref position);
                
                result.Visible = true;
                result.Text = resStr;
                label5.Text = "Данный оператор соответствует языку.";
                label4.Visible = false;
                MessageBox.Show("Данный оператор соответствует языку.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentNullException ex)
            {
                label4.Text = ex.Message;
                label4.ForeColor = Color.Red;
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                HighlightErrorSymbol(position - 1);
                label4.Text = ex.Message;
                label4.ForeColor = Color.Red;
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                HighlightErrorSymbol(position - 1);
                label4.Text = ex.Message;
                label4.ForeColor = Color.Red;
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightErrorSymbol(int i)
        {
            TextBox_InputOperator.SelectionStart = i;
            TextBox_InputOperator.SelectionLength = 1;
            TextBox_InputOperator.Focus();
        }

        private void text_analyze_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListView_Variables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }   



        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FORMAT(<список элементов>)\r\n\n" +
                "<список элементов> :: = <элемент>|<список элементов>,<элемент>\r\n\n" +
                "<элемент> :: = <константа>X |  ’текст’   |  I<константа>|  F<константа 1>.<константа 2> | /\r\n\n" +
                "<константа>,<константа 1>,<константа 2> - натуральные числа;\r\n\n" +
                "/ -переход на новую строку;\r\n\n" +
                "’текст’ -текст;\r\n\n" +
                "X – пробелы, обозначаются подчеркиванием;\r\n\n" +
                "F – обозначение места для знака числа;\r\n\n" +
                "I – обозначение места для цифры.\r\n\n",
                "Формат", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {                         
            MessageBox.Show("Семантика:\r\n" +
                "Натуральное число находится в диапазоне 1 - 256\r\n\n" +
                "Длина текста не может быть более 50 символов\r\n\n" +
                "Количество знаков перевода строки(/) не превышает 3 и <константа 1> больше <константа 2>+2\r\n\n" +
                "Количество знаков перевода строки(/) не превышает 3\r\n" +
                "и <константа 1> больше <константа 2>+2.\r\n\n\n" +


                "Осуществить вывод на экран по заданному формату:\r\n\n" +
                "/ -переход на новую строку;\r\n" +
                "’текст’ -текст;\r\n" +
                " X – пробелы, обозначаются подчеркиванием;\r\n" +
                "F – обозначение места для знака числа;\r\n" +
                "I – обозначение места для цифры.\r\n",
                "Семантика", MessageBoxButtons.OK);
        }

        private void listBox_ident_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox_InputOperator.Clear();
            HighlightErrorSymbol(0);
        }
    }
}
