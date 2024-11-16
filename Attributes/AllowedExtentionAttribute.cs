using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
	public class AllowedExtentionAttribute:ValidationAttribute
	{
		private readonly string _allowedExtentions;
        public AllowedExtentionAttribute(string allowedExtentions)
        {
            _allowedExtentions= allowedExtentions;
        }
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile;
			if (file is not null){ 
			   string extention=Path.GetExtension(file.FileName);
				var isallowed=_allowedExtentions.Split(',').Contains(extention,StringComparer.OrdinalIgnoreCase);
				if (!isallowed)
				{
					return new ValidationResult($"Only {_allowedExtentions} are allowed");
				}
			}
			return ValidationResult.Success;
		}
	}
}
