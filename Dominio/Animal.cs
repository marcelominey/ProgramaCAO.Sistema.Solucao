using System;
using System.IO;

namespace ProgramaCAO.Sistema.Solucao.Dominio
{
public class Animal : IAcao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Genero { get; set; }
        public int Idade { get; set; }

        public Cliente Dono { get; set; }
        
        public Animal(){}
        public Animal(int id, string nome, string especie, string genero, int idade, Cliente dono){
            this.Id = id;
            this.Nome = nome;
            this.Especie = especie;
            this.Genero = genero;
            this.Idade = idade;
            this.Dono = dono;
        }

        public bool Cadastrar()
        {
            bool cadastroAnimal = false;
            StreamWriter arquivoAnimal = null;
            try{
                arquivoAnimal = new StreamWriter("Animais.csv", true);
                
                arquivoAnimal.WriteLine(
                    Id+";"+
                    Nome+";"+
                    Especie+";"+
                    Genero+";"+
                    Idade+";"+
                    Dono
                    );

                cadastroAnimal = true;
            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar gravar o arquivo.");
            }
            finally{
                arquivoAnimal.Close();
            }
            return cadastroAnimal;
        }
        public string Consultar()
        {
            return null;
        }
    }
}
