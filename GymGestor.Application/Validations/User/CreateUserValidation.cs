using FluentValidation;
using GymGestor.Application.Models.InputModels.User;

namespace GymGestor.Application.Validations.User;
public class CreateUserValidation : AbstractValidator<CreateUserInputModel>
{
    public CreateUserValidation()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email não pode ser vazio.")
            .NotNull().WithMessage("Email não pode ser nulo")
            .EmailAddress().WithMessage("Email inválido")
            .MaximumLength(250).WithMessage("Email deve conter no máximo 250 caracteres");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Senha não pode ser vazia.")
            .NotNull().WithMessage("Senha não pode ser nula")
            .MaximumLength(500).WithMessage("Senha deve contér no máximo 500 caracteres");

        RuleFor(u => u.Role)
            .IsInEnum();
    }
}
