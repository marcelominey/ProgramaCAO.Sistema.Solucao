using System;

namespace ProgramaCAO.Sistema.Solucao.Dominio
{
public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Endereco End { get; set; }
        public Cliente(){}
        public Cliente(int id, string nome, string cpf, string telefone, Endereco endereco){
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.End = endereco;
        }
    }
}