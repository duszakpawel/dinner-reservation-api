using Demo.Logic.Seedwork.Ddd;

namespace Demo.Logic.Models.ValueObjects
{
    public class DateTimeRange : ValueObject
    {
        public DateTimeRange(DateTime startDateTime, DateTime endDateTime)
        {
            if (endDateTime <= startDateTime)
            {
                throw new ArgumentException($"\"{nameof(endDateTime)}\" - {endDateTime} has to follow \"{nameof(startDateTime)}\" - {startDateTime}.");
            }

            Start = startDateTime;
            End = endDateTime;
        }

        public DateTimeRange(Date start, TimeSpanRange timeSpanRange)
        {
            Start = start.AsDateTime + timeSpanRange.Start;
            End = Start + timeSpanRange.Length;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TimeSpan Length => End - Start;

        public bool Contains(DateTime dateTime) => dateTime >= Start && dateTime <= End;

        /// <summary>
        /// Whether this and other <see cref="DateTimeRange"/> have at least two distinct common instants.
        /// </summary>
        public bool Intersects(DateTimeRange other) => other.End > Start && other.Start < End;

        public DateTimeRange Intersection(DateTimeRange other)
        {
            if (!Intersects(other))
            {
                throw new InvalidOperationException();
            }

            return new DateTimeRange(Start > other.Start ? Start : other.Start, End < other.End ? End : other.End);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Start;
            yield return End;
        }

        public override string ToString()
        {
            return $"{Start.ToString()} - {End.ToString()}";
        }
    }
}
