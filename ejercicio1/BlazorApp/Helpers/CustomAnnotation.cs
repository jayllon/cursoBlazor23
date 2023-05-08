using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Helpers
{
    public class RequiredConditionalAttribute : ValidationAttribute
    {
        public string PropertyName { get; set; }
        public object[] InValues { get; set; }
        public object[] NotInValues { get; set; }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;
            if (model == null || ((InValues == null || InValues.Count() == 0) && (NotInValues == null || NotInValues.Count() == 0)))
            {
                return ValidationResult.Success;
            }

            var currentValue = model.GetType().GetProperty(PropertyName)?.GetValue(model, null);
            var propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            if (InValues != null && InValues.Count() > 0 && InValues.Contains(currentValue) && (value is string && String.IsNullOrWhiteSpace(value.ToString()) || (value is int && value.Equals(0)) || value == null))
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
            if (NotInValues != null && NotInValues.Count() > 0 && !NotInValues.Contains(currentValue) && (value is string && String.IsNullOrWhiteSpace(value.ToString()) || (value is int && value.Equals(0)) || (value == null)))
            {
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }

}
