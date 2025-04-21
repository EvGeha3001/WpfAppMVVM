using WpfMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM.DAL.Repos;
using WpfMVVM.Cmds;
using System.Data.Entity.Core.Metadata.Edm;


namespace WpfMVVM.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly InventoryRepo _inventoryRepo = new InventoryRepo();

        private Inventory _selectedInventory; 
        public Inventory SelectedInventory
        {
            get => _selectedInventory;
            set => _selectedInventory = value;
        }
        
        private RelayCommand<Inventory> _deleteCarCommand = null;
        public RelayCommand<Inventory> DeleteCarCmd => _deleteCarCommand ??
            (_deleteCarCommand = new RelayCommand<Inventory>(car => 
            {
                Cars.Remove(car);
                _inventoryRepo.Delete(car);
            }, car => car != null));


        private ICommand _changeColorCommand = null;
        public ICommand ChangeColorCmd =>
            _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());

        private ICommand _addCarCommand = null;
        public ICommand AddCarCmd => _addCarCommand ?? (_addCarCommand = new AddCarCommand());

        public IList<Inventory> Cars { get; }
        
        public MainWindowViewModel()
        {            
            Cars = new ObservableCollection<Inventory>(_inventoryRepo.GetAll());
        }
    }
}
