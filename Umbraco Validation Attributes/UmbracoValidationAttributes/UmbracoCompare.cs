using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoCompare : System.Web.Mvc.CompareAttribute, IClientValidatable
    {

        public UmbracoCompare(string errorMessageDictionaryKey,string otherProperty)
            : base(otherProperty)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);
        }
    }
}
