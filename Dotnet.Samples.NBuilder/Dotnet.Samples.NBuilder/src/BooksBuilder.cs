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

namespace Dotnet.Samples.NBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FizzWare.NBuilder;

    public static class BooksBuilder
    {
        private static Random random = new Random();

        public static List<Book> GetFakes(int quantity)
        {
            if (quantity < 1) throw new ArgumentOutOfRangeException("Quantity should be positive.");

            return Builder<Book>
                .CreateListOfSize(quantity)
                    .All()
                        .With(book => book.Isbn = GetRandomFakeIsbn())
                        .With(book => book.Publication = GetRandomPastDate())
                        .With(book => book.Pages = random.Next(0,1000))
                        .With(book => book.InStock = Convert.ToBoolean(random.Next(0,2)))
                .Build()
                    .ToList();
        }

        private static string GetRandomFakeIsbn()
        {
            var ean = "978";
            var group = random.Next(0, 2).ToString("0");
            var publisher = random.Next(200, 699).ToString("000");
            var title = random.Next(0, 1000000).ToString("000000");
            var check = random.Next(0, 10).ToString("0"); // Not a real checksum!

            return string.Format("{0}-{1}-{2}-{3}-{4}", ean, group, publisher, title, check);
        }

        private static DateTime GetRandomPastDate()
        {
            var start = new DateTime(1900,1,1);
            var range = ((TimeSpan)(DateTime.Today - start)).Days;

            return start.AddDays(random.Next(range));
        }
    }


}
