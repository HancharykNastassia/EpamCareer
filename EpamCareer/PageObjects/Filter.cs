using EpamCareer.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;

namespace EpamCareer.PageObjects
{
  class Filter
  {
    [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'job-search__input')]")]
    private IWebElement keywords;

    [FindsBy(How = How.XPath, Using = "//div[@class = 'selection']")]
    private IWebElement locationList;

    [FindsBy(How =How.XPath,Using = "//div[@class = 'selected-params ']")]
    private IWebElement jobMultiFilter;

    [FindsBy(How = How.XPath, Using = "//button[@type = 'submit']")]
    private IWebElement searchButton;

    public Filter()
    {
      PageFactory.InitElements(Browser.Instance.Driver, this);
    }

    public void SetKeywords(string words)
    {
      keywords.SendKeys(words);
    }

    public void SetLocation(string country, string city)
    {
      if (country == "" || city == "")
      {
        return;
      }

      locationList.Click();
      var cityElement = Browser.Instance.Driver.FindElement(By.XPath($"//li[text() = '{city}']"));
      if (cityElement.Displayed)
      {
        cityElement.Click();
      }
      else
      {
        Browser.Instance.Driver.FindElement(By.XPath($"//li[@aria-label = '{country}']")).Click();
        cityElement.Click();
      }
    }

    public void SetJobFilter(params string[] values)
    {
      jobMultiFilter.Click();
      var checkboxes = Browser.Instance.Driver.FindElements(By.ClassName("checkbox-custom-label"));
      foreach(var value in values)
      {
        checkboxes.FirstOrDefault(c => c.Text == value)?.Click();
      }
    }

    public void DoSearch()
    {
      searchButton.Click();
    }
  }
}
