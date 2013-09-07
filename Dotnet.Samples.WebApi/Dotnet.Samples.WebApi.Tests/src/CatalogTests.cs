// ----------------------------------------------------------------------------
// <copyright file="CatalogTests.cs" company="NanoTaboada">
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

namespace Dotnet.Samples.WebApi.Tests
{
    using Dotnet.Samples.WebApi.Models;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void Create_WhenInvokedWithBook_ThenShouldAddNewBook()
        {
            // Arrange
            var catalog = new Catalog();

            // Act
            catalog.Create(BookStub.Object);

            // Assert
            catalog.Retrieve(BookStub.Object.Isbn).ShouldBeEquivalentTo(BookStub.Object);
        }

        [TestMethod]
        public void Retrieve_WhenInvokedWithExistingIsbn_ThenShouldReturnMatchingBook()
        {
            // Arrange
            var catalog = new Catalog();
            catalog.Create(BookStub.Object);

            // Act
            var book = catalog.Retrieve(BookStub.Object.Isbn);

            // Assert
            book.ShouldBeEquivalentTo(BookStub.Object);
        }

        [TestMethod]
        public void Update_WhenInvokedWithExistingBook_ThenShouldUpdateMatchingBookAndReturnTrue()
        {
            // Arrange
            var catalog = new Catalog();
            catalog.Create(BookStub.Object);
            var book = catalog.Retrieve(BookStub.Object.Isbn);

            // Act
            book.InStock = BookStub.Object.InStock = false;
            var result = catalog.Update(book);

            // Assert
            book.ShouldBeEquivalentTo(catalog.Retrieve(BookStub.Object.Isbn));
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Update_WhenInvokedWithUnexistingBook_ThenShouldReturnFalse()
        {
            // Arrange
            var catalog = new Catalog();

            // Act
            var result = catalog.Update(BookStub.Object);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Delete_WhenInvokedWithExistingIsbn_ThenShouldRemoveMatchingBookAndReturnTrue()
        {
            // Arrange
            var catalog = new Catalog();
            catalog.Create(BookStub.Object);
            var book = catalog.Retrieve(BookStub.Object.Isbn);

            // Act
            var result = catalog.Delete(BookStub.Object.Isbn);

            // Assert
            catalog.RetrieveAll().Should().NotContain(book);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Delete_WhenInvokedWithUnexistingIsbn_ThenShouldReturnFalse()
        {
            // Arrange
            var catalog = new Catalog();

            // Act
            var result = catalog.Delete(BookStub.Object.Isbn);

            // Assert
            result.Should().BeFalse();
        }
    }
}
