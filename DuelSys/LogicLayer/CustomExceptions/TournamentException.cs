using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TournamentException : Exception
    {
        public TournamentException()
        {
        }

        public TournamentException(string? message) : base(message)
        {
        }

        public TournamentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TournamentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
