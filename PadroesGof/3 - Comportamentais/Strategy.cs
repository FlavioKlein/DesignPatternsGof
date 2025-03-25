using System.Runtime.Intrinsics.X86;
using System;

namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Strategy:
    /// O padrão Strategy define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis. 
    /// Ele permite que o algoritmo varie independentemente dos clientes que o utilizam.
    /// Em vez de implementar vários algoritmos dentro de uma mesma classe usando estruturas if/else ou switch, 
    /// você pode criar diferentes classes para cada estratégia e permitir que o objeto cliente selecione qual deseja 
    /// usar dinamicamente.
    /// 
    /// Quando usar?
    /// Quando você precisa de diferentes variações de um algoritmo e deseja alterná-las sem modificar o código do cliente.
    /// Quando há muitos if/else ou switch/case para decidir qual comportamento executar.
    /// Quando você deseja tornar um sistema mais extensível, permitindo adicionar novas estratégias sem modificar 
    /// código existente.
    /// 
    /// Exemplo - Calculadora com Estratégia
    /// Vamos criar um exemplo de calculadora, onde podemos escolher diferentes estratégias para operações matemáticas.

    public interface IEstrategia
    {
        double Calcular(double a, double b);
    }

    public class Somar : IEstrategia
    {
        public double Calcular(double a, double b)
        {
            return a + b;
        }
    }

    public class Subtrair : IEstrategia
    {
        public double Calcular(double a, double b)
        {
            return a - b;
        }
    }

    public class Multiplicar : IEstrategia
    {
        public double Calcular(double a, double b)
        {
            return a * b;
        }
    }

    public class Dividir : IEstrategia
    {
        public double Calcular(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Divisão por zero não permitida.");
            }
            return a / b;
        }
    }

    public class Calculadora
    {
        private IEstrategia _estrategia;

        public void DefinirEstrategia(IEstrategia estrategia)
        {
            _estrategia = estrategia;
        }

        public double ExecutarCalculo(double a, double b)
        {
            if (_estrategia == null)
            {
                throw new InvalidOperationException("Nenhuma estratégia definida.");
            }
            return _estrategia.Calcular(a, b);
        }
    }
}

