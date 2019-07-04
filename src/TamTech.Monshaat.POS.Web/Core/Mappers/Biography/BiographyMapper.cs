using System;
using System.Collections.Generic; 
using TamTech.Monshaat.POS.Web.Services.ContentService.Biography.Models;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Biographies;
using Newtonsoft.Json; 
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Biography;

namespace TamTech.Monshaat.POS.Web.Core.Mappers.Biography
{
    public static class BiographyMapper
    {
        public static Dictionary<string, string> DefulatSocailMedia()
        {
            var SocailMedia = new Dictionary<string, string>{
                {"Facebook", "" },
                {"Twitter", "" },
                {"Youtube", "" },
                {"instagram", "" },
                {"linkedin", "" }
                };
            return SocailMedia;

        }


        private static Dictionary<string, string> MapToSocailMedia(string values)
        {
            var _Values = JsonConvert.DeserializeObject<Dictionary<string, string>>(values);
            var _defualt = DefulatSocailMedia();

            if (_Values == null || _Values.Count == 0) return _defualt;

            foreach (KeyValuePair<string, string> val in _Values)
            {
                _defualt[val.Key] = val.Value;
            };

            return _defualt;
        }

        private static T DeserializeObject<T>(string items)
        {
            return !string.IsNullOrEmpty(items) ? JsonConvert.DeserializeObject<T>(items) : (T)Activator.CreateInstance(typeof(T));
        }

        public static SiteInformationVm MapTOSiteInformationVm(this List<BiographyDto> items)
        {
            SiteInformationVm _info = new SiteInformationVm();


            foreach (BiographyDto item in items)
            {
                switch (item.Key.ToLower())
                {
                    case BiographyKeysConstants.Logo:
                        _info.Logo = item.Value;
                        break;
                    case BiographyKeysConstants.Sitetitle:
                        _info.SiteTitle = item.Value;
                        break;
                    case BiographyKeysConstants.Faxs:
                        _info.Faxs = DeserializeObject<List<string>>(item.Value);
                        break;
                    case BiographyKeysConstants.Phones:
                        _info.Phones = DeserializeObject<List<string>>(item.Value);
                        break;
                    case BiographyKeysConstants.Moblies:
                        _info.Moblies = DeserializeObject<List<string>>(item.Value);
                        break;
                    case BiographyKeysConstants.Emails:
                        _info.Emails = DeserializeObject<List<string>>(item.Value);
                        break;
                    case BiographyKeysConstants.Images:
                        _info.Images = DeserializeObject<Dictionary<string, string>>(item.Value);
                        break;
                    case BiographyKeysConstants.Address:
                        _info.Address = item.Value;
                        break;
                    case BiographyKeysConstants.Brief:
                        _info.Brief = item.Value;
                        break;
                    case BiographyKeysConstants.About:
                        _info.About = item.Value;
                        break;
                    case BiographyKeysConstants.Vision:
                        _info.Vision = item.Value;
                        break;
                    case BiographyKeysConstants.Mission:
                        _info.Mission = item.Value;
                        break;
                    case BiographyKeysConstants.Metadescription:
                        _info.MetaDescription = item.Value;
                        break;
                    case BiographyKeysConstants.Metakeywords:
                        _info.MetaKeywords = item.Value;
                        break;
                    case BiographyKeysConstants.Summury:
                        _info.Summury = item.Value;
                        break;
                    case BiographyKeysConstants.Longitude:
                        _info.Longitude = item.Value;
                        break;
                    case BiographyKeysConstants.Latitude:
                        _info.Latitude = item.Value;
                        break;
                    case BiographyKeysConstants.Socailmedia:
                        _info.SocailMedia = MapToSocailMedia(item.Value);
                        break;
                }

            }

            return _info;
        }

        public static BiographyInfoVm MapToBiographyInfoModel(this List<BiographyDto> items)
        {
            BiographyInfoVm _info = new BiographyInfoVm();


            foreach (BiographyDto item in items)
            {
                switch (item.Key.ToLower())
                {
                    case BiographyKeysConstants.Logo:
                        _info.Logo = item.Value;
                        break;
                        //case BiographyKeysConstants.Sitetitle:
                        //    _info.SiteTitle = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Faxs:
                        //    _info.Faxs = DeserializeObject<List<string>>(item.Value);
                        //    break;
                        //case BiographyKeysConstants.Phones:
                        //    _info.Phones = DeserializeObject<List<string>>(item.Value);
                        //    break;
                        //case BiographyKeysConstants.Moblies:
                        //    _info.Moblies = DeserializeObject<List<string>>(item.Value);
                        //    break;
                        //case BiographyKeysConstants.Emails:
                        //    _info.Emails = DeserializeObject<List<string>>(item.Value);
                        //    break;
                        //case BiographyKeysConstants.Images:
                        //    _info.Images = DeserializeObject<Dictionary<string, string>>(item.Value);
                        //    break;
                        //case BiographyKeysConstants.Address:
                        //    _info.Address = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Brief:
                        //    _info.Brief = item.Value;
                        //    break;
                        //case BiographyKeysConstants.About:
                        //    _info.About = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Vision:
                        //    _info.Vision = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Mission:
                        //    _info.Mission = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Metadescription:
                        //    _info.MetaDescription = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Metakeywords:
                        //    _info.MetaKeywords = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Summury:
                        //    _info.Summury = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Longitude:
                        //    _info.Longitude = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Latitude:
                        //    _info.Latitude = item.Value;
                        //    break;
                        //case BiographyKeysConstants.Socailmedia:
                        //    _info.SocailMedia = MapToSocailMedia(item.Value);
                        //    break;
                }

            }

            return _info;
        }



        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        private static bool isEquals(string A, string B)
        {
            return string.Equals(A, B, StringComparison.OrdinalIgnoreCase);
        }
        public static List<BiographyModel> MapModelVmToListBiographyModel(SiteInformationVm item, int GroupId)
        {
            List<BiographyModel> result = new List<BiographyModel>();

            if (GroupId == (int)BiogrphyGroupEnum.Biography)
            {
                foreach (BiographKeys val in Enum.GetValues(typeof(BiographKeys)))
                {
                    result.Add(new BiographyModel
                    {
                        Id = (int)val,
                        Key = val.ToString(),
                        Value = (string)GetPropValue(item, val.ToString())
                    });
                }
            }

            if (GroupId == (int)BiogrphyGroupEnum.Information)
            {
                foreach (InformationKeys val in Enum.GetValues(typeof(InformationKeys)))
                {
                    if (isEquals(val.ToString(), InformationKeys.Emails.ToString()) ||
                         isEquals(val.ToString(), InformationKeys.Faxs.ToString()) ||
                         isEquals(val.ToString(), InformationKeys.Phones.ToString()) ||
                         isEquals(val.ToString(), InformationKeys.Moblies.ToString()) ||
                         isEquals(val.ToString(), InformationKeys.SocailMedia.ToString()) ||
                         isEquals(val.ToString(), InformationKeys.Images.ToString())
                         )
                    {
                        result.Add(new BiographyModel
                        {
                            Id = (int)val,
                            Key = val.ToString(),
                            Value = JsonConvert.SerializeObject(GetPropValue(item, val.ToString()))
                        });
                    }
                    else
                    {
                        result.Add(new BiographyModel
                        {
                            Id = (int)val,
                            Key = val.ToString(),
                            Value = (string)GetPropValue(item, val.ToString())
                        });
                    }

                };

            }

            return result;
        }
    }

    enum SettingsKeys
    {
        Logo = 1,
        SiteTitle = 2,
        Phones = 3,
        Moblies = 4,
        Faxs = 5,
        Emails = 6,
        SocailMedia = 7,
        Address = 8,
        Brief = 9,
        About = 10,
        Vision = 11,
        Mission = 12,
        MetaDescription = 13,
        MetaKeywords = 14,
        Summury = 15,
        Longitude = 16,
        Latitude = 17,
        Images = 18,
    }

    enum InformationKeys
    {
        Logo = 1,
        SiteTitle = 2,
        Phones = 3,
        Moblies = 4,
        Faxs = 5,
        Emails = 6,
        SocailMedia = 7,
        Address = 8,
        Longitude = 16,
        Latitude = 17,
        Images = 18,
    }

    enum BiographKeys
    {
        Brief = 9,
        About = 10,
        Vision = 11,
        Mission = 12,
        MetaDescription = 13,
        MetaKeywords = 14,
        Summury = 15
    }

}


