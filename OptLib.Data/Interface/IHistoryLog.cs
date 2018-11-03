using OptLib.Data.ComplexType;

namespace OptLib.Data.Interface
{
    /// <summary>
    /// رابط لاگ
    /// </summary>
    /// <typeparam name="TKeyTable">The type of the t key table.</typeparam>
    public interface IHistoryLog<TKeyTable>
    {
        /// <summary>
        /// کد کلید اصلی جدول
        /// </summary>
        /// <value>The t key.</value>
        TKeyTable LKey { get; set; }

        /// <summary>
        /// افزودن کلاس افزایشی تاریخچه تغییرات
        /// </summary>
        /// <value>The h log.</value>
        _HistoryLog HistoryLog { get; set; }

    }
}
