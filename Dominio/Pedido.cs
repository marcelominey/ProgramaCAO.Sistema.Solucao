using System;
using System.IO;
using System.Text;

namespace ProgramaCAO.Sistema.Solucao_master.Dominio
{
    public class Pedido : IAcao
    {

        public int IDPedido { get; set; }
        public string NomeCliente { get; set; }
        public string NomePet { get; set; }
        public string DescricaoProdutoServico { get; set; }


        public Pedido() { }

        public Pedido(int idPedido, string nomeCliente, string nomePet, string descricaoProdutoServico)
        {

            this.IDPedido = idPedido;
            this.NomeCliente = nomeCliente;
            this.NomePet = nomePet;
            this.DescricaoProdutoServico = descricaoProdutoServico;

        }


        public bool Cadastrar()
        {

            string arquivo = "pedido.csv";
            bool cadastrado = false;
            StreamWriter gravador = null;

            try
            {

                gravador = new StreamWriter(arquivo, true);
                gravador.WriteLine("{0};{1};{2};{3}", this.IDPedido, this.NomeCliente, this.NomePet, this.DescricaoProdutoServico);
                cadastrado = true;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar o pedido\n" + ex.Message);

            }

            return cadastrado;

        }

        public string Consultar(int idPedido)
        {

            bool encontrado=false;
            string arquivo = "pedido.csv";
            StreamReader leitor = null;
            string retorno = "ID do pedido não encontrado.";

            try
            {

                string linha = "";
                string[] dados = null;
                leitor = new StreamReader(arquivo, Encoding.Default);
                while (!leitor.EndOfStream)
                {

                    linha = leitor.ReadLine();
                    dados = linha.Split(';');

                    if (int.Parse(dados[0]) == idPedido)
                    {

                        encontrado=true;
                        break;

                    }
                }

                if (encontrado)
                    retorno = linha;

            }
            catch (System.Exception ex)
            {

                //throw new Exception("Erro ao ler o arquivo de pedidos.\n" + ex.Message);
                retorno = "Erro ao ler o arquivo de pedidos. " + ex.Message;

            } finally{

                leitor.Close();

            }

            return retorno;

        }
    }
}