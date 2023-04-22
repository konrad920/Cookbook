namespace Cookbook
{
    public class MealInMemory : MealBase
    {
        public List<int> rates = new List<int>();
        public MealInMemory(string name) 
             : base(name)
        {
        }

        public override event AddNewRateOfMeal AddNewRate;

        public override void AddNextRateOfMeal(string rate)
        {
            AddRateOfTheMeal(rate);
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
                AddNewRate(this, new EventArgs());
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
    }
}
