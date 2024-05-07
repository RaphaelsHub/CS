namespace ConsoleApp6;

using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Ввод строки для шифрования
            Console.WriteLine("Введите строку для шифрования:");
            string original = Console.ReadLine();

            // Создание объекта RSA
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Шифрование строки
                byte[] encrypted = EncryptString(original, rsa.ExportParameters(false));

                // Расшифровка строки
                string roundtrip = DecryptString(encrypted, rsa.ExportParameters(true));

                // Вывод зашифрованной и расшифрованной строки
                Console.WriteLine($"Зашифрованная строка: {Convert.ToBase64String(encrypted)}");
                Console.WriteLine($"Расшифрованная строка: {roundtrip}");
            }
        }

    }


}
