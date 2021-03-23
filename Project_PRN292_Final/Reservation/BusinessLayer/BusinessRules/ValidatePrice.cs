using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects.BusinessRules
{
    public class ValidatePrice : ValidateRegex
    {
        public ValidatePrice(string propertyName) :
            base(propertyName, @"[1-9]+\.?\d+")
        {
            Error = propertyName + " is not a valid price";
        }

        public ValidatePrice(string propertyName, string errorMessage) :
            this(propertyName)
        {
            Error = errorMessage;
        }
    }
}
