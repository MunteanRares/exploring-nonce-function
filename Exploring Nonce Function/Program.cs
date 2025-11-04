using System.Diagnostics;
using System.Threading.Channels;
using ExploringNonceFunction;
using ExploringNonceFunction.Core;

int id = 1;

Blockchain blockchain = new Blockchain();    

ConsoleHelper.MineAndPrint(id++, "Tranzactie: Rares -> Geani", blockchain);
ConsoleHelper.MineAndPrint(id++, "Tranzactie: Rares -> Iorgu", blockchain);

Console.WriteLine($"Blockchain este valid: {blockchain.IsValid()}");

