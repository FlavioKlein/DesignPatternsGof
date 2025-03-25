namespace PadroesGof.Criacionais
{
    /// <summary>
    /// Singleton:
    /// Uma única instância global
    /// O Singleton garante que uma classe tenha apenas uma instância e fornece um ponto global de acesso a ela.
    /// </summary>
    public class Singleton
    {
        private static Singleton _instancia;

        private Singleton() { } // Construtor privado impede instanciação externa

        public static Singleton Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Singleton();
                }
                return _instancia;
            }
        }

        public void ExibirMensagem() => Console.WriteLine("Singleton ativo!");
    }
}
