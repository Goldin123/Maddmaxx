using Grpc.Core;
using Maddmaxx.Service.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Shared;

namespace Maddmaxx.Service.Services;

public class CaptureBusinessInformationService(ILogger<CaptureBusinessInformationService> logger)
    : BusinessRegistration.BusinessRegistrationBase, ICaptureBusinessInformationService
{
    private readonly ILogger<CaptureBusinessInformationService> _logger = logger;

    // Implementation for interface (for internal/testable usage)
    public Task<BusinessInfoReply> CaptureBusinessInformation(BusinessInfoRequest request)
    {
        var message = $"Company {request.CompanyName} successfully captured";
        _logger.LogInformation($"{message} at {DateTime.UtcNow}");

        return Task.FromResult(new BusinessInfoReply
        {
            Message = message
        });
    }

    // Implementation for gRPC (called by framework)
    public override Task<BusinessInfoReply> CaptureBusinessInformation(
        BusinessInfoRequest request, ServerCallContext context)
    {
        // Just call the interface method (DRY)
        return CaptureBusinessInformation(request);
    }
}
