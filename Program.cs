public class Program
{

    public static void Main()
    {
        Grid grid = new Grid();

        grid.setupBoard();


        while (grid.checkWin())
        {
            grid.add();
            System.Console.WriteLine("===========MOVE===========");
            System.Console.WriteLine("give the Y coordinate of the piece you want to move");
            int CurrentPosY = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("give the X coordinate of the piece you want to move");
            int CurrentPosX = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("give the Y coordinate of where you want to move");
            int PosToMoveY = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("give the X coordinate of where you want to move");
            int PosToMoveX = Convert.ToInt32(Console.ReadLine());


            grid.Move(PosToMoveY, PosToMoveX, CurrentPosY, CurrentPosX);
            System.Console.WriteLine("Saved grid");

            int decision = 1;
            while (decision == 1)
            {
                
                System.Console.WriteLine("Wanna pop grid 1-yes 0-no");
                decision = Convert.ToInt32(Console.ReadLine());
                if(decision == 1)
                    grid.pastGrid();

            }
            

        }





    }




}
