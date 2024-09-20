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
using Kazik.Classes;
using Kazik.DBModel;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        DBModel.Users u = new DBModel.Users();
        public RegWindow()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            while (true) //ХУЙНЯ ИСПРАВИТЬ
            {
                if (string.IsNullOrEmpty(UsernameTextBox.Text)) 
                {
                    UsernameTextBox.Text = "Заполните поле";
                    break;
                }
                if (string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    
                    break;
                }
                if (string.IsNullOrEmpty(PasswordBox.Password))
                {
                    break;
                }
                if (string.IsNullOrEmpty(FirstNameTextBox.Text))
                {
                    break;
                }
                if (string.IsNullOrEmpty(LastNameTextBox.Text))
                {
                    break;
                }
                if(PasswordBox.Password != ConfirmPasswordBox.Password)
                {
                    MessageBox.Show("Пароли не совпадают!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                u.Username = UsernameTextBox.Text;
                u.Email = EmailTextBox.Text;
                u.Password = PasswordBox.Password;
                u.Name = FirstNameTextBox.Text;
                u.FName = LastNameTextBox.Text;
                u.CreatedAt = DateTime.Now;
                ConnectionClass.connect.Users.Add(u);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Добро пожаловать!", "Добавлен новый пользователь", MessageBoxButton.OK, MessageBoxImage.Information);
                break;
            }
        }
    }
}
