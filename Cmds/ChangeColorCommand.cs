using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.Cmds
{
    public class ChangeColorCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => (parameter as Inventory) != null;
        public override void Execute(object parameter)
        {
            ((Inventory)parameter).Color = "Pink";
        }
    }
}
