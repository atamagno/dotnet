// ----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------﻿-----

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.Redis
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using ServiceStack.Redis;
    using ServiceStack.Text;

    public class Program
    {
        public static void Main()
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var file = Path.Combine(Path.Combine(path, "cmd"), "redis-server.exe");

                if (File.Exists(file))
                {
                    using (var server = Process.Start(file))
                    {
                        if (server.Responding)
                        {
                            using (var client = new RedisClient())
                            {
                                client.FlushAll();
                                CatalogInitializer.Configure();

                                // Create
                                CatalogInitializer.Seed().ForEach(created => client.Store<Book>(created));
                                var message = string.Format("{0} [INFO] Created initial catalog (9 books):", DateTime.Now.ToTimestamp());
                                message.ToConsoleInfo();

                                // Read
                                var catalog = client.GetAll<Book>().ToList();
                                message = string.Format("{0} [INFO] Retrieving initial catalog ({1} books):", DateTime.Now.ToTimestamp(), catalog.Count);
                                message.ToConsoleInfo();
                                catalog.ForEach(retrieved => retrieved.ToJson<Book>().ToConsole());

                                var isbn = "9780596800956";
                                var book = client.GetById<Book>(isbn).ToJson<Book>();
                                message = string.Format("{0} [INFO] Retrieved book with ISBN {1}:", DateTime.Now.ToTimestamp(), isbn);
                                message.ToConsoleInfo();
                                book.ToConsole();

                                // Delete
                                var isbns = catalog.Take(3).Select(c => c.Isbn).ToList();
                                client.DeleteByIds<Book>(isbns);
                                message = string.Format("{0} [INFO] Deleted first {1} books.", DateTime.Now.ToTimestamp(), isbns.Count);
                                message.ToConsoleInfo();
                                catalog = null;
                                catalog = client.GetAll<Book>().ToList();

                                message = string.Format("{0} [INFO] Retrieving current catalog ({1} books):", DateTime.Now.ToTimestamp(), catalog.Count);
                                message.ToConsoleInfo();
                                catalog.ForEach(retrieved => retrieved.ToJson<Book>().ToConsole());
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(exception.ToString());
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
