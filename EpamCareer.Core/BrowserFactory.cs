using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace EpamCareer.Core
{
  public enum BrowserType
  {
    Firefox,
    Chrome,
  }

  public static class BrowserFactory
  {
     public static IWebDriver GetDriver(BrowserType type, int timeoutSec)
    {
      IWebDriver driver;
      switch (type)
      {
        case BrowserType.Firefox:
          {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeoutSec);
            break;
          }
        case BrowserType.Chrome:
          {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeoutSec);
            break;
          }
        default:
          {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeoutSec);
            break;
          }
      }
      return driver;
    }
  }
}
