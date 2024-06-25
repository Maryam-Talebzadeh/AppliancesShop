using Base_Framework.Domain.Core.Contracts;
using Microsoft.Extensions.Configuration;
using SmsIrRestful;

namespace Base_Framework.Domain.Services
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Send(string number, string message, CancellationToken cancellationToken)
        {
            var token = GetToken();
            var lines = new SmsLine().GetSmsLines(token);
            if (lines == null) return;

            var line = lines.SMSLines.Last().LineNumber.ToString();
            var data = new MessageSendObject
            {
                Messages = new List<string>
                    {message}.ToArray(),
                MobileNumbers = new List<string> { number }.ToArray(),
                LineNumber = line,
                SendDateTime = DateTime.Now,
                CanContinueInCaseOfError = true
            };
            var messageSendResponseObject =
                new MessageSend().Send(token, data);

            if (messageSendResponseObject.IsSuccessful) return;

            line = lines.SMSLines.First().LineNumber.ToString();
            data.LineNumber = line;
            new MessageSend().Send(token, data);
        }

        private string GetToken()
        {
            var smsSecrets = _configuration.GetSection("SmsSecrets");
            var tokenService = new Token();
            return tokenService.GetToken(smsSecrets["ApiKey"], smsSecrets["SecretKey"]);
        }
    }
}
