using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameExtractor.Enums;

namespace NameExtractor
{
    /// <summary>
    /// Name extraction result class
    /// </summary>
    public class NameExtractionResult
    {
        public EnumTitle Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
