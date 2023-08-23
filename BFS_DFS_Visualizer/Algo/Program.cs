using OwnLibrary;
/*
    Coded By : Mohamed Bakr
    GitHub : https://github.com/MohamedBakr27
    Date : 22-8-2023
    
    Project : 
        Breadth First Search (BFS) & Depth First Search (DFS) Visualizer.
        Simple Grid of '.'s as safe cell, '#'s as wall, 'S' as Start cell, 'E' as End cell.
        Move Directions is Up, Down, Left, Right.
*/
namespace Algo
{
    internal class Program
    {
        struct Map
        {
            int n;
            char[,] grid;
            Pair<int, int> begin = new Pair<int, int>(0,0);
            Pair<int, int> end = new Pair<int, int>(0,0);
            Queue<Pair<int,int>> OrderedPaths = new Queue<Pair<int,int>>();
            Stack<Pair<int, int>> Path = new Stack<Pair<int, int>>();
            
            public Map(int N)
            {
                n = N;
                grid = new char[n, n];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        grid[i, j] = '.';

                w("Enter Begin Row: ");
                int tmpR = Read.Int() - 1;
                w("Enter Begin Col: ");
                int tmpC = Read.Int() - 1; 
                while (!Valid(tmpR, tmpC))
                {
                    w("Enter Valid Begin Row: ");
                    tmpR = Read.Int() - 1;
                    w("Enter Valid Begin Col: ");
                    tmpC = Read.Int() - 1;
                }
                begin.First = tmpR;
                begin.Second = tmpC;

                w("Enter End Row: ");
                tmpR = Read.Int() - 1;
                w("Enter End Col: ");
                tmpC = Read.Int() - 1;
                while (!Valid(tmpR, tmpC))
                {
                    w("Enter Valid End Row: ");
                    tmpR = Read.Int() - 1;
                    w("Enter Valid End Col: ");
                    tmpC = Read.Int() - 1;
                }
                end.First = tmpR;
                end.Second = tmpC;

                grid[begin.First,begin.Second] = 'S';
                grid[end.First,end.Second] = 'E';

                Display(grid);
            }
            public void Display(char[,] m,int markR=-1, int markC=-1)
            {
                Console.Clear();
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        w(m[row, col].ToString());
                    }
                    wl();
                }
            }
            public bool Valid(int r,int c)
            {
                return r >= 0 && c >= 0 && r < n && c < n;
            }
            private int[] nwRow = { 1, 0, -1, 0 };
            private int[] nwCol = { 0, 1, 0, -1 };
            public void BFS()
            {
                Queue<Pair<int, int>> q = new Queue<Pair<int, int>>();
                bool[,] Visited = new bool[n,n];
                Pair<int, int>[,] Parent = new Pair<int, int>[n,n];
                q.Enqueue(begin);
                Visited[begin.First, begin.Second] = true;
                Parent[begin.First, begin.Second] = begin;
                bool done = false;
                while(q.Count>0 && !done)
                {
                    Pair<int,int> cur = q.Dequeue();
                    OrderedPaths.Enqueue(cur);
                    if (grid[cur.First, cur.Second] == '#') continue;
                    for (int r = 0;r<4 && !done; r++)
                    {
                        int row = cur.First + nwRow[r];
                        int col = cur.Second + nwCol[r];
                        if (Valid(row, col) && !Visited[row,col])
                        {
                            Visited[row, col] = true;
                            Parent[row,col] = cur;
                            if (row==end.First&&col==end.Second) done = true;
                            q.Enqueue(new Pair<int, int>(row,col));
                        }
                    }
                }

                Pair<int, int> Par = Parent[end.First, end.Second];
                if (Par == null) return;
                while (Par != Parent[Par.First, Par.Second])
                {
                    Path.Push(Par);
                    Par = Parent[Par.First, Par.Second];
                }
            }
            public void DFS()
            {
                Stack<Pair<int, int>> s = new Stack<Pair<int, int>>();
                bool[,] Visited = new bool[n, n];
                Pair<int, int>[,] Parent = new Pair<int, int>[n, n];
                s.Push(begin);
                Visited[begin.First, begin.Second] = true;
                Parent[begin.First, begin.Second] = begin;

                bool done = false;
                while (s.Count > 0&&!done)
                {
                    Pair<int, int> cur = s.Pop();
                    OrderedPaths.Enqueue(cur);
                    if (grid[cur.First, cur.Second] == '#') continue;
                    for (int r = 0; r < 4&&!done; r++)
                    {
                        int row = cur.First + nwRow[r];
                        int col = cur.Second + nwCol[r];
                        if (Valid(row, col) && !Visited[row, col])
                        {
                            Visited[row, col] = true;
                            Parent[row, col] = cur;
                            if (row == end.First && col == end.Second) done = true;
                            s.Push(new Pair<int, int>(row, col));
                        }
                    }
                }

                Pair<int, int> Par = Parent[end.First, end.Second];
                if (Par == null) return;
                while (Par != Parent[Par.First, Par.Second])
                {
                    Path.Push(Par);
                    Par = Parent[Par.First, Par.Second];
                }
            }
            public void Paths()
            {
                while (OrderedPaths.Count > 0)
                {
                    System.Threading.Thread.Sleep(20);
                    Pair<int, int> cur = OrderedPaths.Dequeue();
                    if (grid[cur.First, cur.Second] == '.')
                    {
                        grid[cur.First, cur.Second] = '-';
                        Color.Red();
                        Console.SetCursorPosition(cur.Second, cur.First);
                        w('-'.ToString());
                        System.Threading.Thread.Sleep(30);
                        Color.Yellow();
                        Console.SetCursorPosition(cur.Second, cur.First);
                        w('-'.ToString());
                    }
                }
                Color.White();
                Console.SetCursorPosition(0,n+1);
            }
            public void finalPath()
            {
                Queue<Pair<int, int>> tmp = new Queue<Pair<int, int>>(Path);
                while(Path.Count>0)
                {
                    System.Threading.Thread.Sleep(10);
                    Pair<int, int> cur = Path.Pop();
                    if (grid[cur.First, cur.Second] == '-')
                    {
                        Color.Red();
                        Console.SetCursorPosition(cur.Second, cur.First);
                        w('-'.ToString());
                        System.Threading.Thread.Sleep(20);
                        Color.Cyan();
                        Console.SetCursorPosition(cur.Second, cur.First);
                        w('-'.ToString());
                    }
                }
                while(tmp.Count>0)
                {
                    System.Threading.Thread.Sleep(10);
                    Pair<int, int> cur = tmp.Dequeue();
                    if (grid[cur.First, cur.Second] == '-')
                    {
                        Color.Green();
                        Console.SetCursorPosition(cur.Second, cur.First);
                        w('-'.ToString());
                    }
                }
                Color.White();
                Console.SetCursorPosition(0, n + 5);
            }
            public void Reset()
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (grid[i, j] == '-' || grid[i,j]=='#')
                            grid[i, j] = '.';
            }
            public void Gen()
            {
                Random random = new Random();
                int wallCnt = random.Next(0, n * n - 2*n);
                while(wallCnt>0)
                {
                    int row = random.Next(0, n);
                    int col = random.Next(0, n);
                    if (grid[row,col]=='.')
                    {
                        grid[row, col] = '#';
                        wallCnt--;
                    }
                }
                Display(grid);
            }
        }
        static void Main(string[] args)
        {
            bool Y = true;
            do
            {
                Console.Clear();
                w("Enter N: ");
                int n = Read.Int();
                while(n<2)
                {
                    w("Enter N Value Greater Than 1: ");
                    n = Read.Int();
                }
                Map map = new Map(n);

                w("You Need Generate Walls(Y-N): ");
                if (Read.String().ToLower() == "y") map.Gen();

                Another:

                w("1- BFS.\t2-DFS.\n");
                w("Enter Choice: ");
                int choice = Read.Int();
                while(choice>2&&choice<1)
                {
                    w("Enter Valid Choice: ");
                    choice = Read.Int();
                }
                if (choice == 1) map.BFS();
                else if (choice == 2) map.DFS();

                map.Paths();
                map.finalPath();
                map.Reset();

                w("You Need Another Generator Walls(Y-N): ");
                if (Read.String().ToLower() == "y")
                {
                    map.Gen();
                    goto Another;
                }

                w("You Need Another Task(Y-N): ");
                Y = (Read.String().ToLower() == "y");
            } while (Y);
        }
        public static void w(string text, int spd = 0)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                System.Threading.Thread.Sleep(spd);
            }
        }
        public static void wl(string text="", int spd = 0)
        {
            w(text+'\n', spd);
        }
    }
}