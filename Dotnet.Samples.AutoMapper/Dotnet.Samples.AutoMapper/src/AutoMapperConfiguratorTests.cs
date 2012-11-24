﻿﻿#region License
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

namespace Dotnet.Samples.AutoMapper
{
    using System;
    using AutoMapper;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class AutoMapperConfiguratorTests
    {
        [Test]
        public void Configure_AssertConfigurationIsValid_ShouldPass()
        {
            // Arrange & Act
            AutoMapperConfigurator.Configure();

            // Assert
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void WhenMappingBookToBookDto_ObjectGraph_ShouldBeEquivalent()
        {
            //Arrange
            var book = new Book()
            {
                Isbn13 = "0123456789012",
                Title = "Lorem Ipsum",
                Author = "John Doe",
                Publisher = "Foobar",
                Publication = DateTime.Now,
                Pages = 42,
                Description = "The quick brown fox jumps over the lazy dog.",
                InStock = true
            };

            //Act
            var bookDto = Mapper.Map<Book, BookDto>(book);

            //Assert
            bookDto.ShouldBeEquivalentTo(book, options => options.ExcludingMissingProperties());
        }

    }
}
