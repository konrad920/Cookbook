namespace Cookbook
{
    public class Meal
    {
        private List<int> grades = new List<int>();
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
                this.Time = result;
            }
            else
            {
                throw new Exception("Wrong time format, try again");
            }
        }

        public void AddRateOfTheMeal(string grade)
        {
            if (int.TryParse (grade, out var result))
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
                grades.Add(grade);
            }
            else
            {
                throw new Exception("Wrong range of grades");
            }
        }
    }
}
