using EpamCareer.Core;
using EpamCareer.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace EpamCareer.Pages
{
  public class VacancyPage
  {
    public MenueBar menueBar;

    private Filter SearchFilters => new Filter();
    private List<Record> SearchResults;

    public void PerformSearch(string keywords = "", string country = "", string city = "", params string[] jobFilter)
    {
      SearchFilters.SetKeywords(keywords);
      SearchFilters.SetLocation(country, city);
      SearchFilters.SetJobFilter(jobFilter);
      SearchFilters.DoSearch();
    }

    public bool IsAnyExtra(string keywords, string location)
    {
      GetResults();
      var extraElements = SearchResults.Where(c => !(c.Vacancy.Contains(keywords) && (location.Contains(c.Location))));

      return extraElements.Any();
    }

    private void GetResults()
    {
      SearchResults = new List<Record>();
      var results = Browser.Instance.Driver.FindElements(By.TagName("article"));
      foreach(var result in results)
      {
        SearchResults.Add(new Record(result));
      }
    }
  }
}
