using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models.CustomDataAnnotations
{
    public class NotZeroOrLessValueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            return (int)value > 0;
            
        }
    }
}