namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// TemplateMethod:
    /// O Template Method define a estrutura de um algoritmo dentro de um método da classe base, mas permite que algumas 
    /// etapas do algoritmo sejam implementadas nas subclasses.
    /// Isso significa que o esqueleto do algoritmo é fixo, mas detalhes específicos podem ser sobrescritos pelas classes
    /// filhas.
    /// 
    /// Quando usar?
    /// Quando você deseja definir o fluxo geral de um algoritmo, mas permitir que algumas partes sejam personalizadas 
    /// por subclasses.
    /// Quando várias classes compartilham uma estrutura semelhante de algoritmo, mas cada uma precisa de implementações 
    /// específicas para algumas etapas.
    /// Para evitar duplicação de código, extraindo o código comum para a classe base e permitindo a personalização 
    /// apenas quando necessário.
    /// 
    /// Exemplo - Preparação de Bebidas
    /// Vamos criar um exemplo onde temos um processo padrão para preparar bebidas (chá e café), mas com algumas variações 
    /// em cada tipo de bebida.


    public abstract class BebidaQuente
    {
        // Método Template - Define o algoritmo
        public void PrepararBebida()
        {
            FerverAgua();
            AdicionarIngrediente();
            ServirNoCopo();
            AdicionarExtras();
        }

        private void FerverAgua()
        {
            Console.WriteLine("Fervendo a água...");
        }

        protected abstract void AdicionarIngrediente(); // Cada bebida tem seu ingrediente

        private void ServirNoCopo()
        {
            Console.WriteLine("Servindo no copo...");
        }

        protected virtual void AdicionarExtras()
        {
            // Opcional - Subclasses podem sobrescrever este método
        }
    }

    public class Cafe : BebidaQuente
    {
        protected override void AdicionarIngrediente()
        {
            Console.WriteLine("Adicionando pó de café...");
        }

        protected override void AdicionarExtras()
        {
            Console.WriteLine("Adicionando açúcar e leite...");
        }
    }

    public class Cha : BebidaQuente
    {
        protected override void AdicionarIngrediente()
        {
            Console.WriteLine("Adicionando folhas de chá...");
        }

        // Não sobrescrevemos `AdicionarExtras()`, pois o chá não precisa de extras.
    }
}

