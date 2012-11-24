#region License
// Copyright 2011 Google Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

namespace Dotnet.Samples.JsonNet
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A Volume represents information that Google Books hosts about a book or
    /// a magazine. It contains metadata, such as title and author, as well as
    /// personalized data, such as whether or not it has been purchased.
    /// https://developers.google.com/books/docs/v1/reference/volumes
    /// </summary>
    public class Volume
    {
        [JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        [JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        [JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        [JsonPropertyAttribute("selfLink")]
        public virtual string SelfLink { get; set; }

        [JsonPropertyAttribute("volumeInfo")]
        public virtual VolumeInfoData VolumeInfo { get; set; }

        [JsonPropertyAttribute("userInfo")]
        public virtual UserInfoData UserInfo { get; set; }

        [JsonPropertyAttribute("saleInfo")]
        public virtual SaleInfoData SaleInfo { get; set; }

        [JsonPropertyAttribute("accessInfo")]
        public virtual AccessInfoData AccessInfo { get; set; }
    }

    public class AccessInfoData
    {
        [JsonPropertyAttribute("accessViewStatus")]
        public virtual string AccessViewStatus { get; set; }

        [JsonPropertyAttribute("country")]
        public virtual string Country { get; set; }

        [JsonPropertyAttribute("downloadAccess")]
        public virtual DownloadAccessRestriction DownloadAccess { get; set; }

        [JsonPropertyAttribute("embeddable")]
        public virtual bool Embeddable { get; set; }

        [JsonPropertyAttribute("epub")]
        public virtual EpubData Epub { get; set; }

        [JsonPropertyAttribute("pdf")]
        public virtual PdfData Pdf { get; set; }

        [JsonPropertyAttribute("publicDomain")]
        public virtual bool PublicDomain { get; set; }

        [JsonPropertyAttribute("viewability")]
        public virtual string Viewability { get; set; }
    }

    public class AuthorData
    {
        [JsonPropertyAttribute("displayName")]
        public virtual string DisplayName { get; set; }
    }

    public class DimensionsData
    {
        [JsonPropertyAttribute("height")]
        public virtual string Height { get; set; }

        [JsonPropertyAttribute("thickness")]
        public virtual string Thickness { get; set; }

        [JsonPropertyAttribute("width")]
        public virtual string Width { get; set; }
    }

    public class DownloadAccessRestriction
    {

        [JsonPropertyAttribute("deviceAllowed")]
        public virtual Nullable<bool> DeviceAllowed { get; set; }

        [JsonPropertyAttribute("downloadsAcquired")]
        public virtual Nullable<long> DownloadsAcquired { get; set; }

        [JsonPropertyAttribute("justAcquired")]
        public virtual Nullable<bool> JustAcquired { get; set; }

        [JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        [JsonPropertyAttribute("maxDownloadDevices")]
        public virtual Nullable<long> MaxDownloadDevices { get; set; }

        [JsonPropertyAttribute("message")]
        public virtual string Message { get; set; }

        [JsonPropertyAttribute("nonce")]
        public virtual string Nonce { get; set; }

        [JsonPropertyAttribute("reasonCode")]
        public virtual string ReasonCode { get; set; }

        [JsonPropertyAttribute("restricted")]
        public virtual Nullable<bool> Restricted { get; set; }

        [JsonPropertyAttribute("signature")]
        public virtual string Signature { get; set; }

        [JsonPropertyAttribute("source")]
        public virtual string Source { get; set; }

        [JsonPropertyAttribute("volumeId")]
        public virtual string VolumeId { get; set; }
    }

    public class EpubData
    {
        [JsonPropertyAttribute("acsTokenLink")]
        public virtual string AcsTokenLink { get; set; }

        [JsonPropertyAttribute("downloadLink")]
        public virtual string DownloadLink { get; set; }
    }

    public class ImageLinksData
    {
        [JsonPropertyAttribute("extraLarge")]
        public virtual string ExtraLarge { get; set; }

        [JsonPropertyAttribute("large")]
        public virtual string Large { get; set; }

        [JsonPropertyAttribute("medium")]
        public virtual string Medium { get; set; }

        [JsonPropertyAttribute("small")]
        public virtual string Small { get; set; }

        [JsonPropertyAttribute("smallThumbnail")]
        public virtual string SmallThumbnail { get; set; }

        [JsonPropertyAttribute("thumbnail")]
        public virtual string Thumbnail { get; set; }
    }

    public class IndustryIdentifiersData
    {
        [JsonPropertyAttribute("identifier")]
        public virtual string Identifier { get; set; }

        [JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }
    }

    public class ListPriceData
    {
        [JsonPropertyAttribute("amount")]
        public virtual double Amount { get; set; }

        [JsonPropertyAttribute("currencyCode")]
        public virtual string CurrencyCode { get; set; }
    }

    public class PdfData
    {
        [JsonPropertyAttribute("acsTokenLink")]
        public virtual string AcsTokenLink { get; set; }

        [JsonPropertyAttribute("downloadLink")]
        public virtual string DownloadLink { get; set; }
    }

    public class ReadingPosition
    {
        [JsonPropertyAttribute("epubCfiPosition")]
        public virtual string EpubCfiPosition { get; set; }

        [JsonPropertyAttribute("gbImagePosition")]
        public virtual string GbImagePosition { get; set; }

        [JsonPropertyAttribute("gbTextPosition")]
        public virtual string GbTextPosition { get; set; }

        [JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        [JsonPropertyAttribute("pdfPosition")]
        public virtual string PdfPosition { get; set; }

        [JsonPropertyAttribute("updated")]
        public virtual string Updated { get; set; }

        [JsonPropertyAttribute("volumeId")]
        public virtual string VolumeId { get; set; }

        public virtual string ETag { get; set; }
    }

    public class RetailPriceData
    {
        [JsonPropertyAttribute("amount")]
        public virtual double Amount { get; set; }

        [JsonPropertyAttribute("currencyCode")]
        public virtual string CurrencyCode { get; set; }
    }

    public class Review
    {
        [JsonPropertyAttribute("author")]
        public virtual AuthorData Author { get; set; }

        [JsonPropertyAttribute("content")]
        public virtual string Content { get; set; }

        [JsonPropertyAttribute("date")]
        public virtual string Date { get; set; }

        [JsonPropertyAttribute("fullTextUrl")]
        public virtual string FullTextUrl { get; set; }

        [JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        [JsonPropertyAttribute("rating")]
        public virtual string Rating { get; set; }

        [JsonPropertyAttribute("source")]
        public virtual SourceData Source { get; set; }

        [JsonPropertyAttribute("title")]
        public virtual string Title { get; set; }

        [JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }

        [JsonPropertyAttribute("volumeId")]
        public virtual string VolumeId { get; set; }
    }

    public class SaleInfoData
    {
        [JsonPropertyAttribute("buyLink")]
        public virtual string BuyLink { get; set; }

        [JsonPropertyAttribute("country")]
        public virtual string Country { get; set; }

        [JsonPropertyAttribute("isEbook")]
        public virtual bool IsEbook { get; set; }

        [JsonPropertyAttribute("listPrice")]
        public virtual ListPriceData ListPrice { get; set; }

        [JsonPropertyAttribute("retailPrice")]
        public virtual RetailPriceData RetailPrice { get; set; }

        [JsonPropertyAttribute("saleability")]
        public virtual string Saleability { get; set; }
    }

    public class SourceData
    {
        [JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        [JsonPropertyAttribute("extraDescription")]
        public virtual string ExtraDescription { get; set; }

        [JsonPropertyAttribute("url")]
        public virtual string Url { get; set; }
    }

    public class UserInfoData
    {
        [JsonPropertyAttribute("isPurchased")]
        public virtual bool IsPurchased { get; set; }

        [JsonPropertyAttribute("readingPosition")]
        public virtual ReadingPosition ReadingPosition { get; set; }

        [JsonPropertyAttribute("review")]
        public virtual Review Review { get; set; }

        [JsonPropertyAttribute("updated")]
        public virtual string Updated { get; set; }
    }

    public class VolumeInfoData
    {
        [JsonPropertyAttribute("authors")]
        public virtual IList<string> Authors { get; set; }

        [JsonPropertyAttribute("averageRating")]
        public virtual double AverageRating { get; set; }

        [JsonPropertyAttribute("categories")]
        public virtual IList<string> Categories { get; set; }

        [JsonPropertyAttribute("contentVersion")]
        public virtual string ContentVersion { get; set; }

        [JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        [JsonPropertyAttribute("dimensions")]
        public virtual DimensionsData Dimensions { get; set; }

        [JsonPropertyAttribute("imageLinks")]
        public virtual ImageLinksData ImageLinks { get; set; }

        [JsonPropertyAttribute("industryIdentifiers")]
        public virtual IList<IndustryIdentifiersData> IndustryIdentifiers { get; set; }

        [JsonPropertyAttribute("infoLink")]
        public virtual string InfoLink { get; set; }

        [JsonPropertyAttribute("language")]
        public virtual string Language { get; set; }

        [JsonPropertyAttribute("mainCategory")]
        public virtual string MainCategory { get; set; }

        [JsonPropertyAttribute("pageCount")]
        public virtual long PageCount { get; set; }

        [JsonPropertyAttribute("previewLink")]
        public virtual string PreviewLink { get; set; }

        [JsonPropertyAttribute("printType")]
        public virtual string PrintType { get; set; }

        [JsonPropertyAttribute("publishedDate")]
        public virtual string PublishedDate { get; set; }

        [JsonPropertyAttribute("publisher")]
        public virtual string Publisher { get; set; }

        [JsonPropertyAttribute("ratingsCount")]
        public virtual long RatingsCount { get; set; }

        [JsonPropertyAttribute("subtitle")]
        public virtual string Subtitle { get; set; }

        [JsonPropertyAttribute("title")]
        public virtual string Title { get; set; }
    }
}