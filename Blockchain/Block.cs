using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//https://towardsdatascience.com/blockchain-explained-using-c-implementation-fb60f29b9f07
//статья про то, как сделать блокчейн с майнингом и пр.
namespace Blockchain
{
    /// <summary>
    /// Блок данных
    /// </summary>
    public class Block
    {
        public int Id { get; private set; }//private чтобы запретить возможность внешнего редактирования
        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; private set; }
        /// <summary>
        /// Create Time and date
        /// </summary>
        public DateTime Created { get; private set; }
        /// <summary>
        /// Хэш блока
        /// </summary>
        public string Hash { get; private set; }
        /// <summary>
        /// Хэш предыдущего блока
        /// </summary>
        public string PreviousHash { get; private set; }
        /// <summary>
        /// Имя пользователя 
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// конструктор генезис блока
        /// </summary>
        public Block()
        {
            Id = 1;
            Data = "Hello, World";
            Created = DateTime.Parse("01.07.2023 00:00:00.000").ToUniversalTime();
            PreviousHash = "111111";
            User = "Admin";

            var data = GetData();
            Hash = GetHash(data);
        }

        /// <summary>
        /// Конструктор блока
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        /// <param name="block"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Block(string data, string user, Block block)
        { 
            if(string.IsNullOrWhiteSpace(data)) 
            {
                throw new ArgumentNullException($"Пустой аргумент дата", nameof(data));
            }

            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException($"Пустой аргумент дата", nameof(user));
            }

            if (block == null) 
            {
                throw new ArgumentNullException($"Пустой аргумент дата", nameof(block));
            }

            Data = data;
            User = user;
            PreviousHash = block.Hash;
            Created = DateTime.UtcNow;
            Id = block.Id + 1;
            var blockData = GetData();
            Hash = GetHash(blockData);
        }

        /// <summary>
        /// Получение значимых данных
        /// </summary>
        /// <returns></returns>
        private string GetData()
        {
            string result = "";
            result += Id.ToString();
            result += Created.ToString("dd.MM.yyyy HH:mm:ss.fff");
            result += PreviousHash;
            result += User;

            return result;
        }

        /// <summary>
        /// Хэширование данных
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetHash(string data) 
        {
            //переводим data в массив байт
            var message = Encoding.ASCII.GetBytes(data);
            var hashString = new SHA256Managed();
            //объявляем результирующую переменную
            string hex = "";
            //вызываем метод, который захэширует сообщение
            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue) 
            {
                hex += String.Format("{0:x2}", x);
            }
            //получаем на выходе набор данных
            return hex;            
        }

        public override string ToString()
        {
            return Data;
        }

    }
}
