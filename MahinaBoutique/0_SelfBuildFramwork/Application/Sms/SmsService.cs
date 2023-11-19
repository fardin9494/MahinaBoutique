using IPE.SmsIrClient;
using Microsoft.Extensions.Configuration;

namespace _0_SelfBuildFramwork.Application.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        SmsIr smsIr = new SmsIr("KLzqK9Bc1gd8f8LCGBTcy5z74HZfcqeRjFvz5knyblEc6iCFQk0WegyDWvhJ4O3G");

      
        public void Send(string number, string message)
        {
            var ApiKey = _configuration.GetSection("SMS")["ApiKey"];
            
            var token = new SmsIr(ApiKey);
            
            var lines = token.GetLines();
            var Line = lines.Data[0];
            
             var bulkSendResult = smsIr.BulkSend(Line, message, new string[] { number });

            
        }

    }
}
