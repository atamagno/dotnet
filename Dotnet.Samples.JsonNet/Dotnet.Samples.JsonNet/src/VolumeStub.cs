// -----------------------------------------------------------------------------
// <copyright file="VolumeStub.cs" company="NanoTaboada">
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

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.JsonNet
{
    public static class VolumeStub
    {
        public static string Create()
        {
            return @"{""kind"":""books#volume"",""id"":""value"",""etag"":""value"",""selfLink"":""value"",""volumeInfo"":{""authors"":[""value""],""averageRating"":0.0,""categories"":[""value""],""contentVersion"":""value"",""description"":""value"",""dimensions"":{""height"":""value"",""thickness"":""value"",""width"":""value""},""imageLinks"":{""extraLarge"":""value"",""large"":""value"",""medium"":""value"",""small"":""value"",""smallThumbnail"":""value"",""thumbnail"":""value""},""industryIdentifiers"":[{""identifier"":""value"",""type"":""value""}],""infoLink"":""value"",""language"":""value"",""mainCategory"":""value"",""pageCount"":0,""previewLink"":""value"",""printType"":""value"",""publishedDate"":""value"",""publisher"":""value"",""ratingsCount"":0,""subtitle"":""value"",""title"":""value""},""userInfo"":{""isPurchased"":true,""readingPosition"":null,""review"":null,""updated"":""newDate(1357012799)""},""saleInfo"":{""buyLink"":""value"",""country"":""value"",""isEbook"":true,""listPrice"":{""amount"":0.0,""currencyCode"":""value""},""retailPrice"":{""amount"":0.0,""currencyCode"":""value""},""saleability"":""value""},""accessInfo"":{""accessViewStatus"":""value"",""country"":""value"",""downloadAccess"":{""deviceAllowed"":true,""downloadsAcquired"":0,""justAcquired"":true,""kind"":""books#downloadAccessRestriction"",""maxDownloadDevices"":0,""message"":""value"",""nonce"":""value"",""reasonCode"":""value"",""restricted"":true,""signature"":""value"",""source"":""value"",""volumeId"":""value""},""embeddable"":true,""epub"":{""acsTokenLink"":""value"",""downloadLink"":""value""},""pdf"":{""acsTokenLink"":""value"",""downloadLink"":""value""},""publicDomain"":true,""viewability"":""value""}}";
        }
    }
}