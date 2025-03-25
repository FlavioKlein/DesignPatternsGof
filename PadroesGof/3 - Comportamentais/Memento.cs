using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System;

namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Memento:
    /// O padrão Memento permite salvar o estado de um objeto em um dado momento, de forma que ele possa ser 
    /// restaurado posteriormente.
    /// Ele oferece uma maneira de capturar e externalizar o estado interno de um objeto sem expor sua implementação.
    /// O Memento é útil quando precisamos fornecer uma funcionalidade de desfazer (undo) ou restaurar o estado.
    /// Quando usar?
    /// Quando precisamos implementar uma funcionalidade de desfazer ou restaurar o estado de um objeto.
    /// Quando o estado de um objeto precisa ser salvo e restaurado em um momento posterior sem expor a estrutura 
    /// interna do objeto.
    /// Quando queremos permitir a reversão de mudanças em um objeto sem quebrar o encapsulamento.
    /// Exemplo - Editor de Texto com Desfazer
    /// Vamos criar um exemplo de editor de texto onde podemos adicionar texto e, se necessário, desfazer a adição.
    /// Usaremos o padrão Memento para salvar e restaurar o estado do texto.


    public class EditorTexto
    {
        public string Texto { get; set; }

        public EditorTexto(string texto)
        {
            Texto = texto;
        }

        // Cria um memento com o estado atual
        public Memento CriarMemento()
        {
            return new Memento(Texto);
        }

        // Restaura o estado a partir do memento
        public void RestaurarMemento(Memento memento)
        {
            Texto = memento.Texto;
        }

        public override string ToString()
        {
            return Texto;
        }
    }

    public class Memento
    {
        public string Texto { get; private set; }

        public Memento(string texto)
        {
            Texto = texto;
        }
    }

    public class Cuidadores
    {
        private List<Memento> _mementos = new List<Memento>();

        // Adiciona um memento
        public void SalvarMemento(Memento memento)
        {
            _mementos.Add(memento);
        }

        // Recupera um memento
        public Memento RecuperarMemento(int indice)
        {
            if (indice >= 0 && indice < _mementos.Count)
            {
                return _mementos[indice];
            }
            return null;
        }
    }
}
