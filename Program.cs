try
{
    Console.WriteLine($"\n\t***\tWelcome to day one of 2022 Advent of Code\t***\n");
   
    Console.WriteLine($"\t\tDay One - part I:");
    StreamReader sr = new StreamReader("Day_01_Data.txt");
    SolutionsBase solve = new SolveDayOne(sr);
    solve.part_one();
    Console.WriteLine($"\t\tDay One - part II:");
    solve.part_two();
    sr.Close();

    Console.WriteLine($"\t\tDay Two - part I:");
    sr = new StreamReader("Day_02_Data.txt");
    solve = new SolveDayTwo(sr);
    solve.part_one();
    Console.WriteLine($"\t\tDay Two - part II:");
    solve.part_two();
    sr.Close();

    Console.WriteLine($"\t\tDay Three - part I:");
    sr = new StreamReader("Day_03_Data.txt");
    solve = new SolveDayThree(sr);
    solve.part_one();
    Console.WriteLine($"\t\tDay Three - part II:");
    solve.part_two();
    sr.Close();

    Console.WriteLine($"\t\tDay Four - part I:");
    sr = new StreamReader("Day_04_Data.txt");
    solve = new SolveDayFour(sr);
    solve.part_one();
    Console.WriteLine($"\t\tDay Four - part II:");
    solve.part_two();
    sr.Close();

    Console.WriteLine($"\t\tDay Five - part I:");
    sr = new StreamReader("Day_05_Data.txt");
    solve = new SolveDayFive(sr);
    solve.part_one();
    Console.WriteLine($"\t\tDay Five - part II:");
    solve.part_two();
    sr.Close();

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

class SolutionsBase
{
    protected StreamReader stream_handle;

    public SolutionsBase(StreamReader given_sr)
    {
        stream_handle = given_sr;
    }

    protected void resetStream()
    {
        stream_handle.DiscardBufferedData();
        stream_handle.BaseStream.Seek(0, 0);
    } 

    public virtual void part_one(){}
    public virtual void part_two(){}
}
