using System.Text.RegularExpressions;

namespace GymGestor.Core.ValueObjects;
public sealed class CPF
{
    public string Value { get; }

    private CPF(string value)
    {
        Value = value;
    }

    public static CPF Create(string cpf)
    {
        if (!IsValid(cpf))
            throw new ArgumentException("CPF inválido.", nameof(cpf));

        return new CPF(Normalize(cpf));
    }

    private static bool IsValid(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = Normalize(cpf);

        if (cpf.Length != 11 || Regex.IsMatch(cpf, @"^(\d)\1{10}$"))
            return false;

        return ValidateDigits(cpf);
    }

    private static string Normalize(string cpf)
    {
        return Regex.Replace(cpf, @"\D", ""); // Remove não numéricos
    }

    private static bool ValidateDigits(string cpf)
    {
        int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int primeiroDigito = CalcularDigito(tempCpf, multiplicadores1);
        int segundoDigito = CalcularDigito(tempCpf + primeiroDigito, multiplicadores2);

        return cpf.EndsWith($"{primeiroDigito}{segundoDigito}");
    }

    private static int CalcularDigito(string cpfParcial, int[] multiplicadores)
    {
        int soma = 0;
        for (int i = 0; i < multiplicadores.Length; i++)
        {
            soma += (cpfParcial[i] - '0') * multiplicadores[i];
        }

        int resto = soma % 11;
        return resto < 2 ? 0 : 11 - resto;
    }

    public override string ToString() => Convert.ToUInt64(Value).ToString(@"000\.000\.000\-00");

    public override bool Equals(object obj) => obj is CPF cpf && cpf.Value == Value;

    public override int GetHashCode() => Value.GetHashCode();
}
