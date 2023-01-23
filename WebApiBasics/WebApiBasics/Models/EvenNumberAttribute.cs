using System.ComponentModel.DataAnnotations;

namespace WebApiBasics.Models
{
  [AttributeUsage(AttributeTargets.Property)]
  public class EvenNumberAttribute : ValidationAttribute
  {
    public override string FormatErrorMessage(string name)
    {
      return $"{name} must be an even number";
    }

    public override bool IsValid(object? value)
    {
      int number = (int)(value ?? 0);
      //int number = (int)value!;

      return number % 2 == 0;
    }
  }
}
