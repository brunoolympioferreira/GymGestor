using GymGestor.Application.Models.InputModels.User;
using GymGestor.Application.Validations.User;
using GymGestor.Core.Exceptions;
using GymGestor.Infra.Authentication;
using GymGestor.Infra.Persistence.UnityOfWork;

namespace GymGestor.Application.Services.User.WriteOnly;
public class UserWriteOnlyService(IUnityOfWork unityOfWork, IAuthService authService) : IUserWriteOnlyService
{
    public async Task Create(CreateUserInputModel model)
    {
        Validate(model);

        string passwordHash = authService.ComputeSha256Hash(model.Password);

        var user = model.ToEntity(passwordHash);

        bool existUsername = await unityOfWork.Users.ExistUserWithUsername(user.Username, user.Id);

        if (existUsername)
        {
            throw new ValidationErrorsException($"Username {user.Username} já existe no banco de dados.");
        }

        await unityOfWork.Users.Add(user);
        await unityOfWork.CompleteAsync();
    }

    private static void Validate(CreateUserInputModel model)
    {
        var validator = new CreateUserValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
