// ----------------------------------------------------------------------------
// <copyright file="CatalogInitializer.cs" company="NanoTaboada">
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
    using Dotnet.Samples.WebApi.Models;
    
    public static class CatalogInitializer
    {
        public static List<Book> Seed()
        {
            var books = new List<Book>();
 
            books.Add(
                new Book()
                {
                    Isbn = "9781430242338",
                    Title = "Pro C# 5.0 and the .NET 4.5 Framework",
                    Author = "Andrew Troelsen",
                    Publisher = "Apress",
                    Published = new DateTime(2012, 8, 22),
                    Pages = 1560,
                    InStock = true
                });

            books.Add(
                new Book()
                {
                    Isbn = "9781449320102",
                    Title = "C# 5.0 in a Nutshell",
                    Author = "Joseph Albahari, et al.",
                    Publisher = "O'Reilly Media",
                    Published = new DateTime(2012, 6, 26),
                    Pages = 1064,
                    InStock = true
                });

            books.Add(
                new Book()
                {
                    Isbn = "9780672336904",
                    Title = "C# 5.0 Unleashed",
                    Author = "Bart De Smet",
                    Publisher = "Sams Publishing",
                    Published = new DateTime(2013, 5, 3),
                    Pages = 1700,
                    InStock = true
                });

            books.Add(
                new Book()
                {
                    Isbn = "9781617291340",
                    Title = "C# in Depth, 3rd Edition",
                    Author = "Jon Skeet",
                    Publisher = "Manning Publications",
                    Published = new DateTime(2013, 09, 28),
                    Pages = 631,
                    InStock = true
                });

            books.Add(
                new Book()
                {
                    Isbn = "9780735668010",
                    Title = "Microsoft Visual C# 2012 Step by Step",
                    Author = "John Sharp",
                    Publisher = "Microsoft Press",
                    Published = new DateTime(2013, 1, 11),
                    Pages = 842,
                    InStock = true
                });

            books.Add(
                new Book()
                {
                    Isbn = "9780321877581",
                    Title = "Essential C# 5.0",
                    Author = "Mark Michaelis",
                    Publisher = "Addison-Wesley Professional",
                    Published = new DateTime(2012, 12, 7),
                    Pages = 1032,
                    InStock = true
                });

            books.Add(
                new Book()
                {
                    Isbn = "9781890774721",
                    Title = "Murach's C# 2012",
                    Author = "Joel Murach, et al.",
                    Publisher = "Mike Murach & Associates",
                    Published = new DateTime(2013, 5, 6),
                    Pages = 842,
                    InStock = true
                });

            books.Add(
                new Book()
                {
                    Isbn = "9780470502259",
                    Title = "Professional C# 2012 and .NET 4.5",
                    Author = "Christian Nagel, et al.",
                    Publisher = "Wrox",
                    Published = new DateTime(2012, 10, 6),
                    Pages = 1584,
                    InStock = true
                });

            books.Add(
                new Book()
                {
                    Isbn = "9781449320416",
                    Title = "Programming C# 5.0",
                    Author = "Ian Griffiths, et al.",
                    Publisher = "O'Reilly Media",
                    Published = new DateTime(2012, 10, 5),
                    Pages = 886,
                    InStock = true
                });

            return books;
        }
    }
}