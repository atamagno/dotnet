﻿#region License
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

namespace Dotnet.Samples.AutoMapper
{
    using System.Collections.Generic;
    using AutoMapper;

    public static class AutoMapperConfigurator
    {
        public static void Configure()
        {
            Mapper.CreateMap<Book, IndustryIdentifier>()
                .ForMember(industryIdentifier => industryIdentifier.Type, options => options.UseValue("ISBN_13"))
                .ForMember(industryIdentifier => industryIdentifier.Identifier, options => options.MapFrom(book => book.Isbn13));

            Mapper.CreateMap<Book, VolumeInfo>()
                .ForMember(volumeInfo => volumeInfo.Authors, options => options.MapFrom(book => book.Author.Split(',')))
                .ForMember(volumeInfo => volumeInfo.PublishedDate, options => options.MapFrom(book => book.Publication))
                .ForMember(volumeInfo => volumeInfo.PageCount, options => options.MapFrom(book => book.Pages))
                .ForMember(volumeInfo => volumeInfo.IndustryIdentifiers, options => options.UseValue(new List<IndustryIdentifier>()));

            Mapper.CreateMap<Book, BookDto>()
                .ForMember(dto => dto.Id, options => options.Ignore())
                .ForMember(dto => dto.Kind, options => options.Ignore())
                .ForMember(dto => dto.VolumeInfo, options => options.MapFrom(book => Mapper.Map<Book, VolumeInfo>(book)));
        }
    }
}
