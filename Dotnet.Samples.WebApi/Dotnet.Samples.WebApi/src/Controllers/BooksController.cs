// ----------------------------------------------------------------------------
// <copyright file="BooksController.cs" company="NanoTaboada">
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
// -----------------------------------------------------------------------------

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Dotnet.Samples.WebApi.Models;

    public class BooksController : ApiController
    {
        private static Catalog catalog = new Catalog();

        // GET
        public IEnumerable<Book> GetBooks()
        {
            return catalog.RetrieveAll();
        }

        public HttpResponseMessage GetBook(string isbn)
        {
            var book = catalog.Retrieve(isbn);

            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse<Book>(HttpStatusCode.OK, book);
            }
        }

        // POST
        public HttpResponseMessage PostBook(Book book)
        { 
            if (!string.IsNullOrWhiteSpace(book.Isbn))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                catalog.Create(book);
                var uri = Url.Link("DefaultApi", new { isbn = book.Isbn });

                var response = Request.CreateResponse<Book>(HttpStatusCode.Created, book);
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        // PUT
        public HttpResponseMessage PutBook(string isbn, Book book)
        {
            if (!catalog.Update(book))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse<Book>(HttpStatusCode.OK, book);
            }
        }

        // DELETE
        public HttpResponseMessage DeleteBook(string isbn)
        {
            if (!catalog.Delete(isbn))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
