﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создайте абстрактный класс Гражданин.Создайте классы Студент, Пенсионер, Рабочий
//унаследованные от Гражданина. Создайте непараметризированную коллекцию со следующим
//функционалом:
//1. Добавление элемента в коллекцию.
//1) Можно добавлять только Гражданина.
//2) При добавлении, элемент добавляется в конец коллекции.Если Пенсионер, – то в
//начало с учетом ранее стоящих Пенсионеров. Возвращается номер в очереди.
//3) При добавлении одного и того же человека(проверка на равенство по номеру
//паспорта, необходимо переопределить метод Equals и/или операторы равенства для
//сравнения объектов по номеру паспорта) элемент не добавляется, выдается
//сообщение.
//2. Удаление
//1) Удаление – с начала коллекции.
//2) Возможно удаление с передачей экземпляра Гражданина.
//3. Метод Contains возвращает true/false при налчичии/отсутствии элемента в коллекции и
//номер в очереди.
//4. Метод ReturnLast возвращsает последнего человека в очереди и его номер в очереди.
//5. Метод Clear очищает коллекцию.
//6. С коллекцией можно работать опертаором foreach. 
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            UserCollection userCollection = new UserCollection();
            userCollection.Add(new Pensioner(random.Next()));
            userCollection.Add(new Worker(random.Next()));
            userCollection.Add(new Worker(random.Next()));
            userCollection.Add(new Student(random.Next()));
            userCollection.Add(new Student(random.Next()));
            userCollection.Add(new Pensioner(random.Next()));
            userCollection.Add(new Pensioner(random.Next()));
            Worker worker = new Worker(1000);
            userCollection.Add(worker);
            userCollection.Add(new Worker(random.Next()));
            userCollection.Add(new Student(random.Next()));
            userCollection.Add(new Student(random.Next()));
            userCollection.Add(new Pensioner(random.Next()));
            userCollection.Add(new Pensioner(random.Next()));
            userCollection.GetNumberCitizenInCollection(worker);
            userCollection.Delete(worker);
            userCollection.Add(new Student(1000));
            foreach (var item in userCollection)
            {
                Console.WriteLine(item.GetType());
            }
            Console.WriteLine(userCollection.Contains(new Student(1000)));
            Console.WriteLine(userCollection.ReturnLast());
            Console.WriteLine(userCollection.Count);
            userCollection.Clear();
            foreach (var item in userCollection)
            {
                Console.WriteLine(item.GetType());
            }
            Console.WriteLine(userCollection.Count);            
            Console.ReadKey();
        }
    }
}
