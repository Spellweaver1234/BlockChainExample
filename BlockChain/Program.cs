using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain[] blockchain;
            blockchain = new Chain[10];
            for (int i = 0; i < blockchain.Length; i++)
            {
                blockchain[i] = new Chain();
            }

            blockchain[0].CreateBlock(100, "");
            blockchain[1].CreateBlock(50, blockchain[0].hash);
            blockchain[2].CreateBlock(250, blockchain[1].hash);
            blockchain[3].CreateBlock(75, blockchain[2].hash);
            blockchain[4].CreateBlock(250, blockchain[3].hash);
            blockchain[5].CreateBlock(200, blockchain[4].hash);
            blockchain[6].CreateBlock(100, blockchain[5].hash);
            blockchain[7].CreateBlock(220, blockchain[6].hash);
            blockchain[8].CreateBlock(30, blockchain[7].hash);

            if (VerifyBC(blockchain))
                Console.WriteLine("Блокчейн не нарушен");
            else
                Console.WriteLine("Блокчейн нарушен");

            Console.ReadLine();
        }

        static bool VerifyBC(Chain[] blockchain)
        {
            for (int i = 1; i < Chain.count; i++)
            {
                if (blockchain[i].hash != blockchain[i].getHash())
                {
                    return false;
                }

                if (blockchain[i].prevHash != blockchain[i - 1].hash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}