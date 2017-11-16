using System;

namespace ProgramaCAO.Sistema.Solucao.Dominio
{
public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }

        public Cliente Dono { get; set; }
        
        public Animal(){}
        public Animal(int id, string nome, string especie, string sexo, int idade, Cliente dono){
            this.Id = id;
            this.Nome = nome;
            this.Especie = especie;
            this.Sexo = sexo;
            this.Idade = idade;
            this.Dono = dono;
        }
    }
}