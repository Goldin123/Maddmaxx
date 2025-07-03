using MediatR;

namespace Maddmaxx.Application.Usecases.CreateDocument;

public record CreateDocCommand(string? Content, string? ContentType) : IRequest<long>;
