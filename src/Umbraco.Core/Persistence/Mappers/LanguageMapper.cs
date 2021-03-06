﻿using System.Collections.Concurrent;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence.Dtos;

namespace Umbraco.Core.Persistence.Mappers
{
    /// <summary>
    /// Represents a <see cref="Language"/> to DTO mapper used to translate the properties of the public api
    /// implementation to that of the database's DTO as sql: [tableName].[columnName].
    /// </summary>
    [MapperFor(typeof(ILanguage))]
    [MapperFor(typeof(Language))]
    public sealed class LanguageMapper : BaseMapper
    {
        private static readonly ConcurrentDictionary<string, DtoMapModel> PropertyInfoCacheInstance = new ConcurrentDictionary<string, DtoMapModel>();

        internal override ConcurrentDictionary<string, DtoMapModel> PropertyInfoCache => PropertyInfoCacheInstance;

        protected override void BuildMap()
        {
            CacheMap<Language, LanguageDto>(src => src.Id, dto => dto.Id);
            CacheMap<Language, LanguageDto>(src => src.IsoCode, dto => dto.IsoCode);
            CacheMap<Language, LanguageDto>(src => src.CultureName, dto => dto.CultureName);
        }
    }
}
