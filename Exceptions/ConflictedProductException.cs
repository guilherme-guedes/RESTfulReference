namespace RESTfulReference.Exceptions
{
    public class ConflictedProductException : Exception
    {
        public ConflictedProductException(string message) : base(message)
        {
        }

        public ConflictedProductException(string message, Exception innerException) : base(message, innerException) { }
    }
}
