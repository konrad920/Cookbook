namespace Cookbook
{
    public class MealInMemory : MealBase
    {
        private List<string> meals = new List<string>();

        public List<int> rates = new List<int>();
        public MealInMemory(string name) 
             : base(name)
        {
        }

        public override event AddNewMealName AddNewMeal;
        public override event AddNewRateOfMeal AddNewRate;

        public override void AddFileAsNameOfMeal()
        {
            meals.Add(this.Name);
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
                this.rates.Add(grade);
            }
            else
            {
                throw new Exception("Wrong range of grades");
            }
        }

        public override Statistic GetStatistic()
        {
            var statistic = new Statistic();
            foreach (var rate in this.rates)
            {
                statistic.AddRate(rate);
            }
            return statistic;
        }

        public override void ReadMenuFileToLines()
        {
            foreach (var meal in meals)
            {
                Console.WriteLine(meal);
            }
        }
    }
}
