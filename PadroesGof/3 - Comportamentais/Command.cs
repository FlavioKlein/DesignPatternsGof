namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Command:
    /// O padrão Command encapsula uma solicitação como um objeto, permitindo que possamos:
    /// Registrar comandos para serem executados posteriormente.
    /// Implementar desfazer/refazer operações.
    /// Criar filas de comandos para execução assíncrona.
    /// 
    /// Quando usar?
    /// Quando queremos desacoplar quem solicita uma ação de quem a executa.
    /// Para permitir que comandos sejam registrados, desfeitos e refeitos.
    /// Para criar filas de operações ou implementar macros (sequências de comandos).
    /// 
    /// Exemplo - Controle Remoto com "Desfazer"
    /// Um controle remoto onde cada botão representa um comando encapsulado.
    /// Podemos executar ou desfazer ações como ligar/desligar a TV.
    /// </summary>    
    /// 

    // Interface para todos os comandos
    public interface IComando
    {
        void Executar();
        void Desfazer();
    }

    // Receptor (TV) - O objeto real que executa ações
    public class TV
    {
        public void Ligar()
        {
            Console.WriteLine("TV Ligada.");
        }

        public void Desligar()
        {
            Console.WriteLine("TV Desligada.");
        }
    }

    // Comando concreto para ligar a TV
    public class ComandoLigarTV : IComando
    {
        private TV _tv;

        public ComandoLigarTV(TV tv)
        {
            _tv = tv;
        }

        public void Executar()
        {
            _tv.Ligar();
        }

        public void Desfazer()
        {
            _tv.Desligar();
        }
    }

    // Comando concreto para desligar a TV
    public class ComandoDesligarTV : IComando
    {
        private TV _tv;

        public ComandoDesligarTV(TV tv)
        {
            _tv = tv;
        }

        public void Executar()
        {
            _tv.Desligar();
        }

        public void Desfazer()
        {
            _tv.Ligar();
        }
    }

    // Invocador (Controle Remoto)
    public class CtrlRemoto
    {
        private IComando _ultimoComando;

        public void DefinirComando(IComando comando)
        {
            _ultimoComando = comando;
        }

        public void PressionarBotao()
        {
            _ultimoComando.Executar();
        }

        public void PressionarDesfazer()
        {
            _ultimoComando.Desfazer();
        }
    }
}
