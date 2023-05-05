using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        // Enthält eine Liste aller möglichen Blöcke im Spiel
        private Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        private Random random = new Random();

        public Block NextBlock;

        public BlockQueue()
        {
            this.NextBlock = RandomBlock();
        }

        private Block RandomBlock()
        {
            return this.blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block = this.NextBlock;

            NextBlock = RandomBlock();

            return block;
        }
    }
}
