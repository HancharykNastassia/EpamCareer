using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace EpamCareer.Core
{
  public class Browser
  {
    public IWebDriver Driver { get; private set; }
    private static Browser currentInstance;
    public static Browser Instance => currentInstance ?? (currentInstance = new Browser());

    private Browser()
    {
      Driver = new FirefoxDriver();
      Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
    }

    public static void NavigateTo(string url)
    {
      Instance.Driver.Navigate().GoToUrl(url);
    }

    public static void Maximize()
    {
      Instance.Driver.Manage().Window.Maximize();
    }

    public static void Quit()
    {
      Instance.Driver.Quit();
    }
  }
}
