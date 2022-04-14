using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando() : this(0)
        {
        }

        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";

            if (EsBinario(binario))
            {
                char[] array = binario.ToCharArray();
                Array.Reverse(array);

                int sum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }
                retorno = sum.ToString();
            }

            return retorno;
        }

        public string DecimalBinario(double numero)
        {
            string retorno = string.Empty;

            if (numero == 0)
            {
                retorno = "0";
            }
            else if (numero < 0)
            {
                retorno = "Valor invalido";
            }
            else
            {
                int num1 = (int)numero;
                int num2;

                while (num1 > 0)
                {
                    num2 = num1 % 2;
                    num1 /= 2;
                    retorno = num2.ToString() + retorno;
                }
            }

            return retorno;
        }

        public string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";

            if (Int32.TryParse(numero, out int x))
            {
                retorno = DecimalBinario(x);
            }

            return retorno;
        }

        private bool EsBinario(string binario)
        {
            bool retorno = false;

            foreach (char c in binario)
            {
                retorno = true;
                if (c != '0' && c != '1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }

        public static double operator +(Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator -(Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator *(Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }

        public static double operator /(Operando num1, Operando num2)
        {
            double retorno = double.MinValue;

            if (num2.numero != 0)
            {
                retorno = num1.numero / num2.numero;
            }

            return retorno;
        }

        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;

            if (Int32.TryParse(strNumero, out int numero))
            {
                retorno = (double)numero;
            }

            return retorno;
        }
    }
}
