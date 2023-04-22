namespace Cookbook
{
    public abstract class MealBase : IMeal
    {
        public delegate void AddNewMealName(object sender, EventArgs args);

        public delegate void AddNewRateOfMeal(object sender, EventArgs args);

        public abstract event AddNewRateOfMeal AddNewRate;

        public MealBase(string name)
        {
            this.Name = name;
        }
        public MealBase()
        {
        }

        public string Name { get; private set; }

        public abstract void AddRateOfTheMeal(string grade);

        public abstract void AddRateOfTheMeal(int grade);

        public abstract void AddNextRateOfMeal(string rate);

        public abstract Statistic GetStatistic();

        public List<string> ReadMenuFileToLines(string file)
        {
            List<string> linesFromFile = new List<string>();
            if (File.Exists(file))
            {
                using (var reader = File.OpenText(file))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        linesFromFile.Add(line);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception("You don't add any position to the list of meals yet");
            }
            return linesFromFile;
        }
    }
}
