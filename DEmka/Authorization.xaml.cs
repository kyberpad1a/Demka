using DEmka.AppDataFile;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace DEmka
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();

        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            var user = TradeDB.GetContext().Users.Where(x => x.UserLogin == TbLog.Text && x.UserPassword == TbPas.Text).FirstOrDefault();
            var iduser = user.UserID;
            if (iduser != 0)
            {
                FrameObj.frameMain.Navigate(new Products(user));
                FrameObj.FIO = String.Concat(user.UserSurname , user.UserName , user.UserSurname);
            }
            else
            {
                FrameObj.FIO = "Gues";
            }


        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = TradeDB.GetContext().Users.Where(x => x.UserLogin == TbLog.Text && x.UserPassword == TbPas.Text).FirstOrDefault();
            FrameObj.frameMain.Navigate(new Products(user));
        }
    }
}
