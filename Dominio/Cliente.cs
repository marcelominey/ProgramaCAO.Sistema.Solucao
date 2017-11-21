using System;
using System.IO;
using System.Text;

namespace ProgramaCAO.Sistema.Solucao.Dominio {
    public class Cliente : IAcao {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Endereco End { get; set; }
        public Cliente () { }
        public Cliente(int id, string nome, string cpf, string telefone, Endereco endereco){
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.End = endereco;
        }
        public bool Cadastrar () {
            StreamWriter arquivo = null;
            try {
                arquivo = new StreamWriter ("arquivo.csv", true);
                arquivo.WriteLine (Id + ";" + Nome + ";" + Cpf + ";" + Telefone + ";" + End.Logradouro + ";" + End.Numero + ";" + End.Complemento + ";" + End.CEP + ";" + End.Estado);
            } catch (Exception ex) {
                throw new Exception ("Erro ao cadastrar! " + ex.Message);
            } finally {
                arquivo.Close ();
            }
            return true;
        }

        public string Consultar(int Id) {   
            StreamReader ler=null;
            string resultado="Cliente não encontrado!";

            try{
                ler=new StreamReader("arquivo.csv", Encoding.Default);
                string linha="";
                while((linha=ler.ReadLine())!=null){
                    string[] dados=linha.Split(';');
                    if(dados[0]==Id.ToString()){
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