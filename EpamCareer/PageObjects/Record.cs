using OpenQA.Selenium;

namespace EpamCareer.PageObjects
{
  public class Record
  {
    private IWebElement element;

    public string Vacancy { get; set; }

    public string Location { get; set; }

    public string Description { get; set; }

    public Record(IWebElement element)
    {
      this.element = element;
      Vacancy = this.element.FindElement(By.TagName("h5")).Text;
      Location = this.element.FindElement(By.TagName("strong")).Text;
      Description = this.element.FindElement(By.TagName("p")).Text;
    }
  }
}
