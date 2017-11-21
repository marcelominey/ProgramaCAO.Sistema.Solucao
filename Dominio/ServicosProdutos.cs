using System;
using System.IO;
using System.Text;

namespace ProgramaCAO.Sistema.Solucao.Dominio
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
            //precisa construir o PRECOTOTAL
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
        public string Consultar(int cod) {   
            StreamReader ler=null;
            string resultado="Serviço ou produto não encontrado!";

            try{
                ler=new StreamReader("arquivo.csv", Encoding.Default);
                string linha="";
                while((linha=ler.ReadLine())!=null){
                    string[] dados=linha.Split(';');
                    if(dados[0]==Cod.ToString()){
                    resultado=linha;
                    break;
                    }
                }
            }
            catch(Exception ex){
                resultado="Erro ao consultar arquivo! "+ex.Message;
            }
            finally{
                ler.Close();
            }
        return resultado;
        }
    }
}