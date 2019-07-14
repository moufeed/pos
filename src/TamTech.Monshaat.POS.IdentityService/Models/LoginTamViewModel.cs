namespace TamTech.Monshaat.POS.IdentityService.Models
{
    public class LoginTamViewModel : LoginTamInputModel
    {

        public bool AllowRememberLogin { get; set; }

        public bool EnableLocalLogin { get; set; }
    }
}
