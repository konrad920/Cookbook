using System.Runtime.CompilerServices;

namespace Cookbook
{
    public class MealInFile : Meal
    {
        private List<string> mealNames = new List<string>();

        private const string fileMealNames = "List_of_meals.txt";
        public MealInFile(string name)
            : base(name)
        {
        }
        public void AddFileAsNameOfMeal()
        {
            if (File.Exists($"{this.Name}"))
            {
                Console.WriteLine("File is already exist");
            }
            else
            {
                using (var writer = File.Create($"{this.Name}.txt"))
                {
                    mealNames.Add(this.Name);
                }

                using (var writer = File.AppendText(fileMealNames))
                {
                    writer.WriteLine($"{this.Name}, {this.Time}");
                }
            }
        }
        public void AddRateOfTheMeal(string grade)
        {
            if (int.TryParse(grade, out var result))
            {
                AddRateOfTheMeal(result);
            }
            else
            {
                throw new Exception("This is not integer");
            }
        }

        public void AddRateOfTheMeal(int grade)
        {
            if (grade > 0 && grade <= 10)
            {
                string fileName = $"{this.Name}.txt";
                using(var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
            }
            else
            {
                throw new Exception("Wrong range of grades");
            }
        }
    }
}
