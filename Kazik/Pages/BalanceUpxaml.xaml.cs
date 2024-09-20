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
using Kazik.Classes;
using Kazik.DBModel;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для BalanceUpxaml.xaml
    /// </summary>
    public partial class BalanceUpxaml : Window
    {
        Users us;
        Transactions tr = new Transactions();
        public BalanceUpxaml(Users _us)
        {
            InitializeComponent();
            us = _us;
            this.DataContext = us;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(TxtAdd.Text))
                {
                    MessageBox.Show("Введите сумму", "Пополнение", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }

                int a = Convert.ToInt32(TxtAdd.Text);
                if (a == 0)
                {
                    MessageBox.Show("Вы не можете пополнить на ноль", "Пополнение", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                us.Balance = us.Balance + a;
                tr.Amount = a;

                tr.UserID = us.UserID;
                tr.TransactionType = "Пополнение";
                tr.TransactionDate = DateTime.Now;

                tr.Status = "Проведено";
                ConnectionClass.connect.Transactions.Add(tr);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Cредства поступили на счет. Приятной игры", "Пополнение", MessageBoxButton.OK, MessageBoxImage.None);
                this.Close();
                break;
            }


           
        }

        private void TxtAdd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
