using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Shop.Products
{
    public class PublicProductVM
    {
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string ShortDescription { get; set; }


        public string FullDescription { get; set; }


        public int StockQuantity { get; set; }


        public double Price { get; set; }

        public double DiscountPrice { get; set; }


        public bool Published { get; set; }


        public string MainImageUrl { get; set; }


        public string SKU { get; set; }

        public string Currency { get; set; } = "SAR";

        public string DiscountedPercentage
        {

            get
            {
                if (DiscountPrice <= 0)
                {
                    return "";
                }
                return $"{100 - Convert.ToInt32(((DiscountPrice / Price) * 100))} %";
            }
        }


        public bool HasDiscount
        {
            get
            {
                return (DiscountPrice > 0);
            }
        }

        public string OldPrice
        {
            get
            {
                return DiscountPrice > 0 ? $"{Price} {Currency}" : "";
            }
        }

        public string NewPrice
        {
            get
            {
                return DiscountPrice == 0 ? $"{Price} {Currency}" : $"{DiscountPrice} {Currency}";
            }
        }
    }
}
