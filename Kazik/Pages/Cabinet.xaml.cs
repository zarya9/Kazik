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
using Kazik.DBModel;
using Kazik.Classes;
using Kazik.Pages;
using QRCoder;
using System.IO;
using System.Drawing;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class Cabinet : Page
    {
        DBModel.Users us;
        
        public Cabinet(DBModel.Users _us)
        {
            InitializeComponent();
            us = _us;
            this.DataContext = us;
            Refresh();

            FName.Text = us.FName;
            Name.Text = us.Name;
            Email.Text = us.Email;
            Balance.Text = us.Balance.ToString();
            CardNumber.Text = us.Number_card.ToString();
            QRCode();


        }

         public void Refresh()
        {
            FName.Text = us.FName;
            Name.Text = us.Name;
            Email.Text = us.Email;
            Balance.Text = us.Balance.ToString();
            CardNumber.Text = us.Number_card.ToString();
        }

        //private void UpdateUserData()
        //{
        //    if (CurrentUser.IsAuthenticated)
        //    {
        //        try
        //        {
        //            var updatedUser = ConnectionClass.connect.Users.FirstOrDefault(u => u.UserID == CurrentUser.User.UserID);
        //            if (updatedUser != null)
        //            {
        //                CurrentUser.SetUser(updatedUser);

        //                FName.Text = $"{updatedUser.FName}";
        //                Name.Text = $"{updatedUser.Name.ToString()}";
        //                Email.Text = updatedUser.Email;
        //                Balance.Text = updatedUser.Balance.ToString();
        //                CardNumber.Text = updatedUser.Number_card.ToString();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Пользователь не найден.");
        //                // Можно перенаправить на страницу авторизации
        //                NavigationService.Navigate(new Authorization());
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Ошибка при обновлении данных пользователя: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Пользователь не авторизован!");
        //        // Перенаправление на страницу авторизации
        //        NavigationService.Navigate(new Authorization());
        //    }
        //}

        private void Games_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                
                if (us.Number_card == null)
                {
                    Cardxaml card = new Cardxaml(us);
                    card.Show();
                    break;
                }
                
                NavigationService.Navigate(new Games(us));
                break;
            }
            
        }

        private void EditData_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage(us));
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TransactList());
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            BalanceUpxaml bal = new BalanceUpxaml(us);
            bal.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Хотите выйти?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                //Close();
            }
        }

        private void Vivod_Click(object sender, RoutedEventArgs e)
        {
            Vivod viv = new Vivod(us);
            viv.Show();
        }

        private void QRCode()
        {
            string url = us.qr; 

            
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            
            qrImage.Source = ConvertBitmapToBitmapImage(qrCodeImage);
        }

        private BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }   
}
