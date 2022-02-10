class Program
{
    public static string Reverse(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public static void Main(string[] args)
    {
        try
        {
            int selection;
            do
            {
                Console.WriteLine("Select one of the following\n[1]. Sum of 2 nums\n[2]. X bit of Y num\n[3]. Reset last bit of num");
                selection = int.Parse(Console.ReadLine());
            } while (selection < 0 || selection > 3);

            switch (selection)
            {
                case 1:
                    float firstNum, secondNum, result;

                    Console.WriteLine("Here you can write to nums and I show you their sum\n\nEnter first num:");
                    firstNum = float.Parse(Console.ReadLine().Replace(".", ",")); //числа с плавающей запятой теперь можно писать с точкой и ничего плохого не случится
                    Console.WriteLine("Enter second num:");
                    secondNum = float.Parse(Console.ReadLine().Replace(".", ","));

                    result = firstNum + secondNum;
                    Console.WriteLine("\n\nResult is " + Math.Round(result, 3));
                    break;
                case 2:
                    int firstNumInt, secondNumInt;
                    string resultString;

                    Console.WriteLine("Simple - enter a num and desirable bit to show\n\nEnter num:");
                    firstNumInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter which bit of num to show:");
                    secondNumInt = int.Parse(Console.ReadLine());

                    resultString = Convert.ToString((byte)firstNumInt, 2);
                    Console.WriteLine("Written num in bytes - " + resultString);
                    resultString = Reverse(resultString);
                    Console.WriteLine(secondNumInt + " bit of num: " + resultString[secondNumInt-1]);
                    break;
                case 3:
                    Console.WriteLine("Reset last bit of num\n\nEnter num:");
                    firstNumInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Reseting bit...");
                    firstNumInt = ((firstNumInt >> 1) << 1);
                    Console.WriteLine(firstNumInt);
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in arguments");
            switch (e)
            {
                case FormatException _:
                    Console.WriteLine("Format Exception - only numbers allowed");
                    break;
                case OverflowException _:
                    Console.WriteLine("Overflow Exception - num too big");
                    break;
                case IndexOutOfRangeException _:
                    Console.WriteLine("OutofRange exception - chosen number is out of range");
                    break;
                default:
                    Console.WriteLine("Unknown error - " + e.Message);
                    break;
            }

        }
        finally
        {
            Console.Write("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}