using Kazik.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cardxaml.xaml
    /// </summary>
    public partial class Cardxaml : Window
    {
        DBModel.Users users;
        public Cardxaml(DBModel.Users _users)
        {
            InitializeComponent();
            users = _users;
            this.DataContext = users;
        }

        private void NumberCard_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "[0-9]"))
            {
                e.Handled = true;
                return;
            }
            TextBox textBox = sender as TextBox;
            string currentText = textBox.Text.Replace(" ", ""); 
            if (currentText.Length >= 16)
            {
                e.Handled = true;
                return;
            }
            if ((currentText.Length + 1) % 4 == 0 && currentText.Length < 16)
            {
                textBox.Text += e.Text + " ";
                e.Handled = true;
                textBox.CaretIndex = textBox.Text.Length;
            }
        }

        private void Date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;
            string currentText = textBox.Text.Replace("/", ""); 
            if (!Regex.IsMatch(e.Text, "[0-9]"))
            {
                e.Handled = true;
                return;
            }
            if (currentText.Length >= 4)
            {
                e.Handled = true;
                return;
            }
            if (currentText.Length == 1 && !currentText.Contains("/"))
            {
                textBox.Text += e.Text + "/";
                e.Handled = true;
                textBox.CaretIndex = textBox.Text.Length; 
            }
        }

        private void BtnCard_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(NumberCard.Text))
                {
                    MessageBox.Show("Введите номер карты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(CvvInput.Password))
                {
                    MessageBox.Show("Введите CVV!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(Date.Text))
                {
                    MessageBox.Show("Введите дату пользования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }

                var t = ConnectionClass.connect.Users.Where(z => z.UserID == users.UserID).FirstOrDefault();
                string inputNumber = NumberCard.Text;
                string outputText = inputNumber.Replace(" ", "");
                users.Number_card = Convert.ToInt64(outputText);
                users.CVV = Convert.ToInt32(CvvInput.Password);
                string inputDate = Date.Text;
                string outputDate = inputDate.Replace("/","");
                users.DateCard = Convert.ToInt32(outputDate);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Карта добавлена", "Добавление карты", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                break;
            }
        }
    }
}
