using System;
using System.Text;

namespace Instruments.Randomization
{
    public class RandomIdGenerator
    {
        private string _alphabet;

        public string GenerateId()
        {
            _alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm!@#%^&?/*()-+=1234567890";
            return $"#{GetRandomString(_alphabet, 16)}";
        }

        /// <summary>
        /// Генерирует рандомные строки
        /// </summary>
        /// <param name="alphabet"> алфавит с доступными символами </param>
        /// <param name="length"> длинна генерируемой строки </param>
        /// <returns></returns>
        private string GetRandomString(string alphabet, int length)
        {
            Random random = new();
            StringBuilder stringBuilder = new(length - 1);
            var position = 0;

            for (int i = 0; i < length; i++)
            {
                position = random.Next(0, alphabet.Length - 1);
                stringBuilder.Append(alphabet[position]);
            }

            return stringBuilder.ToString();
        }
    }
}
