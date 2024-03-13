using System.ComponentModel;

namespace Domain.Entities
{
    public enum DocumentTypeEnum
    {
        [Description("Неизвестно")]
        None = 0,
        [Description("Пасспорт РФ")]
        PassportRF = 1,
        [Description("Свидетельство о рождении")]
        BirtCertificate = 2,
        [Description("Прочее")]
        Other
    }
}
