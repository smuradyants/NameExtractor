using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameExtractor.Exceptions
{
    /// <summary>
    /// More than three words logic Eception Class.
    /// </summary>
    public class MoreThanThreeWordsException : Exception
    {
        public MoreThanThreeWordsException()
        {

        }

        public MoreThanThreeWordsException(string message)
            : base(message)
        {

        }

        public MoreThanThreeWordsException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
