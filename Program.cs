using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP12
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ShowAllCommand = "show";
            const string ApproachTheEnclosureCommand = "go";
            const string Exit = "exit";

            bool isWorking = true;
            Zoopark zoopark = new Zoopark();

            while (isWorking)
            {
                Console.WriteLine($"Введите команду:\nПросмотреть всех - {ShowAllCommand}\nПодойти к вольеру - {ApproachTheEnclosureCommand}\nВыход из программы - {Exit}");
                string input = Console.ReadLine().ToLower();

                switch(input)
                {
                    case ShowAllCommand:
                        zoopark.ShowAllAviary(zoopark.aviaryList);
                        break; 
                    case ApproachTheEnclosureCommand:
                        zoopark.ApproachTheEnclosure(zoopark.aviaryList);
                        break;
                    case Exit:
                        Console.WriteLine("Программа завершена");

                        isWorking = false;
                        break;
                }

                ClearConsole();
            }
        }

        private static void ClearConsole()
        {
            Console.WriteLine("Для продолжения нажмите ENTER");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Zoopark
    {
        private List<Aviary> _aviaryList = new List<Aviary>() {new Aviary("Лев", "Мужской", 2, "Рычание"), new Aviary("Зебра", "Женский", 4, "Ква-ха"), new Aviary("Жираф", "Мужской", 3, "Фыркает"), new Aviary("Капибара", "Мужской/Женский", 12, "Свист"), new Aviary("Пингвин", "Мужской/Женский", 22, "Писк") };

        public void ShowAllAviary()
        {
            int index = 0;

            foreach(Aviary aviary in _aviaryList)
            {
                index++;
                Console.WriteLine($"{index}. {aviary.TypeAnimal} - {aviary.Gender} - {aviary.CountAnimal} особей - {aviary.Sound}");
            }    
        }

        public void ApproachTheEnclosure()
        {
            ShowAllAviary();

            Console.WriteLine("Выберите индекс вольера");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("Вы подошди к вальеру с " + _aviaryList[index].TypeAnimal);
            Console.WriteLine($"Информация: {_aviaryList[index].TypeAnimal} - {_aviaryList[index].Gender} - {_aviaryList[index].CountAnimal} особей - {_aviaryList[index].Sound}");
        }
    }

    class Aviary
    {
        public string TypeAnimal { get; private set; }
        public string Gender { get; private set; }
        public int CountAnimal { get; private set; }
        public string Sound {  get; private set; }

        public Aviary(string typeAnimal, string gender, int countAnimal, string sound) 
        {
            TypeAnimal = typeAnimal;
            Gender = gender;
            CountAnimal = countAnimal;
            Sound = sound;
        }
    }
}
