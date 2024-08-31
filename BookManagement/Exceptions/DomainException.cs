namespace BookManagement.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message) 
        {
            
        }
    }

    public class DomainNotFound : DomainException
    {
        public DomainNotFound(string message) : base(message)
        {

        }
    }

    public class DomainBadRequest : DomainException
    {
        public DomainBadRequest(string message) : base(message)
        {
            
        }
    }

    public class DomainInternalServerError : DomainException
    {
        public DomainInternalServerError(string message) : base(message) 
        {
            
        }
    }

    public class DomainUnAuthorizedError : DomainException
    {
        public DomainUnAuthorizedError(string message) : base(message) 
        {
            
        }
    }
}
