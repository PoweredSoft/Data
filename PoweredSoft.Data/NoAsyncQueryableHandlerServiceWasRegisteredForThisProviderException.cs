using System;
using System.Runtime.Serialization;

namespace PoweredSoft.Data
{
    public class NoAsyncQueryableHandlerServiceWasRegisteredForThisProviderException : Exception
    {
        public NoAsyncQueryableHandlerServiceWasRegisteredForThisProviderException() : base("No AsyncQueryableHandlerService was registered for this queryable provider")
        {
        }
    }
}