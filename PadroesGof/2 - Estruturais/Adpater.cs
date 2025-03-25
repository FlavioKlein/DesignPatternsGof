namespace PadroesGof.Estruturais
{
    /// <summary>
    /// Adapter:
    /// Permite que duas interfaces incompatíveis trabalhem juntas, funcionando como um conversor.
    /// </summary>
    
    // Classe existente (Incompatível)
    public class TomadaAntiga
    {
        public void ConectarTomada110V() => Console.WriteLine("Tomada 110V conectada.");
    }

    // Interface esperada
    public interface ITomada220V
    {
        void ConectarTomada220V();
    }

    // Adaptador
    public class AdaptadorTomada : ITomada220V
    {
        private readonly TomadaAntiga _tomadaAntiga;

        public AdaptadorTomada(TomadaAntiga tomadaAntiga) => _tomadaAntiga = tomadaAntiga;

        public void ConectarTomada220V() => _tomadaAntiga.ConectarTomada110V();
    }   
}
