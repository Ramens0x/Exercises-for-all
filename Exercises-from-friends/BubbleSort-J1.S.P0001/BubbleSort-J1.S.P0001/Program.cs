using System;
using System.Text;

namespace BubbleSort_J1.S.P0001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool playAgain;
            do
            {
                //--- Phần 1: Nhận và kiểm tra đầu vào ---

                int number = 0;
                bool isValidInput = false;

                do
                {
                    Console.Write("Nhập số phần tử của mảng: ");
                    string userInput = Console.ReadLine();

                    try
                    {
                        number = int.Parse(userInput);
                        if (number > 0)
                        {
                            isValidInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập một số nguyên dương.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập một số nguyên.");
                    }

                } while (!isValidInput);

                //--- Phần 2: Tạo và hiển thị mảng chưa sắp xếp ---

                // Tạo mảng với các số nguyên ngẫu nhiên từ 0 đến 100 ( Mảng 1 chiều kích thước number )
                Random rand = new Random();
                int[] array = new int[number];
                for (int i = 0; i < number; i++)
                {
                    array[i] = rand.Next(1, 101);
                }
                // Hiển thị mảng chưa sắp xếp
                Console.WriteLine("Mảng chưa sắp xếp: " + string.Join(", ", array));

                //--- Phần 3: Sắp xếp mảng theo thuật toán Bubble Sort và hiển thị ---

                BubbleSort(array);
                Console.Write("Mảng đã sắp xếp: " + string.Join(", ", array));

                Console.Write("\nBạn có muốn thử lại không? (Y/N): ");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }
            }while(playAgain);

            Console.ReadKey();
        }
        public static void BubbleSort(int[] array)
        {
            int n = array.Length;

            // Vòng lặp bên ngoài để lặp qua từng phần tử
            for (int i = 0; i < n - 1; i++)
            {
                // Vòng lặp bên trong để so sánh và đổi chỗ các phần tử
                for (int j = 0; j < n - 1; j++)
                {
                    if (array[j] > array[j +1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }    
                }    
            }    
        }
    }
}