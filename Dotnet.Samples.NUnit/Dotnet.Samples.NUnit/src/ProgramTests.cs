// ----------------------------------------------------------------------------
// <copyright file="ProgramTests.cs" company="NanoTaboada">
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

using NUnit.Framework;

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1200:UsingDirectivesMustBePlacedWithinNamespace", Justification = "Prevented solution build.")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.NUnit
{
    [TestFixture]
    public class ProgramTests
    {
        public Program Program { get; private set; }
        
        [SetUp]
        public void Setup()
        {
            this.Program = new Program();
        }
        
        [Test]
        public void GetPangram_ExpectedValue_IsNotNullOrEmpty()
        {
            // Arrange
            string expected;
            
            // Act
            expected = this.Program.GetPangram();
            
            // Assert
            Assert.IsNotNullOrEmpty(expected);
        }
        
        [Test]
        public void GetPangram_ExpectedAndActualValues_AreEqual()
        {
            // Arrange
            string expected = "The quick brown fox jumps over the lazy dog.";
            string actual;
            
            // Act
            actual = this.Program.GetPangram();
            
            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TearDown]
        public void TearDown()
        {
            this.Program = null;
        }
    }
}
