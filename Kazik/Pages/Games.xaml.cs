using Kazik.DBModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : Page
    {
        DBModel.Users us;
        
        public Games(DBModel.Users _us)
        {
            InitializeComponent();
            us = _us;
            this.DataContext = us;
            
        }

        private void Btn21_Click(object sender, RoutedEventArgs e)
        {
            var j = (sender as Button).DataContext as DBModel.Users;
            NavigationService.Navigate(new _21(j));
           
        }

        private void BtnSlot_Click(object sender, RoutedEventArgs e)
        {
            var j = (sender as Button).DataContext as DBModel.Users;
            NavigationService.Navigate(new Slots_machine(j));
        }

        private void BtnBeta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
