using System.ComponentModel;

namespace Services.Contracts
{
    public enum RelevanceStatusEnum
    {
        [Description("Нет")]
        None = 0,
        [Description("Новый")]
        New,
        [Description("Подтвержден")]
        Confirmed,
        [Description("Удален")]
        Deleted,
        [Description("Заблокирован")]
        Blocked
    }
}
