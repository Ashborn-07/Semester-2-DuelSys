using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ScoreExceptions : Exception
    {
        public ScoreExceptions()
        {
        }

        public ScoreExceptions(string? message) : base(message)
        {
        }

        public ScoreExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ScoreExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
