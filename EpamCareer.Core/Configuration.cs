using System.Configuration;

namespace EpamCareer.Core
{
  public static class Configuration
  {
    public static string Browser => GetConfirurationParameter("Browser", "Firefox");

    public static string Timeout => GetConfirurationParameter("Timeout", "30");

    public static string GetConfirurationParameter(string parameter, string defaultValue)
    {
      return ConfigurationManager.AppSettings[parameter] ?? defaultValue;
    }
  }
}
