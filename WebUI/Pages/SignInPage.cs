namespace WebUI.Pages;

internal class SignInPage : MainPage
{
    private static readonly By SignInFormLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div/div[1]/div/div[2]");

    private static readonly By SignInUsernameInputLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div/div[1]/div/div[2]/div[2]/form/div[1]/div/div[2]/input");

    private static readonly By SignInPasswordInputLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div/div[1]/div/div[2]/div[2]/form/div[2]/div/div[2]/input");

    private static readonly By SignInLoginButton =
        By.XPath("//*[@id=\"app\"]/div[1]/div/div[1]/div/div[2]/div[2]/form/div[3]/button");

    public SignInPage(IWebDriver driver) : base(driver)
    {
        return;
    }

    private SignInPage GetSignInPage()
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
        wait.Until(value => Driver.FindElement(SignInFormLocator));
        Thread.Sleep(100);
        return this;
    }

    private SignInPage EnterUsername(string username)
    {
        Driver.FindElement(SignInUsernameInputLocator).SendKeys(username);
        return this;
    }

    private SignInPage EnterPassword(string password)
    {
        Driver.FindElement(SignInPasswordInputLocator).SendKeys(password);
        return this;
    }

    private HomePage ClickLoginButton()
    {
        Driver.FindElement(SignInLoginButton).Click();
        return new HomePage(Driver);
    }

    private HomePage LoginAsUser(string username, string password)
    {
        GetSignInPage();

        Thread.Sleep(100);

        EnterUsername(username);
        EnterPassword(password);

        return ClickLoginButton();
    }

    public HomePage LoginAsAdmin(UserList user)
    {
        return LoginAsUser(user.UserName, user.Password);
    }
}