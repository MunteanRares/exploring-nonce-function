using System.Threading.Channels;
using ExploringNonceFunction.Core;

int id = 0;

string data = "Tranzactie: Rares -> Vlazi";
Block block = new Block(id++, "00000000000000000000000000", data);

Console.WriteLine("User 1 Mines block 1...");
block.Mine();
Console.WriteLine($"Block Minat: {block.Hash}");
Console.WriteLine($"Nonce folosit: {block.Nonce}\n");

Block block2 = new Block(id++, block.Hash, block.Data);
Console.WriteLine("User 2 Mines block 2...");
block2.Mine();
Console.WriteLine($"Block Minat: {block2.Hash}");
Console.WriteLine($"Nonce folosit: {block2.Nonce}\n");
