﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Model.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int PageCount { get; set; }

        public bool IsBorrowed { get; set; }

        public Customer Borrower { get; set; }
    }
}
