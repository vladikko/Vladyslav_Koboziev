namespace OrangeHRMTests
{
    [Binding]
    public sealed class ScenarioTest
    {
        private const string WebsiteUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(WebsiteUrl);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void AuthorizationTest()
        {
            var logPage = new SignInPage(_driver);
            var result = logPage.LoginAsAdmin(new UserList("Admin", "admin123"))
                .GoToAdminPanel()
                .GoToJobScenario()
                .CreatingNewJob(new JobInfo("Tester", ".NET", "C#"));
            Assert.False(result);
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            _driver.Close();
        }
    }
}

