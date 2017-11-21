namespace ProgramaCAO.Sistema.Solucao.Dominio
{
    public interface IAcao
    {
        bool Cadastrar();

        string Consultar(int id);
    }
}