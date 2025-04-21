using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfMVVM.ViewModels;

namespace WpfMVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для AddCarView.xaml
    /// </summary>
    public partial class AddCarView : Window
    {
        public AddCarViewModel ViewModel { get; set; } = new AddCarViewModel();
        public AddCarView()
        {
            InitializeComponent();
        }
    }
}
