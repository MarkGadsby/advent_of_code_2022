class SolveDayOne : SolutionsBase
{   
    public SolveDayOne(StreamReader given_sr) : base(given_sr)
    { 
    }

    public override void part_one()
    {
        int foodItemCalories = 0;
        int elfTotal = 0;
        int highElfTotal = 0;

        while (stream_handle.Peek() >= 0)
        {
            if (int.TryParse(stream_handle.ReadLine(), out foodItemCalories))
            {
                elfTotal +=  foodItemCalories;               
            }
            else
            {
                if (elfTotal > highElfTotal)
                    highElfTotal = elfTotal;
                
                elfTotal = 0;
            }
        }
        Console.WriteLine($"\t\tThe highest total calories carried by an Elf is: {highElfTotal}.\n");
    }

    private void sortSet(int[] set)
    {
        int temp = 0;

        if (set[0] > set[1])
        {
            temp = set[0];
            set[0] = set[1];
            set[1] = temp;
        }

        if (set[1] > set[2])
        {
            temp = set[1];
            set[1] = set[2];
            set[2] = temp;
        }

        if (set[0] > set[1])
        {
            temp = set[0];
            set[0] = set[1];
            set[1] = temp;
        }
    }

    public override void part_two()
    {
        resetStream();

        int[] topThree = new int[3]{0,0,0};
        sortSet(topThree);

        int foodItemCalories = 0;
        int elfTotal = 0;

        while (stream_handle.Peek() >= 0)
        {
            if (int.TryParse(stream_handle.ReadLine(), out foodItemCalories))
            {
                elfTotal +=  foodItemCalories;               
            }
            else
            {
                if (elfTotal > topThree[0])
                {
                    topThree[0] = elfTotal;
                }
                
                elfTotal = 0;
                sortSet(topThree);
            }                
        }

        int topThreeElfsTotal = 0;
        
        foreach (int num in topThree)
        {
            topThreeElfsTotal += num;
        }
        Console.WriteLine($"\t\tTotal calories carried by the top three Elfs is: {topThreeElfsTotal}.\n");
    }
}