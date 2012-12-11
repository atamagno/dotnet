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
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using ServiceStack.Redis;
    using ServiceStack.Text;

    class Program
    {
        static void Main()
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

                                foreach (var book in CatalogInitializer.Seed())
                                {
                                    client.Store<Book>(book);
                                }

                                var books = client.GetAll<Book>();

                                foreach (var book in books)
                                {
                                    Console.WriteLine(JsonSerializer.SerializeToString<Book>(book));
                                    Console.Write(Environment.NewLine);
                                }   
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
