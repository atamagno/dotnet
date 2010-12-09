﻿#region License
// Copyright (c) 2010 Nano Taboada, http://openid.nanotaboada.com.ar 
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

namespace Dotnet.Samples.LinqToSql
{
    #region References
    using System;
    using System.Linq;
    #endregion

    /// <summary>
    /// Interaction logic for Program
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Northwind and pubs sample databases are available to downloaded from:
                // http://www.microsoft.com/downloads/details.aspx?familyid=06616212-0356-46a0-8da2-eebc53a68034&displaylang=en

                // Make sure that SQL Server service is running and Northwind.mdf is plugged
                // (Server Explorer -> Data Connections -> Northwind.mdf -> [Right-click] -> Refresh)

                using (NorthwindDataContext data = new NorthwindDataContext())
                {
                    var query = from c in data.Customers where c.City == "Buenos Aires" select c;

                    Console.WriteLine("-----  ----------------------------------");
                    Console.WriteLine("Id     Company Name");
                    Console.WriteLine("-----  ----------------------------------");

                    foreach (var record in query)
                    {
                        Console.WriteLine("{0}  {1}", record.CustomerID, record.CompanyName);
                    }

                    Console.WriteLine("-----  ----------------------------------");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: " + error.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
