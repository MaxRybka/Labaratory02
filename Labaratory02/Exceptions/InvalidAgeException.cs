using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labaratory02.Exceptions
{
    class InvalidAgeException : Exception
    {
        private string _Message = "Invalid Age!";

        public InvalidAgeException()
        {

        }

        public InvalidAgeException(string message)
            : base(message)
        {
            _Message = message;
        }

        public InvalidAgeException(string message, Exception inner)
            : base(message, inner)
        {
            _Message = message;
        }

        public override string Message
        {
            get { return _Message; }
        }
    }
}
