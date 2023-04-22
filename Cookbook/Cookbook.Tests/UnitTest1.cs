namespace Cookbook.Tests
{
    public class Tests
    {
        [Test]
        public void GetNewRateThenReturnCorrectAverange()
        {
            //arrange
            var nameOfMeal = "Spagethi";
            var newMeal = new MealInMemory(nameOfMeal);

            //act
            newMeal.AddRateOfTheMeal(5);
            newMeal.AddRateOfTheMeal("7");
            newMeal.AddNextRateOfMeal("6");
            newMeal.GetStatistic();

            //assert
            Assert.AreEqual(6, newMeal.GetStatistic().AverangeRate);
        }
    }
}