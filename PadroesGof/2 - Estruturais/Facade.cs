namespace PadroesGof.Estruturais
{
    /// <summary>
    /// Facade:
    /// Fornece uma interface simplificada para um sistema complexo.
    /// </summary>

    public class CPU { 
        public void Ligar() => Console.WriteLine("CPU Ligada"); 
    }
    public class Memoria { 
        public void Carregar() => Console.WriteLine("Memória Carregada"); 
    }
    public class Disco { 
        public void Ler() => Console.WriteLine("Disco Rígido Lendo Dados"); 
    }

    public class ComputadorFacade
    {
        private CPU cpu = new();
        private Memoria memoria = new();
        private Disco disco = new();

        public void LigarComputador()
        {
            cpu.Ligar();
            memoria.Carregar();
            disco.Ler();
            Console.WriteLine("Computador Pronto para Uso.");
        }
    }
}
