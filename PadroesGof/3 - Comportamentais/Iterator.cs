using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System;

namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Iterator:
    /// O padrão Iterator fornece uma maneira de acessar os elementos de uma coleção sequencialmente sem 
    /// expor sua estrutura interna.
    /// Ele permite percorrer coleções de forma uniforme, sem precisar se preocupar com os detalhes de 
    /// implementação da coleção.
    /// 
    /// Quando usar?
    /// Quando queremos fornecer uma maneira consistente de percorrer elementos em diferentes tipos 
    /// de coleções(listas, conjuntos, etc.).
    /// Quando desejamos acessar os elementos de uma coleção sem expor a estrutura interna.
    /// Quando desejamos facilitar a navegação por diferentes tipos de objetos.
    /// 
    /// Exemplo - Iterando sobre uma Lista de Tarefas
    /// Vamos criar um exemplo de uma lista de tarefas onde podemos iterar sobre elas e exibir suas descrições.

    public class Tarefa
    {
        public string Descricao { get; set; }
        public bool Concluida { get; set; }

        public Tarefa(string descricao, bool concluida)
        {
            Descricao = descricao;
            Concluida = concluida;
        }
    }

    public class IteradorTarefa
    {
        private List<Tarefa> _tarefas;
        private int _indice = 0;

        public IteradorTarefa(List<Tarefa> tarefas)
        {
            _tarefas = tarefas;
        }

        // Retorna o item atual
        public Tarefa Current => _tarefas[_indice];

        // Move para o próximo item
        public bool Next()
        {
            if (_indice < _tarefas.Count - 1)
            {
                _indice++;
                return true;
            }
            return false;
        }

        // Move para o item anterior
        public bool Previous()
        {
            if (_indice > 0)
            {
                _indice--;
                return true;
            }
            return false;
        }

        // Verifica se há mais elementos
        public bool HasNext() => _indice < _tarefas.Count - 1;

        // Verifica se há elementos anteriores
        public bool HasPrevious() => _indice > 0;
    }

    public class ListaTarefas
    {
        private List<Tarefa> _tarefas = new List<Tarefa>();

        public void AdicionarTarefa(Tarefa tarefa)
        {
            _tarefas.Add(tarefa);
        }

        // Retorna o iterador para a lista de tarefas
        public IteradorTarefa GetIterator()
        {
            return new IteradorTarefa(_tarefas);
        }
    }
}
