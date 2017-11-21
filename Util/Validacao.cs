using System;

namespace Util
{
    public class Validacao
    {
        
        /// <summary>
        /// Essa função calcula os dois dígitos do CPF e valida com o CPF informado, 
        /// retornando True em caso positivo, ou False em caso negativo.
        /// </summary>
        /// <param name="cpfUsuario">Digitar o CPF do usuário, que terá os dígitos validados</param>
        /// <returns>retorna True caso os dígitos do CPF informado sejam válidos, ou False, 
        /// caso os dígitos do CPF informado sejam inválidos</returns>
                
        public static bool ValidaCPF(string cpfUsuario)
        {
            bool retorno = true;
            string cpfCalculo = "";

            int[] v1 = {10,9,8,7,6,5,4,3,2}; //usa para calcular o primeiro dígito
            int[] v2 = {11,10,9,8,7,6,5,4,3,2}; //usa para calcular o segundo dígito
            int resultado = 0;
            int resto = 0;

            
            cpfCalculo = cpfUsuario.Substring(0,9); // "Substring": to pegando só o CPF sem os dígitos

            //Calculando o primeiro dígito
            for (int i=0;i<cpfCalculo.Length; i++){
                resultado+= Int16.Parse(cpfCalculo[i].ToString())*v1[i];//IMPORTANTE - VER AS ANOTAÇÕES DA AULA 11
            }
            resto = resultado % 11;
            if(resto < 2)
                cpfCalculo+="0";
            else cpfCalculo+=(11-resto).ToString();
            
            resto = 0;
            resultado = 0;

            //Agora calculando o segundo dígito
            for (int i=0;i<cpfCalculo.Length; i++){
                resultado+= Int16.Parse(cpfCalculo[i].ToString())*v2[i];//IMPORTANTE - VER AS ANOTAÇÕES DA AULA 11
            }
            resto = resultado % 11;
            if(resto < 2)
                cpfCalculo+="0";
            else cpfCalculo+=(11-resto).ToString();
            
            resto = 0;
            resultado = 0;

            if (cpfUsuario!=cpfCalculo)
                retorno = false;
            //não preciso fazer else true, pq já iniciei ela como true.
            
            return retorno;

        }


        /// <summary>
        /// Validação de CNPJ
        /// </summary>
        /// <param name="cnpj">Recebe como parametro de entrada um string com o valor do cnpj a ser validado</param>
        /// <returns>Retorna true ou false</returns>
        public bool ValidarCNPJ(string cnpj){

            //Retira os caracteres especiais do CNPJ
            cnpj = cnpj.Trim().Replace(".", "").Replace("-","");

            //Verifica se o CNPJ possui 14 caracteres
            if (cnpj.Length != 14){
                return false;
            }

            //Declara um array com valores a serem multiplicados para encontrar o primeiro caractere
            int[] multiplicador1 = new int[12]{5,4,3,2,9,8,7,6,5,4,3,2};
            //Declara um array com valores a serem multiplicados para encontrar o segundo caractere
            int[] multiplicador2 = new int[13]{6,5,4,3,2,9,8,7,6,5,4,3,2};


            string tempCnpj, digito;
            int soma =0,resto =0;

            //Atribui a variavel os 12 primeiros caracteres do cnpj
            tempCnpj = cnpj.Substring(0,12);

            //Percorre os 12 caracteres e otem a soma
            for (int i = 0; i < 12; i++)
             {
                 //multiplica o valor do array na poição i ao caracter na posição i
                 soma += Convert.ToInt16(tempCnpj[i].ToString())  * multiplicador1[i];
             }

            //obtêm o resto da divisão da soma por 11
            resto = soma % 11;

            //Caso o resto seja menor que 2 atribui 0 e caso seja maior atribui ao valor 11 - resto
            if(resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //Atribui o valor do resto a variável digito
            digito = resto.ToString();
            //Concatena o cnpj com 12 caracteres ao resto para validar o segundo dígito
            tempCnpj = tempCnpj + digito;

            soma = 0;
            //Percorre os 13 caracteres e otem a soma
            for (int i = 0; i < 13; i++)
            {
                 //multiplica o valor do array na poição i ao caracter na posição i
                 soma += Convert.ToInt16(tempCnpj[i].ToString())  * multiplicador2[i];
            }

            //Caso o resto seja menor que 2 atribui 0 e caso seja maior atribui ao valor 11 - resto
            resto = soma % 11;

            //Caso o resto seja menor que 2 atribui 0 e caso seja maior atribui ao valor 11 - resto
            if(resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //Atribui o valor do resto a variável digito
            digito = resto.ToString();

            //Verifica se o digito é igual aos do cnpj, caso seja retorna true caso contrário retorna false
            return cnpj.EndsWith(digito);
        }
    }
}
