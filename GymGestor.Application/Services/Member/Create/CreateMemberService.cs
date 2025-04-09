using GymGestor.Application.Models.InputModels.Member;
using GymGestor.Application.Validations.Member;
using GymGestor.Core.Exceptions;
using GymGestor.Core.ValueObjects;
using GymGestor.Infra.Persistence.UnityOfWork;

namespace GymGestor.Application.Services.Member.Create
{
    public class CreateMemberService(IUnityOfWork unityOfWork) : ICreateMemberService
    {
        public async Task Create(CreateMemberInputModel model)
        {
            Validate(model);

            Gender gender = Gender.FromString(model.Gender);

            CPF cpf = CPF.Create(model.CPF);

            Email email = Email.Create(model.Email);

            Address address = new (
                model.Address.Street, 
                model.Address.Number, 
                model.Address.City, 
                model.Address.State, 
                model.Address.ZipCode
            );

            Core.Entities.Member member = model.ToEntity(gender, cpf, email, address);

            await unityOfWork.Members.Add(member);
            await unityOfWork.CompleteAsync();
        }

        private static void Validate(CreateMemberInputModel model)
        {
            var validator = new CreateMemberValidation();
            var result = validator.Validate(model);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationErrorsException(errorMessages);
            }
        }
    }
}
