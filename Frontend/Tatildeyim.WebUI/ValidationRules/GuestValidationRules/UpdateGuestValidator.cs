using FluentValidation;
using Tatildeyim.WebUI.Dtos.GuestDto;

namespace Tatildeyim.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator:AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim en az 3 karakterden oluşmalıdır");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("İsim en fazla 20 karakterden oluşmalıdır");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyisim en az 3 karakterden oluşmalıdır");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Soyisim en fazla 30 karakterden oluşmalıdır");

            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Şehir en az 3 karakterden oluşmalıdır");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Şehir en fazla 20 karakterden oluşmalıdır");
        }
    }
}
