using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Lesson5_HomeWork_3
{
    internal class Program
    {
        //ввод данных
        private static List<byte> GetWriteData()
        {
            //
            List<byte> outData = new List<byte>();

            //
            int number;
            bool isNumber;

            //ввод значений
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {
                //ввод числа 
                Console.Write("Введите число из диапазона от 0 до 255 (по окончании ввода нажмите ENTER) : ");
                string sNumber = Console.ReadLine();

                //проверки корректности ввода
                isNumber = int.TryParse(sNumber, out number); //проверка, что введенная строка является числом
                if (isNumber) //число
                {
                    if (number >= 0 && number <= 255)
                    {
                        outData.Add((byte)number);
                    }
                    else
                    {
                        Console.WriteLine($"Введенное число {number} не входит в диапазон [0; 255]");
                    }
                }
                else //строка
                {
                    Console.WriteLine($"Введенная строка {sNumber} не является числом");
                }
                Console.Write("Для продолжения ввода данных нажмите любую клавишу, для окончания клавишу n : ");
                cki = Console.ReadKey(true);
                Console.WriteLine();
            }
            while (cki.Key != ConsoleKey.N);

            //
            return outData;
        }

        //запись данных в бинарный файл
        private static void WriteDataToBinaryFile(string fileName, List<byte> vData)
        {
            try
            {
                //преобразование List<byte> в byte[]
                byte[] arrayBytes = vData.ToArray();

                //запись
                File.WriteAllBytes(fileName, arrayBytes);

                //
                Console.WriteLine($"\nДанные записаны в файл {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }

        //считать данные файла и вывести на консоль 
        private static void ReadAndPrintFileData(string fileName)
        {
            //считать данные
            byte[] arrayBytes = File.ReadAllBytes(fileName);

            //преобразование массива данных в строку
            string sData = string.Join(" ", arrayBytes);

            //вывод данных на консоль
            Console.WriteLine($"\nДанные файла {fileName} : {sData}");
        }

        static void Main(string[] args)
        {
            //
            Console.WriteLine("----- Урок № 5, задание № 3 -----");
            Console.WriteLine();

            //имя записываемого файла
            string fileName = "bytesData.bin";

            //получить данные для записи и записать данные в файл
            WriteDataToBinaryFile(fileName, GetWriteData());

            //считать данные файла и вывести на консоль 
            ReadAndPrintFileData(fileName);

            //
            Console.ReadLine();
        }
    }
}
