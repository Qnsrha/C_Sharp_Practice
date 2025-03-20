using Inventory;
internal class Program
{
    private static void Main(string[] args)
    {
        Inven NewInven = new Inven(5, 3);
        Item NewItem1 = new Item("검", 100);
        Item NewItem2 = new Item("방패", 100);
        Item NewItem3 = new Item("활", 100);

        NewInven.ItemIn(NewItem1);
        NewInven.ItemIn(NewItem1);
        NewInven.ItemIn(NewItem3);
        NewInven.ItemIn(NewItem3, 7);
        NewInven.ItemIn(NewItem2, 7);

        while (true)
        {
            Console.Clear();
            NewInven.Render();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    NewInven.SelectIndex -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    NewInven.SelectIndex += 1;
                    break;
                case ConsoleKey.UpArrow:
                    NewInven.SelectIndex -= NewInven.ItemX;
                    break;
                case ConsoleKey.DownArrow:
                    NewInven.SelectIndex += NewInven.ItemX;
                    break;

                default:
                    break;
            }


            
        }
    }
}