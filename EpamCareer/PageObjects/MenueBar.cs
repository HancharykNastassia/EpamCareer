using EpamCareer.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EpamCareer.PageObjects
{
  public class MenueBar
  {
    [FindsBy(How = How.XPath, Using = "//nav//a[@href = '/careers']")]
    private IWebElement careerButton;

    [FindsBy(How = How.XPath, Using = "//nav//a[@href = '/careers/job-listings']")]
    private IWebElement vacancybutton;

    public MenueBar()
    {
      PageFactory.InitElements(Browser.Instance.Driver, this);
    }

    public void GoToVacancies()
    {
      careerButton.Click();
    }
  }
}
