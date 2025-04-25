using FluentValidation;
using GymGestor.Application.Models.DTOs;
using GymGestor.Application.Models.InputModels.Member;
using GymGestor.Application.Validations.Shared;

namespace GymGestor.Application.Validations.Member;
public class UpdateMemberValidation : AbstractValidator<UpdateMemberInputModel>
{
    public UpdateMemberValidation()
    {
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("E-mail inválido.")
            .MaximumLength(PropertiesValues.EmailMaxLenght)
            .When(e => string.IsNullOrEmpty(e.Email));

        RuleFor(x => x.PhotoUrl)
            .MaximumLength(PropertiesValues.PhoneMaxLenght)
            .When(x => !string.IsNullOrEmpty(x.PhotoUrl));

        RuleFor(x => x.Address)
            .SetValidator(new AddressDTOValidator())
            .When(x => x.Address is not null);

        RuleForEach(x => x.HealthRecords)
            .SetValidator(new HealthRecordDTOValidator())
            .When(x => x.HealthRecords is not null);
    }
}
