using static Cookbook.MealBase;

namespace Cookbook
{
    public interface IMeal
    {
        string Name { get; }

        List<string> ReadMenuFileToLines(string file);

        void AddRateOfTheMeal(string grade);

        void AddRateOfTheMeal(int grade);

        Statistic GetStatistic();
        
        event AddNewRateOfMeal AddNewRate;
    }
}
