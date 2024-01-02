namespace RESTfulReference.Exceptions
{
    public class MalformedIdException : Exception
    {
        public MalformedIdException(string message) : base(message)
        {
        }

        public MalformedIdException(string message, Exception innerException) : base(message, innerException) { }
    }
}
