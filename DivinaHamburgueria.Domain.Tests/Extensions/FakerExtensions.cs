using Bogus;

namespace DivinaHamburgueria.Domain.Tests.Extensions
{
    public static class FakerExtensions
    {

        public static string CPF (this Faker faker)
        {

            int soma = 0, resto;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente += resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente += resto;
            return semente;

        }

        public static string CNPJ(this Faker faker)
        {

            int soma = 0, resto;
            int[] multiplicadores = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string raiz;
            string sufixo;

            var random = new Random();

            do
            {
                raiz = random.Next(1, 99999999).ToString().PadLeft(8, '0');
                sufixo = random.Next(1, 9999).ToString().PadLeft(4, '0');
            } while (
                (raiz == "00000000" && sufixo == "0000")
                || (raiz == "11111111" && sufixo == "1111")
                || (raiz == "22222222" && sufixo == "2222")
                || (raiz == "33333333" && sufixo == "3333")
                || (raiz == "44444444" && sufixo == "4444")
                || (raiz == "55555555" && sufixo == "5555")
                || (raiz == "66666666" && sufixo == "6666")
                || (raiz == "77777777" && sufixo == "7777")
                || (raiz == "88888888" && sufixo == "8888")
                || (raiz == "99999999" && sufixo == "9999")
            );

            string semente = raiz + sufixo;

            for (int i = 1; i < multiplicadores.Count(); i++)
            {
                soma += int.Parse(semente[i - 1].ToString()) * multiplicadores[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            semente += resto;
            soma = 0;

            for (int i = 0; i < multiplicadores.Count(); i++)
            {
                soma += int.Parse(semente[i].ToString()) * multiplicadores[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            semente += resto;
            return semente;

        }

    }
}
