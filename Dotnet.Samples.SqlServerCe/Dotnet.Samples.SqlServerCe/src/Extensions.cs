// -----------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="NanoTaboada">
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

namespace Dotnet.Samples.SqlServerCe
{
    using System;
    using System.Data.Common;
    using System.Text;

    public static class Extensions
    {
        public static string FormatValues(this DbDataReader reader)
        {
            var builder = new StringBuilder();

            builder.AppendLine(string.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));
            builder.AppendLine(string.Format("{0,-37} {1,-23} {2,-10} {3,-5}", "Title", "Author", "Published", "Pages"));
            builder.AppendLine(string.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));

            while (reader.Read())
            {
                builder.AppendFormat("{0,-37} {1,-23} {2,10} {3,5}", reader.GetString(1), reader.GetString(2), reader.GetDateTime(4).ToShortDateString(), reader.GetValue(5));
                builder.Append(Environment.NewLine);
            }

            builder.AppendLine(string.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));

            return builder.ToString();
        }

        public static string Repeat(this char character, int frequency)
        {
            return new string(character, frequency);
        }

        public static string Repeat(this string content, int frequency)
        {
            var container = new StringBuilder(frequency * content.Length);

            for (int i = 0; i < frequency; i++)
            {
                container.Append(content);
            }

            return container.ToString();
        }
    }
}