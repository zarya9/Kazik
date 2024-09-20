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
using static Kazik.Pages.Authorization;

namespace Kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для _21.xaml
    /// </summary>
    public partial class _21 : Page
    {
        DBModel.Users us;
        
        string[] cards_a = new string[9] { "6", "7", "8", "9", "10", "J", "Q", "K", "Ace" };
        string[] cards_b = new string[4] { "clubs", "diamonds", "hearts", "spades" };
        Random rnd = new Random();
        string curcard;
        

        List<string> row1 = new List<string>();
        List<string> row2 = new List<string>();
        List<string> row3 = new List<string>();
        int row1c = 0;
        int row2c = 0;
        int row1p = 0;
        int row2p = 0;
        int hp = 3;
        int pts = 0;
        string messageBoxText = "Do you want to save changes?";
        string caption = "Word Processor";
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxImage icon = MessageBoxImage.Warning;
        MessageBoxResult result;
        GameSessions gs = new GameSessions();
        Bets bts = new Bets();
        public _21(DBModel.Users _us)
        {
            InitializeComponent();
            us = _us;
            this.DataContext = us;
            
            curcard = shuffle();
            hpUpd();
            ScoreUpd();
            row1_pts.Content = "0";
            row2_pts.Content = "0";
            us.Balance -= 700;
            gs.UserID = us.UserID;
            gs.StartedAt = DateTime.Now;
            gs.GameType = "21";
            

            ConnectionClass.connect.GameSessions.Add(gs);
            bts.UserID = us.UserID;
            bts.SessionId = gs.SessionID;
            ConnectionClass.connect.Bets.Add(bts);
        }

        private void row1_btn_Click(object sender, RoutedEventArgs e)
        {
            row1.Add(curcard);
            row1c++;
            switch (row1c)
            {
                case 1:
                    {
                        ChangeImage(row1_1, curcard);
                        break;
                    }
                case 2:
                    {
                        ChangeImage(row1_2, curcard);
                        break;
                    }
                case 3:
                    {
                        ChangeImage(row1_3, curcard);
                        break;
                    }
                case 4:
                    {
                        ChangeImage(row1_4, curcard);
                        break;
                    }
                case 5:
                    {
                        ChangeImage(row1_5, curcard);
                        break;
                    }
                case 6:
                    {
                        RowEnd("1");
                        row1c = 0;
                        break;
                    }
            }
            curcard = shuffle();
            RowEnd("1");
        }

        private void row2_btn_Click(object sender, RoutedEventArgs e)
        {
            row2.Add(curcard);
            row2c++;
            switch (row2c)
            {
                case 1:
                    {
                        ChangeImage(row2_1, curcard);
                        break;
                    }
                case 2:
                    {
                        ChangeImage(row2_2, curcard);
                        break;
                    }
                case 3:
                    {
                        ChangeImage(row2_3, curcard);
                        break;
                    }
                case 4:
                    {
                        ChangeImage(row2_4, curcard);
                        break;
                    }
                case 5:
                    {
                        ChangeImage(row2_5, curcard);
                        break;
                    }
                case 6:
                    {
                        RowEnd("2");
                        row2c = 0;
                        break;
                    }
            }
            curcard = shuffle();
            RowEnd("2");
        }

        

        public string shuffle()
        {
            string curr_card = $"{cards_b[rnd.Next(cards_b.Count())]} {cards_a[rnd.Next(cards_a.Count())]}";
            ChangeImage(curCard, curr_card);
            return curr_card;
        }
        public void ChangeImage(Image img, string card)
        {
            switch (card)
            {
                
                case "clubs 6":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/00.gif"));
                        break;
                    }
                case "clubs 7":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/01.gif"));
                        break;
                    }
                case "clubs 8":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/02.gif"));
                        break;
                    }
                case "clubs 9":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/03.gif"));
                        break;
                    }
                case "clubs 10":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/04.gif"));
                        break;
                    }
                case "clubs J":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/05.gif"));
                        break;
                    }
                case "clubs Q":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/06.gif"));
                        break;
                    }
                case "clubs K":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/07.gif"));
                        break;
                    }
                case "clubs Ace":
                    {
                        img.Source = BitmapFrame.Create(new Uri("https://magiachisel.ru/Pictures/Karty/k19/08.gif"));
                        break;
                    }
                case "diamonds 6":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/18.gif"));
                        break;
                    }
                case "diamonds 7":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/19.gif"));
                        break;
                    }
                case "diamonds 8":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/20.gif"));
                        break;
                    }
                case "diamonds 9":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/21.gif"));
                        break;
                    }
                case "diamonds 10":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/22.gif"));
                        break;
                    }
                case "diamonds J":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/23.gif"));
                        break;
                    }
                case "diamonds Q":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/24.gif"));
                        break;
                    }
                case "diamonds K":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/25.gif"));
                        break;
                    }
                case "diamonds Ace":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/26.gif"));
                        break;
                    }
                
                case "hearts 6":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/09.gif"));
                        break;
                    }
                case "hearts 7":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/10.gif"));
                        break;
                    }
                case "hearts 8":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/11.gif"));
                        break;
                    }
                case "hearts 9":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/12.gif"));
                        break;
                    }
                case "hearts 10":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/13.gif"));
                        break;
                    }
                case "hearts J":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/14.gif"));
                        break;
                    }
                case "hearts Q":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/15.gif"));
                        break;
                    }
                case "hearts K":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/16.gif"));
                        break;
                    }
                case "hearts Ace":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/17.gif"));
                        break;
                    }
                
                case "spades 6":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/27.gif"));
                        break;
                    }
                case "spades 7":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/28.gif"));
                        break;
                    }
                case "spades 8":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/29.gif"));
                        break;
                    }
                case "spades 9":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/30.gif"));
                        break;
                    }
                case "spades 10":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/31.gif"));
                        break;
                    }
                case "spades J":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/32.gif"));
                        break;
                    }
                case "spades Q":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/33.gif"));
                        break;
                    }
                case "spades K":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/34.gif"));
                        break;
                    }
                case "spades Ace":
                    {
                        img.Source = BitmapFrame.Create(new Uri(@"https://magiachisel.ru/Pictures/Karty/k19/35.gif"));
                        break;
                    }
            }
        }
        public void hpUpd()
        {
            Lives.Content = $"Жизни: {hp}";
            if (hp == 0)
            {
                
                messageBoxText = "Вы проиграли!";
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                row1.Clear();
                row2.Clear();
                row3.Clear();
                row1_1.Source = null;
                row1_2.Source = null;
                row1_3.Source = null;
                row1_4.Source = null;
                row1_5.Source = null;
                row2_1.Source = null;
                row2_2.Source = null;
                row2_3.Source = null;
                row2_4.Source = null;
                row2_5.Source = null;
               
                row1p = 0;
                row2p = 0;
                row1c = 0;
                row2c = 0;
                row1_pts.Content = 0;
                row2_pts.Content = 0;
                
                row1.Clear();
                row2.Clear();
                
                hp = 3;
                
                
                pts = 0;
                Lives.Content = $"Жизни: {hp}";
                ScoreUpd();
                
            }
        }
        public void ScoreUpd()
        {
            Score.Content = $"Счет: {pts}";
        }
        public void RowEnd(string rw)
        {
            if (rw == "1")
            {
                foreach (string c in row1)
                {
                    if (c.Contains("2"))
                    {
                        row1p += 2;
                        continue;
                    }
                    if (c.Contains("3"))
                    {
                        row1p += 3;
                        continue;
                    }
                    if (c.Contains("4"))
                    {
                        row1p += 4;
                        continue;
                    }
                    if (c.Contains("5"))
                    {
                        row1p += 5;
                        continue;
                    }
                    if (c.Contains("6"))
                    {
                        row1p += 6;
                        continue;
                    }
                    if (c.Contains("7"))
                    {
                        row1p += 7;
                        continue;
                    }
                    if (c.Contains("8"))
                    {
                        row1p += 8;
                        continue;
                    }
                    if (c.Contains("9"))
                    {
                        row1p += 9;
                        continue;
                    }
                    if (c.Contains("10"))
                    {
                        row1p += 10;
                        continue;
                    }
                    if (c.Contains("J"))
                    {
                        row1p += 2;
                        continue;
                    }
                    if (c.Contains("Q"))
                    {
                        row1p += 3;
                        continue;
                    }
                    if (c.Contains("K"))
                    {
                        row1p += 4;
                        continue;
                    }
                    if (c.Contains("Ace"))
                    {
                        if (row1p + 11 <= 21)
                            row1p += 11;
                        else
                            row1p += 1;
                        continue;
                    }
                }
                row1_pts.Content = row1p;
                if (row1p == 21)
                {
                    messageBoxText = "21!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row1_1.Source = null;
                    row1_2.Source = null;
                    row1_3.Source = null;
                    row1_4.Source = null;
                    row1_5.Source = null;
                    row1.Clear();
                    row1c = 0;
                    row1_pts.Content = 0;
                    pts += 300;
                    ScoreUpd();
                }
                else if (row1p > 21 & row1c <= 5)
                {
                    messageBoxText = "Слишком много карт!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row1_1.Source = null;
                    row1_2.Source = null;
                    row1_3.Source = null;
                    row1_4.Source = null;
                    row1_5.Source = null;
                    row1.Clear();
                    row1c = 0;
                    row1_pts.Content = 0;
                    if (pts >= 50)
                        pts -= 50;
                    hp = hp -1;
                    hpUpd();
                }
                else if (row1p < 21 & row1c == 5)
                {
                    messageBoxText = "Больше карт нельзя!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row1_1.Source = null;
                    row1_2.Source = null;
                    row1_3.Source = null;
                    row1_4.Source = null;
                    row1_5.Source = null;
                    row1.Clear();
                    row1c = 0;
                    row1_pts.Content = 0;
                    pts += 150;
                }
                row1p = 0;
            }
            if (rw == "2")
            {
                foreach (string c in row2)
                {
                    if (c.Contains("2"))
                    {
                        row2p += 2;
                        continue;
                    }
                    if (c.Contains("3"))
                    {
                        row2p += 3;
                        continue;
                    }
                    if (c.Contains("4"))
                    {
                        row2p += 4;
                        continue;
                    }
                    if (c.Contains("5"))
                    {
                        row2p += 5;
                        continue;
                    }
                    if (c.Contains("6"))
                    {
                        row2p += 6;
                        continue;
                    }
                    if (c.Contains("7"))
                    {
                        row2p += 7;
                        continue;
                    }
                    if (c.Contains("8"))
                    {
                        row2p += 8;
                        continue;
                    }
                    if (c.Contains("9"))
                    {
                        row2p += 9;
                        continue;
                    }
                    if (c.Contains("10"))
                    {
                        row2p += 10;
                        continue;
                    }
                    if (c.Contains("J"))
                    {
                        row2p += 2;
                        continue;
                    }
                    if (c.Contains("Q"))
                    {
                        row2p += 3;
                        continue;
                    }
                    if (c.Contains("K"))
                    {
                        row2p += 4;
                        continue;
                    }
                    if (c.Contains("Ace"))
                    {
                        if (row2p + 11 <= 21)
                            row2p += 11;
                        else
                            row2p += 1;
                        continue;
                    }
                }
                row2_pts.Content = row2p;
                if (row2p == 21)
                {
                    messageBoxText = "21!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row2_1.Source = null;
                    row2_2.Source = null;
                    row2_3.Source = null;
                    row2_4.Source = null;
                    row2_5.Source = null;
                    row2.Clear();
                    row2c = 0;
                    row2_pts.Content = 0;
                    pts += 300;
                    ScoreUpd();
                }
                else if (row2p > 21 & row2c <= 5)
                {
                    messageBoxText = "Слишком много карт!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row2_1.Source = null;
                    row2_2.Source = null;
                    row2_3.Source = null;
                    row2_4.Source = null;
                    row2_5.Source = null;
                    row2.Clear();
                    row2c = 0;
                    row2_pts.Content = 0;
                    if (pts >= 50)
                        pts -= 50;
                    hp --;
                    hpUpd();
                }
                else if (row2p < 21 & row2c == 5)
                {
                    messageBoxText = "Больше карт нельзя!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row2_1.Source = null;
                    row2_2.Source = null;
                    row2_3.Source = null;
                    row2_4.Source = null;
                    row2_5.Source = null;
                    row2.Clear();
                    row2c = 0;
                    row2_pts.Content = 0;
                    pts += 150;
                    ScoreUpd();
                }
                hpUpd();
                row2p = 0;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Хотите выйти?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                

                
                us.Balance += pts;
                
                NavigationService.GoBack();
                gs.EndedAt = DateTime.Now;
                
                ConnectionClass.connect.SaveChanges();
            }

        }
    }
}
