namespace PadroesGof.Criacionais
{
    /// <summary>
    /// Prototype:
    /// Permite copiar objetos existentes sem depender de suas classes concretas.
    /// </summary>

    // Interface Prototype
    public interface ICloneable
    {
        ICloneable Clonar();
    }

    // Classe concreta que implementa o Prototype
    public class Pessoa : ICloneable
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public ICloneable Clonar() => (Pessoa)this.MemberwiseClone();
    }    
}
