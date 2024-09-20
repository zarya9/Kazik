using Kazik.Classes;
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
using System.Windows.Shapes;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Vivod.xaml
    /// </summary>
    public partial class Vivod : Window
    {
        Users us;
        Transactions tr = new Transactions();
        public Vivod(Users _us)
        {
            InitializeComponent();
            us = _us;
            this.DataContext = us;
            TxtCard.Text = us.Number_card.ToString();
        }

        private void TxtAdd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);

        }

        
        private void Vivodi_Click(object sender, RoutedEventArgs e)
        {

            
            while (true)
            {
                if (string.IsNullOrEmpty(TxtAdd.Text))
                {
                    MessageBox.Show("Введите сумму", "Ошибка вывода", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                int a = Convert.ToInt32(TxtAdd.Text);
                if (a > us.Balance)
                {
                    MessageBox.Show("Вы не можете вывести больше имеющейся суммы", "Ошибка вывода", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                us.Balance = us.Balance - a;
                tr.Amount = a;

                tr.UserID = us.UserID;
                tr.TransactionType = "Вывод";
                tr.TransactionDate = DateTime.Now;

                tr.Status = "Проведено";
                ConnectionClass.connect.Transactions.Add(tr);
                ConnectionClass.connect.SaveChanges();


                MessageBox.Show("Cредства поступили на счет", "Вывод", MessageBoxButton.OK, MessageBoxImage.None);
                this.Close();
                break;
            }

        }
    }
}
