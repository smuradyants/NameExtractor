using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameExtractor.Enums;
using NameExtractor.Exceptions;
using NameExtractor.Interfaces;

namespace NameExtractor
{
    /// <summary>
    /// Name extractor class
    /// </summary>
    public class NameExtractor
    {
        private INameProvider NameProvider { get; }
        public NameExtractor(INameProvider nameProvider)
        {
            NameProvider = nameProvider;
        }

        public NameExtractionResult Extract()
        {
            var personName = NameProvider.GetPersonName();
            var personNameWords = personName.Split(' ').Where(_ => _ != "").ToList();
            var wordsCount = personNameWords.Count;

            var nameExtractionResult = new NameExtractionResult();

            if (wordsCount == 0)
                return nameExtractionResult;

            if (wordsCount > 3)
            {
                throw new MoreThanThreeWordsException("There are more than three words");
            }

            EnumTitle title;
            Enum.TryParse(personNameWords[0].Replace(".", ""), true, out title);
            if (wordsCount == 1)
            {
                nameExtractionResult.LastName = personNameWords[0];
            }
            if (wordsCount >= 2)
            {
                if (wordsCount == 2 && title != EnumTitle.Unknown)
                {
                    nameExtractionResult.Title = title;
                    nameExtractionResult.LastName = personNameWords[1];
                }
                else
                {
                    if (title == EnumTitle.Unknown)
                    {
                        nameExtractionResult.FirstName = personNameWords[0];
                        nameExtractionResult.LastName = personNameWords[1];
                    }
                    else
                    {
                        nameExtractionResult.Title = title;
                        nameExtractionResult.FirstName = personNameWords[1];
                        nameExtractionResult.LastName = personNameWords[2];
                    }
                }
            }

            return nameExtractionResult;
        }
    }
}
