using System;

namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Interpreter:
    /// O Interpreter define uma forma de interpretar sentenças de uma linguagem específica, 
    /// criando uma gramática e um analisador.
    /// Cada símbolo ou regra da linguagem é representado por uma classe que interpreta a expressão.
    /// 
    /// Quando usar?
    /// Quando há uma linguagem própria no sistema e precisamos interpretá-la.
    /// Para avaliar expressões matemáticas, linguagens de configuração ou comandos personalizados.
    /// Quando a estrutura gramatical é bem definida e não muda com frequência.
    /// 
    /// Exemplo - Interpretador Matemático Simples
    /// Vamos criar um interpretador que resolve expressões matemáticas simples como 5 + 3 - 2.
    /// </summary>    
    /// 

    // Interface para expressões
    public interface IExpressao
    {
        int Interpretar();
    }

    // Expressão para números (terminais)
    public class Numero : IExpressao
    {
        private int _valor;

        public Numero(int valor)
        {
            _valor = valor;
        }

        public int Interpretar()
        {
            return _valor;
        }
    }

    // Expressão para adição
    public class Adicao : IExpressao
    {
        private IExpressao _esquerda, _direita;

        public Adicao(IExpressao esquerda, IExpressao direita)
        {
            _esquerda = esquerda;
            _direita = direita;
        }

        public int Interpretar()
        {
            return _esquerda.Interpretar() + _direita.Interpretar();
        }
    }

    // Expressão para subtração
    public class Subtracao : IExpressao
    {
        private IExpressao _esquerda, _direita;

        public Subtracao(IExpressao esquerda, IExpressao direita)
        {
            _esquerda = esquerda;
            _direita = direita;
        }

        public int Interpretar()
        {
            return _esquerda.Interpretar() - _direita.Interpretar();
        }
    }
}
