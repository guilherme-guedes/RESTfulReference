namespace RESTfulReference.Exceptions
{
    public class EntityConflictedException : Exception
    {
        public EntityConflictedException(string message) : base(message)
        {
        }

        public EntityConflictedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
