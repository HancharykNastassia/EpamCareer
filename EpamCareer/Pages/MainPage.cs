using EpamCareer.PageObjects;

namespace EpamCareer.Pages
{
  public class MainPage
  {
    public MenueBar MenueBar => new MenueBar();

    public VacancyPage OpenVacancies()
    {
      MenueBar.GoToVacancies();
      return new VacancyPage();
    }
  }
}
