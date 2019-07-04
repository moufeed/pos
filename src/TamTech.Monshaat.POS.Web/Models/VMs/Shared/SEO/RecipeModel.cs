using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Shared.SEO
{
    public class RecipeModel : SeoSchema
    {

        [JsonProperty("cookTime")]
        public string CookTime { get; set; }

        [JsonProperty("prepTime")]
        public string PrepTime { get; set; }

        [JsonProperty("recipeCategory")]
        public string RecipeCategory { get; set; }

        [JsonProperty("recipeYield")]
        public string RecipeYield { get; set; }

        [JsonProperty("totalTime")]
        public string TotalTime { get; set; }

        [JsonProperty("recipeIngredient")]
        public List<string> RecipeIngredient { get; set; }

        [JsonProperty("recipeInstructions")]
        public List<string> RecipeInstructions { get; set; }


        [JsonProperty("author")]
        public Person Author { get; set; }

        [JsonProperty("Keywords")]
        public string Keywords { get; set; }

        [JsonProperty("recipeCuisine")]
        public string RecipeCuisine { get; set; }

    }
}
