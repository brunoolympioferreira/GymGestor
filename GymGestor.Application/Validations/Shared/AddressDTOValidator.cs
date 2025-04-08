using FluentValidation;
using GymGestor.Application.Models.DTOs;

namespace GymGestor.Application.Validations.Shared
{
    public class AddressDTOValidator : AbstractValidator<AddressDTO>
    {
        private const int STREET_MAX_LENGHT = 200;
        private const int NUMBER_MAX_LENGHT = 10;
        private const int CITY_MAX_LENGHT = 100;
        private const int STATE_MAX_LENGHT = 50;
        private const int ZIPCODE_MAX_LENGHT = 20;
        public AddressDTOValidator()
        {
            RuleFor(a => a.Street)
                .NotNull().WithMessage("Rua não pode ser nulo")
                .NotEmpty().WithMessage("Rua não pode ser vazio")
                .MaximumLength(STREET_MAX_LENGHT);

            RuleFor(a => a.Number)
                .NotNull().WithMessage("Número não pode ser nulo")
                .NotEmpty().WithMessage("Número não pode ser vazio")
                .MaximumLength(NUMBER_MAX_LENGHT);

            RuleFor(a => a.City)
                .NotNull().WithMessage("Cidade não pode ser nulo")
                .NotEmpty().WithMessage("Cidade não pode ser vazio")
                .MaximumLength(CITY_MAX_LENGHT);

            RuleFor(a => a.State)
                .NotNull().WithMessage("Estado não pode ser nulo")
                .NotEmpty().WithMessage("Estado não pode ser vazio")
                .MaximumLength(STATE_MAX_LENGHT);

            RuleFor(a => a.ZipCode)
                .NotNull().WithMessage("CEP não pode ser nulo")
                .NotEmpty().WithMessage("CEP não pode ser vazio")
                .MaximumLength(ZIPCODE_MAX_LENGHT);
        }
    }
}
