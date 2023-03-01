using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie2
{
    class Subcscriber
    {
        private int id;
        private string adress;
        public int long_distance_call_time, short_distance_call_time;
        public string name, surname, otchestvo;
        private double debet, credit;
        public int GetID()
        {
            return id;
        }
        public double GetDebet()
        {
            return debet;
        }
        public double GetCredit()
        {
            return credit;
        }
        public string GetAdress()
        {
            return adress;
        }
        public Subcscriber() { }
        public Subcscriber(int id, double debet, double credit, int long_distance_call_time, int short_distance_call_time, string adress, string name, string surname, string otchestvo)
        {
            this.id = id;
            this.debet = debet;
            this.credit = credit;
            this.long_distance_call_time = long_distance_call_time;
            this.short_distance_call_time = short_distance_call_time;
            this.adress = adress;
            this.name = name;
            this.surname = surname;
            this.otchestvo = otchestvo;
        }
        public bool SetID(int userid)
        {
            try
            {
                if (userid < 0)
                {
                    MessageBox.Show("id не может быть отрицательным");
                    return true;
                }
                else
                    id = userid;
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не число в id пользователя");
                return true;
            }

        }
        public bool SetDebet(double userdebet)
        {

            try
            {
                debet = userdebet;
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не число в дебете");
                return true;
            }
        }
        public bool SetCredit(double usercredit)
        {
            try
            {
                if (usercredit < 0)
                {
                    MessageBox.Show("Кредит не может быть отрицательным");
                    return true;
                }
                else
                {
                    credit = usercredit;
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не число");
                return true;
            }

        }
        public bool SetCall(int calltime, int k)
        {
            try
            {
                if (calltime < 0)
                {
                    MessageBox.Show("Длительность звонка не может быть меньше нуля");
                    return true;
                }
                else
                {
                    if (k == 1)
                        long_distance_call_time = calltime;
                    else
                        short_distance_call_time = calltime;
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не число");
                return true;
            }
        }
        public bool CheckFIO(string username, int k)
        {

            bool check = false;
            if (username.Length == 0)
            {
                MessageBox.Show("Вы ввели пустую строку");
                return true;
            }
            else
            {
                for (int i = 0; i < username.Length; i++)
                {
                    if (!char.IsLetter(username[i]))
                        check = true;
                }
                if (check == true)
                {
                    MessageBox.Show("Имя, отчество и фамилия должны состоять только из букв");
                    return true;
                }
                else
                {
                    username.ToLower();
                    char.ToUpper(username[0]);
                    if (k == 1)
                        name = username;
                    else if (k == 2)
                        surname = username;
                    else if (k == 3)
                        otchestvo = username;
                    return false;
                }
            }

        }
        public bool SetAdress(string city, string street, int number_of_home)
        {
            try
            {
                int max_number_of_letters;
                if (city.Length < street.Length)
                    max_number_of_letters = street.Length;
                else
                    max_number_of_letters = city.Length;
                bool check_city = false;
                bool check_street = false;

                for (int i = 0; i < max_number_of_letters; i++)
                {
                    if (city.Length > i)
                    {
                        if (!char.IsLetter(city[i]))
                            check_city = true;
                    }
                    if (street.Length > i)
                    {
                        if (!char.IsLetter(street[i]))
                            check_street = true;
                    }
                }
                if (check_city == true)
                {
                    MessageBox.Show("В название города могут быть только буквы");
                    return true;
                }
                else if (check_street == true)
                {
                    MessageBox.Show("В названии улицы могут быть толкьо буквы");
                    return true;
                }
                else if (number_of_home <= 0)
                {
                    MessageBox.Show("Номер дома не может быть меньше или равен нулю");
                    return true;
                }
                else
                {
                    adress = $"Город {city}, улица {street}, дом номер {number_of_home}";
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не число");
                return true;
            }
        }

    }
}
