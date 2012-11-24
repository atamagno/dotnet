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
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class CatalogTests
    {
        [Test]
        public void Create_WhenInvokedWithValidBook_ShouldCreateBook()
        {
            // Arrange
            var catalog = new Catalog();
            var book = new Book()
            {
                Isbn = "9781577315933",
                Title = "The Hero with a Thousand Faces",
                Author = "Joseph Campbell",
                Publisher = "New World Library",
                Publication = new DateTime(2008, 7, 28),
                Pages = 418,
                Description = "Since its release in 1949, The Hero with a Thousand Faces...",
                InStock = true
            };

            // Act
            catalog.Create(book);
            var result = catalog.Retrieve(book.Isbn);

            // Assert
            result.Should().NotBeNull();
            result.ShouldBeEquivalentTo(book);
            result.Description.ShouldBeEquivalentTo(book.Description);
            result.InStock.ShouldBeEquivalentTo(book.InStock);
        }

        [Test]
        public void Retrieve_WhenInvokedWithInvalidIsbn_ShouldThrowFormatException()
        {
            // Arrange
            var catalog = new Catalog();
            var book = new Book()
            {
                Isbn = "42"
            };

            // Act
            Action act = () => catalog.Retrieve(book.Isbn);

            // Assert
            act.ShouldThrow<FormatException>().WithMessage("Invalid ISBN format.");
        }

        [Test]
        public void Update_WhenInvokedWithValidBook_ShouldUpdateBook()
        {
            // Arrange
            var catalog = new Catalog();
            var book = new Book()
            {
                Isbn = "9781577315933",
                Title = "The Hero with a Thousand Faces",
                Author = "Joseph Campbell",
                Publisher = "New World Library",
                Publication = new DateTime(2008, 7, 28),
                Pages = 418,
                Description = "Since its release in 1949, The Hero with a Thousand Faces...",
                InStock = true
            };

            // Act
            catalog.Create(book);

            book.Description = "Originally written by Campbell in the '40s...";
            book.InStock = false;
            catalog.Update(book);

            var result = catalog.Retrieve(book.Isbn);

            // Assert
            result.Should().NotBeNull();
            result.ShouldBeEquivalentTo(book);
            result.Description.ShouldBeEquivalentTo(book.Description);
            result.InStock.ShouldBeEquivalentTo(book.InStock);
        }

        [Test]
        public void Delete_WhenInvokedWithValidBook_ShouldDeleteBook()
        {
            // Arrange
            var catalog = new Catalog();
            var book = new Book()
            {
                Isbn = "9781577315933",
                Title = "The Hero with a Thousand Faces",
                Author = "Joseph Campbell",
                Publisher = "New World Library",
                Publication = new DateTime(2008, 7, 28),
                Pages = 418,
                Description = "Since its release in 1949, The Hero with a Thousand Faces...",
                InStock = true
            };

            // Act
            catalog.Create(book);
            catalog.Delete(book);
            var result = catalog.Retrieve(book.Isbn);

            // Assert
            result.Should().BeNull();
        }

    }
}
