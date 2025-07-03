using Grpc.Core;
using Shared;

namespace Madmaxx.Services
{
    public class CaptureBusinessInformationService : BusinessRegistration.BusinessRegistrationBase
    {
        private readonly ILogger<CaptureBusinessInformationService> _logger;

        public CaptureBusinessInformationService(ILogger<CaptureBusinessInformationService> logger)
        {
            _logger = logger;
        }

        public override Task<BusinessInfoReply> CaptureBusinessInformation(
            BusinessInfoRequest request, ServerCallContext context)
        {
            var message = $"Company {request.CompanyName} successfully captured";
            _logger.LogInformation(message);

            return Task.FromResult(new BusinessInfoReply
            {
                Message = message
            });
        }
    }
}
