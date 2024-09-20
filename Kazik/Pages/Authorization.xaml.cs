using Kazik.Classes;
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
using Kazik.Pages;
using Kazik.DBModel;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    /// 
    //public static class CurrentUser
    //{
    //    public static Users User { get; private set; }

    //    public static void SetUser(Users user)
    //    {
    //        User = user;
    //    }

    //    public static void ClearUser()
    //    {
    //        User = null;
    //    }

    //    public static bool IsAuthenticated => User != null;
    //}
    public partial class Authorization : Page
    {
        
        public Authorization()
        {
            InitializeComponent();
            
            
        }

       

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            string login = txtUserName.Text;
            string password = txtPassword.Password;

            var user = ConnectionClass.connect.Users.FirstOrDefault(log => log.Username == login && log.Password == password);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }
            else
            {
                
                //CurrentUser.SetUser(user);
                MessageBox.Show($"Вы авторизовались как {user.FName} {user.Name}!");
                user.LastLogin = DateTime.Now;
                ConnectionClass.connect.SaveChanges();
                NavigationService.Navigate(new Cabinet(user));
            }
            
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();

        }

        
    }
}
