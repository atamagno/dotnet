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

namespace Dotnet.Samples.LinqToSql
{
    using System;
    using System.Data.SqlServerCe;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            try
            {
                var directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "res");
                var connection = new SqlCeConnectionStringBuilder();
                connection.DataSource = Path.Combine(directory, "Northwind.sdf");

                using (var data = new NorthwindDataContext(connection.ConnectionString))
                {
                    var query = from customer in data.Customers
                                join order in data.Orders
                                on customer.CustomerID equals order.CustomerID
                                where customer.Country == "USA" 
                                group customer by customer.City into customerPerCity
                                orderby customerPerCity.Count() descending
                                select new
                                {
                                    City = customerPerCity.Key,
                                    CustomerCount = customerPerCity.Count(),
                                    OrdersCount = customerPerCity.Sum(c => c.Orders.Count)
                                };

                    if (query != null)
                    {
                        var builder = new StringBuilder();
                        builder.AppendConsoleFormat();

                        foreach (var item in query)
                        {
                            builder.AppendLine(string.Format("{0,-54} {1,11} {2,11}", item.City, item.CustomerCount, item.OrdersCount));
                        }
                        
                        Console.Write(builder.ToString());
                    }
                }
            }
            catch (Exception error)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(string.Format("Exception: {0}", error.Message));
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
