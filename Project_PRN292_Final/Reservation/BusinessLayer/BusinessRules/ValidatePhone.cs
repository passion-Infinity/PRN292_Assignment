using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects.BusinessRules
{
    public class ValidatePhone : ValidateRegex
    {
        public ValidatePhone(string propertyName) :
            base(propertyName, @"\d{8,15}")
        {
            Error = propertyName + " is not a valid phone number";
        }

        public ValidatePhone(string propertyName, string errorMessage) :
            this(propertyName)
        {
            Error = errorMessage;
        }
    }
}
