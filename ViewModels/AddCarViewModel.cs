using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM.Cmds;
using WpfMVVM.Views;

namespace WpfMVVM.ViewModels
{
    public class AddCarViewModel : Inventory
    {
        private InventoryRepo _inventoryRepo = new InventoryRepo();

        private ICommand _submitCommand = null;
        public ICommand SubmitCmd => _submitCommand ?? (_submitCommand = new RelayCommand<object>(ExecuteSubmit, CanExecuteSubmit));

        private ICommand _cancelCommand = null;
        public ICommand CancelCmd => _cancelCommand ?? (_cancelCommand = new RelayCommand<object>((parameter) => ((System.Windows.Window)parameter).Close()));
        private bool CanExecuteSubmit(object parameter) => true;
        private void ExecuteSubmit(object parameter)
        {
            Inventory inventory = new Inventory() { Color = this.Color, Make = this.Make, PetName = this.PetName };
            _inventoryRepo.Add(inventory);
            ((System.Windows.Window)parameter).Close();
        }
    }
}
