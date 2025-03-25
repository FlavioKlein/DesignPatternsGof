namespace PadroesGof.Estruturais
{
    /// <summary>
    /// ChainOfResponsability:
    /// Permite que uma solicitação percorra uma cadeia de manipuladores até que um deles a processe.
    /// Quando usar?
    /// Quando há várias classes que podem processar uma solicitação, mas não sabemos qual será responsável.
    /// Para evitar grandes estruturas de if-else ou switch-case.    
    /// 
    /// Exemplo - Sistema de Suporte
    /// Um sistema de suporte onde pedidos podem ser processados por atendentes, supervisores ou gerentes, 
    /// dependendo da gravidade do problema.
    /// </summary>    

    // Classe base para os manipuladores
    public abstract class Suporte
    {
        protected Suporte _proximo;

        public void DefinirProximo(Suporte proximo)
        {
            _proximo = proximo;
        }

        public abstract void ManipularPedido(int nivel);
    }

    // Manipulador específico (Atendente)
    public class Atendente : Suporte
    {
        public override void ManipularPedido(int nivel)
        {
            if (nivel <= 1)
                Console.WriteLine("Atendente resolveu o problema.");
            else if (_proximo != null)
                _proximo.ManipularPedido(nivel);
        }
    }

    // Manipulador específico (Supervisor)
    public class Supervisor : Suporte
    {
        public override void ManipularPedido(int nivel)
        {
            if (nivel <= 2)
                Console.WriteLine("Supervisor resolveu o problema.");
            else if (_proximo != null)
                _proximo.ManipularPedido(nivel);
        }
    }

    // Manipulador específico (Gerente)
    public class Gerente : Suporte
    {
        public override void ManipularPedido(int nivel)
        {
            Console.WriteLine("Gerente resolveu o problema.");
        }
    }
}
