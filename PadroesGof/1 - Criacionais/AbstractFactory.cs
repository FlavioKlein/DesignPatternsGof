namespace PadroesGof.Criacionais
{
    /// <summary>
    /// Abstract Factory:
    /// Cria famílias de objetos relacionados, sem especificar suas classes concretas.
    /// </summary>
    

    // Produtos abstratos
    public interface ICadeira
    {
        void Sentar();
    }
    public interface ISofa
    {
        void Deitar();
    }

    // Produtos concretos
    public class CadeiraModerna : ICadeira {
        public void Sentar() => Console.WriteLine("Sentando na Cadeira Moderna."); 
    }
    
    public class SofaModerno : ISofa { 
        public void Deitar() => Console.WriteLine("Deitando no Sofá Moderno."); 
    }

    // Fábrica abstrata
    public interface IFabricaMoveis
    {
        ICadeira CriarCadeira();
        ISofa CriarSofa();
    }

    // Fábrica concreta
    public class FabricaModerna : IFabricaMoveis
    {
        public ICadeira CriarCadeira() => new CadeiraModerna();
        public ISofa CriarSofa() => new SofaModerno();
    }
}
