using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Posts.Models
{
   public class ListFilters
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string SortBy { get; set; } = null;

        [JsonProperty("desc")]
        public bool Desc { get; set; } = false;

        public Guid? SectionId { get; set; } = null;

        public string Title { get; set; }
         
        public override bool Equals(object obj)
        {
            var filters = obj as ListFilters;
            return filters != null &&
                   SortBy == filters.SortBy &&
                   Desc == filters.Desc &&
                   EqualityComparer<Guid?>.Default.Equals(SectionId, filters.SectionId) &&
                   Title == filters.Title;
        }
        public static bool operator ==(ListFilters filters1, ListFilters filters2)
        {
            return EqualityComparer<ListFilters>.Default.Equals(filters1, filters2);
        }

        public static bool operator !=(ListFilters filters1, ListFilters filters2)
        {
            return !(filters1 == filters2);
        }
    }
}

 