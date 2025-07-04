using Grpc.Core;
using Maddmaxx.Application.Usecases.CreateDocument;
using Maddmaxx.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Shared;
using System.Text.Json;

namespace Maddmaxx.Service.Services;

public class CaptureBusinessInformationService(
    ILogger<CaptureBusinessInformationService> logger,
    IMediator mediator
) : BusinessRegistration.BusinessRegistrationBase, ICaptureBusinessInformationService
{
    private readonly ILogger<CaptureBusinessInformationService> _logger = logger;
    private readonly IMediator _mediator = mediator;

    // Implementation for interface (for internal/testable usage)
    public async Task<BusinessInfoReply> CaptureBusinessInformation(BusinessInfoRequest request)
    {
        var message = $"Company {request.CompanyName} successfully captured";
        _logger.LogInformation($"{message} at {DateTime.UtcNow}");

        // Serialize the request to JSON
        string json = JsonSerializer.Serialize(request);

        // Use MediatR to call the CQRS command (assuming you have the command)
        var command = new CreateDocCommand(json, "CaptureBusinessInformation");
        long docId = await _mediator.Send(command);

        _logger.LogInformation("Business info persisted with DocId: {DocId}", docId);

        return new BusinessInfoReply
        {
            Message = $"{message} (DocId: {docId})"
        };
    }

    // Implementation for gRPC (called by framework)
    public override Task<BusinessInfoReply> CaptureBusinessInformation(
        BusinessInfoRequest request, ServerCallContext context)
    {
        // Just call the interface method (DRY)
        return CaptureBusinessInformation(request);
    }
}
