using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
//количество дней в соответствующем месяце.Реализуйте возможность выбора месяцев, как по
//порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
//только один месяц.
namespace Task2
{
    class Calendar : IEnumerable, IEnumerator
    {
        readonly private int[] monthNum = {1,2,3,4,5,6,7,8,9,10,11,12};
        readonly private string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        readonly private int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int position = -1;
        public object Current
        {
            get { return monthNum[position]+" "+months[position] +" "+ days[position];}
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position<months.Length-1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
        public string GetMonthByNumber(int monthNumber)
        {
            if (monthNumber<=months.Length && 0<monthNumber)
            {
                return months[monthNumber-1];
            }
            else
            {
                Console.WriteLine("Неверные данные");
                return GetMonthByNumber(Int32.Parse(Console.ReadLine()));
            }
            
        }
        public List<string> GetMonthWithDays(int countDay)
        {
            List<string> monthByDays = new List<string>();
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i]== countDay)
                {
                    monthByDays.Add(months[i]);
                }
            }
            return monthByDays;
        }

        public int GetDaysInMonth(int monthNum)
        {
            int day = 0;
            foreach (var item in this.monthNum)
            {
                if (item==monthNum)
                {
                    day = days[item-1];
                }
            }
            return day;
        }
        public int GetDaysInMonth(string monthName)
        {
            int day = 0;
            for (int i = 0; i < months.Length; i++)
            {
                if (months[i]==monthName)
                {
                    day = days[i];
                }
            }
            return day;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Calendar calendar = new Calendar();
            foreach (var item in calendar)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(calendar.GetMonthByNumber(2));
            Console.WriteLine(new string('-',20));
            foreach (var item in calendar.GetMonthWithDays(30))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(calendar.GetDaysInMonth(12));
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(calendar.GetDaysInMonth("Май"));
            Console.WriteLine("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
            
        }
    }
}
