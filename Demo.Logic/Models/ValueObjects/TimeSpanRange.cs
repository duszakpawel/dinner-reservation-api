using Demo.Logic.Seedwork.Ddd;

namespace Demo.Logic.Models.ValueObjects
{
    public class TimeSpanRange : ValueObject
    {
        public TimeSpanRange(TimeSpan start, TimeSpan end)
        {
            Validate(start, nameof(start));
            Validate(end, nameof(end));
            Start = start;
            End = end;
        }

        public TimeSpan Start { get; private set; }
        public TimeSpan End { get; private set; }

        public TimeSpan Length => Overnight ? TimeSpan.FromDays(1) - Start + End : End - Start;
        public bool Overnight => End <= Start;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Start;
            yield return End;
        }

        private void Validate(TimeSpan time, string argumentName)
        {
            if (time >= TimeSpan.FromDays(1))
            {
                throw new ArgumentException($"\"{argumentName}\" must be a time of a day.");
            }
        }
        public override string ToString()
        {
            return $"{Start.ToString()} - {End.ToString()}";
        }
    }
}
