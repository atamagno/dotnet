// -----------------------------------------------------------------------------
// <copyright file="Program.cs" company="NanoTaboada">
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

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.LinqToXml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml.Linq;

    public class Program
    {
        public static void Main()
        {
            try
            {
                //// Sample XML file (books.xml) is available to be downloaded from:
                //// http://msdn.microsoft.com/en-us/library/ms762271%28VS.85%29.aspx

                var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                var path = Path.Combine(Path.Combine(directory, "res"), "books.xml");
                var file = XDocument.Load(path);
                
                var books = from b in file.Descendants("book")
                            select new
                            { 
                                Id = b.Attribute("id").Value,
                                Title = b.Element("title").Value,
                                Author = b.Element("author").Value,
                                Genre = b.Element("genre").Value,
                                Price = b.Element("price").Value,
                                Published = b.Element("publish_date").Value
                            };

                // Notice that books is IEnumerable<anonymous>
                if (books != null)
                {
                    var builder = new StringBuilder();
                    builder.AppendConsoleFormat();

                    // Taking first 3 elements to fit default console window size (80x25)
                    foreach (var book in books.Take(3))
                    {
                        builder.AppendLine(string.Format("{0,-25} {1,-25} {2,-15} {3,10}", book.Title, book.Author, book.Published, book.Price));
                    }

                    builder.AppendLine(string.Format("{0,-25} {1,-25} {2,-15} {3,10}", "-".Repeat(25), "-".Repeat(25), "-".Repeat(15), "-".Repeat(10)));
                    Console.Write(builder.ToString());
                }

                Console.Write(Environment.NewLine);
                Console.WriteLine("2. Made taking advantage of LINQ to XML functional construction:");

                XDocument xml = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement(
                        "catalog",
                        new XElement(
                            "book",
                            new XAttribute("id", "bk999"),
                            new XElement("author", "Doe, John"),
                            new XElement("title", "Lorem Ipsum"),
                            new XElement("genre", "Miscellaneous"),
                            new XElement("price", "42"),
                            new XElement("publish_date", DateTime.Now.ToShortDateString()),
                            new XElement("description", "The quick brown fox jumps over the lazy dog."))));
                
                Console.Write(Environment.NewLine);
                Console.WriteLine(xml.ToString());
            }
            catch (Exception error)
            {
                Console.WriteLine(string.Format("Exception caught: {0}", error.Message));
            }
            finally
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
