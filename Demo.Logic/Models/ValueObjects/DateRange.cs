namespace Demo.Logic.Models.ValueObjects
{
    public class DateRange : DateTimeRange
    {
        public DateRange(Date startDate, Date endDate) : base(startDate, endDate.AddDays(1) /*include last day*/)
        {
        }

        public new DateTime End => base.End.AddDays(-1);

        public IEnumerable<Date> Dates
        {
            get
            {
                var d = Start;
                while (d < base.End)
                {
                    yield return Date.FromDateTime(d);
                    d = d.AddDays(1);
                }
            }
        }

        public bool Contains(Date date) => date >= Start && date < base.End;
    }
}
