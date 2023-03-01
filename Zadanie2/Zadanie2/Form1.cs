using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie2
{
    public partial class Form1 : Form
    {
        string[,] meow = new string[10, 9];
        int i=0;
        public Form1()
        {
            InitializeComponent();
            label15.Text = $"Введите данные для абонента номер {i + 1}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label15.Text = $"Введите данные для абонента номер {i + 1}";
            try
            {
                if (i < 10) {
                    Subcscriber subcscriber = new Subcscriber();
                    if (!subcscriber.SetID(int.Parse(textBox4.Text)) && !subcscriber.SetDebet(int.Parse(textBox5.Text)) && !subcscriber.CheckFIO(textBox1.Text)
                        && !subcscriber.CheckFIO(textBox2.Text) && !subcscriber.CheckFIO(textBox3.Text) && !subcscriber.SetCredit(double.Parse(textBox6.Text)) && !subcscriber.SetCall(int.Parse(textBox7.Text)) && !subcscriber.SetCall(int.Parse(textBox8.Text)) && !subcscriber.SetAdress(textBox9.Text, textBox10.Text, int.Parse(textBox11.Text)))
                    {
                        meow[i, 0] = subcscriber.name;
                        meow[i, 1] = subcscriber.surname;
                        meow[i, 2] = subcscriber.otchestvo;
                        meow[i, 3] = subcscriber.GetID().ToString();
                        meow[i, 4] = subcscriber.GetDebet().ToString();
                        meow[i, 5] = subcscriber.GetCredit().ToString();
                        meow[i, 6] = subcscriber.long_distance_call_time.ToString();
                        meow[i, 7] = subcscriber.short_distance_call_time.ToString();
                        meow[i, 8] = subcscriber.GetAdress().ToString();
                        i++;
                        label15.Text = $"Введите данные для абонента номер {i + 1}";
                    }
                }
                else
                {
                    textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled = textBox8.Enabled = textBox9.Enabled = textBox10.Enabled = textBox11.Enabled = false;
                    button1.Visible = label15.Visible = false;
                    button2.Visible = label12.Visible = label13.Visible = label14.Visible = textBox12.Visible = textBox13.Visible = true;
                    
                }
                    
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не число в одно из полей");
            }

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox12.Text) < 10 && int.Parse(textBox12.Text) >= 0 && int.Parse(textBox13.Text) >= 0 && int.Parse(textBox13.Text) <= 8)
                label14.Text = $"{meow[int.Parse(textBox12.Text), int.Parse(textBox13.Text)]}";
            else
                MessageBox.Show("такого пользователя или такой строки с данными нет");
        }
    }
}
