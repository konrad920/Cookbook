using Cookbook;

Console.WriteLine("Hello in my Cookbook program!!!");

var programActive = true;
while (programActive)
{
    Console.WriteLine("What do you want? (S)-show statistic, (A)-add rate of meal, (N)-add new meal, (Q)-quit the program, (L)-list of meals");
    var input = Console.ReadLine();
    switch (input)
    {
        case "N":
        case "n":
            Console.Write("Add name of the meal: ");
            var newMealName = Console.ReadLine();
            var newMeal = new MealInFile(newMealName);

            newMeal.AddNewMeal += AddNewMealName;
            void AddNewMealName(object sender, EventArgs args)
            {
                Console.WriteLine("You added new meal");
            }

            try
            {
                newMeal.AddFileAsNameOfMeal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("How would you rate this meal (integer from 0 to 10): ");
            var newRate = Console.ReadLine();

            newMeal.AddNewRate += AddNewRateOfMeal;
            void AddNewRateOfMeal(object sender, EventArgs args)
            {
                Console.WriteLine("You added new rate for this meal");
            }

            try
            {
                newMeal.AddRateOfTheMeal(newRate);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception catched: {e.Message}");
                continue;
            }
            break;
        case "A":
        case "a":
            Console.Write("Which meal do you want to rate: ");
            var mealToRate = Console.ReadLine();
            var meal = new MealInFile(mealToRate);
            if (File.Exists($"{mealToRate}.txt"))
            {
                Console.WriteLine("How would you rate this meal (integer from 0 to 10):");
                var nextRate = Console.ReadLine();

                meal.AddNewRate += AddNewRateOfMeal;
                void AddNextRateOfMeal(object sender, EventArgs args)
                {
                    Console.WriteLine("You added next rate for this meal");
                }

                try
                {
                    meal.AddNextRateOfMeal(nextRate);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            break;
        case "S":
        case "s":
            Console.Write("Which meal statistic you want see: ");
            var newStatisticName = Console.ReadLine();
            var newStatistic = new MealInFile(newStatisticName);
            try
            {
                Console.WriteLine($"Średnia ocena: {newStatistic.GetStatistic().AverangeRate}");
                Console.WriteLine($"Ilość ocen: {newStatistic.GetStatistic().CountRates}");
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
            break;
        case "L":
        case "l":
            var newList = new MealInFile();
            try
            {
                var newListOfNames = newList.ReadMenuFileToLines("List_of_meals.txt");
                Console.WriteLine($"Currently you have {newListOfNames.Count} meals in list");
                foreach (var line in newListOfNames)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "Q":
        case "q":
            Console.WriteLine("You closed my program");
            programActive = false;
            break;
        default: 
            Console.WriteLine("Wrong char, please try again");
            break;
    }
    
}
