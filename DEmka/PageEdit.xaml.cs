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

namespace DEmka
{
    /// <summary>
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {   private Product ProductGL;
        public PageEdit(Product product)
        {
            InitializeComponent();
            DataContext=product;
            //CbProd.SelectedIndex = ;
            CbProd.ItemsSource = TradeDB.GetContext().Products.ToList();
            //CbProd.SelectedValuePath = "";
            CbProd.DisplayMemberPath = "ProductName";

            TextB.Text = product.ProductDescription;
            TextC.Text = product.ProductCost.ToString();
            ProductGL = product;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductGL.ProductName = CbProd.Text;
            ProductGL.ProductDescription = TextB.Text;
            ProductGL.ProductCost = Convert.ToDecimal(TextC.Text);

            TradeDB.GetContext().SaveChanges();
        }
    }
}
