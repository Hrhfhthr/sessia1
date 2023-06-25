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

namespace test2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void Load()
        {
            dataG.ItemsSource = App.db.Products.ToList();
        }
        public void Cnt()
        {
            all.Content = dataG.Items.Count + " из " + App.db.Products.Count();
        }
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CB1.SelectedIndex == 0)
            {
                dataG.ItemsSource=App.db.Products.Where(a=>a.Discount>=0 && a.Discount<=9.99).ToList();
                Cnt();
            }
            else if (CB1.SelectedIndex == 1)
            {
                dataG.ItemsSource = App.db.Products.Where(a => a.Discount >= 10 && a.Discount <= 14.99).ToList();
                Cnt();
            }
            else if (CB1.SelectedIndex == 2)
            {
                dataG.ItemsSource = App.db.Products.Where(a => a.Discount >= 15).ToList();
                Cnt();
            }
            else if (CB1.SelectedIndex == 3)
            {
                Load();
                Cnt();
            }
        }

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB2.SelectedIndex == 0)
            {
                var exmpl = App.db.Products.ToList();
                var sort = from i in exmpl
                           orderby i.Price descending
                           select i;
                dataG.ItemsSource = sort;
                Cnt();
            }
            else if (CB2.SelectedIndex == 1)
            {
                var exmpl = App.db.Products.ToList();
                var sort = from i in exmpl
                           orderby i.Price 
                           select i;
                dataG.ItemsSource = sort;
                Cnt();
            }
        }
    }
}
