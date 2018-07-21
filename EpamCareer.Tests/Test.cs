using EpamCareer.Core;
using EpamCareer.Pages;
using NUnit.Framework;

namespace EpamCareer.Tests
{
  [TestFixture]
  public class Test
  {
    MainPage startPage;

    [SetUp]
    public void Init()
    {
      Browser.NavigateTo("https://careers.epam.by/");
      Browser.Maximize();
      startPage = new MainPage();
    }

    [Test]
    public void TestVacancySearch()
    {
      VacancyPage vacancyPage = startPage.OpenVacancies();
      vacancyPage.PerformSearch("Java Developer", "Беларусь", "Минск", "Разработка");
      var isAnyExtra = vacancyPage.IsAnyExtra("Java Developer", "MINSK, BELARUS МИНСК, БЕЛАРУСЬ");
      Assert.IsFalse(isAnyExtra, "There are some extra found items");
    }

    [TearDown]
    public void Quit()
    {
      Browser.Quit();
    }
  }
}
