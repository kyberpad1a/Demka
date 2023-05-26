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
using DEmka.AppDataFile;

namespace DEmka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameObj.frameMain = MainFrame;

            MainFrame.Navigate(new Authorization());
            
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if(((Page)MainFrame.Content).Title.ToString() == "Authorization")
            {
                Header.Text = "Авторизация";
                BackBtn.Visibility = Visibility.Hidden;
            }
            else if(((Page)MainFrame.Content).Title.ToString() == "Products")
            {
                if (FrameObj.FIO == "Gues")
                {
                    TbFio.Text = FrameObj.FIO.ToString();
                }
                BackBtn.Visibility = Visibility.Visible;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void LogPage_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new Authorization());
        }
    }
}
