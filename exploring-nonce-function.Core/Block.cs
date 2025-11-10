using System.Security.Cryptography;
using System.Text;

namespace ExploringNonceFunction.Core
{
    public class Block
    {
        public int Index { get; private set; }
        public string Data { get; private set; } = string.Empty; // Contentul blocului
        public long Nonce { get; private set; } = 0;
        public int Difficulty { get; set; } // Cu cat e mai mare numarul cu atat e mai greu de minat (numarul este mai mic)
        public string PreviousHash { get; set; } = string.Empty; // Hashul blocului anterior
        public string Hash { get; private set; } = string.Empty;
        public DateTime TimeStamp { get; private set; } // Cand s a create blocul
        
        public Block(int index, string previousHash, string data, int difficulty)
        {
            Index = index;
            PreviousHash = previousHash;
            Data = data;
            Difficulty = difficulty;
            TimeStamp = DateTime.UtcNow;
        }

        // Creeaza un hash bazat pe datele blocului (raw string -> hashing the bytes -> returning hashed block as hexadecimal 'x2')
        internal string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = $"{Index}{PreviousHash}{Data}{Nonce}{TimeStamp:O}";
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)                
                    builder.Append(b.ToString("x2"));
                
                return builder.ToString();
            }
        }

        // Nonce se incrementeaza pana cand hash-ul are la inceput la fel sau mai multe zerouri date de Difficulty
        internal void Mine()
        {
            string targetZeroes = new string('0', Difficulty);
            while (true)
            {
                Hash = CalculateHash();
                if (Hash.StartsWith(targetZeroes))
                    break;
                Nonce++;
            }
        }

    }
}
