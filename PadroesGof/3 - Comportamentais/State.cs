namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// State:
    /// O padrão State permite que um objeto altere seu comportamento quando seu estado interno muda. 
    /// Em outras palavras, ele permite que um objeto pareça alterar sua classe. Esse padrão é útil quando um 
    /// objeto pode ter vários comportamentos diferentes dependendo do seu estado e você deseja evitar grandes 
    /// estruturas de if ou switch.
    /// Ele encapsula os diferentes estados dentro de objetos de estado e permite que o contexto(objeto principal) 
    /// altere seu estado de forma transparente, delegando o comportamento ao estado atual.
    /// 
    /// Quando usar?
    /// Quando um objeto precisa alterar seu comportamento dependendo do seu estado atual, e você não quer usar 
    /// estruturas condicionais(como if ou switch).
    /// Quando o estado de um objeto muda frequentemente, e você deseja encapsular os comportamentos relacionados ao estado.
    /// Quando você precisa evitar o acoplamento entre o contexto e os estados de forma a facilitar a manutenção do código.
    /// 
    /// Exemplo - Máquina de Venda com Estados
    /// Vamos imaginar uma máquina de vendas (como uma máquina de refrigerantes) que pode ter vários estados.
    /// A máquina pode estar em um estado de espera(aguardando uma moeda), vendendo(quando o item é escolhido) ou 
    /// sem estoque(quando o produto não está disponível).

    public interface IEstado
    {
        void InserirMoeda(MaquinaVendas maquina);
        void EscolherProduto(MaquinaVendas maquina);
        void EntregarProduto(MaquinaVendas maquina);
    }

    public class EstadoEsperandoMoeda : IEstado
    {
        public void InserirMoeda(MaquinaVendas maquina)
        {
            Console.WriteLine("Moeda inserida.");
            maquina.EstadoAtual = new EstadoEscolhendoProduto();
        }

        public void EscolherProduto(MaquinaVendas maquina)
        {
            Console.WriteLine("Primeiro, insira uma moeda.");
        }

        public void EntregarProduto(MaquinaVendas maquina)
        {
            Console.WriteLine("Primeiro, insira uma moeda.");
        }
    }
    public class EstadoEscolhendoProduto : IEstado
    {
        public void InserirMoeda(MaquinaVendas maquina)
        {
            Console.WriteLine("Moeda já inserida. Escolha o produto.");
        }

        public void EscolherProduto(MaquinaVendas maquina)
        {
            Console.WriteLine("Produto escolhido.");
            maquina.EstadoAtual = new EstadoEntregandoProduto();
        }

        public void EntregarProduto(MaquinaVendas maquina)
        {
            Console.WriteLine("Escolha o produto primeiro.");
        }
    }

    public class EstadoEntregandoProduto : IEstado
    {
        public void InserirMoeda(MaquinaVendas maquina)
        {
            Console.WriteLine("Produto entregue. Aguarde.");
        }

        public void EscolherProduto(MaquinaVendas maquina)
        {
            Console.WriteLine("Produto já entregue.");
        }

        public void EntregarProduto(MaquinaVendas maquina)
        {
            Console.WriteLine("Produto sendo entregue.");
            maquina.EstadoAtual = new EstadoEsperandoMoeda();
        }
    }

    public class MaquinaVendas
    {
        public IEstado EstadoAtual { get; set; }

        public MaquinaVendas()
        {
            EstadoAtual = new EstadoEsperandoMoeda();  // Inicializa com o estado inicial
        }

        public void InserirMoeda()
        {
            EstadoAtual.InserirMoeda(this);
        }

        public void EscolherProduto()
        {
            EstadoAtual.EscolherProduto(this);
        }

        public void EntregarProduto()
        {
            EstadoAtual.EntregarProduto(this);
        }
    }

}

