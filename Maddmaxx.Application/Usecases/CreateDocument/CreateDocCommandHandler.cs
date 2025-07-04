using Maddmaxx.Application.Usecases.CreateDocument;
using Maddmaxx.Domain.Entities;
using Maddmaxx.Domain.Interfaces;
using MediatR;

namespace Maddmaxx.Application.Usecases.CreateDocument;


public class CreateDocCommandHandler(IDocRepository docRepository)
    : IRequestHandler<CreateDocCommand, long>
{
    public async Task<long> Handle(CreateDocCommand request, CancellationToken cancellationToken)
    {
        var doc = new Doc
        {
            Content = request.Content,
            ContentType = request.ContentType
            // Created, Processed, etc. are handled by the DB
        };

        // Communicate with the repository (infrastructure)
        return await docRepository.CreateAsync(doc);
    }
}
