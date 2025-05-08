using GymGestor.Application.Models.DTOs;
using GymGestor.Application.Models.InputModels.Member;

namespace GymGestor.UnitTests.Builders.Member;
public static class CreateMemberInputModelBuilder
{
    public static CreateMemberInputModel BuildValid()
    {
        return new CreateMemberInputModel
        {
            FullName = "Maria Souza",
            DateOfBirth = DateTime.Now.AddYears(-30),
            Gender = "Female",
            CPF = "87430251455",
            Email = "mariasouza@email.com",
            Phone = "31999999999",
            Address = new AddressDTO
            {
                Street = "Rua das Flores",
                Number = "123",
                City = "Belo Horizonte",
                State = "MG",
                ZipCode = "30123-456"
            },
            PhotoUrl = "https://example.com/photo.jpg"
        };
    }

    public static CreateMemberInputModel WithInvalidGender()
    {
        var model = BuildValid();
        model.Gender = "Alienígena";
        return model;
    }

    public static CreateMemberInputModel WithInvalidCpf()
    {
        var model = BuildValid();
        model.CPF = "00000000000";
        return model;
    }

    public static CreateMemberInputModel WithInvalidEmail()
    {
        var model = BuildValid();
        model.Email = "emailsemarroba";
        return model;
    }
}
