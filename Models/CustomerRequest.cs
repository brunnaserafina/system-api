namespace MeuProjetoMVC.Models;

public class CustomerRequest
{
    public string? code { get; set; }
    public string? name { get; set; }
    public string? cpf { get; set; }
    public string? address { get; set; }
    public string? phone { get; set; }

    public bool ValidateCPF()
    {
        if (string.IsNullOrEmpty(cpf))
        {
            return false;
        }

        string cleanedCPF = new string(cpf.Where(char.IsDigit).ToArray());

        if (cleanedCPF.Length != 11)
        {
            return false;
        }

        if (cleanedCPF.Distinct().Count() == 1)
        {
            return false;
        }

        int[] multipliers1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multipliers2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string cpfDigits = cleanedCPF.Substring(0, 9);
        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(cpfDigits[i].ToString()) * multipliers1[i];
        }

        int remainder = sum % 11;
        int digit1 = remainder < 2 ? 0 : 11 - remainder;

        cpfDigits += digit1;

        sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(cpfDigits[i].ToString()) * multipliers2[i];
        }

        remainder = sum % 11;
        int digit2 = remainder < 2 ? 0 : 11 - remainder;

        cpfDigits += digit2;

        if (cleanedCPF.Substring(9) != cpfDigits.Substring(9))
        {
            return false;
        }

        return true;

    }
}