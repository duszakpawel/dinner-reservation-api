using Demo.Logic.Seedwork.Ddd;

namespace Demo.Logic.Models.ValueObjects
{
    public class Date : ValueObject, IComparable<Date>
    {
        public static Date Today => new Date(DateTime.Now);
        public static Date FromDateTime(DateTime dateTime)
        {
            return new Date(dateTime);
        }

        public Date(int year, int month, int day)
        {
            AsDateTime = new DateTime(year, month, day);
        }

        public Date(DateTime dateTime)
        {
            AsDateTime = dateTime.Date;
        }

        public DateTime AsDateTime { get; }

        public Date AddDays(int days)
        {
            return new Date(AsDateTime.AddDays(days));
        }

        public bool Is(DayOfWeek dayOfWeek)
        {
            var thisDayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), AsDateTime.DayOfWeek.ToString());
            return dayOfWeek.HasFlag(thisDayOfWeek);
        }

        public static implicit operator DateTime(Date d) => d.AsDateTime;
        public static explicit operator Date(DateTime dt) => new Date(dt);

        public int CompareTo(Date other)
        {
            return AsDateTime.CompareTo(other);
        }

        public static bool operator <(Date left, Date right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Date left, Date right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Date left, Date right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Date left, Date right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return AsDateTime;
        }

        public override string ToString()
        {
            return AsDateTime.ToString();
        }
    }

    public static class Extensions
    {
        public static Date ToDate(this DateTime dateTime)
        {
            return new Date(dateTime);
        }
    }
}
