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
using Kazik.Classes;
using Kazik.DBModel;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        Users us;
        public EditPage(Users _us)
        {
            InitializeComponent();
            us = _us;
            this.DataContext = us;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(FName.Text))
                {
                    MessageBox.Show("Введите фамилию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(Name.Text))
                {
                    MessageBox.Show("Введите имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(Email.Text))
                {
                    MessageBox.Show("Введите почту!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(CardNumber.Text))
                {
                    MessageBox.Show("Введите номер карты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(CVV.Text))
                {
                    MessageBox.Show("Введите CVV!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(DateCard.Text))
                {
                    MessageBox.Show("Введите срок карты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                
                var t = ConnectionClass.connect.Users.Where(z => z.UserID == us.UserID).FirstOrDefault();
                t.CVV = Convert.ToInt32(CVV.Text);
                t.FName = FName.Text;
                t.Name = Name.Text;
                string inputNumber = CardNumber.Text;
                string outputText = inputNumber.Replace(" ", "");
                t.Number_card = Convert.ToInt64(outputText);
                t.Email = Email.Text;
                string inputDate = DateCard.Text;
                string outputDate = inputDate.Replace("/", "");
                t.DateCard = Convert.ToInt32(outputDate);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Запись изменена", "Изменение записи", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
                break;
            }
            
        }

        private void FName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {

                e.Handled = true;


            }
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {

                e.Handled = true;


            }
        }

        private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void CardNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void CVV_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text != ".") && (!CVV.Text.Contains(".") && CVV.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void DateCard_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void FName_GotFocus(object sender, RoutedEventArgs e)
        {
            FName.Text = "";
        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            Name.Text = "";
        }

        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            Email.Text = "";
        }

        private void CardNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            CardNumber.Text = "";
        }

        private void CVV_GotFocus(object sender, RoutedEventArgs e)
        {
            CVV.Text = "";
        }

        private void DateCard_GotFocus(object sender, RoutedEventArgs e)
        {
            DateCard.Text = "";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
