using System;

namespace ProgramaCAO.Sistema.Solucao.Dominio
{
public class ServicosProdutos
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
    }
}