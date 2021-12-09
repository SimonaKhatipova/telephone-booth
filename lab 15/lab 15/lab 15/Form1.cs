using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_15
{
    public partial class Form1 : Form
    {
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            isTrubkaOn = !isTrubkaOn;
            if (isTrubkaOn)
            {
                button12.Image = Properties.Resources.трубка_on1;
                
            }
            else
            {
                button12.Image = Properties.Resources.трубка_офф;
                 textBox1.Clear();
                Reboot();
            }
           
        }
      

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
                MessageBox.Show("Пик-пик (вот-вот начнется общение)");
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
            
            
            if (isTrubkaOn==false)
            {
                timer1.Stop();
                timer1.Enabled = false;
                textBox1.Text = timer1.ToString();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
