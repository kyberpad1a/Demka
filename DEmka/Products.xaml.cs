using DEmka.AppDataFile;
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
using System.Windows.Threading;

namespace DEmka
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products(User user)
        {
            InitializeComponent();
            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(2);
            tmr.Tick += Update;
            tmr.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            var listdata = TradeDB.GetContext().Products.ToList();
            LstBooks.ItemsSource = listdata;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuDel_Click(object sender, RoutedEventArgs e)
        {
                TradeDB.GetContext().Products.Remove((Product)LstBooks.SelectedItem);
                TradeDB.GetContext().SaveChanges();
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageEdit((Product)LstBooks.SelectedItem));
        }





        //private void Abunga_Click(object sender, RoutedEventArgs e)
        //{
        //    var query =
        //    from product in tradeDB.Products
        //    where product.ProductName == "R"
        //    orderby product.ProductCost
        //    select new {product.ProductManufacturer, product.ProductPhoto};

        //}
    }
}
