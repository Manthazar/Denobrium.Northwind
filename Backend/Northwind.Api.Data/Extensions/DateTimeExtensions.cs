namespace Northwind.Api.Extensions
{
    internal static class DateTimeExtensions
    {
        public static DateOnly ToDateOnly (this DateTime date) 
            => DateOnly.FromDateTime(date);

        public static DateOnly? ToDateOnly(this DateTime? date)
           => date != null ? DateOnly.FromDateTime(date.GetValueOrDefault()) : null;
    }
}
