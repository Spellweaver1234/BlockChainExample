using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    class Chain
    {
        public double amount;
        public string hash;
        public string prevHash;
        public int index;
        static public int count = 0;

        public string getHash()
        {
            MD5 md5Hash = MD5.Create();
            return GetMd5Hash(md5Hash, amount.ToString() + prevHash.ToString() + index.ToString());
        }

        public void CreateBlock(double a,string ph)
        {
            amount = a;
            prevHash = ph;
            index = count;
            count++;
            hash = getHash();
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}