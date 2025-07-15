using FluentValidation;
using GymGestor.Application.Models.InputModels.Member;
using GymGestor.Application.Validations.Shared;

namespace GymGestor.Application.Validations.Member
{
    public class CreateMemberValidation : AbstractValidator<CreateMemberInputModel>
    {
        public CreateMemberValidation()
        {
            RuleFor(m => m.FullName)
                .NotNull().WithMessage("Nome do membro não pode ser nulo")
                .NotEmpty().WithMessage("Nome do membro não pode ser vazio")
                .MaximumLength(PropertiesValues.FullNameLenght).WithMessage($"Nome do membro deve conter no máximo {PropertiesValues.FullNameLenght} caracteres");

            RuleFor(m => m.DateOfBirth)
                .NotNull().WithMessage("Data de Nascimento do membro não pode ser nulo")
                .NotEmpty().WithMessage("Data de Nascimento do membro não pode ser vazio");

            RuleFor(m => m.Gender)
                .NotNull().WithMessage("Gênero do membro não pode ser nulo")
                .NotEmpty().WithMessage("Gênero do membro não pode ser vazio")
                .MaximumLength(PropertiesValues.GenderMaxLenght).WithMessage($"Gênero deve conter no máximo {PropertiesValues.GenderMaxLenght} caracteres");

            RuleFor(m => m.CPF)
                .NotNull().WithMessage("CPF do membro não pode ser nulo")
                .NotEmpty().WithMessage("CPF do membro não pode ser vazio")
                .MaximumLength(PropertiesValues.CPFMaxLenght).WithMessage($"CPF deve conter no máximo {PropertiesValues.CPFMaxLenght} caracteres");

            RuleFor(m => m.Email)
                .NotNull().WithMessage("Email do membro não pode ser nulo")
                .NotEmpty().WithMessage("Email do membro não pode ser vazio")
                .EmailAddress().WithMessage("Email inválido")
                .MaximumLength(PropertiesValues.EmailMaxLenght).WithMessage($"Email deve conter no máximo {PropertiesValues.EmailMaxLenght} caracteres");

            RuleFor(m => m.Phone)
                .NotNull().WithMessage("Telefone do membro não pode ser nulo")
                .NotEmpty().WithMessage("Telefone do membro não pode ser vazio")
                .MaximumLength(PropertiesValues.PhoneMaxLenght).WithMessage($"Telefone deve conter no máximo {PropertiesValues.PhoneMaxLenght} caracteres");

            RuleFor(m => m.Address)
                .SetValidator(new AddressDTOValidator());

            RuleFor(m => m.PhotoUrl)
                .NotNull().WithMessage("Foto do membro não pode ser nulo")
                .NotEmpty().WithMessage("Foto do membro não pode ser vazio")
                .MaximumLength(PropertiesValues.PhotoMaxLenght).WithMessage($"URL deve conter no máximo {PropertiesValues.PhotoMaxLenght} caracteres");
        }
    }
}
