using Domain.Entities;
using HelpersDTO.Patient.DTO;
using System;

namespace Infrastructure.Repositories.Implementations.Mapping
{
    public static class Extentions
    {
        public static Document ToDocument(this PassportDTO passportDTO, Guid? userId)
        {
            if (passportDTO == null) return null;
            return new Document()
            {
                UserId = userId,
                Series = passportDTO.Series,
                Number = passportDTO.Number,
                IssueDate = passportDTO.IssueDate,
                DepartmentCode = passportDTO.SubdivisionCode,
                IssuedBy = passportDTO.IssuedBy,
                // всегда пасспорт
                DocumentType = 1
            };
        }
    }
}
