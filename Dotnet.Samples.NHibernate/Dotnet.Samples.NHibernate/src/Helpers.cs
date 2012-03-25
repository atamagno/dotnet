#region License
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

#region References
using System;
using System.IO;
using System.Reflection;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
#endregion

namespace Dotnet.Samples.NHibernate
{
    public static class Helpers
    {
        public static ISessionFactory CreateSessionFactory()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var sdf = Path.Combine(dir, "res", "Catalog.sdf");
            var cfg = MsSqlCeConfiguration
                .Standard.ConnectionString(raw => raw.Is(string.Format("Data Source = {0}", sdf)))
                .ShowSql()
                .FormatSql();

            return Fluently.Configure()
                .Database(cfg)
                .Mappings(map => map.FluentMappings
                    .AddFromAssemblyOf<Book>()
                    .Conventions.Add(Table.Is(pl => string.Format("{0}s", pl.EntityType.Name))))
                .BuildSessionFactory();
        }

        public static string FormatConsoleOutput(Book book)
        {
            var txt = new StringBuilder();
            txt.Append(System.Environment.NewLine);
            // INFO: ISBN-10 format pattern should be #-###-#####-#
            txt.AppendLine(String.Format("Getting book with ISBN: {0}-{1}-{2}-{3}", book.Isbn.Substring(0, 1), book.Isbn.Substring(1, 3), book.Isbn.Substring(4, 5), book.Isbn.Substring(9, 1)));
            txt.Append(System.Environment.NewLine);
            txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));
            txt.AppendLine(String.Format("{0,-37} {1,-23} {2,-10} {3,-5}", "Title", "Author", "Published", "Pages"));
            txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));
            txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", book.Title, book.Author, book.Published.ToShortDateString(), book.Pages));
            txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));
            return txt.ToString();
        }
    }
}
