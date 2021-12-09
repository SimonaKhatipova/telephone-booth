using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab_15
{
    public partial class Form1 : Form
    {
        string phone_book_path = "PhoneBook.txt";
        string last_naumber;

        public bool isTrubkaOn = false;
        int NumbOfFigure = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NumbOfFigure < 3)
            {
                textBox1.Text += (sender as Button).Text;
                if (NumbOfFigure == 2)
                {
                    textBox2.Text = "Цифра";
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    NumbOfFigure++;
                }
                NumbOfFigure++;
            }
            last_naumber = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // трубка
        private void button12_Click(object sender, EventArgs e)
        {
            isTrubkaOn = !isTrubkaOn;
            if (isTrubkaOn)
            {
                button12.Image = Properties.Resources.трубка_on1;
                groupBox1.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                }
                if (isTrubkaOn) textBox1.Text = "Введите номер";
                else
                {
                    textBox1.Clear();
                }
             
                button12.Image = Properties.Resources.трубка_офф;
                textBox1.Clear();
                Reboot();
            }           

        }

        
        // отправить сигналы от атс
        private void button13_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                MessageBox.Show("Готов");
                textBox1.Clear();
                NumbOfFigure = 0;
                panel1.Enabled = true;
            }
            if (radioButton2.Checked)
            {
                timer1.Stop();
                timer1.Enabled = false;
                MessageBox.Show("Занято");
                textBox1.Clear();
                NumbOfFigure = 0;
            }
            if (radioButton3.Checked)
            {
                MessageBox.Show("Гудки, ответ получен.");
                radioButton3.Enabled = false;
                radioButton4.Enabled = true;
            }

            if (radioButton4.Checked)
            {
                //<разговор пошел>---
                radioButton4.Checked = false;
                radioButton4.Enabled = false;
                timer1.Enabled = true;
                timer1.Start();
                //---
            }

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            button13.Enabled = false;
            if (timer1.Enabled) radioButton2.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button13.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //textBox3.Text = "time";
            if (isTrubkaOn==false)
            {
                timer1.Stop();
                timer1.Enabled = false;
                textBox1.Text = "разговор закончен";
                Reboot();
            }
        }
        
        private void Reboot()
        {
            textBox2.Text = "Конец";
            panel1.Enabled = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ////построчное чтение

            //try
            //{
            //    StreamReader f = new StreamReader("Num.txt");
            //    string s;
            //    long i = 0;
            //    while ((s = f.ReadLine()) != null)
            //        Console.WriteLine(++i + ":" + s);
            //    f.Close();
            //}
            //catch { }// (FileNotFoundException e)
            ////{
            ////    Console.WriteLine(e.Message);
            ////    Console.WriteLine("Проверьте правильность имени файла!");
            ////    return;
            ////}

            System.Diagnostics.Process.Start(@"PhoneBook.txt");
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
            string num_to_add;
            if(textBox1.Text!="")
            {
                num_to_add = textBox1.Text;
                File.AppendAllText(phone_book_path, Environment.NewLine + num_to_add, Encoding.Default);
            }        
            MessageBox.Show("Номер добавлен", "Все оки", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = last_naumber;
        }

        //Удалить
        private void button16_Click(object sender, EventArgs e)
        {         
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines("PhoneBook.txt").Where(l => l != textBox1.Text);
            File.WriteAllLines(tempFile, linesToKeep);
            File.Delete("PhoneBook.txt");
            File.Move(tempFile, "PhoneBook.txt");
            MessageBox.Show("Номер удален", "Все оки", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
