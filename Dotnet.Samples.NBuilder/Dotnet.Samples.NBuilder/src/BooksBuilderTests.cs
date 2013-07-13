// -----------------------------------------------------------------------------
// <copyright file="BooksBuilderTests.cs" company="NanoTaboada">
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
// -----------------------------------------------------------------------﻿------

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.NBuilder
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class BooksBuilderTests
    {
        [Test]
        [TestCase(-1)]
        public void GetFakes_QuantityLessThanZero_ShouldThrowArgumentException(int quantity)
        {
            // Arrange & Act
            Action act = () => BooksBuilder.GetFakes(quantity);

            // Assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        [TestCase(8)]
        public void GetFakes_Isbns_ShouldNotContainNullsAndOnlyHaveUniqueItems(int quantity)
        {
            // Arrange & Act
            var isbns = BooksBuilder.GetFakes(quantity).Select(book => book.Isbn);

            // Assert
            isbns.Should().NotContainNulls().And.OnlyHaveUniqueItems();
        }

        [Test]
        [TestCase(8)]
        public void GetFakes_Titles_ShouldNotContainNullsAndOnlyHaveUniqueItems(int quantity)
        {
            // Arrange & Act
            var titles = BooksBuilder.GetFakes(quantity).Select(book => book.Title);

            // Assert
            titles.Should().NotContainNulls().And.OnlyHaveUniqueItems();
        }

        [Test]
        [TestCase(8)]
        public void GetFakes_Authors_ShouldNotContainNullsAndOnlyHaveUniqueItems(int quantity)
        {
            // Arrange & Act
            var authors = BooksBuilder.GetFakes(quantity).Select(book => book.Author);

            // Assert
            authors.Should().NotContainNulls().And.OnlyHaveUniqueItems();
        }

        [Test]
        [TestCase(8)]
        public void GetFakes_Publishers_ShouldNotContainNullsAndOnlyHaveUniqueItems(int quantity)
        {
            // Arrange & Act
            var publishers = BooksBuilder.GetFakes(quantity).Select(book => book.Publisher);

            // Assert
            publishers.Should().NotContainNulls().And.OnlyHaveUniqueItems();
        }

        [Test]
        [TestCase(8)]
        public void GetFakes_Publications_ShouldNotContainNullsAndBeBetweenStartAndToday(int quantity)
        {
            // Arrange
            var start = 1.January(1900);

            // Act
            var books = BooksBuilder.GetFakes(quantity);

            // Assert
            books.Should().NotContainNulls();
            books.All(book => book.Publication > start && book.Publication < DateTime.Today);
        }

        [Test]
        [TestCase(8)]
        public void GetFakes_Pages_ShouldBeOfLenghtLessThanAThousand(int quantity)
        {
            // Arrange & Act
            var pages = BooksBuilder.GetFakes(quantity).Select(book => book.Pages);

            // Assert
            pages.All(length => length < 1000);
        }

        [Test]
        [TestCase(8)]
        public void GetFakes_Descriptions_ShouldNotContainNullsAndOnlyHaveUniqueItems(int quantity)
        {
            // Arrange & Act
            var descriptions = BooksBuilder.GetFakes(quantity).Select(book => book.Description);

            // Assert
            descriptions.Should().NotContainNulls().And.OnlyHaveUniqueItems();
        }

        [Test]
        [TestCase(8)]
        public void GetFakes_InStockFlags_ShouldNotContainNullsAndOnlyContainTrueOrFalse(int quantity)
        {
            // Arrange & Act
            var instockFlags = BooksBuilder.GetFakes(quantity).Select(book => book.InStock);

            // Assert
            instockFlags.Should().NotContainNulls().And.OnlyContain(value => value == true || value == false);
        }
    }
}
