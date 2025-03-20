
namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TETRISSCREEN NewSC = new TETRISSCREEN(10, 15, true);
            ACCSCREEN NewASC = new ACCSCREEN(NewSC);

            BLOCK NewBlock = new BLOCK(NewSC, NewASC);

            while (true) 
            {
                for (int i = 0; i < 10000000; i++)
                {
                    int a = 0;
                }

                Console.Clear();
                NewSC.Render();
                NewSC.Clear();
                NewASC.Render();
                NewASC.DestoryCheck();
                NewBlock.Move();
            }
            
        }
    }
}