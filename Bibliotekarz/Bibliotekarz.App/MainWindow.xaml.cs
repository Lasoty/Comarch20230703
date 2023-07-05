using Bibliotekarz.Model.Data;
using Bibliotekarz.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bibliotekarz.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> allBooks;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDb();

            DataContext = this;

            //GenerateFakeData();
            RefreshData();
        }

        private void RefreshData()
        {
            using ApplicationDbContext dbContext = new ApplicationDbContext();
            allBooks = dbContext.Books.ToList();

            BookList = new ObservableCollection<Book>(allBooks);
        }

        private void InitializeDb()
        {
            using ApplicationDbContext dbContext = new ApplicationDbContext();
            dbContext.Database.Migrate();
        }

        public ObservableCollection<Book> BookList { get; set; } = new();

        //private void GenerateFakeData()
        //{
        //    Book book = new Book
        //    {
        //        Id = 1,
        //        Author = "Leszek Lewandowski",
        //        Title = "Programowanie w C#",
        //        PageCount = 234,
        //        IsBorrowed = false
        //    };
        //    BookList.Add(book);

        //    book = new Book
        //    {
        //        Id = 1,
        //        Author = "John Sharp",
        //        Title = "Visual Studio krok po kroku",
        //        PageCount = 800,
        //        IsBorrowed = true,
        //        Borrower = new Customer
        //        {
        //            Id = 1,
        //            FirstName = "Jan",
        //            LastName = "Kowalski"
        //        }
        //    };
        //    BookList.Add(book);
        //}

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz zamnknąć aplikację?", "Zamykanie aplikacji", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);            
            }
            else
            {
                e.Handled = true;
            }

        }

        private void OnFilterClick(object sender, RoutedEventArgs e)
        {
            string filterText = txtFilter.Text;

            var filteredItems = allBooks
                .Where(book => book.Title.Contains(filterText, StringComparison.InvariantCultureIgnoreCase)
                            || book.Author.Contains(filterText, StringComparison.InvariantCultureIgnoreCase)
                            || (book.Borrower?.FirstName.Contains(filterText, StringComparison.InvariantCultureIgnoreCase) ?? false)
                            || (book.Borrower?.LastName.Contains(filterText, StringComparison.InvariantCultureIgnoreCase) ?? false));

            BookList.Clear();

            foreach (var item in filteredItems) 
            {
                BookList.Add(item);
            }
        }
    }
}
