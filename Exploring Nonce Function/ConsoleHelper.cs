using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExploringNonceFunction.Core;

namespace ExploringNonceFunction
{
    public static class ConsoleHelper
    {
        public static void MineAndPrint(int id, string data, Blockchain blockchain)
        {
            Console.WriteLine($"User {id} Mines block {id}...");

            Stopwatch sw = Stopwatch.StartNew();
            Block block = blockchain.AddBlock(data);
            sw.Stop();
            
            Console.WriteLine($"Block Minat: {block.Hash}");
            Console.WriteLine($"Nonce folosit: {block.Nonce}");
            Console.WriteLine($"A minat blocul in: {sw.ElapsedMilliseconds / 1000.0}\n");
        }
    }
}
