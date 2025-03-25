namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Mediator:
    /// O padrão Mediator define um objeto que encapsula a comunicação entre componentes. 
    /// Ele atua como um intermediário para evitar que as partes do sistema se comuniquem diretamente, 
    /// o que pode levar a um código fortemente acoplado.
    /// Com o Mediator, as classes interagem indiretamente por meio de um único ponto de comunicação.
    /// Isso facilita a manutenção, pois qualquer mudança na comunicação entre os objetos pode ser feita no mediador.
    /// 
    /// Quando usar?
    /// Quando vários objetos interagem entre si de maneira complexa e você quer reduzir o acoplamento entre eles.
    /// Para centralizar a comunicação entre objetos, tornando o sistema mais modular e flexível.
    /// Quando há muitas dependências entre objetos e você quer evitar a criação de relações complexas.
    /// 
    /// Exemplo - Chat com Mediador
    /// Imagine que temos um sistema de chat, onde diferentes usuários se comunicam.O mediador será responsável 
    /// por gerenciar a comunicação entre eles, evitando que os usuários se comuniquem diretamente.

    public interface IMediador
    {
        void EnviarMensagem(string mensagem, Usuario usuario);
    }

    public class Usuario
    {
        public string Nome { get; set; }
        private IMediador _mediador;

        public Usuario(string nome, IMediador mediador)
        {
            Nome = nome;
            _mediador = mediador;
        }

        public void EnviarMensagem(string mensagem)
        {
            Console.WriteLine($"{Nome} está enviando: {mensagem}");
            _mediador.EnviarMensagem(mensagem, this);
        }

        public void ReceberMensagem(string mensagem)
        {
            Console.WriteLine($"{Nome} recebeu a mensagem: {mensagem}");
        }
    }

    public class ChatMediator : IMediador
    {
        private List<Usuario> _usuarios;

        public ChatMediator()
        {
            _usuarios = new List<Usuario>();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public void EnviarMensagem(string mensagem, Usuario usuario)
        {
            // O mediador se certifica de que todos os outros usuários recebam a mensagem
            foreach (var u in _usuarios)
            {
                if (u != usuario)
                {
                    u.ReceberMensagem(mensagem);
                }
            }
        }
    }
}
