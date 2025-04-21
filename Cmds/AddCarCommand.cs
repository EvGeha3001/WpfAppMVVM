using WpfMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM.Views;


namespace WpfMVVM.Cmds
{
    public class AddCarCommand : CommandBase
    {      

        public AddCarCommand() { }
        public override bool CanExecute(object parameter) =>
            parameter != null && parameter is ObservableCollection<Inventory>;
        public override void Execute(object parameter)
        {
            if (parameter is ObservableCollection<Inventory> cars)
            {
                AddCarView carView = new AddCarView();
                carView.Show();
            }
        }       
    }
}
