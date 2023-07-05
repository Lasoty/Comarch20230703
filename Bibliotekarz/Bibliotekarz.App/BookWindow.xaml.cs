using Bibliotekarz.Model.Data;
using Bibliotekarz.Model.Models;
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
using System.Windows.Shapes;

namespace Bibliotekarz.App
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        public BookWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public BookWindow(Book editedBook) : this()
        {
            MyBook = editedBook;

            if (MyBook.Borrower == null)
            {
                MyBook.Borrower = new Customer();
            }

            txtHeader.Text = "Edycja książki";
            this.Title = "Edytuj książke";
        }

        public Book MyBook { get; set; } = new Book()
        {
            Borrower = new Customer()
        };

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            using ApplicationDbContext dbContext = new ApplicationDbContext();

            if (MyBook.IsBorrowed == false)
                MyBook.Borrower = null;

            if (MyBook.Id != 0)
            {
                dbContext.Books.Attach(MyBook);
                dbContext.Books.Update(MyBook);
            }
            else
            {
                dbContext.Books.Add(MyBook);
            }
            dbContext.SaveChanges();

            DialogResult = true;
            Hide();
        }
    }
}
