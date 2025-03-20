namespace Zone
{
    class Zone
    {
        string mName = "None";
        public List<Zone> LinkZone = new List<Zone>();

        public Zone Update()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("이곳은" + mName + "입니다");
                Console.WriteLine("이동가능한 리스트");

                for (int i = 0; i< LinkZone.Count; i++)
                {
                    Console.WriteLine((i + 1) + LinkZone[i].mName);
                }

                int Number = (int)Console.ReadKey().Key;
                Number -= 49;

                return LinkZone[Number];

            }
        }
        public Zone(string Name)
        {
            this.mName = Name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Zone NewZone0 = new Zone("태초마을");
            Zone NewZone1 = new Zone("초보사냥터");
            Zone NewZone2 = new Zone("중급사냥터");
            Zone NewZone3 = new Zone("중급마을");
            Zone NewZone4 = new Zone("고급사냥터");

            NewZone0.LinkZone.Add(NewZone1);
            NewZone0.LinkZone.Add(NewZone2);

            NewZone1.LinkZone.Add(NewZone3);
            NewZone1.LinkZone.Add(NewZone0);

            NewZone2.LinkZone.Add(NewZone3);

            NewZone3.LinkZone.Add(NewZone4);

            Zone StartZone = NewZone0;

            while (true) 
            { 
                StartZone = StartZone.Update(); 
            }    
        }
    }
}