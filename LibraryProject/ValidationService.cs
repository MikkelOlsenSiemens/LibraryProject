using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    public class ValidationService : IValidationService
    {
        public bool IsValidBookPubYear(int pubYear)
        {
            if (pubYear < 0) return false;

            return true;
        }
    }
}
