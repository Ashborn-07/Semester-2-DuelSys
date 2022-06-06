using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MatchesException : Exception
    {
        public MatchesException()
        {
        }

        public MatchesException(string? message) : base(message)
        {
        }

        public MatchesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MatchesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
