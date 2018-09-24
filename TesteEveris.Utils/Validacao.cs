using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TesteEveris.Utils
{
    /// <summary>
    /// Classe responsável de realizar validações (Assertion)
    /// </summary>
    public static class Validacao
    {
        /// <summary>
        /// Validar se string é vazia
        /// </summary>
        public static bool Vazio(string value)
        {
            if (String.IsNullOrEmpty(value))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Validar se email é vazio
        /// </summary>
        public static bool EmailInvalido(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return !rg.IsMatch(email);
        }

        /// <summary>
        /// Validar se cpf é válido
        /// </summary>
        public static bool CpfValido(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;

            }
            else
                if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }

        /// <summary>
        /// Verifica se o tamanho da string é maior
        /// </summary>
        public static bool TamanhoMaiorQue(string valor, int tamanhoMaximo)
        {
            return (valor.Length > tamanhoMaximo);
        }

        public static bool ValorVazio(decimal valor)
        {
            return (valor <= 0);
        }

        public static bool DataVazio(DateTime valor)
        {
            return (valor == System.DateTime.MinValue);
        }

        private static Boolean isDigito(string digito)
        {
            int n;
            return Int32.TryParse(digito, out n);
        }

        public static string CalculaDigCPF(string cpf)
        {
            // Declara variaveis para uso
            string new_cpf = "";
            string digito = "";
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cpf.Length; i++)
            {
                if (isDigito(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CPF para 9 digitos completando com zeros a esquerda
            new_cpf = Convert.ToInt64(new_cpf).ToString("D9");

            // Caso o tamanho do CPF informado for maior que 9 digitos retorna nulo
            if (new_cpf.Length > 9)
            {
                return null;
            }

            // Calcula o primeiro digito do CPF
            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (10 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            // Carrega o primeiro digito na variavel digito
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }

            // Adiciona o primeiro digito ao final do CPF para calculo do segundo digito
            new_cpf += digito;

            // Calcula o segundo digito do CPF
            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (11 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            // Carrega o segundo digito na variavel digito
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }

            return digito;
        }



    }
}
