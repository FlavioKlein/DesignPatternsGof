namespace PadroesGof.Criacionais
{
    /// <summary>
    /// Builder:
    /// Permite construir objetos complexos passo a passo.   
    /// </summary>

    
    // Produto
    public class Veiculo
    {
        public string Modelo { get; set; }
        public string Motor { get; set; }
        public int Rodas { get; set; }
        public void Exibir() => Console.WriteLine($"{Modelo} com motor {Motor} e {Rodas} rodas.");
    }

    // Builder abstrato
    public interface IVeiculoBuilder
    {
        void DefinirModelo(string modelo);
        void DefinirMotor(string motor);
        void DefinirRodas(int rodas);
        Veiculo ObterVeiculo();
    }

    // Builder concreto
    public class VeiculoBuilder : IVeiculoBuilder
    {
        private Veiculo _veiculo = new();

        public void DefinirModelo(string modelo) => _veiculo.Modelo = modelo;
        public void DefinirMotor(string motor) => _veiculo.Motor = motor;
        public void DefinirRodas(int rodas) => _veiculo.Rodas = rodas;
        public Veiculo ObterVeiculo() => _veiculo;
    }

    // Diretor
    public class Diretor
    {
        public Veiculo ConstruirCarro(IVeiculoBuilder builder)
        {
            builder.DefinirModelo("Carro");
            builder.DefinirMotor("V8");
            builder.DefinirRodas(4);
            return builder.ObterVeiculo();
        }

        public Veiculo ConstruirMoto(IVeiculoBuilder builder)
        {
            builder.DefinirModelo("Moto");
            builder.DefinirMotor("350cc");
            builder.DefinirRodas(2);
            return builder.ObterVeiculo();
        }
    }    
}
