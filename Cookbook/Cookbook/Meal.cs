namespace Cookbook
{
    public class Meal
    {
        public Meal(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public int Time { get; private set; }

        public void AddTimeToPrepareTheMeal(string time)
        {
            if (int.TryParse(time, out var result))
            {
                AddTimeToPrepareTheMeal(result);
            }
            else
            {
                throw new Exception("Wrong time format, try again");
            }
        }
        public void AddTimeToPrepareTheMeal(int time)
        {
            this.Time = time;
        }
    }
}
