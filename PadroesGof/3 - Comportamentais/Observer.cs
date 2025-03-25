namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Observer:
    /// O padrão Observer define uma dependência um-para-muitos entre objetos. Ou seja, quando o estado de um objeto 
    /// (sujeito) muda, todos os seus observadores são notificados automaticamente. Este padrão é muito usado para 
    /// implementar sistemas de notificação ou eventos.
    /// Ele permite que os objetos sejam desacoplados, pois o sujeito não sabe nada sobre os observadores além de 
    /// que existem.
    /// Assim, você pode adicionar ou remover observadores sem alterar a estrutura do sujeito.
    /// 
    /// Quando usar?
    /// Quando um objeto precisa notificar outros objetos sobre mudanças no seu estado.
    /// Quando você deseja que múltiplos objetos recebam atualizações de um único objeto, sem que haja acoplamento forte 
    /// entre eles.
    /// Em sistemas de eventos ou notificações, onde várias partes do sistema precisam reagir a mudanças.
    /// 
    /// Exemplo - Sistema de Notificação de Eventos
    /// Imagine que estamos criando um sistema de notificação de eventos, onde o sujeito pode ser um evento e os 
    /// observadores são os inscritos para serem notificados quando o evento ocorrer.


    public interface IObserver
    {
        void Atualizar(string mensagem);
    }

    public interface ISujeito
    {
        void AdicionarObservador(IObserver observador);
        void RemoverObservador(IObserver observador);
        void NotificarObservadores();
    }

    public class Evento : ISujeito
    {
        private List<IObserver> _observadores = new List<IObserver>();
        public string Nome { get; set; }

        public Evento(string nome)
        {
            Nome = nome;
        }

        // Adiciona um observador à lista
        public void AdicionarObservador(IObserver observador)
        {
            _observadores.Add(observador);
        }

        // Remove um observador da lista
        public void RemoverObservador(IObserver observador)
        {
            _observadores.Remove(observador);
        }

        // Notifica todos os observadores
        public void NotificarObservadores()
        {
            foreach (var observador in _observadores)
            {
                observador.Atualizar($"O evento '{Nome}' ocorreu!");
            }
        }

        // Método para simular o evento acontecendo
        public void OcorrerEvento()
        {
            Console.WriteLine($"O evento '{Nome}' está acontecendo!");
            NotificarObservadores();
        }
    }

    public class Pessoa : IObserver
    {
        public string Nome { get; set; }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        // Método chamado quando o evento é notificado
        public void Atualizar(string mensagem)
        {
            Console.WriteLine($"{Nome} recebeu a notificação: {mensagem}");
        }
    }
}
