using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ServiceBus;
using TamTechSDK.Common.Services.SMS.Models;

namespace TamTechSDK.Common.Services.SMS
{
    public class SMSServiceBus : ISMSService
    {
        #region Props
        private readonly IServiceBus _serviceBus;
        private readonly ServiceBusSettings _settings;
        #endregion

        #region Ctors
        public SMSServiceBus(ServiceBusSettings settings , IServiceBus serviceBus)
        {
            _settings = settings;
            _serviceBus = serviceBus;
        }
        #endregion


        #region Services  
        public async Task SendAsync(SMSModel model)
        {
            var smsServiceModel = new SMSServiceModel
            {
                To = model.to,
                Body = model.body,
                ReasonOfSend = model.properties.Single(p => p.Key == "ReasonOfSend").Value,
                UserId = model.properties.Single(p => p.Key == "UserId").Value,
            };
            try
            {
                await _serviceBus.SendQueueAsync<SMSServiceModel>(_settings, smsServiceModel);
            }
            catch(Exception ex)
            {

            }
        }
        #endregion


        public async Task<IRequestProviderResult<Smslite>> getSmsByIdAsync(string id)
        {
            return new RequestProviderResult<Smslite>
            {
                Success = true,
                Data = new Smslite
                {
                    Id = "92354710-b966-4069-a8e3-1790fd7c9149",
                    CreatedDate = DateTime.Now,
                    Massage = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Laudantium ea, voluptatum sint minima accusamus id?",
                    Recipients = new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            },
                                 new SmsRecipient
                            {
                                Name = "Nathan Savage",
                                Number ="+1-202-555-0169"
                            },
                                  new SmsRecipient
                            {
                                Name = "Elise Franklin",
                                Number = "+1-202-555-0188"

                            },
                                 new SmsRecipient
                            {
                                Name = "Olivia Hurst",
                                Number = "01632 960949"

                            },      new SmsRecipient
                            {
                                Name = "Josh Burke",
                                Number = "01632 960769"
                            },

                        }
                }
            };
        }

        public async Task<IRequestProviderResult<List<Smslite>>> GetSmsMessages()
        {
            return new RequestProviderResult<List<Smslite>>
            {
                Success = true,
                Data = new List<Smslite>
                {
                    new Smslite
                    {
                        Id = "92354710-b966-4069-a8e3-1790fd7c9149",
                        CreatedDate = DateTime.Now,
                        Massage = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Laudantium ea, voluptatum sint minima accusamus id?",
                        Recipients =new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            },
                                 new SmsRecipient
                            {
                                Name = "Nathan Savage",
                                Number ="+1-202-555-0169"
                            },
                                  new SmsRecipient
                            {
                                Name = "Elise Franklin",
                                Number = "+1-202-555-0188"

                            },
                                 new SmsRecipient
                            {
                                Name = "Olivia Hurst",
                                Number = "01632 960949"

                            },      new SmsRecipient
                            {
                                Name = "Josh Burke",
                                Number = "01632 960769"
                            },

                        }
                    }, new Smslite
                    {
                        Id = "92354710-b966-4069-a8e3-1790fd7c9149",
                        CreatedDate = DateTime.Now,
                        Massage = " Lorem ipsum, dolor sit amet consectetur adipisicing elit. Fuga quod eius blanditiis nam in, veritatis, itaque ratione, vel voluptatibus laboriosam provident modi repudiandae consequatur similique!",
                        Recipients =new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            },
                                 new SmsRecipient
                            {
                                Name = "Nathan Savage",
                                Number ="+1-202-555-0169"
                            },
                                  new SmsRecipient
                            {
                                Name = "Elise Franklin",
                                Number = "+1-202-555-0188"

                            },
                                 new SmsRecipient
                            {
                                Name = "Olivia Hurst",
                                Number = "01632 960949"

                            },      new SmsRecipient
                            {
                                Name = "Josh Burke",
                                Number = "01632 960769"
                            },

                        }
                    }, new Smslite
                    {
                        Id = "92354710-b966-4069-a8e3-1790fd7c9149",
                        CreatedDate = DateTime.Now,
                        Massage = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Incidunt, necessitatibus!",
                        Recipients = new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            },
                                 new SmsRecipient
                            {
                                Name = "Nathan Savage",
                                Number ="+1-202-555-0169"
                            },
                                  new SmsRecipient
                            {
                                Name = "Elise Franklin",
                                Number = "+1-202-555-0188"

                            },
                                 new SmsRecipient
                            {
                                Name = "Olivia Hurst",
                                Number = "01632 960949"

                            },      new SmsRecipient
                            {
                                Name = "Josh Burke",
                                Number = "01632 960769"
                            },

                        }
                    }, new Smslite
                    {
                        Id = "92354710-b966-4069-a8e3-1790fd7c9149",
                        CreatedDate = DateTime.Now,
                        Massage = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Aperiam tempore quibusdam amet eius aliquid, non consectetur       l magnam mollitia voluptas deserunt dolores minus dolorum provident, corrupti architecto harum sunt.",
                        Recipients =new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            },
                                 new SmsRecipient
                            {
                                Name = "Nathan Savage",
                                Number ="+1-202-555-0169"
                            },
                                  new SmsRecipient
                            {
                                Name = "Elise Franklin",
                                Number = "+1-202-555-0188"

                            },
                                 new SmsRecipient
                            {
                                Name = "Olivia Hurst",
                                Number = "01632 960949"

                            },      new SmsRecipient
                            {
                                Name = "Josh Burke",
                                Number = "01632 960769"
                            },

                        }
                    }, new Smslite
                    {
                        Id = "c374e16f-220e-428c-a317-ee420ecf7da8",
                        CreatedDate = DateTime.Now,
                        Massage = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae recusandae suscipit harum tempora sunt rem minu   eos harum molestias ab iure corporis quas sed eaque sapiente quia cumque? Veniam minus, voluptatem ipsam facilis labore quos modi.",
                        Recipients = new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            }

                        }
                    }, new Smslite
                    {
                        Id = "f65c9d1e-ad1c-45d1-aaba-9182b7f49555",
                        CreatedDate = DateTime.Now,
                        Massage = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae recusandae",
                        Recipients =new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            }

                        }
                    }, new Smslite
                    {
                        Id = "343a0d09-da2a-4f6e-866d-ae25aadcdbf9",
                        CreatedDate = DateTime.Now,
                        Massage = "consectetur nihil sequi. Eveniet explicabo perspiciatis minus nostrum libero mollitia dolorum quo id quos, ratione, ipsa dolorem atque, exercitationem veniam. Quidem, numquam reprehenderit?",
                        Recipients = new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            }
                        }
                    }, new Smslite
                    {
                        Id = "4e507dab-68a6-42c4-b820-e2cde44009e0",
                        CreatedDate = DateTime.Now,
                        Massage = "necessitatibus sunt pariatur quasi nesciunt est quod, sequi rerum, debitis, voluptatum nemo illum architecto animi! Architecto, ratione.",
                        Recipients =new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Naman Essa",
                                Number ="01632 960107"
                            }

                        }
                    }, new Smslite
                    {
                        Id = "c2f2fb20-7597-404c-9573-d4d28d737a3c",
                        CreatedDate = DateTime.Now,
                        Massage = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Laborum architecto debitis, possimus nulla dolorum corrupti aliquam deleniti similique nesciunt corporis.",
                        Recipients = new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            },
                                 new SmsRecipient
                            {
                                Name = "Nathan Savage",
                                Number ="+1-202-555-0169"
                            },
                                  new SmsRecipient
                            {
                                Name = "Elise Franklin",
                                Number = "+1-202-555-0188"

                            },
                                 new SmsRecipient
                            {
                                Name = "Olivia Hurst",
                                Number = "01632 960949"

                            }

                        }
                    }, new Smslite
                    {
                        Id = "",
                        CreatedDate = DateTime.Now,
                        Massage = "e7ac2dc6-5b71-47a1-89b5-ce09c49f9ecb",
                        Recipients = new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            },
                                 new SmsRecipient
                            {
                                Name = "Nathan Savage",
                                Number ="+1-202-555-0169"
                            },
                                  new SmsRecipient
                            {
                                Name = "Elise Franklin",
                                Number = "+1-202-555-0188"

                            }

                        }
                    }, new Smslite
                    {
                        Id = "ac64efce-1afe-40b1-8ef6-7a90f58697de",
                        CreatedDate = DateTime.Now,
                        Massage = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Commodi explicabo aut hic veritatis dolorem deserunt?",
                        Recipients = new List<SmsRecipient>
                        {
                            new SmsRecipient
                            {
                                Name = "Khalifah ",
                                Number = "01632 960769"
                            },
                             new SmsRecipient
                            {
                                Name = "Harun Na'man Essa",
                                Number ="01632 960107"
                            },
                              new SmsRecipient
                            {
                                Name = "Max Atkinson",
                                Number ="+1-803-555-0127"
                            },
                               new SmsRecipient
                            {
                                Name = "Bethany Finch",
                                Number ="+1-803-555-0192"
                            },
                                new SmsRecipient
                            {
                                Name = "Finley Barker",
                                Number ="202-555-0129"
                            },
                                 new SmsRecipient
                            {
                                Name = "Nathan Savage",
                                Number ="+1-202-555-0169"
                            }

                        }
                    },
                }
            };
        }

    }

  
}
