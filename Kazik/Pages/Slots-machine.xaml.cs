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
using System.Windows.Media.Animation;
using Kazik.DBModel;
using Kazik.Classes;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Slots_machine.xaml
    /// </summary>
    public partial class Slots_machine : Page
    {
        private readonly string[] emojis = new string[] { "😀", "🍒", "🍇", "🍋", "🍉", "💎", "🔔" };
        private Random random = new Random();
        DBModel.Users us;

         public int win = 0;
         public int victory = 0;
        GameSessions gs = new GameSessions();
        Bets bts = new Bets();

        public Slots_machine(DBModel.Users _us)
        {
            InitializeComponent();
            us = _us;
            this.DataContext = us;

            gs.UserID = us.UserID;
            gs.StartedAt = DateTime.Now;
            gs.GameType = "Слоты";


            ConnectionClass.connect.GameSessions.Add(gs);
            bts.UserID = us.UserID;
            bts.SessionId = gs.SessionID;
            ConnectionClass.connect.Bets.Add(bts);


        }
        
        private async void SpinButton_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if(string.IsNullOrEmpty(Stavkatxt.Text) || Stavkatxt.Text == "0")
                {
                    MessageBox.Show("Введите ставку", "Ошибка игры", MessageBoxButton.OK, MessageBoxImage.Stop );
                    break;
                }
                int a = Convert.ToInt32(Stavkatxt.Text);
                
                int bal = (int)us.Balance;
               
                if (a > bal)
                {
                    MessageBox.Show("У вас столько нет", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                }
                us.Balance = us.Balance - a;
                ConnectionClass.connect.SaveChanges();                
                SpinButton.IsEnabled = false;
                ResultText.Text = "";
                await SpinSlot(Slot1);
                await SpinSlot(Slot2);
                await SpinSlot(Slot3);
                CheckResult();
                SpinButton.IsEnabled = true;
                break;
            }
        }

        private async Task SpinSlot(TextBlock slot)
        {
            int spins = random.Next(20, 30);
            for (int i = 0; i < spins; i++)
            {
                slot.Text = emojis[random.Next(emojis.Length)];
                await Task.Delay(20);
            }
        }
        private void CheckResult()
        {
            int stavka = Convert.ToInt32(Stavkatxt.Text);
            
            //"😀", "🍒", "🍇", "🍋", "🍉", "💎", "🔔"
            if (Slot1.Text == Slot2.Text)
            {
                win = stavka * 2;
                ResultText.Text = $"Вы выиграли {win}!";
                
                victory += win;
                StavkaResulttxt.Text = $"Ваш выигрыш {victory}";

            }
            if (Slot2.Text == Slot3.Text)
            {
                win = stavka * 3;
                ResultText.Text = $"Вы выиграли {win}!";
                
                victory += win;
                StavkaResulttxt.Text = $"Ваш выигрыш {victory}";
            }
            if (Slot1.Text == Slot3.Text)
            {
                win = stavka * 4;
                ResultText.Text = $"Вы выиграли {win}!";
                
                victory += win;
                StavkaResulttxt.Text = $"Ваш выигрыш {victory}";
            }
            if (Slot1.Text == Slot2.Text && Slot2.Text == Slot3.Text)
            {
                win = stavka * 10;
                ResultText.Text = $"ДЖЕКПОТ {win}!";
                
                victory += win;
                StavkaResulttxt.Text = $"Ваш выигрыш {victory}";
            }
            
        }

        private void Stavkatxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Хотите выйти?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (win == 0)
                {
                    NavigationService.GoBack();
                }
                us.Balance += victory;
                gs.EndedAt = DateTime.Now;
                ConnectionClass.connect.SaveChanges();
                NavigationService.GoBack();
            }
        }
    }
}
