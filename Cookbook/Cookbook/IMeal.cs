using static Cookbook.MealBase;

namespace Cookbook
{
    public interface IMeal
    {
        string Name { get; }

        void AddFileAsNameOfMeal();

        void ReadMenuFileToLines();

        List<string> ReadMenuFileToLines(string file);

        void AddRateOfTheMeal(string grade);

        void AddRateOfTheMeal(int grade);

        Statistic GetStatistic();

        event AddNewMealName AddNewMeal;
        
        event AddNewRateOfMeal AddNewRate;
    }
}
