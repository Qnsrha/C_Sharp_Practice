using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum BK
{
    W,
    V,
    B

}

namespace Tetris
{
    internal class TETRISSCREEN
    {
        protected List<List<string>> BlockList = new List<List<string>>();

        public int X
        {  get
            {
                return BlockList[0].Count;
            }
        }
        public int Y
        {
            get
            {
                return BlockList.Count;
            }
        }
        public void SetBlock(int _y, int _x, string _Type)
        {
            BlockList[_y][_x] = _Type;
        }

        public bool IsBlock(int _y, int _x, string _Type)
        {
            return BlockList[_y][_x] == _Type;
        }
        public void Clear()
        {
            for (int y = 0; y < BlockList.Count; y++)
            {

                for (int x = 0; x < BlockList[y].Count; x++)
                {
                    if (y == 0 || y == BlockList.Count - 1)
                    {
                        BlockList[y][x] = "▣";
                        continue;
                    }
                    BlockList[y][x] = "□";
                }

            }
        }
        public virtual void Render()
        {
            for (int y = 0; y < BlockList.Count; y++)
            {

                for (int x = 0; x < BlockList[y].Count; x++)
                {
                 /*   switch (BlockList[y][x])
                    {
                        case BK.W:
                            Console.Write("▣");
                            break;
                        case BK.V:
                            Console.Write("□");
                            break;
                        case BK.B:
                            Console.Write("■");
                            break;
                        default:
                            break;
                    }*/
                    Console.Write(BlockList[y][x]);

                }
                Console.WriteLine();
            }
        }
        public TETRISSCREEN(int _X, int _Y, bool TopAndBotLine)
        {
            for (int y = 0; y < _Y; y++)
            {

                BlockList.Add(new List<string>());
                for (int x = 0; x < _X; x++)
                {
                    BlockList[y].Add("□");
                }
            }
            if (TopAndBotLine == true)
            {
                for (int i = 0; i < BlockList[0].Count; i++)
                {
                    BlockList[0][i] = "▣";

                }
                for (int i = 0; i < BlockList[_Y - 1].Count; i++)
                {
                    BlockList[_Y - 1][i] = "▣";

                }
            }


        }
        
    }
}
