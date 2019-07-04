using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TamTech.Monshaat.POS.Web.Core.Enums;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.Pos;

namespace TamTech.Monshaat.POS.Web.Core.Mappers.Pos
{
    public static class PosMapper
    {
        public static TamTech.Monshaat.POS.Web.Services.POSs.Models.CreatePosModel MapToCreateModelWithoutAttachments(this TamTech.Monshaat.POS.Web.Models.VMs.Portal.Pos.PosFormVm item)
        {
            return new  CreatePosModel
            {
                Name = item.Name,
                Lang = item.Lang,
                TypeId = item.TypeId,
                OtherSector = item.OtherSector,
                VendorId = item.VendorId,
                About = item.About,
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Price = item.Price,
                Published = item.Published,
                SectorId = item.SectorId,
                Slug = item.Slug,
                Tags = item.Tags,
                Specifications = item.Specifications?.MapToBackSpecifications(),
            };
        }



        public static UpdatePosModel MapToUpdateModelWithoutAttachments(this TamTech.Monshaat.POS.Web.Models.VMs.Portal.Pos.PosFormVm item)
        {
            return new UpdatePosModel
            {
                Id = item.Id,
                Name = item.Name,
                Lang = item.Lang,
                TypeId = item.TypeId,
                OtherSector = item.OtherSector,
                VendorId = item.VendorId,
                About = item.About,
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                Price = item.Price,
                Published = item.Published,
                SectorId = item.SectorId,
                Slug = item.Slug,
                Tags = item.Tags,
                Specifications = item.Specifications?.MapToBackSpecifications()
            };
        }



        public static List<TamTech.Monshaat.POS.Web.Services.POSs.Models.SpecificationModel> MapToBackSpecifications(this List<Specification> specification)
        {

            var result = new List<TamTech.Monshaat.POS.Web.Services.POSs.Models.SpecificationModel>();

            foreach (Specification item in specification)
            {
                if (item.Values == null) continue;
                SpecificationModel model = new SpecificationModel();
                if (item.InputType == (int)AttributeInputType.Checkbox)
                {
                    var attValues = new List<int>();
                    foreach (var val in item.Values)
                    {
                        if ((item.ChoiceType == (int)AttributeChoiceType.Multichoice && val.IsChecked) || (item.ChoiceType == (int)AttributeChoiceType.OneChoice))
                        {
                            attValues.Add(val.Id);
                        }
                    }
                    model.AttId = item.Id;
                    model.InputType = item.InputType;
                    model.Values = attValues;
                    result.Add(model);
                }
            }
            return result;



        }


        public static PosFormVm MapToPosFormVm(this TamTech.Monshaat.POS.Web.Services.POSs.Models.PosDto item)
        {
            return new PosFormVm
            {
                Id = item.Id,
                Name = item.Name,
                Lang = item.Lang,
                TypeId = item.TypeId,
                Description = item.Description,
                SectorId = item.SectorId,
                OtherSector = item.OtherSector,
                SpecificationsB = item.Specifications.Select(m => m.MapToSpecification()).ToList(),
                VendorId = item.VendorId,
                About = item.About,
                Price = item.Price,
                Slug = item.Slug,
                Tags = item.Tags,
                Published = item.Published,
                DisplayOrder = item.DisplayOrder,
                GenericField = item.GenericField,
                TempImages = item.Images,
                StatusId = item.StatusId,
            };
        }


        public static Specification MapToSpecification(this TamTech.Monshaat.POS.Web.Services.POSs.Models.SpecificationDto item)
        {
            return new Specification
            {
                Id = item.AttId,
                InputType = item.InputType,
                Values = item.Values?.MapToListValues(),
            };
        }


        public static List<value> MapToListValues(this Dictionary<int, string> item)
        {
            return item.Select(m => new value
            {
                Id = m.Key,
                Text = m.Value
            }).ToList();
        }

        //    public static Dictionary<int, Dictionary<int, object>> MapToBackSpecifications(this List<Specification> list)
        //    {
        //        Dictionary<int, Dictionary<int, object>> _dictionary = new Dictionary<int, Dictionary<int, object>>();

        //        foreach (Specification item in list)
        //        {
        //            if (item.Values != null)
        //            {
        //                if (item.InputType == (int)AttributeInputType.Checkbox)
        //                {
        //                    var attValues = new Dictionary<int, object>();
        //                    foreach (var val in item.Values)
        //                    {
        //                        if ((item.ChoiceType == (int)AttributeChoiceType.Multichoice && string.Equals(val.Value, "true"))
        //                            || (item.ChoiceType == (int)AttributeChoiceType.OneChoice))
        //                        {
        //                            attValues.Add(val.Key, null);
        //                        }
        //                    }
        //                    _dictionary.Add(item.Id, attValues);
        //                }
        //            }

        //        }
        //        return _dictionary;
        //    } 
    }
}
