using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Requests
{
    public class FiltersVM
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string SortBy { get; set; } = null;

        public bool Desc { get; set; } = false;

        public string Name { get; set; }

        public string Title { get; set; } = null;

        public int? CityId { get; set; } = null;

        public int? StatusId { get; set; } = null;


        public override bool Equals(object obj)
        {
            var filters = obj as FiltersVM;
            return filters != null &&
                   CityId == filters.CityId &&
                   string.IsNullOrWhiteSpace(SortBy) == string.IsNullOrWhiteSpace(filters.SortBy) &&
                   StatusId == filters.StatusId &&
                   Desc == filters.Desc &&
                   string.IsNullOrWhiteSpace(Name) == string.IsNullOrWhiteSpace(filters.Name);
        }
        public static bool operator ==(FiltersVM filters1, FiltersVM filters2)
        {
            return EqualityComparer<FiltersVM>.Default.Equals(filters1, filters2);
        }

        public static bool operator !=(FiltersVM filters1, FiltersVM filters2)
        {
            return !(filters1 == filters2);
        }
    }
}
