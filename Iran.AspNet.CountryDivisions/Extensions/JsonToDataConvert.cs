﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Iran.AspNet.CountryDivisions.Data.Models;

using Newtonsoft.Json;

namespace Iran.AspNet.CountryDivisions.Extensions
{
    public static class JsonToDataConvert
    {
        public static IEnumerable<Abadi> ToAbadiList(this string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Abadi>>(json);
        }
        public static IEnumerable<Bakhsh> ToBakhshList(this string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Bakhsh>>(json);
        }
        public static IEnumerable<Dehestan> ToDehestanList(this string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Dehestan>>(json);
        }
        public static IEnumerable<Ostan> ToOstanList(this string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Ostan>>(json);
        }
        public static IEnumerable<Shahr> ToShahrList(this string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Shahr>>(json);
        }
        public static IEnumerable<Shahrestan> ToShahrestanList(this string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Shahrestan>>(json);
        }
    }
}
