namespace ConsoleApp5;
using System;
using System.IO;
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

            // Создание объекта AES
            using (Aes aesAlg = Aes.Create())
            {
                // Генерация ключа и вектора инициализации
                aesAlg.GenerateKey();
                aesAlg.GenerateIV();

                // Шифрование строки
                byte[] encrypted = EncryptStringToBytes_Aes(original, aesAlg.Key, aesAlg.IV);

                // Расшифровка строки
                string roundtrip = DecryptStringFromBytes_Aes(encrypted, aesAlg.Key, aesAlg.IV);

                // Вывод зашифрованной и расшифрованной строки
                Console.WriteLine($"Зашифрованная строка: {Convert.ToBase64String(encrypted)}");
                Console.WriteLine($"Расшифрованная строка: {roundtrip}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }

    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
    {
        // Проверка входных аргументов
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException(nameof(plainText));
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException(nameof(Key));
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException(nameof(IV));
        byte[] encrypted;

        // Создание объекта AES для шифрования
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Создание объекта для шифрования потока
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        // Запись данных в поток
                        swEncrypt.Write(plainText);
                    }
                    // Получение зашифрованных данных из потока
                    encrypted = msEncrypt.ToArray();
                }
            }
        }
        return encrypted;
    }
    
    static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        // Проверка входных аргументов
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException(nameof(cipherText));
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException(nameof(Key));
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException(nameof(IV));

        // Строка для хранения расшифрованных данных
        string plaintext = null;

        // Создание объекта AES для расшифровки
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Создание объекта для расшифровки потока
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Чтение данных из потока и расшифровка
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        return plaintext;
    }
}
