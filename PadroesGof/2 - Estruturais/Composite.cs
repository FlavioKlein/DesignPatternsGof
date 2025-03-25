namespace PadroesGof.Estruturais
{
    /// <summary>
    /// Composite:
    /// Permite tratar objetos individuais e grupos de objetos da mesma forma.
    /// </summary>

    // Componente
    public abstract class Componente
    {
        protected string Nome;
        public Componente(string nome) => Nome = nome;
        public abstract void Exibir();
    }

    // Folha
    public class Arquivo : Componente
    {
        public Arquivo(string nome) : base(nome) { }
        public override void Exibir() => Console.WriteLine($"Arquivo: {Nome}");
    }

    // Composite (Grupo de componentes)
    public class Pasta : Componente
    {
        private List<Componente> _componentes = new();

        public Pasta(string nome) : base(nome) { }

        public void Adicionar(Componente componente) => _componentes.Add(componente);

        public override void Exibir()
        {
            Console.WriteLine($"Pasta: {Nome}");
            foreach (var item in _componentes)
            {
                item.Exibir();
            }
        }
    }
}
