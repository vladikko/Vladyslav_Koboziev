namespace WebUI.Storage;

public class JobInfo
{
    public string JobTitle { get; set; }

    public string JobDescription { get; set; }

    public string Note { get; set; }

    public JobInfo(string jobTitle, string jobDescription, string note)
    {
        this.JobTitle = jobTitle;
        this.JobDescription = jobDescription;
        this.Note = note;
    }
}