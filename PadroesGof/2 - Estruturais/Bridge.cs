namespace PadroesGof.Estruturais
{
    /// <summary>
    /// Bridge:
    /// Separa uma abstração de sua implementação, permitindo que ambas possam ser desenvolvidas de forma independente.
    /// </summary>

    // Implementação (interface)
    public interface IDispositivo
    {
        void Ligar();
        void Desligar();
    }

    // Implementação concreta
    public class Televisao : IDispositivo
    {
        public void Ligar() => Console.WriteLine("TV ligada.");
        public void Desligar() => Console.WriteLine("TV desligada.");
    }

    // Abstração
    public class ControleRemoto
    {
        protected IDispositivo dispositivo;

        public ControleRemoto(IDispositivo disp) => dispositivo = disp;

        public void Ligar() => dispositivo.Ligar();
        public void Desligar() => dispositivo.Desligar();
    }    
}
