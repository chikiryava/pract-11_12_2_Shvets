using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie2
{
    public partial class Form1 : Form
    {
        string[,] meow = new string[3, 9];
        int i = 0;
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
            try
            {
                Subcscriber subcscriber = new Subcscriber();
                if (!subcscriber.SetID(int.Parse(textBox4.Text)) && !subcscriber.SetDebet(int.Parse(textBox5.Text)) && !subcscriber.CheckFIO(textBox1.Text, 1)
                    && !subcscriber.CheckFIO(textBox2.Text, 2) && !subcscriber.CheckFIO(textBox3.Text, 3) && !subcscriber.SetCredit(double.Parse(textBox6.Text)) && !subcscriber.SetCall(int.Parse(textBox7.Text), 1) && !subcscriber.SetCall(int.Parse(textBox8.Text), 2) && !subcscriber.SetAdress(textBox9.Text, textBox10.Text, int.Parse(textBox11.Text)))
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
                    if (i >= meow.GetLength(0))
                    {
                        StopAdd();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не число в одно из полей");
            }

        }
        void LowerThenLimitOfCall(int limit)
        {
            label19.Text = "";
            for (int i = 0; i < meow.GetLength(0); i++)
            {
                if (int.Parse(meow[i, 7]) > limit)
                    label19.Text += $"{meow[i, 1]} {meow[i, 0]} {meow[i, 2]} {meow[i, 7]} минут\n";
            }
        }
        void UsedLongDistanceCall()
        {
            label20.Text = "Список людей, который пользовались междугородней связью";
            for (int i = 0; i < meow.GetLength(0); i++)
            {
                if (int.Parse(meow[i, 6]) > 0)
                    label20.Text += $"\n{meow[i, 1]} {meow[i, 0]} {meow[i, 2]} {meow[i, 6]} минут";
            }
        }
        public void StopAdd()
        {
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled = textBox8.Enabled = textBox9.Enabled = textBox10.Enabled = textBox11.Enabled = false;
            button1.Visible = label15.Visible = false;
            button2.Visible = label12.Visible = label13.Visible = label14.Visible = textBox12.Visible = textBox13.Visible = label17.Visible = label18.Visible = label19.Visible = label20.Visible =textBox14.Visible = true;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox12.Text, out int value) && int.TryParse(textBox13.Text, out int k))
            {
                if (int.Parse(textBox12.Text) - 1 < meow.GetLength(0) && int.Parse(textBox12.Text) - 1 >= 0 && int.Parse(textBox13.Text) - 1 >= 0 && int.Parse(textBox13.Text) - 1 < meow.GetLength(1))
                {
                    label14.Text = $"{meow[int.Parse(textBox12.Text) - 1, int.Parse(textBox13.Text) - 1]}";
                    UsedLongDistanceCall();
                    Sort();
                    if (int.TryParse(textBox14.Text, out var test))
                        LowerThenLimitOfCall(int.Parse(textBox14.Text));
                    else
                        MessageBox.Show("Вы ввели не число в графу лимит");
                }
                else
                    MessageBox.Show("такого пользователя или такой строки с данными нет");
            }
            else
                MessageBox.Show("вы ввели не число в строку информации о пользователе");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        void Sort()
        {
            label17.Text = "Список абонентов в алфавитном порядке:";
            string[] test = new string[meow.GetLength(0)];
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = meow[i, 1];
            }
            Array.Sort(test);
            for (int i = 0; i < test.Length; i++)
            {
                for (int j = 0; j < test.Length; j++)
                {
                    if (test[i] == meow[j, 1])
                    {
                        label17.Text += $"\n{meow[j, 1]} {meow[j, 0]} {meow[j, 2]}";
                    }
                }


            }
        }
    }
}
