class SolveDayThree : SolutionsBase
{   
    public SolveDayThree(StreamReader given_sr) : base(given_sr)
    { 
    }

    public override void part_one()
    {
        string rucksack;
        string firstCompartment;
        string secondCompartment;
        char commonChar = '?';
        int numericValue;
        int totalValues = 0;

        while (stream_handle.Peek() >= 0)
        {
            rucksack = stream_handle.ReadLine();

            int totalItems = rucksack.Length;

            firstCompartment = rucksack.Substring(0, totalItems / 2);
            secondCompartment = rucksack.Substring(totalItems / 2, totalItems / 2);

            foreach(char f_ch in firstCompartment)
                foreach(char s_ch in secondCompartment)
                    if (f_ch == s_ch)
                        commonChar = f_ch;
            
            // mask off the last five bits
            numericValue = commonChar & 0x1F;

            // check for the letter case bit
            if ((commonChar & 0x20) == 0)
                numericValue += 26;

            totalValues += numericValue;
        }
        Console.WriteLine($"\t\tSum of the common priorities between each compartment in a signal rucksack is: {totalValues}.\n");
    }

    public override void part_two()
    {
        resetStream();

        string rucksack_I;
        string rucksack_II;
        string rucksack_III;
        char commonChar = '?';
        int numericValue;
        int totalValues = 0;

        while (stream_handle.Peek() >= 0)
        {
            rucksack_I = stream_handle.ReadLine();
            rucksack_II = stream_handle.ReadLine();
            rucksack_III = stream_handle.ReadLine();

            foreach(char item_I in rucksack_I)
                foreach(char item_II in rucksack_II)
                    if (item_I == item_II)
                        foreach(char item_III in rucksack_III)
                            if (item_I == item_III)
                                commonChar = item_I;

            numericValue = commonChar & 0x1F;

            if ((commonChar & 0x20) == 0)
                numericValue += 26;

            totalValues += numericValue;
        }
        Console.WriteLine($"\t\tSum of the bagdes that are common between teams of three Elves is: {totalValues}.\n");
    }
}