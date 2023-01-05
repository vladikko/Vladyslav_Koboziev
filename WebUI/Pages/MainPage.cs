namespace WebUI.Pages;

internal class MainPage
{
    protected readonly IWebDriver Driver;

    protected MainPage(IWebDriver driver)
    {
        this.Driver = driver;
    }
}