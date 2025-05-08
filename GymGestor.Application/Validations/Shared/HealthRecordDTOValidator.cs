using FluentValidation;
using GymGestor.Application.Models.DTOs;

namespace GymGestor.Application.Validations.Shared;
public class HealthRecordDTOValidator : AbstractValidator<HealthRecordDTO>
{
    public HealthRecordDTOValidator()
    {
        RuleFor(x => x.MemberId)
            .NotEmpty().WithMessage("O ID do membro é obrigatório.");

        RuleFor(x => x.Condition)
            .NotEmpty().WithMessage("A condição é obrigatória.")
            .MaximumLength(PropertiesValues.ConditionMaxLenght).WithMessage($"A condição deve ter no máximo {PropertiesValues.ConditionMaxLenght} caracteres.");

        RuleFor(x => x.Notes)
            .MaximumLength(PropertiesValues.NotesMaxLenght).WithMessage($"As observações devem ter no máximo {PropertiesValues.NotesMaxLenght} caracteres.")
            .When(x => !string.IsNullOrWhiteSpace(x.Notes));
    }
}
