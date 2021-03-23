using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects.BusinessRules
{
    public class ValidateIdentity : ValidateRegex
    {
        public ValidateIdentity(string propertyName) :
            base(propertyName, @"\d{12}")
        {
            Error = propertyName + " is not a valid identity card";
        }

        public ValidateIdentity(string propertyName, string errorMessage) :
            this(propertyName)
        {
            Error = errorMessage;
        }
    }
}
