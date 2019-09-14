using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class UserCollection : IEnumerable, IEnumerator
    {
        Citizen[] citizens = new Citizen[0];
        private int count = 0;
        public int Count { get { return count; } }
        int position = -1;
        int pensionerLast = 0;
        public object Current { get { return citizens[position]; } }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < citizens.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
        public void Add(Citizen citizen)
        {
            Citizen[] temp = citizens;
            int number = 0;
            if (citizens.Length == 0)
            {
                citizens = new Citizen[citizens.Length + 1];
                citizens[citizens.Length - 1] = citizen;
                number = citizens.Length - 1;
                if (citizen.GetType().ToString() == typeof(Pensioner).ToString())
                {
                    pensionerLast++;
                }
                count++;
                ShowAddCitizen(citizen, number);
            }
            else
            {
                if (!Contains(citizen, out int index))
                {
                    citizens = new Citizen[citizens.Length + 1];
                    if (citizen.GetType().ToString() == typeof(Pensioner).ToString())
                    {
                        if (pensionerLast >= 1)
                        {
                            Citizen[] before = new Citizen[pensionerLast];
                            Citizen[] after = new Citizen[temp.Length - pensionerLast];
                            for (int i = 0; i < pensionerLast; i++)
                            {
                                before[i] = temp[i];
                            }
                            for (int i = pensionerLast; i < after.Length + pensionerLast; i++)
                            {
                                after[i - pensionerLast] = temp[i];
                            }
                            for (int i = 0; i < before.Length; i++)
                            {
                                citizens[i] = before[i];
                            }
                            for (int i = 0; i < after.Length; i++)
                            {
                                citizens[i + pensionerLast + 1] = after[i];
                            }
                            citizens[pensionerLast] = citizen;
                            number = pensionerLast;
                        }
                        else
                        {
                            for (int i = 1; i < citizens.Length; i++)
                            {
                                citizens[i] = temp[i - 1];
                            }
                            citizens[0] = citizen;
                            number = 0;
                        }
                        count++;
                        pensionerLast++;
                    }
                    else
                    {
                        for (int i = 0; i < citizens.Length - 1; i++)
                        {
                            citizens[i] = temp[i];
                        }
                        citizens[citizens.Length - 1] = citizen;
                        number = citizens.Length - 1;
                        count++;
                    }
                    ShowAddCitizen(citizen, number);
                }
                else
                {
                    Console.WriteLine("Такой пользователь уже существует");
                }

            }
        }

        internal string ReturnLast()
        {
            return count.ToString() + " " + citizens[count - 1] + " " + citizens[count - 1].Id;
        }

        private void ShowAddCitizen(Citizen citizen, int number)
        {
            number = number + 1;
            Console.WriteLine("Добавлен " + citizen.GetType().ToString() + " номер паспорта " + citizen.Id + " стал в очередь " + number);

        }
        public void Delete()
        {
            Citizen[] temp = new Citizen[citizens.Length - 1];
            if (citizens[0].GetType().ToString() == typeof(Pensioner).ToString())
            {
                pensionerLast--;
            }
            for (int i = 1; i < citizens.Length; i++)
            {
                temp[i - 1] = citizens[i];
            }
            
            citizens = temp;
            count--;
        }
        public void Delete(Citizen citizen)
        {
            if (Contains(citizen, out int index))
            {
                int del = index;
                Citizen[] temp = new Citizen[citizens.Length - 1];
                for (int i = 0; i < del; i++)
                {
                    temp[i] = citizens[i];
                }
                for (int i = del + 1; i < citizens.Length; i++)
                {
                    temp[i - 1] = citizens[i];
                }
                citizens = temp;
                if (citizen.GetType().ToString() == typeof(Pensioner).ToString())
                {
                    pensionerLast--;
                }
                    count--;
            }
            else
            {
                Console.WriteLine("Нельзя удалить пользователя которого нету в коллекции");
            }
        }
        public void Clear()
        {
            citizens = new Citizen[0];
            count = 0;
            pensionerLast = 0;
        }
        public bool Contains(Citizen citizen, out int number)
        {
            number = 0;
            for (int i = 0; i < citizens.Length; i++)
            {
                number = i;
                if (citizen.Equals(citizens[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
