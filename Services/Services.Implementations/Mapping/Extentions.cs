using Domain.Entities;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations.Mapping
{
    public static class Extentions
    {
        public static List<PatientDto> ToPatientsDto(this List<Patient> patients)
        {
            return patients.Select(p => p.ToPatientDto()).ToList();
        }

        public static PatientDto ToPatientDto(this Patient patient)
        {
            return new PatientDto()
            {
                UserId = patient.UserId,
                Document = patient.Document?.ToDocumentDTO() ?? null,
                Contacts = patient.Contacts?.ToContactsDTO() ?? null,
                Status = (RelevanceStatusEnum)patient.Status
            };
        }

        public static Patient ToPatient(this PatientDto patient)
        {
            return new Patient()
            {
                UserId = patient.UserId,
                Document = patient.Document.ToDocument(),
                Contacts = patient.Contacts.ToContacts(),
                Status = (int)patient.Status
            };
        }
        public static Document ToDocument(this DocumentDTO document)
        {
            return new Document()
            {
                DocumentType = (int)document.DocumentType,
                Series = document.Series,
                Number = document.Number,
                IssueDate = document.IssueDate,
                IssuedBy = document.IssuedBy,
                DepartmentCode = document.DepartmentCode
            };
        }

        public static DocumentDTO ToDocumentDTO(this Document document)
        {
            return new DocumentDTO()
            {
                DocumentType = (DocumentTypeEnum)document.DocumentType,
                Series = document.Series,
                Number = document.Number,
                IssueDate = document.IssueDate,
                IssuedBy = document.IssuedBy,
                DepartmentCode = document.DepartmentCode
            };
        }

        public static Contact ToContact(this ContactDTO contact)
        {
            return new Contact()
            {
                MobilePhone = contact.MobilePhone,
                HomePhone = contact.HomePhone,
                Email = contact.Email,
                Default = contact.Default
            };
        }

        public static ContactDTO ToContactDTO(this Contact contact)
        {
            return new ContactDTO()
            {
                MobilePhone = contact.MobilePhone,
                HomePhone = contact.HomePhone,
                Email = contact.Email,
                Default = contact.Default
            };
        }

        public static List<Contact> ToContacts(this List<ContactDTO> contact)
        {
            return contact.Select(c => c.ToContact()).ToList();
        }

        public static List<ContactDTO> ToContactsDTO(this List<Contact> contact)
        {
            return contact.Select(c => c.ToContactDTO()).ToList();
        }
    }
}
