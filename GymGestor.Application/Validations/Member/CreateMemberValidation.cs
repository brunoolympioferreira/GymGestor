using FluentValidation;
using GymGestor.Application.Models.InputModels.Member;
using GymGestor.Application.Validations.Shared;

namespace GymGestor.Application.Validations.Member
{
    public class CreateMemberValidation : AbstractValidator<CreateMemberInputModel>
    {
        private const int FULL_NAME_MAX_LENGHT = 150;
        private const int GENDER_MAX_LENGHT = 50;
        private const int CPF_MAX_LENGHT = 14;
        private const int EMAIL_MAX_LENGHT = 150;
        private const int PHONE_MAX_LENGHT = 20;
        private const int PHOTO_MAX_LENGHT = 255;
        public CreateMemberValidation()
        {
            RuleFor(m => m.FullName)
                .NotNull().WithMessage("Nome do membro não pode ser nulo")
                .NotEmpty().WithMessage("Nome do membro não pode ser vazio")
                .MaximumLength(FULL_NAME_MAX_LENGHT).WithMessage($"Nome do membro deve conter no máximo {FULL_NAME_MAX_LENGHT} caracteres");

            RuleFor(m => m.DateOfBirth)
                .NotNull().WithMessage("Data de Nascimento do membro não pode ser nulo")
                .NotEmpty().WithMessage("Data de Nascimento do membro não pode ser vazio");

            RuleFor(m => m.Gender)
                .NotNull().WithMessage("Gênero do membro não pode ser nulo")
                .NotEmpty().WithMessage("Gênero do membro não pode ser vazio")
                .MaximumLength(GENDER_MAX_LENGHT).WithMessage($"Gênero deve conter no máximo {GENDER_MAX_LENGHT} caracteres");

            RuleFor(m => m.CPF)
                .NotNull().WithMessage("CPF do membro não pode ser nulo")
                .NotEmpty().WithMessage("CPF do membro não pode ser vazio")
                .MaximumLength(CPF_MAX_LENGHT).WithMessage($"CPF deve conter no máximo {CPF_MAX_LENGHT} caracteres");

            RuleFor(m => m.Email)
                .NotNull().WithMessage("Email do membro não pode ser nulo")
                .NotEmpty().WithMessage("Email do membro não pode ser vazio")
                .EmailAddress().WithMessage("Email inválido")
                .MaximumLength(EMAIL_MAX_LENGHT).WithMessage($"Email deve conter no máximo {EMAIL_MAX_LENGHT} caracteres");

            RuleFor(m => m.Phone)
                .NotNull().WithMessage("Telefone do membro não pode ser nulo")
                .NotEmpty().WithMessage("Telefone do membro não pode ser vazio")
                .MaximumLength(PHONE_MAX_LENGHT).WithMessage($"Telefone deve conter no máximo {PHONE_MAX_LENGHT} caracteres");

            RuleFor(m => m.Address)
                .SetValidator(new AddressDTOValidator());

            RuleFor(m => m.PhotoUrl)
                .NotNull().WithMessage("Foto do membro não pode ser nulo")
                .NotEmpty().WithMessage("Foto do membro não pode ser vazio")
                .MaximumLength(PHOTO_MAX_LENGHT).WithMessage($"Telefone deve conter no máximo {PHOTO_MAX_LENGHT} caracteres");
        }
    }
}
