namespace Cookbook
{
    public class Statistic
    {
        public Statistic()
        {
            this.countMeals = 0;
            this.countRates = 0;
            this.sumRates = 0;
        }

        public int countMeals { get; private set; }
        public int countRates {  get; private set; }
        public int sumRates { get; private set; }
        public float averangeRate 
        {
            get
            {
                if (this.countRates != 0)
                {
                    return this.sumRates / this.countRates;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddRate(int rate)
        {
            this.countRates++;
            this.sumRates += rate;
        }

        public void AddMeal(int meal)
        {
            this.countMeals++;
        }
    }
}
