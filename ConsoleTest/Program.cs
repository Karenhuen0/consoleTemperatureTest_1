using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        // Define Value
        double freezValue = 0; double freezFluct = 0; double boilValue = 0; double boilFluct = 0;
        double tempatureValue = 0; int isFreez = 0; int isBoiling = 0; bool endApp = false;

        ArrayList tempatureAL = new ArrayList();
        ArrayList tempatureResult = new ArrayList();

        // For Freezing Alert Part
        Console.WriteLine("Type a Freezing threshold Default Number, and then press Enter");
        freezValue = returnDoubleValue(Console.ReadLine());

        Console.WriteLine("Type Freezing Fluctuation Limit number, and then press Enter");
        freezFluct = returnDoubleValue(Console.ReadLine());

        // For Boiling Alert Part
        Console.WriteLine("Type a Boiling threshold Default Number, and then press Enter");
        boilValue = returnDoubleValue(Console.ReadLine());

        Console.WriteLine("Type Boiling Fluctuation Limit number, and then press Enter");
        boilFluct = returnDoubleValue(Console.ReadLine());



        while (!endApp)
        {
            // Enter Value
            Console.WriteLine("Type number, and then press Enter");
            tempatureValue = returnDoubleValue(Console.ReadLine());

            tempatureAL.Add(tempatureValue.ToString("F1"));
            tempatureResult.Add(tempatureValue.ToString("F1"));

            // Condition
            if (tempatureValue == freezValue && isFreez == 0)
            {
                if (isBoiling == 1)
                {
                    tempatureResult.Add("unboiling");
                    isBoiling -= 1;
                }
                tempatureResult.Add("freezing");
                isFreez += 1;
            }
            else if (tempatureValue == boilValue && isBoiling == 0)
            {
                if (isFreez == 1)
                {
                    tempatureResult.Add("unfreezing");
                    isFreez -= 1;
                }
                tempatureResult.Add("boiling");
                isBoiling += 1;
            }
            else if (tempatureValue > (freezValue + freezFluct) && isFreez == 1)
            {
                tempatureResult.Add("unfreezing");
                isFreez -= 1;
            }
            else if ((tempatureValue < (boilValue + boilFluct) && tempatureValue < (boilValue - boilFluct)) && isBoiling == 1)
            {
                tempatureResult.Add("unboiling");
                isBoiling -= 1;
            }


            //result
            Console.Write("\nThe temperature inputs:\n");
            Console.Write(string.Join(" ", tempatureAL.ToArray()));
            Console.WriteLine();

            Console.Write("\nThe output:\n");
            Console.Write(string.Join(" ", tempatureResult.ToArray()));
            Console.WriteLine();


            Console.WriteLine("------------------------\n");
        }

    }

    public static double returnDoubleValue(string inputValue)
    {
        double returValue = 0;
        while (!double.TryParse(inputValue, out returValue))
        {
            Console.Write("This is not valid input. Please enter an integer value: ");
            inputValue = Console.ReadLine();
        }

        if (!string.IsNullOrEmpty(inputValue))
        {
            returValue = Convert.ToDouble(inputValue);
        }

        return returValue;
    }
}