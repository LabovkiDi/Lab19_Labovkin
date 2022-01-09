using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_Labovkin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer() {Name="Apple",ID="MGNT#",Processor="Macos",CPU=3.6,Ram=8,HDrive=2000,VCard=512,
                    Price=120000,Numb=10 },
                new Computer() {Name="Asus",ID="XC-830",Processor="Celeron",CPU=2.6,Ram=4,HDrive=1000,VCard=1024,
                    Price=60000,Numb=25 },
                new Computer() {Name="Apple",ID="AMGN",Processor="Macos",CPU=3.2,Ram=6,HDrive=1600,VCard=1024,
                    Price=110000,Numb=15 },
                new Computer() {Name="HP",ID="DeskTopPro",Processor="IntelCore",CPU=4.2,Ram=8,HDrive=2000,VCard=1024,
                    Price=100000,Numb=10 },
                new Computer() {Name="Acer",ID="Veriton",Processor="IntelCore",CPU=2.6,Ram=6,HDrive=1600,VCard=1024,
                    Price=50000,Numb=50 },
                new Computer() {Name="DELL",ID="OptiPlex",Processor="AMD",CPU=2.6,Ram=4,HDrive=1000,VCard=512,
                    Price=40000,Numb=25 },
                new Computer() {Name="HP",ID="Prodesk",Processor="IntelCore",CPU=3.2,Ram=6,HDrive=1000,VCard=512,
                    Price=80000,Numb=40 },
                new Computer() {Name="Asus",ID="G10CE",Processor="Celeron",CPU=4.2,Ram=8,HDrive=3000,VCard=1024,
                    Price=90000,Numb=30 },
                new Computer() {Name="HP",ID="Pro360",Processor="AMD",CPU=2.6,Ram=4,HDrive=1000,VCard=512,Price=60000,Numb=20 }
            };
            //запрос у пользователя
            Console.WriteLine("Введите название процессора");
            string proccesor = Console.ReadLine();
            //через метод расширения выбираем процессоры с указанным именем
            List<Computer> computers1 = computers.Where(x => x.Processor == proccesor).ToList();
            Print(computers1);

            //запрос у пользователя
            Console.WriteLine("Введите объем ОЗУ");
            int ram = Convert.ToInt32(Console.ReadLine());
            //через метод расширения выбираем ОЗУ которая больше или равна указанного значения
            List<Computer> computers2 = computers.Where(x => x.Ram >= ram).ToList();
            Print(computers2);

            //для сортировки по увеличению стоимости используем мметод расширения orderBy
            List<Computer> computers3 = computers.OrderBy(x => x.Price).ToList();
            Print(computers3);

            //создаем коллекцию объектов с общим ключом и группируем с помощью GroupBy
            IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(x => x.Processor);
            //перебираем коллекцию
            foreach (IGrouping<string, Computer> gr in computers4)
            {
                //выводим общий ключ, тип процессора
                Console.WriteLine(gr.Key);
                //перебираем компьютеры в группе
                foreach (Computer c in gr)
                {
                    //    выводим на экран сгруппированные компьютеры
                    Console.WriteLine($"{c.Name} {c.ID} {c.Processor} {c.CPU} {c.Ram} {c.HDrive} {c.VCard} {c.Price} {c.Numb}");
                }
            }
            //отсортируем список,чтобы самый дорогой компьютер оказался наверху и выбираем верхний(первый) эл-т списка
            Computer computer5 = computers.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{computer5.Name} {computer5.ID} {computer5.Processor} {computer5.CPU} {computer5.Ram}" +
                $" {computer5.HDrive} {computer5.VCard} {computer5.Price} {computer5.Numb}");
            //отсортируем список,чтобы самый дешеввый компьютер оказался наверху и выбираем верхний(первый) эл-т списка
            Computer computer6 = computers.OrderBy(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{computer6.Name} {computer6.ID} {computer6.Processor} {computer6.CPU} {computer6.Ram}" +
            $" {computer6.HDrive} {computer6.VCard} {computer6.Price} {computer6.Numb}");

            //функция Any проверяет есть ли хотя бы одна запись с указанным условием
            Console.WriteLine(computers.Any(x => x.Numb > 30));

            Console.ReadKey();
        }
        //метод, который получает список сотрудников и выводит их на экран
        static void Print(List<Computer> computers)
        {
            //перебираем все объекты в коллекции
            foreach (Computer c in computers)
            {
                //выводим по каждому информацию
                Console.WriteLine($"{c.Name} {c.ID} {c.Processor} {c.CPU} {c.Ram} {c.HDrive} {c.VCard} {c.Price} {c.Numb}");
            }
            //пустая строка
            Console.WriteLine();
        }
    }
    class Computer
    {
        //название ммарки компьютера
        public string Name { get; set; }
        // код компьютера
        public string ID { get; set; }
        //тип процессора
        public string Processor { get; set; }
        //частота работы процессора
        public double CPU { get; set; }
        //объем оперативной памяти
        public int Ram { get; set; }
        //объем жесктого диска
        public int HDrive { get; set; }
        //объем видеокарты
        public int VCard { get; set; }
        //стоимость
        public double Price { get; set; }
        //количество
        public int Numb { get; set; }

    }
}

