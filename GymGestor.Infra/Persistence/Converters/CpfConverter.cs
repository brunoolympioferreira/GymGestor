using GymGestor.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymGestor.Infra.Persistence.Converters;
public class CpfConverter : ValueConverter<CPF, string>
{
    public CpfConverter() : base(
            cpf => cpf.Value, // Como salvar no banco (string)
            value => CPF.Create(value)) // Como carregar do banco
    { } 
}
