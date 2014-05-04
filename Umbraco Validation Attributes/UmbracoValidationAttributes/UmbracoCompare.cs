using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace UmbracoValidationAttributes
{
    public class UmbracoCompare : System.ComponentModel.DataAnnotations.CompareAttribute, IClientValidatable
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessageDictionaryKey { get; set; }

        ValidationContext context { get; set; }

        public UmbracoCompare(string otherProperty) : base(otherProperty)
        {
        }

        public override string FormatErrorMessage(string name)
        {

            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(ErrorMessageDictionaryKey);

            //Can't figure out how to get the object/class with the attribute on
            //Default class uses validationContext, but not sure how to get to that either
            //OtherPropertyDisplayName = GetDisplayNameForProperty(validation.ObjectType, OtherProperty);

            return base.FormatErrorMessage(name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var error   = FormatErrorMessage(metadata.GetDisplayName());
            var rule    = new ModelClientValidationEqualToRule(error, CompareAttribute.FormatPropertyForClientValidation(OtherProperty));

            yield return rule;
        }

        //Two methods below copied direct from CompareAttribute
        //But slightly modified to use UmbracoDisplayAttribute

        private static ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
        }

        private static string GetDisplayNameForProperty(Type containerType, string propertyName)
        {
            ICustomTypeDescriptor typeDescriptor    = GetTypeDescriptor(containerType);
            PropertyDescriptor property             = typeDescriptor.GetProperties().Find(propertyName, true);

            if (property == null)
            {
                throw new Exception("Property is null");
            }
            
            //Get the attributes on the property
            IEnumerable<Attribute> attributes = property.Attributes.Cast<Attribute>();

            //See if we can get UmbracoDisplay off the attributes
            UmbracoDisplayName displayName = attributes.OfType<UmbracoDisplayName>().FirstOrDefault();
            if (displayName != null)
            {
                return displayName.DisplayName;
            }
            return propertyName;
        }
    }
}
