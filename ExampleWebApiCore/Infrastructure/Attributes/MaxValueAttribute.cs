using System.ComponentModel.DataAnnotations;

namespace ExampleWebApiCore.Infrastructure.Attributes
{
    public class MaxValueAttribute : ValidationAttribute
    {
        private readonly double _maxValue;

        public MaxValueAttribute(double maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (double)value <= _maxValue;
        }
        
    }
}