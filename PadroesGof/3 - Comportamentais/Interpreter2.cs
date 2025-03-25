using System;

namespace PadroesGof.Comportamentais
{
    /// <summary>
    /// Interpreter:
    /// 
    /// Exemplo - Interpretador Parser de texto
    /// Uma linguagem de comendos simples.
    /// </summary>    
    /// 

    // Interface para expressões (comandos)
    public interface IExpression
    {
        void Interpretar(Contexto contexto);
    }

    // Classe de contexto que mantém o estado do jogador
    public class Contexto
    {
        public int PosicaoX { get; set; } = 0;
        public int PosicaoY { get; set; } = 0;
        public string Direcao { get; set; } = "NORTE";

        public void ExibirEstado()
        {
            Console.WriteLine($"Posição: ({PosicaoX}, {PosicaoY}), Direção: {Direcao}");
        }
    }

    // Comando para mover o jogador
    public class Mover : IExpression
    {
        private string _direcao;
        private int _distancia;

        public Mover(string direcao, int distancia)
        {
            _direcao = direcao;
            _distancia = distancia;
        }

        public void Interpretar(Contexto contexto)
        {
            switch (_direcao.ToUpper())
            {
                case "FORWARD":
                    if (contexto.Direcao == "NORTE") contexto.PosicaoY += _distancia;
                    if (contexto.Direcao == "SUL") contexto.PosicaoY -= _distancia;
                    if (contexto.Direcao == "LESTE") contexto.PosicaoX += _distancia;
                    if (contexto.Direcao == "OESTE") contexto.PosicaoX -= _distancia;
                    break;
                case "BACKWARD":
                    if (contexto.Direcao == "NORTE") contexto.PosicaoY -= _distancia;
                    if (contexto.Direcao == "SUL") contexto.PosicaoY += _distancia;
                    if (contexto.Direcao == "LESTE") contexto.PosicaoX -= _distancia;
                    if (contexto.Direcao == "OESTE") contexto.PosicaoX += _distancia;
                    break;
            }
        }
    }

    // Comando para girar o jogador
    public class Virar : IExpression
    {
        private string _direcao;

        public Virar(string direcao)
        {
            _direcao = direcao;
        }

        public void Interpretar(Contexto contexto)
        {
            string[] direcoes = { "NORTE", "LESTE", "SUL", "OESTE" };
            int indice = Array.IndexOf(direcoes, contexto.Direcao);

            if (_direcao.ToUpper() == "LEFT")
                contexto.Direcao = direcoes[(indice + 3) % 4]; // Gira 90° para a esquerda
            else if (_direcao.ToUpper() == "RIGHT")
                contexto.Direcao = direcoes[(indice + 1) % 4]; // Gira 90° para a direita
        }
    }

    // Classe que interpreta uma sequência de comandos
    public class InterpretadorDeComandos
    {
        public static List<IExpression> AnalisarComandos(string[] comandos)
        {
            List<IExpression> listaComandos = new List<IExpression>();

            foreach (var comando in comandos)
            {
                string[] partes = comando.Split(' ');

                if (partes[0].ToUpper() == "MOVE" && partes.Length == 3)
                {
                    listaComandos.Add(new Mover(partes[1], int.Parse(partes[2])));
                }
                else if (partes[0].ToUpper() == "TURN" && partes.Length == 2)
                {
                    listaComandos.Add(new Virar(partes[1]));
                }
            }

            return listaComandos;
        }
    }




}
