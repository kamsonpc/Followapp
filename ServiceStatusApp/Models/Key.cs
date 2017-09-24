using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStatusApp.Models
{
    public class Key
    {

        /// <summary>
        /// Metoda statyczna losuje ze zbioru znaków,ciąg znaków który będzie zapisany jako Key
        /// </summary>
        /// <param name="lenght">określa długość wylosowanego ciągu</param>
        /// <returns></returns>
        public string GenerateKey(int lenght = 8)
        {
            string charset = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$%^&";

            if (charset.Length < lenght)
            {
                lenght = charset.Length;
            }

            string key = "";
            Random random = new Random();
            for (int i = 0; i < lenght; i++)
            {
                key += charset[random.Next(0, charset.Length)];
            }
            return key;
        }
    }
}