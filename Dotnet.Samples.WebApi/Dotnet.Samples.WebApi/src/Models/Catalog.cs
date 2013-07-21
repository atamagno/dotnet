// ----------------------------------------------------------------------------
// <copyright file="Catalog.cs" company="NanoTaboada">
//   Copyright (c) 2013 Nano Taboada, http://openid.nanotaboada.com.ar 
// 
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//   of this software and associated documentation files (the "Software"), to deal
//   in the Software without restriction, including without limitation the rights
//   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the Software is
//   furnished to do so, subject to the following conditions:
// 
//   The above copyright notice and this permission notice shall be included in
//   all copies or substantial portions of the Software.
// 
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//   THE SOFTWARE.
// </copyright>
// -----------------------------------------------------------------------﻿-----

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.WebApi.Models
{
    using System;
    using System.Collections.Generic;

    public class Catalog
    {
        private List<Book> books;

        public Catalog()
        {
            this.books = CatalogInitializer.Seed();
        }

        public void Create(Book book)
        {
            this.books.Add(book);
        }

        public Book Retrieve(string isbn)
        {
            return this.books.Find(item => item.Isbn == isbn.ToString());
        }

        public IEnumerable<Book> RetrieveAll()
        {
            return this.books;
        }

        public bool Update(string isbn)
        {
            var book = this.books.Find(item => item.Isbn == isbn);

            if (book != null)
            {
                this.books.Remove(book);
                this.books.Add(book);

                return true;
            }

            return false;
        }

        public bool Delete(string isbn)
        {
            var book = this.books.Find(item => item.Isbn == isbn.ToString());

            if (book != null)
            {
                this.books.Remove(book);

                return true;
            }

            return false;
        }
    }
}