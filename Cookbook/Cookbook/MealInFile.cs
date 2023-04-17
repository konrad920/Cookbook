using System.Runtime.CompilerServices;

namespace Cookbook
{
    public class MealInFile : MealBase
    {
        public override event AddNewMealName AddNewMeal;

        public override event AddNewRateOfMeal AddNewRate;

        public List<string> linesFromFile = new List<string>();

        private const string fileMealNames = "List_of_meals.txt";
        public MealInFile(string name)
            : base(name)
        {
        }
        public MealInFile()
        {
        }

        public override void AddFileAsNameOfMeal()
        {
            ReadMenuFileToLines();
            if (File.Exists($"{this.Name}.txt"))
            {
                throw new Exception("File is already exist");
            }
            else
            {
                using (var writer = File.Create($"{this.Name}.txt"))
                {
                    AddNewMeal(this, new EventArgs());
                    var statistic = new Statistic();
                    statistic.AddMeal(1);
                }

                using (var writer = File.AppendText(fileMealNames))
                {
                    writer.WriteLine($"{this.Name}");
                }
            }
        }

        public override void ReadMenuFileToLines()
        {
            if (File.Exists(fileMealNames))
            {
                using (var reader = File.OpenText(fileMealNames))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        this.linesFromFile.Add(line);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                this.linesFromFile = null;
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
                AddNewRate(this, new EventArgs());
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
                        this.linesFromFile.Add(line);
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
            using (var writer = File.CreateText($"{this.Name}-Statistic.txt"))
            {
                writer.WriteLine($"Ilosc ocen dla, {this.Name} to: {statisticfromFile.countRates}");
                writer.WriteLine($"Suma ocen dla, {this.Name} to: {statisticfromFile.sumRates}");
                writer.WriteLine($"Średnia ocena dla, {this.Name} to: {statisticfromFile.averangeRate}");
            }
            return statisticfromFile;
        }
    }
}
