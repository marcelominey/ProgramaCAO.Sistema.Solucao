using System;
using System.IO;

namespace Dominio
{
public class ServicosProdutos : IAcao
    {
        public int Cod { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        
        public ServicosProdutos(){}
        public ServicosProdutos(int cod, string descricao, double preco){
            this.Cod = cod;
            this.Descricao = descricao;
            this.Preco = preco;            
        }
        public bool Cadastrar()
        {
            bool cadastroProdutos = false;
            StreamWriter arquivoProdutos = null;
            try{
                arquivoProdutos = new StreamWriter("Serviços e Produtos.csv", true);
                
                arquivoProdutos.WriteLine(
                    Cod+";"+
                    Descricao+";"+
                    Preco
                    );

                cadastroProdutos = true;
            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar gravar o arquivo.");
            }
            finally{
                arquivoProdutos.Close();
            }
            return cadastroProdutos;
        }
        public string Consultar()
        {
            return null;
        }
    }
}
