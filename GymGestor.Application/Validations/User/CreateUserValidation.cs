using FluentValidation;
using GymGestor.Application.Models.InputModels.User;

namespace GymGestor.Application.Validations.User;
public class CreateUserValidation : AbstractValidator<CreateUserInputModel>
{
    public CreateUserValidation()
    {
        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Username não pode ser vazio.")
            .NotNull().WithMessage("Username não pode ser nulo")
            .MaximumLength(200).WithMessage("Username de conter no máximo 200 caracteres");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Senha não pode ser vazia.")
            .NotNull().WithMessage("Senha não pode ser nula")
            .MaximumLength(500).WithMessage("Senha deve contér no máximo 500 caracteres");

        RuleFor(u => u.Role)
            .IsInEnum();
    }
}
