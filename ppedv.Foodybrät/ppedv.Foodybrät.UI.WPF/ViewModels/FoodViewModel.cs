using ppedv.Foodybrät.Logic;
using ppedv.Foodybrät.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ppedv.Foodybrät.UI.WPF.ViewModels
{
    public class FoodViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //todo
        public ObservableCollection<Food> FoodList { get; set; }

        public Food SelectedFood { get; set; }

        public string KJ
        {
            get
            {
                if (SelectedFood == null)
                    return "---";

                return (SelectedFood.Kcal * 4.1868).ToString();
            }
        }

        Core core = new Core(new Data.EfCore.EfUnitOfWork());


        public FoodViewModel()
        {
            FoodList = new ObservableCollection<Food>(core.UnitOfWork.FoodRepository.Query());
        }

    }
}
