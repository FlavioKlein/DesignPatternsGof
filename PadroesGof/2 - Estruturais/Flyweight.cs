using System;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;

namespace PadroesGof.Estruturais
{
    /// <summary>
    /// Flyweight:
    /// O padrão Flyweight economiza memória ao compartilhar objetos comuns em vez de criar novas instâncias.
    /// Quando usar?
    /// Quando há muitos objetos semelhantes no sistema, e cada um consome muita memória.
    /// Quando se pode compartilhar objetos sem alterar seu estado essencial.
    /// Exemplo - Compartilhamento de caracteres
    /// Imagine um editor de texto que precisa renderizar milhares de caracteres.
    /// Criar uma nova instância de "A" para cada ocorrência consome muita memória.
    /// Com Flyweight, armazenamos apenas uma instância por caractere, reutilizando-a sempre que necessário.
    /// </summary>


    // Flyweight (objeto compartilhado)
    public class Caractere
    {
        private char _simbolo;

        public Caractere(char simbolo)
        {
            _simbolo = simbolo;
        }

        public void Exibir()
        {
            Console.WriteLine($"Caractere: {_simbolo}");
        }
    }

    // Fábrica Flyweight (cria e gerencia caracteres)
    public class FabricaCaractere
    {
        private Dictionary<char, Caractere> _caracteres = new();

        public Caractere ObterCaractere(char simbolo)
        {
            if (!_caracteres.ContainsKey(simbolo))
            {
                _caracteres[simbolo] = new Caractere(simbolo);
            }
            return _caracteres[simbolo];
        }
    }
}
