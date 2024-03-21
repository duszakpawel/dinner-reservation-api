using System.Runtime.Serialization;

namespace Demo.Logic.Seedwork.Ddd
{
    [Serializable]
    public class InvalidEntityStateException : Exception
    {
        public List<string> Errors { get; }
        public InvalidEntityStateException() { }
        public InvalidEntityStateException(string message) : base(message) { }
        public InvalidEntityStateException(string message, Exception inner) : base(message, inner) { }

        protected InvalidEntityStateException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public InvalidEntityStateException(List<string> errors) : base(string.Join(Environment.NewLine, errors))
        {
            Errors = errors;
        }
    }
}
