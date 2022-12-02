class SolveDayTwo : SolutionsBase
{   
    public SolveDayTwo(StreamReader given_sr) : base(given_sr)
    { 
    }

    int [,] lookupTable_I = new int[3,3]
    {
        {3,0,6},
        {6,3,0},
        {0,6,3}
    };

    public override void part_one()
    {
        string round = "";
        int roundOutcome = 0;
        int roundScore = 0;
        int totalScore = 0;

        while (stream_handle.Peek() >= 0)
        {
            round = stream_handle.ReadLine();
            roundOutcome = lookupTable_I[round[2] - 'X', round[0] - 'A'];
            roundScore = roundOutcome + (round[2] - 'X') + 1;
            totalScore += roundScore;
        }
        Console.WriteLine($"\t\tThe total score according to the strategy guide is: {totalScore}.\n");
    }

    int [,] lookupTable_II = new int[3,3]
    {
        {3,6,0},
        {0,3,6},
        {6,0,3}
    };

    public override void part_two()
    {
        resetStream();

        string round = "";
        int col;
        int roundScore;
        int totalScore = 0;
        int value;

        while (stream_handle.Peek() >= 0)
        {
            round = stream_handle.ReadLine();
            value = (round[2] - 'X') * 3;
            col = getCol(round[0] - 'A', value);
            roundScore = col + 1 + value;
            totalScore += roundScore;
        }
        Console.WriteLine($"\t\tThe total score of instructions for the second column, according to the strategy guide is: {totalScore}.\n");
    }

    private int getCol(int row, int val)
    {
        int retVal = -1;

        for (int col = 0; col < 3; col++)
        {
            if (lookupTable_II[row,col] == val)
            {
                retVal = col;                    
            }
        }
        return retVal;
    }
}