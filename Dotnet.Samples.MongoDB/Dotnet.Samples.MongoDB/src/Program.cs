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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1200:UsingDirectivesMustBePlacedWithinNamespace", Justification = "Prevented solution build.")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.MongoDB
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                CatalogInitializer.Configure();

                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var file = Path.Combine(Path.Combine(path, "cmd"), "mongod.exe");

                if (File.Exists(file))
                {
                    var mongodb = new ProcessStartInfo()
                    {
                        FileName = file,
                        Arguments = "--dbpath " + Path.Combine(path, "res"),
                    };

                    var process = Process.Start(mongodb);

                    if (process.Responding)
                    {
                        var client = new MongoClient("mongodb://localhost");
                        var server = client.GetServer();
                        var catalog = server.GetDatabase("catalog");
                        var books = catalog.GetCollection<Book>("books");

                        books.RemoveAll();

                        // Create
                        "[CREATE] InsertBatch".ToConsoleInfo();
                        books.InsertBatch<Book>(CatalogInitializer.Seed());

                        // Read
                        "[READ] FindAll".ToConsoleInfo();
                        books.FindAll().ToJson().ToConsole();

                        "[READ] FindOne".ToConsoleInfo();
                        var query = Query<Book>.EQ(prop => prop.Isbn, "9780596800956");
                        books.FindOne(query).ToJson().ToConsole();

                        // Update
                        "[UPDATE] Update (InStock = false)".ToConsoleInfo();
                        var update = Update<Book>.Set(prop => prop.InStock, false);
                        books.Update(query, update);
                        books.FindOne(query).ToJson().ToConsole();

                        // Delete
                        "[DELETE] Remove".ToConsoleInfo();
                        books.Remove(query);
                        books.FindOne(query).ToJson().ToConsole();
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
