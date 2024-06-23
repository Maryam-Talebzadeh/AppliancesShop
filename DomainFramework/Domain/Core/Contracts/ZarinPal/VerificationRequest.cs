

namespace Base_Framework.Domain.Core.Contracts.ZarinPal
{
    public class VerificationRequest
    {
        public int Amount { get; set; }
        public string MerchantID { get; set; }
        public string Authority { get; set; }
    }
}
