using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория работы с пациентами
    /// </summary>
    public interface IDocumentRepository
    {
        Task<Guid> CreatePassport(Document document);
    }
}
