using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTech.Monshaat.POS.MCI.APISimulator.Models;
using TamTech.Monshaat.POS.MCI.APISimulator.Data;
using TamTech.Monshaat.POS.MCI.APISimulator.EmailService;

namespace TamTech.Monshaat.POS.MCI.APISimulator.Controllers
{
    // For the POS 
    [Route("MCIAPISimulator/v1/GateWayApi/[Action]")]
    [ApiController]
    public class MCIAPISimulatorController : Controller
    {

        private const string _apiKey = "x-mcigateway-key";
        private readonly MCIAPISecret _secret;
        private readonly IEmailSenderService _emailSender;
        public MCIAPISimulatorController(MCIAPISecret secret, IEmailSenderService emailSender)
        {
            _secret = secret;
            _emailSender =  emailSender;     
        }


        [NonAction]
        public bool Authorized()
        {
            string rSecret = HttpContext.Request.Headers[_apiKey];
            if (string.IsNullOrWhiteSpace(rSecret) || !_secret.ApiSecret.Equals(rSecret))
            {
               return false;
            }



            return true;
        }


        [HttpGet]
        public IActionResult Ping()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult PingSecret()
        {
            if (!Authorized()) return Unauthorized();
            return Ok();
        }


       

        [HttpPost]
        public  IActionResult  AuthenticateByAD([FromBody] ADUserModel model)
        {
            if (!Authorized()) return Unauthorized();
            if (ModelState.IsValid)
            {
                var user = new MockData().TestUsers.SingleOrDefault(u => u.Username.Equals(model.Username) && u.Username.Equals(model.Password));
                return Ok(new
                {
                    status = true,
                    authresult = user != null
                });

            }
            return BadRequest(ModelState);
        }



        [HttpPost]
        public IActionResult GetAllPersonsForCR([FromBody] GetAllPersonsForCRModel model)
        {
            if (!Authorized()) return Unauthorized();
            if (ModelState.IsValid)
            {
                var persons = new MockData().GetPersons(model.CR);
                return Ok(new
                {
                    status = true,
                    Persons = persons
                });

            }
            return BadRequest(ModelState);
        }



        [HttpPost]
        public async Task<  IActionResult > SendEmail([FromBody] SendEmailModel model)
        {
            if (!Authorized()) return Unauthorized();
            if (ModelState.IsValid)
            {
                var result = await _emailSender.SendAsync(model);
                return Ok(new
                {
                    status = result    
                });

            }
            return BadRequest(ModelState);
        }

    }
}

