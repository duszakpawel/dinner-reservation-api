using Demo.Logic.Models.ValueObjects;

namespace Demo.Logic.Models.Entities
{
    public interface IDateProvider
    {
        Date Today { get; }
    }
}
