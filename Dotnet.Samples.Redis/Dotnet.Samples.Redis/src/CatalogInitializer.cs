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

namespace Dotnet.Samples.Redis
{
    using System;
    using System.Collections.Generic;

    public static class CatalogInitializer
    {
        public static List<Book> Seed()
        {
            var books = new List<Book>();

            books.Add(
                new Book()
                {
                    Isbn = "9781430225492",
                    Title = "Pro C# 2010 and the .NET 4 Platform",
                    Author = "Andrew Troelsen",
                    Publisher = "Apress",
                    Publication = new DateTime(2010, 5, 10),
                    Pages = 1752,
                    InStock = true
                }
            );

            books.Add(
                new Book()
                {
                    Isbn = "9780596800956",
                    Title = "C# 4.0 in a Nutshell",
                    Author = "Joseph Albahari, et al.",
                    Publisher = "O'Reilly Media",
                    Publication = new DateTime(2010, 2, 10),
                    Pages = 1056,
                    InStock = true
                }
            );

            books.Add(
                new Book()
                {
                    Isbn = "9781449380342",
                    Title = "Head First C#",
                    Author = "Andrew Stellman, et al.",
                    Publisher = "O'Reilly Media",
                    Publication = new DateTime(2010, 5, 28),
                    Pages = 848,
                    InStock = true
                }
            );

            books.Add(
                new Book()
                {
                    Isbn = "9781935182474",
                    Title = "C# in Depth",
                    Author = "Jon Skeet",
                    Publisher = "Manning Publications",
                    Publication = new DateTime(2010, 11, 15),
                    Pages = 584,
                    InStock = true
                }
            );

            books.Add(
                new Book()
                {
                    Isbn = "9780735626706",
                    Title = "Microsoft Visual C# 2010 Step by Step",
                    Author = "John Sharp",
                    Publisher = "Microsoft Press",
                    Publication = new DateTime(2010, 3, 31),
                    Pages = 784,
                    InStock = true
                }
            );

            books.Add(
                new Book()
                {
                    Isbn = "9780321694690",
                    Title = "Essential C# 4.0",
                    Author = "Mark Michaelis",
                    Publisher = "Addison-Wesley Professional",
                    Publication = new DateTime(2010, 3, 20),
                    Pages = 984,
                    InStock = true
                }
            );

            books.Add(
                new Book()
                {
                    Isbn = "9780321658708",
                    Title = "Effective C#",
                    Author = "Bill Wagner",
                    Publisher = "Addison-Wesley Professional",
                    Publication = new DateTime(2010, 3, 15),
                    Pages = 352,
                    InStock = true
                }
            );

            books.Add(
                new Book()
                {
                    Isbn = "9780470502259",
                    Title = "Professional C# 4 and .NET 4",
                    Author = "Christian Nagel, et al.",
                    Publisher = "Wrox",
                    Publication = new DateTime(2010, 3, 8),
                    Pages = 1536,
                    InStock = true
                }
            );

            books.Add(
                new Book()
                {
                    Isbn = "9780596159832",
                    Title = "Programming C# 4.0",
                    Author = "Ian Griffiths, et al.",
                    Publisher = "O'Reilly Media",
                    Publication = new DateTime(2010, 8, 18),
                    Pages = 864,
                    InStock = true
                }
            );

            return books;
        }
    }
}