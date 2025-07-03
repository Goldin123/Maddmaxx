using System.Threading.Tasks;

namespace Maddmaxx.Domain.Interfaces;
using Maddmaxx.Domain.Entities;

public interface IDocRepository
{
    /// <summary>
    /// Inserts a new document and returns its generated Id.
    /// </summary>
    /// <param name="doc">The document entity to insert.</param>
    /// <returns>The Id of the newly created Doc.</returns>
    Task<long> CreateAsync(Doc doc);
}
