namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Visitor:
    /// O Visitor permite adicionar novas operações a objetos sem modificar suas classes. 
    /// Ele separa o comportamento dos objetos, colocando-o em uma classe externa (o visitante).
    /// Isso é útil quando você precisa executar operações em uma hierarquia de classes sem alterar sua estrutura.
    /// 
    /// Quando usar?
    /// Quando você precisa adicionar novas operações a uma estrutura de objetos complexa, sem modificar suas 
    /// classes existentes.
    /// Quando uma estrutura de objetos é imutável, mas novas funcionalidades precisam ser adicionadas frequentemente.
    /// Quando você deseja separar responsabilidades, evitando que classes tenham múltiplas responsabilidades.
    /// 
    /// Exemplo - Relatórios de Funcionários
    /// Vamos criar um sistema onde temos diferentes tipos de funcionários e queremos gerar relatórios personalizados 
    /// para cada tipo. Com o Visitor, podemos adicionar novos relatórios sem modificar as classes dos funcionários.

    public interface IVisitor
    {
        void Visitar(Coordenador coordenador);
        void Visitar(Desenvolvedor desenvolvedor);
    }

    public interface IElemento
    {
        void Aceitar(IVisitor visitor);
    }

    public class Coordenador : IElemento
    {
        public string Nome { get; set; }
        public int Bonus { get; set; }

        public Coordenador(string nome, int bonus)
        {
            Nome = nome;
            Bonus = bonus;
        }

        public void Aceitar(IVisitor visitor)
        {
            visitor.Visitar(this);
        }
    }

    public class Desenvolvedor : IElemento
    {
        public string Nome { get; set; }
        public string Linguagem { get; set; }

        public Desenvolvedor(string nome, string linguagem)
        {
            Nome = nome;
            Linguagem = linguagem;
        }

        public void Aceitar(IVisitor visitor)
        {
            visitor.Visitar(this);
        }
    }

    public class RelatorioVisitor : IVisitor
    {
        public void Visitar(Coordenador coordenador)
        {
            Console.WriteLine($"Coordenador: {coordenador.Nome}, Bônus: R$ {coordenador.Bonus}");
        }

        public void Visitar(Desenvolvedor desenvolvedor)
        {
            Console.WriteLine($"Desenvolvedor: {desenvolvedor.Nome}, Linguagem: {desenvolvedor.Linguagem}");
        }
    }



}

