namespace PadroesGof.Estruturais
{
    /// <summary>
    /// Decorator:
    /// Adiciona funcionalidades extras a objetos dinamicamente, sem alterar suas classes.
    /// </summary>

    // Componente base
    public interface ICafe
    {
        string Descricao();
        double Custo();
    }

    // Componente concreto
    public class CafeSimples : ICafe
    {
        public string Descricao() => "Café simples";
        public double Custo() => 5.0;
    }

    // Decorador abstrato
    public abstract class CafeDecorator : ICafe
    {
        protected ICafe _cafe;
        public CafeDecorator(ICafe cafe) => _cafe = cafe;
        public virtual string Descricao() => _cafe.Descricao();
        public virtual double Custo() => _cafe.Custo();
    }

    // Decorador concreto
    public class CafeComLeite : CafeDecorator
    {
        public CafeComLeite(ICafe cafe) : base(cafe) { }
        public override string Descricao() => _cafe.Descricao() + ", com Leite";
        public override double Custo() => _cafe.Custo() + 2.0;
    }

    public class CafeComMel : CafeDecorator
    {
        public CafeComMel(ICafe cafe) : base(cafe) { }
        public override string Descricao() => _cafe.Descricao() + ", com Mel";
        public override double Custo() => _cafe.Custo() + 3.0;
    }
}
