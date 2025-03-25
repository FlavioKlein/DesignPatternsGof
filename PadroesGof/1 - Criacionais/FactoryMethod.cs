namespace PadroesGof.Criacionais
{
    /// <summary>
    /// Factory Method:
    /// Criação de objetos sem expor a lógica de instância
    /// Permite criar objetos sem especificar suas classes concretas, delegando essa responsabilidade a subclasses.
    /// </summary>
    
    // Produto
    public interface IVeiculo
    {
        void ExibirModelo();
    }

    // Produto Concreto
    public class Carro : IVeiculo
    {
        public void ExibirModelo() => Console.WriteLine("Carro modelo X");
    }

    public class Moto : IVeiculo
    {
        public void ExibirModelo() => Console.WriteLine("Moto modelo Y");
    }

    // Criador Abstrato
    public abstract class CriadorVeiculo
    {
        public abstract IVeiculo CriarVeiculo();
    }

    // Criador Concreto
    public class CriadorCarro : CriadorVeiculo
    {
        public override IVeiculo CriarVeiculo() => new Carro();
    }

    public class CriadorMoto : CriadorVeiculo
    {
        public override IVeiculo CriarVeiculo() => new Moto();
    }
}
