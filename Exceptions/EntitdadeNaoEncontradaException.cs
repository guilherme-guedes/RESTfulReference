namespace RESTfulReference.Exceptions
{
    public class EntitdadeNaoEncontradaException : Exception
    {
        public EntitdadeNaoEncontradaException(string message) : base(message)
        {
        }

        public EntitdadeNaoEncontradaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
