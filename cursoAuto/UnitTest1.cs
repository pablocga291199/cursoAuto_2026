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
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        [Retry(2)]
        [TestCase("student", "Password123")]
        [Category("Funcional")]
        //camino feliz
        public void ValidarLoginExitoso(string username, string password)
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

            //Assert.That(driver.Title, Does.Contain("Practice Test Automation | Test Login"));
            
            //validar que el título de la página y las credenciales son correctas
            Assert.That(driver.Title, Does.Contain("Test Login | Practice Test Automation"));
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            //validar que la URL después del login exitoso es la correcta
            Assert.That(driver.Url, Does.Contain("https://practicetestautomation.com/logged-in-successfully/"));
            //validar que el mensaje de h1 de login exitoso es el correcto
            Assert.That(driver.FindElement(By.TagName("h1")).Text, Does.Contain("Logged In Successfully"));
            //Assert.That(driver.FindElement(By.CssSelector("h1.post-title")).Text, Is.EqualTo("Logged In Successfully"));

            //validar que el mensaje de p de login exitoso es el correcto
            Assert.That(driver.FindElement(By.TagName("p")).Text, Does.Contain("Congratulations student. You successfully logged in!"));
            
            driver.FindElement(By.LinkText("Log out")).Click();
            Assert.That(driver.Url, Does.Contain("https://practicetestautomation.com/practice-test-login/"));
            Assert.That(driver.Title, Does.Contain("Test Login | Practice Test Automation"));

        }

        [Test]
        [Retry(3)]
        [TestCase("students", "Password123")]
        [TestCase(" ", "Password123")]
        [Category("Smoke")]
        public void ValidarLoginErroneoUsuario(string username, string password)
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            Assert.That(driver.Title, Does.Contain("Test Login | Practice Test Automation"));

            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Assert.That(driver.FindElement(By.Id("error")).Text, Does.Contain("Your username is invalid!"));
            Assert.That(driver.FindElement(By.Id("error")).GetDomProperty("textContent"), Is.EqualTo("Your username is invalid!"));
        }

        [Test]
        [Retry(2)]
        [TestCase("student", "Password")]
        [TestCase("student", "321")]
        [TestCase("student", "wrongpassword")]
        [TestCase("student", "******")]
        [Category("Smoke")]
        public void ValidarLoginErroneo(string username, string password)
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            Assert.That(driver.Title, Does.Contain("Test Login | Practice Test Automation"));

            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Assert.That(driver.FindElement(By.Id("error")).Text, Does.Contain("Your password is invalid!"));
            Assert.That(driver.FindElement(By.Id("error")).GetDomProperty("textContent"), Is.EqualTo("Your password is invalid!"));
        }




        [TearDown]
        public void tearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }


    }
}
