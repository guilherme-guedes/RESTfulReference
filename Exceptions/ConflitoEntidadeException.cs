namespace RESTfulReference.Exceptions
{
    public class ConflitoEntidadeException : Exception
    {
        public ConflitoEntidadeException(string message) : base(message)
        {
        }

        public ConflitoEntidadeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
