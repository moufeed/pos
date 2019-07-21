using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Filters
{
    public class Filter
    {


        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string SortBy { get; set; } = null;

        public bool Desc { get; set; } = false;

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Title { get; set; } = null;

        public int? CityId { get; set; } = null;

        public int? StatusId { get; set; } = null;

        public int? SectorId { get; set; } = null;

        public Guid? SectionId { get; set; } = null;

        public Guid? ParentId { get; set; } = null;

        public int? Type { get; set; }

        public int? Visibility { get; set; }

        public int AttId { get; set; }

        public string RoleId { get; set; } = "";

        public string ContinuationToken { get; set; } = null;

        public string Section { get; set; } = "";

        public string AuthorName { get; set; } = "";
        public string Search { get; set; } = null;
        public string SectorSlug { get; set; } = null;

        public string valIds { get; set; } = null;
        public string TypeIds { get; set; } = null;

        public int? Rating { get; set; }

        public int? TypeId { get; set; }

        public int? Moblie { get; set; }

        public List<value> Values { get; set; }



        public override bool Equals(object obj)
        {
            var filters = obj as Filter;

            return filters != null &&
                   Desc == filters.Desc &&
                   CityId == filters.CityId &&
                   StatusId == filters.StatusId &&
                   Desc == filters.Desc &&
                   Type == filters.Type &&
                   Rating == filters.Rating &&
                   TypeId == filters.TypeId &&
                   Moblie == filters.Moblie &&
                   AttId == filters.AttId &&
                   EqualityComparer<Guid?>.Default.Equals(SectionId, filters.SectionId) &&
                   string.IsNullOrWhiteSpace(SortBy) == string.IsNullOrWhiteSpace(filters.SortBy) &&
                   string.IsNullOrWhiteSpace(Title) == string.IsNullOrWhiteSpace(filters.Title) &&
                   string.IsNullOrWhiteSpace(RoleId) == string.IsNullOrWhiteSpace(filters.RoleId) &&
                   string.IsNullOrWhiteSpace(Section) == string.IsNullOrWhiteSpace(filters.Section) &&
                   string.IsNullOrWhiteSpace(AuthorName) == string.IsNullOrWhiteSpace(filters.AuthorName) &&
                   string.IsNullOrWhiteSpace(Email) == string.IsNullOrWhiteSpace(filters.Email) &&
                   string.IsNullOrWhiteSpace(FullName) == string.IsNullOrWhiteSpace(filters.FullName) &&
                   string.IsNullOrWhiteSpace(Search) == string.IsNullOrWhiteSpace(filters.Search) &&
                   string.IsNullOrWhiteSpace(SectorSlug) == string.IsNullOrWhiteSpace(filters.SectorSlug) &&
                   string.IsNullOrWhiteSpace(Name) == string.IsNullOrWhiteSpace(filters.Name);
        }
        public static bool operator ==(Filter filters1, Filter filters2)
        {
            return EqualityComparer<Filter>.Default.Equals(filters1, filters2);
        }

        public static bool operator !=(Filter filters1, Filter filters2)
        {
            return !(filters1 == filters2);
        }

    }

    public class value
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsChecked { get; set; }
    }
}
