namespace WebUI.Pages;

internal class HomePage : MainPage
{
    private static readonly By AdminLinkLocator = 
        By.XPath("//*[@id=\"app\"]/div[1]/div[1]/aside/nav/div[2]/ul/li[1]/a");
    
    private static readonly By JobsMenuLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]");
    
    public HomePage(IWebDriver driver) : base(driver)
    {
        return;
    }

    public HomePage GoToAdminPanel()
    {
        Driver.FindElement(AdminLinkLocator).Click();
        return this;
    }

    private HomePage ClickOnJob()
    {
        Driver.FindElement(JobsMenuLocator).Click();
        return this;
    }

    public UserManagementPage GoToJobScenario()
    {
        ClickOnJob();
        return new UserManagementPage(Driver);
    }
}