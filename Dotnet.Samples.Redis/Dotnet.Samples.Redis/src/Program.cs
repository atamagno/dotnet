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
                    var redis = new ProcessStartInfo()
                    {
                        FileName = file
                    };

                    using (var server = Process.Start(redis))
                    {
                        if (server.Responding)
                        {
                            using (var client = new RedisClient())
                            {
                                client.FlushAll();
                                CatalogInitializer.Configure();

                                // Create
                                "[CREATE] StoreAll".ToConsoleInfo();
                                client.StoreAll<Book>(CatalogInitializer.Seed());

                                // Read
                                "[READ] GetAll".ToConsoleInfo();
                                var catalog = client.GetAll<Book>().ToList();
                                catalog.ForEach(retrieved => retrieved.ToJson<Book>().ToConsole());

                                var isbn = "9780596800956";
                                string.Format("[READ] GetById (Isbn = {0})", isbn).ToConsoleInfo();
                                client.GetById<Book>(isbn).ToJson<Book>().ToConsole();

                                // Update
                                "[UPDATE] (InStock = false)".ToConsoleInfo();
                                var book = client.GetById<Book>(isbn);
                                book.InStock = false;
                                client.Store<Book>(book);
                                client.GetById<Book>(isbn).ToJson<Book>().ToConsole();

                                // Delete
                                string.Format("[DELETE] DeleteById (Isbn = {0})", isbn).ToConsoleInfo();
                                client.DeleteById<Book>(isbn);
                                client.GetById<Book>(isbn).ToJson<Book>().ToConsole();
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ToString().ToConsole();
            }
            finally
            {
                "Press any key to continue . . .".ToConsole();
                Console.ReadKey(true);
            }
        }
    }
}
