class SolveDayFour : SolutionsBase
{   
    public SolveDayFour(StreamReader given_sr) : base(given_sr)
    { 
    }

    public override void part_one()
    {
        int totalValues = 0;
        string assignmentPair;
        string[] numberArray;
        (int,int) Pair1;
        (int,int) Pair2;

        while (stream_handle.Peek() >= 0)
        {
            assignmentPair = stream_handle.ReadLine();
            numberArray = assignmentPair.Split('-',',');

            Pair1.Item1 = int.Parse(numberArray[0]);
            Pair1.Item2 = int.Parse(numberArray[1]);
            Pair2.Item1 = int.Parse(numberArray[2]);
            Pair2.Item2 = int.Parse(numberArray[3]);

            if (Pair1.Item1 <= Pair2.Item1 && Pair1.Item2 >= Pair2.Item2)
                totalValues++;
            else if (Pair2.Item1 <= Pair1.Item1 && Pair2.Item2 >= Pair1.Item2)
                totalValues++;
        }
        Console.WriteLine($"\t\tSum of assignment pairs that fully contain another is: {totalValues}.\n");
    }

    public override void part_two()
    {
        resetStream();
        int totalValues = 0;
        string assignmentPair;
        string[] numberArray;
        (int,int) Pair1;
        (int,int) Pair2;

        while (stream_handle.Peek() >= 0)
        {
            assignmentPair = stream_handle.ReadLine();
            numberArray = assignmentPair.Split('-',',');

            Pair1.Item1 = int.Parse(numberArray[0]);
            Pair1.Item2 = int.Parse(numberArray[1]);
            Pair2.Item1 = int.Parse(numberArray[2]);
            Pair2.Item2 = int.Parse(numberArray[3]);

            if (Pair1.Item2 >= Pair2.Item1 && Pair1.Item1 <= Pair2.Item2)
                totalValues++;
        }
        Console.WriteLine($"\t\tSum of assignment pairs that overlap is: {totalValues}.\n");

    }
}