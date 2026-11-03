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
        // ***camino feliz***
        //[Test]
        ////[Retry(2)]
        //[TestCase("student", "Password123")]
        //[Category("Funcional")]

        //public void ValidarLoginExitoso(string username, string password)
        //{
        //    driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");


        //    //validar que el título de la página y las credenciales son correctas
        //    Assert.That(driver.Title, Does.Contain("Test Login | Practice Test Automation"));
        //    driver.FindElement(By.Id("username")).SendKeys(username);
        //    driver.FindElement(By.Id("password")).SendKeys(password);
        //    driver.FindElement(By.Id("submit")).Click();

        //    //validar que la URL después del login exitoso es la correcta
        //    Assert.That(driver.Url, Does.Contain("https://practicetestautomation.com/logged-in-successfully/"));
        //    //validar que el mensaje de h1 de login exitoso es el correcto
        //    Assert.That(driver.FindElement(By.TagName("h1")).Text, Does.Contain("Logged In Successfully"));
        //    //Assert.That(driver.FindElement(By.CssSelector("h1.post-title")).Text, Is.EqualTo("Logged In Successfully"));

        //    //validar que el mensaje de p de login exitoso es el correcto
        //    Assert.That(driver.FindElement(By.TagName("p")).Text, Does.Contain("Congratulations student. You successfully logged in!"));

        //    driver.FindElement(By.LinkText("Log out")).Click();
        //    Assert.That(driver.Url, Does.Contain("https://practicetestautomation.com/practice-test-login/"));
        //    Assert.That(driver.Title, Does.Contain("Test Login | Practice Test Automation"));

        //}

        //***escenario login fallido_1 | contraseña inválida***
        [Test]
        //[Retry(3)]
        [TestCase("student", "passwd")]
        [TestCase("student", "123")]
        [TestCase("student", "")]
        [TestCase("student", "***")]
        [Category("Funcional")]
        public void ValidarLoginErroneoPasswd(string username, string password)
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            Assert.That(driver.Title, Does.Contain("Test Login | Practice Test Automation"));

            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Assert.That(driver.FindElement(By.Id("error")).Text, Does.Contain("Your password is invalid!"));
            Assert.That(driver.FindElement(By.Id("error")).GetDomProperty("textContent"), Is.EqualTo("Your password is invalid!"));
        }


        //***escenario login fallido_2 | usuario inválido***
        [Test]
        //[Retry(3)]
        [TestCase("", "Password123")]
        [TestCase("test", "Password123")]
        [TestCase("std", "Password123")]
        [TestCase("###", "Password123")]
        [Category("Funcional")]
        public void ValidarLoginErroneoUsername(string username, string password)
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            Assert.That(driver.Title, Does.Contain("Test Login | Practice Test Automation"));

            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Assert.That(driver.FindElement(By.Id("error")).Text, Does.Contain("Your username is invalid!"));
            Assert.That(driver.FindElement(By.Id("error")).GetDomProperty("textContent"), Is.EqualTo("Your username is invalid!"));
        }

      [TearDown]
        public void tearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }


    }
}
