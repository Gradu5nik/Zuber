﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zuber.CustomAtributes
{
    public class PasswordFoolproofAttribute : ValidationAttribute
    {
        private string OtherProperty { get; set; }
        private string OtherProperty2 { get; set; }
        private string OtherProperty3 { get; set; }

        public PasswordFoolproofAttribute(string otherProperty, string otherProperty2, string otherProperty3)
        {
            OtherProperty = otherProperty;
            OtherProperty2 = otherProperty2;
            OtherProperty3 = otherProperty3;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // get other property value
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);
            var otherPropertyInfo2 = validationContext.ObjectType.GetProperty(OtherProperty2);
            var otherValue2 = otherPropertyInfo2.GetValue(validationContext.ObjectInstance);
            var otherPropertyInfo3 = validationContext.ObjectType.GetProperty(OtherProperty3);
            var otherValue3 = otherPropertyInfo3.GetValue(validationContext.ObjectInstance);
            // verify values
            if (value.ToString().Equals(otherValue.ToString())||value.ToString().Equals(otherValue2.ToString())|| value.ToString().Equals(otherValue3.ToString()))
                return new ValidationResult("We ask you to not use personal information as password for safety reasons");
            else
                return ValidationResult.Success;
        }
    }
}
