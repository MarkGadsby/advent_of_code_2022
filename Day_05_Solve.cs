class SolveDayFive : SolutionsBase
{   
    const int NSTACKS = 9;
    bool bPartII = false;

    public SolveDayFive(StreamReader given_sr) : base(given_sr)
    { 
    }

    public override void part_one()
    {
        string stack_data = stream_handle.ReadLine();
        
        Stack<char>[] reverseStack = new Stack<char>[NSTACKS];
        Stack<char>[] stackArray = new Stack<char>[NSTACKS];

        for (int i = 0; i < NSTACKS; i++)
        {
            reverseStack[i] = new Stack<char>();
            stackArray[i] = new Stack<char>();
        }

        while (stack_data[0] == '[')
        {
            for (int charPos = 1; charPos <= 33; charPos += 4)
            {
                if (stack_data[charPos] != ' ')
                    reverseStack[charPos / 4].Push(stack_data[charPos]);
            }
            stack_data = stream_handle.ReadLine();
        }

        for (int index = 0; index < NSTACKS; index++)
        {
            int count = reverseStack[index].Count;
            while (count-- > 0)
            {
                stackArray[index].Push(reverseStack[index].Pop());
            }
        }        

        // skip empty line
        stream_handle.ReadLine();

        string instructions; 
        string[] instruction_parts;
        int loops;
        int iFrom;
        int iTo;

        while (stream_handle.Peek() >= 0)
        {
            instructions = stream_handle.ReadLine();
            instruction_parts = instructions.Split(' ');
            loops = int.Parse(instruction_parts[1]);
            iFrom = int.Parse(instruction_parts[3]) -1;
            iTo = int.Parse(instruction_parts[5]) -1;

            if (bPartII)
            {
                Stack<char> tempStack = new Stack<char>();

                while (loops-- > 0)
                    tempStack.Push(stackArray[iFrom].Pop());

                int count = tempStack.Count;

                while (count-- > 0)
                    stackArray[iTo].Push(tempStack.Pop());
            }
            else
            {
                while (loops-- > 0)
                    stackArray[iTo].Push(stackArray[iFrom].Pop());                        
            }
        }
        
        Console.Write('\t');
        foreach(Stack<char> st in stackArray)
            Console.Write($"\t[{st.Peek()}]");
        Console.WriteLine();
    }

    public override void part_two()
    {
        resetStream();
        bPartII = true;
        part_one();
    }
}