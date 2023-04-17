namespace Cookbook.Tests
{
    public class Tests
    {
        [Test]
        public void GetNewMealThenCreateNewFile()
        {
            //arrange
            var nameOfMeal = "Spagethi";
            var newMeal = new MealInFile(nameOfMeal);

            //act
            newMeal.AddFileAsNameOfMeal();

            //assert
            Assert.IsTrue(File.Exists(nameOfMeal));
        }
    }
}