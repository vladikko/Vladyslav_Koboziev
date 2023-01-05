namespace WebUI.Pages;

internal class UserManagementPage : MainPage
{
    private static readonly By JobsMenuLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]");

    private static readonly By JobTitlesLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[1]/a");

    private static readonly By AddButtonLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div[1]/div/button");

    private static readonly By JobTitlesHeaderLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div[1]/h6");
    
    private static readonly By JobTitlesTitleLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[1]/label");
    
    private static readonly By JobTitleInputLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[2]/input");

    private static readonly By JobDescriptionInputLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/textarea");

    private static readonly By NoteInputLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[4]/div/div[2]/textarea");

    private static readonly By SaveButtonLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[5]/button[2]");

    private static readonly By RecordsFoundLocator =
        By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div[2]/div/span");

    private static readonly By ConfirmDeleteButtonLocator =
        By.CssSelector(".oxd-button--label-danger");
    
    public UserManagementPage(IWebDriver driver) : base(driver)
    {
        return;
    }

    private UserManagementPage ClickOnJob()
    {
        Driver.FindElement(JobsMenuLocator).Click();
        return this;
    }

    private UserManagementPage ClickOnJobTitle()
    {
        Driver.FindElement(JobTitlesLocator).Click();
        return this;
    }

    private UserManagementPage ClickOnAddButton()
    {
        WebDriverWait waitToLoad = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        waitToLoad.Until(jobTitleText => Driver.FindElement(JobTitlesHeaderLocator));
        Driver.FindElement(AddButtonLocator).Click();
        return this;
    }

    private UserManagementPage InputInfo(JobInfo info)
    {
        WebDriverWait waitToLoad = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        waitToLoad.Until(addJobTitleText => Driver.FindElement(JobTitlesTitleLocator));
        Driver.FindElement(JobTitleInputLocator).SendKeys(info.JobTitle);
        Driver.FindElement(JobDescriptionInputLocator).SendKeys(info.JobDescription);
        Driver.FindElement(NoteInputLocator).SendKeys(info.Note);

        return this;
    }

    private UserManagementPage ClickOnSaveButton()
    {
        Driver.FindElement(SaveButtonLocator).Click();
        return this;
    }

    private bool IsOnJobTitlePage(string jobTitleName)
    {
        WebDriverWait waitToLoad = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        waitToLoad.Until(recordFound => Driver.FindElement(RecordsFoundLocator));

        try
        {
            By jobTitleDeleteButtonLocator = By.XPath("//div[div[normalize-space()='" + jobTitleName + "']]//button[i[@class = 'oxd-icon bi-trash']]");

            return Driver.FindElement(jobTitleDeleteButtonLocator).Enabled;
        }
        catch (NoSuchElementException e)
        {
            return false;
        }
    }

    private UserManagementPage DeleteJobTitle(string jobTitleName)
    {
        Driver.FindElement(By.XPath("//div[div[normalize-space()='" + jobTitleName + "']]//button[i[@class = 'oxd-icon bi-trash']]")).Click();

        Driver.FindElement(ConfirmDeleteButtonLocator).Click();

        return this;
    }

    public bool CreatingNewJob(JobInfo info)
    {
        ClickOnJob();
        ClickOnJobTitle();
        ClickOnAddButton();
        InputInfo(info);
        ClickOnSaveButton();

        try
        {
            if (IsOnJobTitlePage(info.JobTitle))
            {
                DeleteJobTitle(info.JobTitle);
            }
        }
        catch (NoSuchElementException e)
        {
            return false;
        }

        return IsOnJobTitlePage(info.JobTitle);
    }
}