using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameExtractor.Interfaces;

namespace NameExtractor
{
    /// <summary>
    /// Name provider class
    /// </summary>
    public class NameProvider : INameProvider
    {
        private string PersonName { get; }

        public NameProvider(string personName)
        {
            PersonName = personName;
        }

        public string GetPersonName()
        {
            return PersonName;
        }
    }
}
