﻿#region License
// Copyright (c) 2012 Nano Taboada, http://openid.nanotaboada.com.ar 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE. 
#endregion

namespace Dotnet.Samples.FluentAssertions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Catalog : IRepository<Book>
    {
        public Catalog()
        {
            this.Books = new List<Book>();
        }

        private List<Book> Books { get; set; }

        #region Impl. of IRepository
        public void Create(Book book)
        {
            this.Books.Add(book);
        }

        public Book Retrieve(string isbn)
        {
            if (!IsValidIsbn(isbn))
            {
                throw new FormatException("Invalid ISBN format.");
            }

            return  this.Books.Find(item => item.Isbn == isbn);
        }

        public void Update(Book book)
        {
            var update = this.Books.Find(item => item.Isbn == book.Isbn);

            if (update != null)
            {
                update.Isbn = (!string.IsNullOrWhiteSpace(book.Isbn) ? book.Isbn : update.Isbn);
                update.Title = (!string.IsNullOrWhiteSpace(book.Title) ? book.Isbn : update.Title);
                update.Author = (!string.IsNullOrWhiteSpace(book.Author) ? book.Author : update.Author);
                update.Publisher = (!string.IsNullOrWhiteSpace(book.Publisher) ? book.Publisher : update.Publisher);
                update.Publication = (book.Publication != update.Publication) ? book.Publication : update.Publication;
                update.Pages = (book.Pages != update.Pages) ? book.Pages : update.Pages;
                update.Description = (!string.IsNullOrWhiteSpace(book.Description) ? book.Description : update.Description);
                update.InStock = (book.InStock != update.InStock) ? book.InStock : update.InStock;

                this.Books.Remove(book);
                this.Books.Add(update);
            }
        }

        public void Delete(Book book)
        {
            this.Books.Remove(book);
        }
        #endregion

        public List<Book> GetAll()
        {
            return this.Books;
        }

        private bool IsValidIsbn(string isbn)
        {
            Regex regex = new Regex(@"(\d{1,3}([- ])\d{1,5}\2\d{1,7}\2\d{1,6}\2(\d|X))|(\d{1,5}([- ])\d{1,7}\5\d{1,6}\5(\d|X))|(\d{13})|(\d{10})");

            if (regex.IsMatch(isbn))
            {
                return true;
            }

            return false;
        }
    }
}
