using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Pages.Enums;
using TamTechSDK.Common.Services.ContentService.Pages.Models;

namespace TamTechSDK.Common.Services.ContentService.Pages
{
    public class MockPagesServices  
    {
        public async Task<IRequestProviderResult<List<PageDto>>> GetPagesAsync()
    {
        return new RequestProviderResult<List<PageDto>>
        {
            Success = true,
            Data = new List<PageDto>
             {
                 new PageDto
                 {
                     Id= new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                     Title  = "About",
                     CreatorUserId = "admin",
                     Type = (int)PageTypeEnum.Html,
                     CreatedDate = DateTime.Now,
                     ModifiedDate= DateTime.Now,
                     Published = true
                 },
                 new PageDto
                 {
                     Id= new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                     Title  = "Terms",
                     CreatorUserId = "admin",
                      Type = (int)PageTypeEnum.Html,
                     CreatedDate = DateTime.Now,
                     ModifiedDate= DateTime.Now
                 },
                 new PageDto
                 {
                     Id= new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                     Title  = "Content",
                     CreatorUserId = "admin",
                     Type = (int)PageTypeEnum.Sections,
                     CreatedDate = DateTime.Now,
                     ModifiedDate= DateTime.Now,
                     Published = true
                 },
                 new PageDto
                 {
                     Id= new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                     Title  = "Services",
                     CreatorUserId = "admin",
                     Type = (int)PageTypeEnum.Sections,
                     CreatedDate = DateTime.Now,
                     ModifiedDate= DateTime.Now
                 },
                 new PageDto
                 {
                     Id= new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                     Title  = "terms",
                     CreatorUserId = "admin",
                     Type = (int)PageTypeEnum.Html,
                     CreatedDate = DateTime.Now,
                     ModifiedDate= DateTime.Now
                 },
                  new PageDto
                 {
                     Id= new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                     Title  = "policies",
                     CreatorUserId = "admin",
                     Type = (int)PageTypeEnum.Html,
                     CreatedDate = DateTime.Now,
                     ModifiedDate= DateTime.Now
                 }
             }
        };




    }

        public async Task<IRequestProviderResult<HtmlPage>> GetHtmlPageByIdAsync(string id)
        {

            return new RequestProviderResult<HtmlPage>
            {
                Success = true,
                Data = new HtmlPage
                {
                    Id = new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                    Title = "About",
                    CreatorUserId = "admin",
                    Keywords = new List<string> { "key", "seo", "ceo", "html", "css" },
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Published = true,
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                }

            };

        }

        public async Task<IRequestProviderResult<SectionsPage>> GetSectionsPageeByIdAsync(string id)
        {
            return new RequestProviderResult<SectionsPage>
            {
                Success = true,
                Data = new SectionsPage
                {
                    Id = new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                    Title = "terms and conditions",
                    CreatorUserId = "admin",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Published = true,
                    Type = (int)PageTypeEnum.Sections,
                    Content = new Dictionary<string, string>
                    {
                        {
                            "Introduction",
                            "Welcome to tamshop.com. These are the terms and conditions governing your access to and use of the website tamshop.com and its related sub-domains, sites, services and tools (the \"Site\"). By accepting these terms and conditions (including the linked information herein), and by using the Site, you represent that you agree to comply with these terms and conditions with tamshop.com FZ-LLC (\"we\", \"us\" or \"tamshop.com\") in relation to your use of the Site (the \"User Agreement\"). This User Agreement is effective upon acceptance. If you do not agree to be bound by this User Agreement please do not access, register with or use this Site. Before you may become or continue as a member of the Site, you must read, agree with and accept this User Agreement and tamshop.com's Privacy Policy (the \"Privacy Policy\"). You should read this User Agreement and the Privacy Policy and access and read all further linked information referred to in this User Agreement, as such information contains further terms and conditions that apply to you as a user of tamshop.com. Such linked information including but not limited to the Privacy Policy is hereby incorporated by reference into this User Agreement."
                        },
                        {
                             "Eligibility for Membership",
                        "tamshop.com wishes to ensure that its members are able to form legally binding contracts and further that minors do not purchase unsuitable content. Therefore membership of the Site is not available to persons under the age of 18 years. You represent that you are 18 years of age or over the age of 18 years before you become a member of the Site. Without prejudice to any other rights and remedies of tamshop.com under this User Agreement or at law, tamshop.com reserves the right to limit or withdraw access to the Site or the membership of any person if tamshop.com believes that person is under the age of 18 years. The Site is not available to persons whose membership has been suspended or withdrawn by tamshop.com. Further, if you are registering as a business entity, you represent that you have the authority to bind that entity to this User Agreement and that you and the business entity will comply with all applicable laws relating to online trading. No person or business entity may register as a member of the Site more than once."
                        },{
                             "Your Account and Registration Obligations",
                        "When you register as a member of the Site you have been or will be required to provide certain information and register a username and password for use on this Site."
                        },{
"On becoming a member of the Site, you agree",
                        "You are responsible for maintaining the confidentiality of, and restricting access to and use of, your account and password, and accept responsibility for all activities that occur under your account and password. You agree to immediately notify tamshop.com of any unauthorised use of your password or account or any other breach of security. In no event will tamshop.com be liable for any direct, indirect or consequential loss or loss of profits, goodwill or damage whatsoever resulting from the disclosure of your username and/or password. You may not use another person's account at any time, without the express permission of the account holder. You agree to reimburse tamshop.com for any improper, unauthorised or illegal use of your account by you or by any person obtaining access to the Site, services or otherwise by using your designated username and password, whether or not you authorised such access. You will provide true, accurate, current and complete information about yourself as prompted by tamshop.com's registration form (the \"Registration Data\"). You will not include:  (i) any of your contact details, including but not limited to email addresses, telephone numbers or other personal details; or (ii) the word \"tamshop\" in your registration user ID. Your store name shall not include the word \"tamshop\". You will treat any other member's information provided to you (in accordance with these terms of use and the information on the Site) by tamshop.com or any other user as confidential. You will maintain and promptly update the Registration Data to keep it true, accurate, current and complete. If you provide any information that is untrue, inaccurate, not current or incomplete or if tamshop.com has reasonable grounds to suspect that such information is untrue, inaccurate, not current or incomplete, or not in accordance with this User Agreement, without prejudice to any other rights and remedies of tamshop.com under this User Agreement or at law, tamshop.com has the right to indefinitely suspend, limit or withdraw your access to the Site and/or your membership of the Site."
                        },{
  "Electronic Communications",
                        "You agree that we may communicate with you by email or by posting notices on the Site. You agree that all agreements, notices, disclosures and other communications that we provide to you electronically satisfy any legal requirement that such communications be in writing. tamshop.com requires your agreement during the registration process to send you promotional emails to let you know about any new changes, features or promotional activities added to the Site. If, at any time, you decide that you do not wish to receive promotional emails, you can opt out of receiving such promotional emails by clicking on the link at the bottom of any promotional email."
                        },{
 "Amendments to this User Agreement",
                        "You acknowledge and agree that tamshop.com shall endeavour to give you notice for any amendment to this User Agreement that materially increases your obligations or decreases your rights under the User Agreement (\"Substantial Amendment\") in accordance with the terms of this User Agreement. You acknowledge and agree that tamshop.com at its sole discretion and without liability may make amendments that are not Substantial Amendments without your further specific agreement at any time with immediate effect by posting a notice of the amendment on the Site."
                        },{
                             "Fees and Services",
                        "tamshop.com is not an auction house nor a bank, and does not offer auction or banking services. The Site is an online platform allowing for the sale and purchase of items between end-user sellers and buyers.  Membership on the Site is free. tamshop.com does not charge any fee for browsing, bidding and buying listed items on the Site. tamshop.com charges transaction fees to all sellers when their item is successfully sold on the Site, listing fees for classifieds and special listing fees to sellers who use the special listing feature for listing their items.  Sellers must pay all fees due and payable to tamshop.com after a successful sale and in the case that a buyer does not complete the transaction, the seller may seek a refund of the relevant transaction fees from tamshop.com by submitting an online no-sale claim.  Before you list an item for sale through the Site, we request you to review the fees that you will be charged based on our Fees & Credit Policy which we may amend from time to time with immediate effect by posting the changes on the Site.  tamshop.com may choose to temporarily change the fees for our services for promotional events (for example, free shipping days) or new services, and such temporary changes are effective in accordance with their terms when we post them on the Site.  Unless otherwise stated, all fees shall be quoted in your country's currency. You must pay all fees payable to tamshop.com (and any applicable taxes or charges) within 30 days of the date of any invoice to you from tamshop.com with a valid payment method as set out in our Fees & Credit Policy .  In case of non-payment of fees and/or any applicable taxes and charges by you to tamshop.com, without prejudice to any other rights and remedies of tamshop.com under this User Agreement or at law, tamshop.com without liability reserves the right to: issue you with a warning regarding the non-payment in question. temporarily or indefinitely suspend, limit or withdraw your access to the Site and/or your membership, if you fail to make the outstanding payment within 7 calendar days of tamshop.com issuing a warning to you. tamshop.com also reserves the right to take any necessary steps including legal action in case of non-payment of fees by you to tamshop.com for accounts over 30 days past due, deduct the amount owed from your MyWallet account balance (and you acknowledge and agree to tamshop.com doing so in these circumstances) and confirm the same to you by email. deduct from your MyWallet. invoice you for a fixed late payment fee (as set out in our Fees and Credit Policy from time to time). take any steps tamshop.com considers necessary including without limitation legal action for recovery of the outstanding fees and/or any applicable taxes and charges."
                        }
                    }
                }

            };

        }

        public async Task<IRequestProviderResult<object>> DeletePageByIdAsync(string id)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }

       

       

       
    }
}
