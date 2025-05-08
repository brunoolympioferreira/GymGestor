using GymGestor.Application.Models.DTOs;
using GymGestor.Application.Models.InputModels.Member;
using GymGestor.Application.Validations.Member;
using GymGestor.Core.Entities;
using GymGestor.Core.Exceptions;
using GymGestor.Core.ValueObjects;
using GymGestor.Infra.Persistence.UnityOfWork;

namespace GymGestor.Application.Services.Member.Update;
public class UpdateMemberService(IUnityOfWork unityOfWork) : IUpdateMemberService
{
    public async Task Update(UpdateMemberInputModel model, Guid id)
    {
        Validate(model);

        var member = await unityOfWork.Members.GetById(id) 
            ?? throw new NotFoundErrorException("Membro não encontrado.");

        var email = CreateEmail(model.Email);
        var address = CreateAddress(model.Address);
        var healthRecords = CreateHealthRecords(model.HealthRecords);

        member.Update(email, model.Phone, address, model.PhotoUrl, healthRecords);

        unityOfWork.Members.Update(member);
        await unityOfWork.CompleteAsync();
    }

    private static void Validate(UpdateMemberInputModel model)
    {
        var validator = new UpdateMemberValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }

    private static Email? CreateEmail(string? email) =>
    email is not null ? Email.Create(email) : null;

    private static Address? CreateAddress(AddressDTO? input) =>
        input is not null ? new Address(input.Street, input.Number, input.City, input.State, input.ZipCode) : null;

    private static ICollection<HealthRecord>? CreateHealthRecords(IEnumerable<HealthRecordDTO>? records) =>
        records?.Select(x => new HealthRecord(x.MemberId, x.Condition, x.Notes, x.RecordDate)).ToList();
}
