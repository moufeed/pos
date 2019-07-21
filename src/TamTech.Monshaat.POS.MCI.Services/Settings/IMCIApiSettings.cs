using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.Services.Settings
{
   public interface IMCIApiSettings
    {     
         string AuthenticateByAD { get; }    
         string GetAllPersonsForCR { get; }    
         string SendEmail { get; }    
    }
}
