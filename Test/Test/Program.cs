using System.Security.Cryptography;
using System.Text;

namespace Test
{
    internal class Program
    {
        //test
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Encrypt("hello"); //comment in second
        }
        private void Encrypt(string text)
        {
            //Закидываем массив байт секретного ключа при инициализации HMACSHA256
            using (HMACSHA256 hash256 = new HMACSHA256(Encoding.UTF8.GetBytes("SecretKey123")))
            {
                byte[] hashBytes = hash256.ComputeHash(Encoding.UTF8.GetBytes(text));
                string encryptedString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Console.WriteLine(encryptedString);
            }
        }

        private int BinarySearch(int[] arr, int num)
        {
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
            //int num = 11;
            //Console.WriteLine("Number = " + arr[p.BinarySearch(arr, num)]);

            int index = -1;
            int low = 0;
            int high = arr.Length - 1;
            int i = 1;
            while (low <= high)
            {
                Console.WriteLine("Проход No: " + i++);
                int mid = low + (high - low) / 2;
                //Если средний элемент массива меньше искомого, перекидываем начало на средний элемент + 1.
                if (arr[mid] < num)
                    low = mid + 1;
                else if (arr[mid] > num)
                    high = mid - 1;
                //нашли искомый элемент
                else
                {
                    index = mid;
                    break;
                }
            }
            return index;
        }
    }
}