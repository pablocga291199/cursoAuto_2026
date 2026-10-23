using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace cursoAuto
{
    public class Tests
    {
        private ChromeDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");

            Assert.That(driver.Title, Does.Contain("Google"));
        }

        [TearDown]
        public void tearDown()
        {
            driver?.Quit();

            driver?.Dispose();
        }


    }
}
