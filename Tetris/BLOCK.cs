using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Tetris
{
    enum BLOCKDIR
    {
        BD_T,
        BD_R,
        BD_B,
        BD_L,
        BD_MAX
    }
    enum BLOCKSHAPE
    {
        BS_I,
        BS_L,
        BS_J,
        BS_Z,
        BS_S,
        BS_T,
        BS_O,
        BS_MAX
    }
    internal class BLOCK
    {
        int X = 0;
        int Y = 0;
        BLOCKDIR Dir = BLOCKDIR.BD_T;
        string[][] Arr = null;

        List<List<string[][]>> AllBlock = new List<List<string[][]>>();

        TETRISSCREEN Screen = null;
        ACCSCREEN AccScreen = null;

        BLOCKSHAPE CurShape = BLOCKSHAPE.BS_T;
        BLOCKDIR CurDir = BLOCKDIR.BD_T;
        Random NewRandom = new Random();
        public BLOCK(TETRISSCREEN _Screen, ACCSCREEN _AccScreen)
        {
            if (_Screen == null || _AccScreen == null)
            {
                return;
            }
            Screen = _Screen;
            AccScreen = _AccScreen;
            DataInit();

            Reset();
        }
        public void SettingBlock(BLOCKSHAPE _Shape, BLOCKDIR _Dir)
        {
            Arr = AllBlock[(int)_Shape][(int)_Dir];
        }
        public void RandomBlockShape()
        {
            int RandomIndex = NewRandom.Next((int)BLOCKSHAPE.BS_I, (int)BLOCKSHAPE.BS_MAX);
            CurShape = (BLOCKSHAPE)RandomIndex;
        }
        public void SetAccScreen()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (Arr[y][x] == "■")
                    {
                        AccScreen.SetBlock(Y+y-1, X+x, Arr[y][x]);
                    }
                }
            }
        }

        public void Reset()
        {
            RandomBlockShape();
            X = 0;
            Y = 1;
            SettingBlock(CurShape, CurDir);
        }
        public bool DownCheck()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if(Arr[y][x] == "■")
                    {
                        if(AccScreen.Y == Y+y || true == AccScreen.IsBlock(Y+y,X+x,"■"))
                        {
                            SetAccScreen();
                            Reset();
                            return true;
                        }
                    }
                    
                }
            }
            return false;
        }
        public void Down()
        {
            if (DownCheck() == true)
            {
                return;
            }
            Y += 1;
        }

        public void Input()
        {
            //Y += 1;
            if (Console.KeyAvailable == false)
            {
                return;

            }
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    X -= 1;
                    break;
                case ConsoleKey.D:
                    X += 1;
                    break;
                case ConsoleKey.S:
                    Down();
                    break;
                case ConsoleKey.Q:
                    CurDir--;
                    if(CurDir <0)
                    {
                        CurDir = BLOCKDIR.BD_L;
                    }
                    SettingBlock(CurShape, CurDir);

                    break;
                case ConsoleKey.E:
                    CurDir++;
                    if (CurDir == BLOCKDIR.BD_MAX)
                    {
                        CurDir = BLOCKDIR.BD_T;
                    }
                    SettingBlock(CurShape, CurDir);
                    break;
                default:
                    break;

            }
        }
        public void Move()
        {
            
            Input();

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if ((Arr[y][x] == "□") )
                    {
                        continue;
                    }
                    Screen.SetBlock(Y+y, X+x, Arr[y][x]);
                }
            }

        }


        public void DataInit()
        {
            for (int BS = 0; BS < (int)BLOCKSHAPE.BS_MAX; BS++)
            {
                AllBlock.Add(new List<string[][]>());
                for (int BD = 0; BD < (int)BLOCKDIR.BD_MAX; BD++)
                {
                    AllBlock[BS].Add(null);
                }
            }

            #region I
            {
                AllBlock[(int)BLOCKSHAPE.BS_I][(int)BLOCKDIR.BD_T] = new string[][]
                {
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_I][(int)BLOCKDIR.BD_R] = new string[][]
                {
                    new string[]{ "■", "■", "■", "■" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_I][(int)BLOCKDIR.BD_L] = new string[][]
                {
                    new string[]{ "■", "■", "■", "■" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_I][(int)BLOCKDIR.BD_B] = new string[][]
                {
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "□", "□", "□" }
                };
            }
            #endregion
            #region L
            {
                AllBlock[(int)BLOCKSHAPE.BS_L][(int)BLOCKDIR.BD_T] = new string[][]
                {
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_L][(int)BLOCKDIR.BD_R] = new string[][]
                {
                    new string[]{ "■", "■", "■", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_L][(int)BLOCKDIR.BD_L] = new string[][]
                {
                    new string[]{ "□", "□", "■", "□" },
                    new string[]{ "■", "■", "■", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_L][(int)BLOCKDIR.BD_B] = new string[][]
                {
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
            }
            #endregion
            #region J
            {
                AllBlock[(int)BLOCKSHAPE.BS_J][(int)BLOCKDIR.BD_T] = new string[][]
                {
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_J][(int)BLOCKDIR.BD_R] = new string[][]
                {
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "■", "■", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_J][(int)BLOCKDIR.BD_L] = new string[][]
                {
                    new string[]{ "■", "■", "■", "□" },
                    new string[]{ "□", "□", "■", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_J][(int)BLOCKDIR.BD_B] = new string[][]
                {
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
            }
            #endregion
            #region Z
            {
                AllBlock[(int)BLOCKSHAPE.BS_Z][(int)BLOCKDIR.BD_T] = new string[][]
                {
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "■", "■", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_Z][(int)BLOCKDIR.BD_R] = new string[][]
                {
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_Z][(int)BLOCKDIR.BD_L] = new string[][]
                {
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_Z][(int)BLOCKDIR.BD_B] = new string[][]
                {
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "■", "■", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
            }
            #endregion
            #region S
            {
                AllBlock[(int)BLOCKSHAPE.BS_S][(int)BLOCKDIR.BD_T] = new string[][]
                {
                    new string[]{ "□", "■", "■", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_S][(int)BLOCKDIR.BD_R] = new string[][]
                {
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_S][(int)BLOCKDIR.BD_L] = new string[][]
                {
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_S][(int)BLOCKDIR.BD_B] = new string[][]
                {
                    new string[]{ "□", "■", "■", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
            }
            #endregion
            #region T
            {
                AllBlock[(int)BLOCKSHAPE.BS_T][(int)BLOCKDIR.BD_T] = new string[][]
                {
                    new string[]{ "■", "■", "■", "□" },
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_T][(int)BLOCKDIR.BD_R] = new string[][]
                {
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_T][(int)BLOCKDIR.BD_L] = new string[][]
                {
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "■", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_T][(int)BLOCKDIR.BD_B] = new string[][]
                {
                    new string[]{ "□", "■", "□", "□" },
                    new string[]{ "■", "■", "■", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
            }
            #endregion
            #region O
            {
                AllBlock[(int)BLOCKSHAPE.BS_O][(int)BLOCKDIR.BD_T] = new string[][]
                {
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_O][(int)BLOCKDIR.BD_R] = new string[][]
                {
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_O][(int)BLOCKDIR.BD_L] = new string[][]
                {
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
                AllBlock[(int)BLOCKSHAPE.BS_O][(int)BLOCKDIR.BD_B] = new string[][]
                {
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "■", "■", "□", "□" },
                    new string[]{ "□", "□", "□", "□" },
                    new string[]{ "□", "□", "□", "□" }
                };
            }
            #endregion

        }
    }
}
