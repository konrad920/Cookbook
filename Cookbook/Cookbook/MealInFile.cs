using System.Runtime.CompilerServices;

namespace Cookbook
{
    public class MealInFile : MealBase
    {
        public event AddNewMealName AddNewMeal;

        public override event AddNewRateOfMeal AddNewRate;

        private const string fileMealNames = "List_of_meals.txt";
        public MealInFile(string name)
            : base(name)
        {
        }
        public MealInFile()
        {
        }

        public void AddFileAsNameOfMeal()
        {
            if (File.Exists($"{this.Name}.txt"))
            {
                throw new Exception("File is already exist");
            }
            else
            {
                using (var writer = File.Create($"{this.Name}.txt"))
                {
                    if(AddNewMeal != null)
                    {
                        AddNewMeal(this, new EventArgs()); 
                    }
                    var statistic = new Statistic();
                }

                using (var writer = File.AppendText(fileMealNames))
                {
                    writer.WriteLine($"{this.Name}");
                }
            }
        }

        public override void AddRateOfTheMeal(string grade)
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

        public override void AddRateOfTheMeal(int grade)
        {
            if (grade > 0 && grade <= 10)
            {
                string fileName = $"{this.Name}.txt";
                using(var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
                if(AddNewRate != null)
                {
                    AddNewRate(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Wrong range of grades");
            }
        }

        private List<int> ReadMealFile(string file)
        {
            var rates = new List<int>();
            if (File.Exists(file))
            {
                using (var reader = File.OpenText(file))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        rates.Add(int.Parse(line));
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception("File does not exist");
            }
            return rates;
        }
        public Statistic CountStatistic(List<int> rates)
        {
            var statistic = new Statistic();
            foreach (var rate in rates)
            {
                statistic.AddRate(rate);
            }
            return statistic;
        }
        public override Statistic GetStatistic()
        {
            var ratesFromFile = ReadMealFile($"{this.Name}.txt");
            var statisticfromFile = CountStatistic(ratesFromFile);
            return statisticfromFile;
        }
    }
}
