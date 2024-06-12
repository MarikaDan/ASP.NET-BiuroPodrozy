using BiuroPodrozy_Zad_dom.Models;

namespace BiuroPodrozy_Zad_dom.ViewModels
{
	public class AdminPanelViewModel
	{
		public int ClientsCount { get; set; }
		public int ToursCount { get; set; }
		public int ReservationsCount { get; set; }

		public Tour[] Tours { get; set; }
	}
}