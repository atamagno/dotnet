// -----------------------------------------------------------------------------
// <copyright file="SessionFactory.cs" company="NanoTaboada">
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

using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1200:UsingDirectivesMustBePlacedWithinNamespace", Justification = "Prevented solution build.")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.NHibernate
{    
    public static class SessionFactory
    {
        public static ISessionFactory Create()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //// Make sure 'System.Data.SqlServerCe' has its 'Copy Local' property set to 'True'.
            var path = Path.Combine(directory, "res", "Catalog.sdf");
            var config = MsSqlCeConfiguration
                .Standard.ConnectionString(raw => raw.Is(string.Format("Data Source = {0}", path)))
                .ShowSql()
                .FormatSql();

            return Fluently.Configure()
                .Database(config)
                .Mappings(map => map.FluentMappings
                    .AddFromAssemblyOf<Book>()
                    .Conventions.Add(Table.Is(plural => string.Format("{0}s", plural.EntityType.Name))))
                .BuildSessionFactory();
        }
    }
}
