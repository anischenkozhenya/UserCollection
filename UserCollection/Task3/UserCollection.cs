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
        public int Count = 0;
        int position = -1;
        int pensionerLast = -1;
        public object Current { get; }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < citizens.Length)
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
            if (citizens.Length == 0)
            {
                citizens = new Citizen[citizens.Length + 1];
                citizens[citizens.Length - 1] = citizen;
                if (citizen.GetType().ToString() == typeof(Pensioner).ToString())
                {
                    pensionerLast++;
                }
                Count++;
            }
            else
            {
                if (Method(citizen))
                {
                    citizens = new Citizen[citizens.Length + 1];
                    if (citizen.GetType().ToString() == typeof(Pensioner).ToString())
                    {
                        if (pensionerLast>=0)
                        {
                            Citizen[] before;
                            Citizen[] after;
                        }
                        else
                        {
                            for (int i = 1; i < citizens.Length - 1; i++)
                            {
                                citizens[i] = temp[i-1];
                            }
                            citizens[0] = citizen;
                        }
                        Count++;
                        pensionerLast++;
                    }
                    else
                    {
                        for (int i = 0; i < citizens.Length - 1; i++)
                        {
                            citizens[i] = temp[i];
                        }
                        citizens[citizens.Length - 1] = citizen;
                        Count++;
                    }
                }
                else
                {
                    Console.WriteLine("Такой пользователь уже существует");
                }

            }
        }

        private bool Method(Citizen citizen)
        {
            for (int i = 0; i < citizens.Length; i++)
            {
                if (citizen.Id == citizens[i].Id)
                {
                    return false;
                }
            }
            return true;

        }

        public void Delete(Citizen citizen)
        {
            if (citizen.GetType().ToString() == typeof(Pensioner).ToString())
            {
                Count--;
            }
        }
    }
}
