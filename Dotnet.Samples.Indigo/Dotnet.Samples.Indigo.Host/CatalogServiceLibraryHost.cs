﻿#region License
// Copyright (c) 2011 Nano Taboada, http://openid.nanotaboada.com.ar
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

/// <remarks>
/// [NOTE] Make sure you open this project via 'Run as administrator'
/// otherwise its execution will be throwing the following exception:
/// 
/// Please try changing the HTTP port to 8732 or running as Administrator.
/// System.ServiceModel.AddressAccessDeniedException:
/// HTTP could not register URL http://+:8000/Indigo/.
/// Your process does not have access rights to this namespace
/// (see http://go.microsoft.com/fwlink/?LinkId=70353 for details).
/// ---> System.Net.HttpListenerException: Access is denied
/// </remarks>

namespace Dotnet.Samples.Indigo.Host
{
    using System;
    using System.ServiceModel;
    using System.Text;
    // [INFO] Reference to assembly created by Dotnet.Samples.Indigo.Library:
    using Dotnet.Samples.Indigo.Library;
    using System.ServiceModel.Description;

    class CatalogServiceLibraryHost
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceHost host = new ServiceHost(typeof(CatalogServiceImplementation)))
                {
                    host.Open();
                    Console.WriteLine("Indigo Catalog Service Host successfully started.");
                    Console.WriteLine("Press any key to terminate process and exit . . .");
                    Console.ReadKey(true);
                    host.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
