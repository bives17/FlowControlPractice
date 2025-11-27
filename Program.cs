using System;

namespace FlowControlPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Практическая работа 3: Управление потоком выполнения в .NET");
            Console.WriteLine("============================================================\n");

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "3":
                        FindPrimeNumbers();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы. До свидания!");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! Для демонстрации доступен только вариант 3.\n");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("МЕНЮ ПРАКТИЧЕСКОЙ РАБОТЫ - ВАРИАНТ 3");
            Console.WriteLine("=====================================");
            Console.WriteLine("3 - Поиск простых чисел (реализовано)");
            Console.WriteLine("0 - Выход");
            Console.Write("\nВыберите вариант: ");
        }

        // Вариант 3: "Поиск простых чисел"
        static void FindPrimeNumbers()
        {
            Console.WriteLine("\n=== ПОИСК ПРОСТЫХ ЧИСЕЛ ===");
            Console.WriteLine("Программа находит все простые числа от 2 до заданного числа N\n");

            try
            {
                Console.Write("Введите целое число N: ");
                int n = int.Parse(Console.ReadLine());

                // Проверка корректности введенного числа
                if (n < 2)
                {
                    Console.WriteLine("Простые числа начинаются с 2. Пожалуйста, введите число больше или равное 2.");
                    return;
                }

                Console.WriteLine($"\nПростые числа в диапазоне от 2 до {n}:");

                int primeCount = 0; // Счетчик найденных простых чисел

                // ВНЕШНИЙ ЦИКЛ: перебираем все числа от 2 до N
                // Используем цикл for, так как известно количество итераций
                for (int number = 2; number <= n; number++)
                {
                    bool isPrime = true; // Предполагаем, что число простое

                    // ВНУТРЕННИЙ ЦИКЛ: проверяем делители от 2 до квадратного корня из number
                    // Используем оптимизацию - проверяем только до sqrt(number)
                    for (int divisor = 2; divisor * divisor <= number; divisor++)
                    {
                        // УСЛОВНЫЙ ОПЕРАТОР: проверяем, делится ли число на divisor без остатка
                        if (number % divisor == 0)
                        {
                            isPrime = false; // Найден делитель - число не простое

                            // ОПЕРАТОР BREAK: выходим из внутреннего цикла досрочно
                            // Так как уже нашли делитель, дальнейшая проверка не нужна
                            break;
                        }
                    }

                    // Если число прошло проверку и осталось простым
                    if (isPrime)
                    {
                        Console.Write(number + " ");
                        primeCount++;

                        // Форматируем вывод - 10 чисел в строке
                        if (primeCount % 10 == 0)
                            Console.WriteLine();
                    }
                }

                Console.WriteLine($"\n\nНайдено простых чисел: {primeCount}");

                // Дополнительная информация о производительности
                Console.WriteLine($"\nДиапазон проверки: 2 - {n}");
                Console.WriteLine($"Оптимизация: проверка делителей до √{n} ≈ {Math.Sqrt(n):F0}");
            }
            catch (FormatException)
            {
                // Обработка исключения: пользователь ввел не число
                Console.WriteLine("Ошибка: Введено не числовое значение! Пожалуйста, введите целое число.");
            }
            catch (OverflowException)
            {
                // Обработка исключения: число слишком большое
                Console.WriteLine("Ошибка: Введено слишком большое число! Максимальное значение: 2,147,483,647");
            }
            catch (Exception ex)
            {
                // Обработка всех остальных исключений
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }
        }
    }
}
