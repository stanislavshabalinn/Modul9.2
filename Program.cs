using System.Security.Cryptography.X509Certificates;

namespace Module9
{
    class Programm
    {
        public static void Main(string[] args)
        {
            /// Чтение чисел

            NumberReader numberReader = new NumberReader();

            /// Сортировка имен

            numberReader.NumberEnteredEvent += NameSorted;

            /// Цикл до тех пор, пока будет без исключений
            while (true)
            {
                try
                {
                    /// Чтение
                    numberReader.Read();

                    break;

                    /// Исключение - некорректный тип данных
                }
                catch (FormatException)
                {
                    Console.WriteLine("Повторите ввод данных, должно быть целое число");

                    /// Исключение - данные вне диапазона
                }
                catch (ArgumentOutOfRangeException argumentOutOfRangeException)
                {
                    Console.WriteLine("Повторите ввод данных, значение должно быть 1 или 2");

                    /// Исключения (при невыполнении - прерывание)
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    break;
                };
            }
        }

        public static void NameSorted(int number)
        {
            /// Задаем список из 5 фамилий
            List<string> stringList = new List<string> { "Шабалин", "Муравьев", "Петяхин", "Кучумов", "Лебедев" };

            switch (number)
            {
                /// Сортировка по возрастанию
                case 1:
                    Console.WriteLine("Выбрана прямая сортировка (1)\n");
                    var sortedList = stringList.OrderBy(s => s);
                    foreach (var item in sortedList)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                /// Сортировка по убыванию
                case 2:
                    Console.WriteLine("Выбрана обратная сортировка (2)\n");
                    sortedList = stringList.OrderByDescending(s => s);
                    foreach (var item in sortedList)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            }
        }
    }
    /// <summary>
    /// Делегат
    /// </summary>
    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine("\nДля прямой сортировки выберите 1, для обратной сортировки выберите 2");
            int number = Convert.ToInt32(Console.ReadLine());

            ///Не корректный дип данных
            if (number! == 1 && number! == 2) throw new FormatException();

            /// число вне диапазона
            if (number! < 1 | number! > 2) throw new ArgumentOutOfRangeException();

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
}













