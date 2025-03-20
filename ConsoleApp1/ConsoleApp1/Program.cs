
enum ITEMTYPE
{
    EA,
    BE,
    NO
}
class Item
{

    public ITEMTYPE itemType = ITEMTYPE.NO;

    public void Change()
    {
        itemType = ITEMTYPE.BE;
    }
}





namespace ConsoleApp1
{

    internal class Program
    {

        private static void Main(string[] args)
        {
            Item newItem = new Item();

            newItem.itemType = ITEMTYPE.EA;

            newItem.Change();


            

            
        }
    
    }
    
    
}

