using Cookbook;

Console.WriteLine("Hello in my Cookbook program!!!");

while (true)
{
    Console.WriteLine("Would you like to give a new dish (Y/N): ");
    var input = Console.ReadLine();
    if (input == "y" || input == "Y")
    {
        Console.Write("Add name of the meal: ");
        var newMealName = Console.ReadLine();
        var newMeal = new Meal(newMealName);
        Console.Write("How long do you prepare this meal in minutes: ");
        var newMealTime = Console.ReadLine();
        try
        {
            newMeal.AddTimeToPrepareTheMeal(newMealTime);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
            continue;
        }
        Console.Write("How would you rate this meal (integer from 0 to 10): ");
        var newRate = Console.ReadLine();
        try
        {
            newMeal.AddRateOfTheMeal(newRate);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched {e.Message}");
            continue;
        }
    }
    else if (input == "n" || input == "N")
    {
        Console.WriteLine("You have finished the program.");
        break;
    }
    else
    {
        Console.WriteLine("Wrong char please try again");
        continue;
    }
}
