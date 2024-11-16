using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
	public class MaxSizeFileAttribute:ValidationAttribute
	{
		private readonly int _MaxFilesize;
		public MaxSizeFileAttribute(int MaxFilesize)
		{
			_MaxFilesize = MaxFilesize;
		}
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile;
			if (file is not null)
			{
				if (file.Length > _MaxFilesize)
				{
					return new ValidationResult($"Max allowed is {_MaxFilesize} Bytes");
				}
				
			}
			return ValidationResult.Success;
		}
	}
}
