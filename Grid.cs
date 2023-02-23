using System;
using System.Linq;

public class Grid
{
    private char[,] grid;
    private Stack<char[,]> PastGrids = new Stack<char[,]>();

    public char CurrentPlayer { get; set; }
    public char EnemyPlayer { get; set; }


    public Grid()
    {
        this.grid = new char[,] {
        {'-','-','-','-','-','-','-'}, //1
        {'-','-','-','-','-','-','-'}, //2
        {'-','-','-','-','-','-','-'}, //3
        {'-','-','-','-','-','-','-'}, //4
        {'-','-','-','-','-','-','-'}, //5
        {'-','-','-','-','-','-','-'}, //6
        {'-','-','-','-','-','-','-'}  //7        
        };


    }


    private void printGrid(char[,] grid)
    {

        int rowLength = this.grid.GetLength(0);
        int colLength = this.grid.GetLength(1);

        for (int y = 0; y < rowLength; y++)
        {
            for (int x = 0; x < colLength; x++)
            {
                Console.Write(string.Format("|{0}", grid[y, x]));


            }

            System.Console.WriteLine();

        }
    }

    //B
    //H

    public void setupBoard()
    {

        int startsize = 2;

        //row = x
        //column = y

        int rowLength = this.grid.GetLength(0);
        int columnLength = this.grid.GetLength(1);


        //Place B
        for (int j = 0; j < startsize; j++)
        {
            for (int i = rowLength - startsize; i < rowLength; i++)
            {
                this.grid[i, j] = 'B';
            }
        }

        //Place H
        for (int l = columnLength - startsize; l < columnLength; l++)
        {
            for (int k = 0; k < startsize; k++)
            {
                this.grid[k, l] = 'H';
            }
        }
        CurrentPlayer = 'H';
        EnemyPlayer = 'B';
        printGrid(this.grid);

    }

    public void Move(int PositionToMoveY, int PositionToMoveX, int CurrentPositionY, int CurrentPositionX)
    {


        if (this.grid[CurrentPositionY, CurrentPositionX] != CurrentPlayer)
        {
            System.Console.WriteLine("This piece is not yours");
            return;
        }
        if (this.grid[PositionToMoveY, PositionToMoveX] != '-')
        {
            System.Console.WriteLine("not an Empty space");
            return;
        }

        if (Math.Abs(CurrentPositionX - PositionToMoveX) <= 1 && Math.Abs(CurrentPositionY - PositionToMoveY) <= 1)
        {
            this.grid[PositionToMoveY, PositionToMoveX] = CurrentPlayer;
            Infect(PositionToMoveY, PositionToMoveX);
            printGrid(this.grid);
        }
        else if (Math.Abs(CurrentPositionX - PositionToMoveX) <= 2 && Math.Abs(CurrentPositionY - PositionToMoveY) <= 2)
        {
            this.grid[PositionToMoveY, PositionToMoveX] = CurrentPlayer;
            this.grid[CurrentPositionY, CurrentPositionX] = '-';
            Infect(PositionToMoveY, PositionToMoveX);
            printGrid(this.grid);
        }
        else
        {
            System.Console.WriteLine("thats not a valid move");
            return;
        }




        (CurrentPlayer, EnemyPlayer) = (EnemyPlayer, CurrentPlayer);
        System.Console.WriteLine("Player " + CurrentPlayer + " Is nu aan de beurt");
    }

    private void Infect(int newPosY, int newPosX)
    {
        for (int j = -1; j <= 1; j++)
        {
            for (int i = -1; i <= 1; i++)
            {
                if (((newPosX + i) > (this.grid.GetLength(0) -1)) || ((newPosX + i) < 0))
                {
                    continue;
                }

                if (((newPosY + j) > (this.grid.GetLength(1) -1)) || ((newPosY + j) < 0))
                {
                    continue;
                }

                if (this.grid[newPosY + j, newPosX + i] == EnemyPlayer)
                    this.grid[newPosY + j, newPosX + i] = CurrentPlayer;


            }
        }
    }

    public Boolean checkWin()

    {
        int totalH = 0;
        int PossibleMovesH = 0;
        int totalB = 0;
        int PossibleMovesB = 0;
        int rowLength = this.grid.GetLength(0);
        int colLength = this.grid.GetLength(1);

        for (int y = 0; y < rowLength; y++)
        {
            for (int x = 0; x < colLength; x++)
            {
                if (grid[y, x] == 'B')
                {
                    totalB++;
                    if (totalB == rowLength * colLength)
                    {
                        System.Console.WriteLine("Player B heeft gewonnen door size");
                        return false;
                    }
                    for (int j = -2; j <= 2; j++)
                    {
                        for (int i = -2; i <= 2; i++)
                        {
                            if (((x + i) > (this.grid.GetLength(0) -1)) || ((x + i) < 0))
                            {
                                continue;
                            }

                            if (((y + j) > (this.grid.GetLength(1) - 1)) || ((y + j) < 0))
                            {
                                continue;
                            }

                            else if (grid[y+j, x+i] == '-')
                                PossibleMovesB++;
                        }
                    }
                    if (PossibleMovesB == 0) {
                        System.Console.WriteLine("Player H heeft gewonnen");
                        return false;
                    }
                }
                else if (grid[y, x] == 'H')
                {
                    totalH++;
                    if (totalH == rowLength * colLength)
                    {
                        System.Console.WriteLine("Player H heeft gewonnen door size");
                        return false;
                    }
                     for (int j = -2; j <= 2; j++)
                    {
                        for (int i = -2; i <= 2; i++)
                        {
                            if (((x + i) > (this.grid.GetLength(0) -1)) || ((x + i) < 0))
                            {
                                continue;
                            }

                            if (((y + j) > (this.grid.GetLength(1)- 1)) || ((y + j) < 0))
                            {
                                continue;
                            }
                            else if (grid[y+j, x+i] == '-')
                                PossibleMovesH++;
                        }
                    }
                    if (PossibleMovesH == 0) {
                        System.Console.WriteLine("Player B heeft gewonnen");
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public void add()
    {
        char[,] copy = new char[,] {
        {'-','-','-','-','-','-','-'}, //1
        {'-','-','-','-','-','-','-'}, //2
        {'-','-','-','-','-','-','-'}, //3
        {'-','-','-','-','-','-','-'}, //4
        {'-','-','-','-','-','-','-'}, //5
        {'-','-','-','-','-','-','-'}, //6
        {'-','-','-','-','-','-','-'}  //7        
        };


        copy = grid.Clone() as char[,];
        PastGrids.Push(copy);


    }

    public void pastGrid()
    {
        if (PastGrids.Count() != 0)
            grid = PastGrids.Peek();
        printGrid(PastGrids.Pop());
    }

}