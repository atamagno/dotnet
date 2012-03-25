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
using NHibernate;
#endregion

/// <remarks>
/// INFO: Make sure 'System.Data.SqlServerCe' has its 'Copy Local' property set to 'True'.
/// </remarks>

namespace Dotnet.Samples.NHibernate
{
    class Program
    {
        static void Main()
        {
            try
            {
                var config = Helpers.CreateSessionFactory();

                using (ISession session = config.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var book = session.Get<Book>("0596800959");

                        if (book != null)
                        {
                            Console.WriteLine(Helpers.FormatConsoleOutput(book));
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(String.Format("Exception: {0}", error.ToString()));
            }
            finally
            {
                Console.Write(Environment.NewLine);
                Console.Write("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
