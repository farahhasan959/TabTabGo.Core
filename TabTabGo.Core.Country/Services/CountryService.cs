﻿using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabTabGo.Core.Country.Services
{
    public class CountryService : ICountryService
    {
        private readonly IStringLocalizer _stringLocalizer;

        public CountryService(IStringLocalizer stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public async Task<string> GetCountryName(string code, string culture = "en")
        {
            if (string.IsNullOrEmpty(code))
            {
                return code;
            }

            RegionInfo region = new RegionInfo(code);
            string countryName = region.EnglishName;
            if(culture != "en")
                countryName = _stringLocalizer.GetString(countryName, culture);
            return countryName;
        }
    }
}
