using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploringNonceFunction.Core
{
    public class Blockchain
    {
        private readonly List<Block> _blocks = new List<Block>();
        public IEnumerable<Block> Blocks => _blocks;

        public Block AddBlock(string data, int difficulty = 4)
        {
            string previousHash = _blocks.Count == 0 ? new string('0', 64) : _blocks.Last().Hash;
            Block block = new Block(_blocks.Count + 1, previousHash, data, difficulty);

            block.Mine();
            _blocks.Add(block);

            return block;
        }

        public bool IsValid()
        {
            for (int i = 1; i < _blocks.Count; i++)
            {
                if (_blocks[i].PreviousHash != _blocks[i - 1].Hash)
                    return false;
                if (!_blocks[i].Hash.StartsWith(new string('0', _blocks[i].Difficulty)))
                    return false;
                if (_blocks[i].CalculateHash() != _blocks[i].Hash)
                    return false;
            }
            return true;
        }
    }
}
