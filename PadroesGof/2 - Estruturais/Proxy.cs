using System;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;

namespace PadroesGof.Estruturais
{
    /// <summary>
    /// Proxy:
    /// O padrão Proxy atua como um intermediário para controlar o acesso a um objeto real.
    /// 
    /// Tipos de Proxy
    /// Virtual Proxy → Carrega objetos apenas quando necessário(lazy loading).
    /// Remote Proxy → Controla o acesso a objetos remotos(ex: banco de dados, API).
    /// Protection Proxy → Restringe acesso baseado em permissões.
    /// 
    /// Exemplo - Proxy Virtual (Carregamento sob demanda)
    /// Imagine um sistema que carrega imagens.Para otimizar o desempenho, 
    /// usamos um proxy para carregar a imagem apenas quando necessário.
    /// </summary>

    // Interface comum
    public interface IImagem
    {
        void Exibir();
    }

    // Objeto real (Imagem grande)
    public class ImagemReal : IImagem
    {
        private string _caminhoArquivo;

        public ImagemReal(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
            CarregarDoDisco();
        }

        private void CarregarDoDisco()
        {
            Console.WriteLine($"Carregando imagem do disco: {_caminhoArquivo}");
        }

        public void Exibir()
        {
            Console.WriteLine($"Exibindo imagem: {_caminhoArquivo}");
        }
    }

    // Proxy (Atrasando o carregamento da imagem)
    public class ProxyImagem : IImagem
    {
        private ImagemReal _imagemReal;
        private string _caminhoArquivo;

        public ProxyImagem(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }

        public void Exibir()
        {
            if (_imagemReal == null)
            {
                _imagemReal = new ImagemReal(_caminhoArquivo); // Carregamento sob demanda
            }
            _imagemReal.Exibir();
        }
    }
}
