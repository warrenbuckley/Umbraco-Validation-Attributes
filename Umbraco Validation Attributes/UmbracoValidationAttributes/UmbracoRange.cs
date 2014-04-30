using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoRange : RangeAttribute, IClientValidatable
    {
        public UmbracoRange(Type type, string minimum, string maximum): base(type, minimum, maximum)
        {
        }

        public UmbracoRange(double minimum, double maximum): base(minimum, maximum)
        {
        }

        public UmbracoRange(int minimum, int maximum): base(minimum, maximum)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return null;
            //var rule = new ModelClientValidationRangeRule();
        }
    }
}
