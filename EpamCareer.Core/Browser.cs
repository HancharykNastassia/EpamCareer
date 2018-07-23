using OpenQA.Selenium;
using System;

namespace EpamCareer.Core
{
  public class Browser
  {
    public IWebDriver Driver { get; private set; }
    private static Browser currentInstance;
    public static Browser Instance => currentInstance ?? (currentInstance = new Browser());

    public string timeout;

    private string browserType;
    private BrowserType type;

    private Browser()
    {
      browserType = Configuration.Browser;
      timeout = Configuration.Timeout;

      Enum.TryParse(browserType, out type);
      Driver = BrowserFactory.GetDriver(type, Convert.ToInt32(timeout));
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
      currentInstance = null;
    }
  }
}
