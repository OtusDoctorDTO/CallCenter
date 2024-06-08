using Domain.Entities;
using Infrastructure.EntityFramework;
using Services.Repositories.Abstractions;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с курсами
    /// </summary>
    public class DocumentRepository(DatabaseContext context) : IDocumentRepository
    {
        private readonly DatabaseContext context = context;

        public async Task<Guid> CreatePassport(Document document)
        {
            context.Add(document);
            await context.SaveChangesAsync();
            return document.Id;
        }
    }
}
