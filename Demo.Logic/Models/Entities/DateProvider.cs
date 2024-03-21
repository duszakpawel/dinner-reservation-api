using Demo.Logic.Models.ValueObjects;

namespace Demo.Logic.Models.Entities
{
    public class DateProvider : IDateProvider
    {
        public Date Today => Date.Today;
    }
}
