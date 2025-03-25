using PadroesGof.Comportamentais;
using PadroesGof.Criacionais;
using PadroesGof.Estruturais;

namespace ConsoleApp1
{
    /// <summary>
    /// Padrões de projeto (Design Patterns) são soluções reutilizáveis para problemas 
    /// comuns no desenvolvimento de software. Eles não são código pronto, 
    /// mas sim modelos que ajudam a criar sistemas mais organizados, flexíveis e manuteníveis.
    /// Os padrões de projeto foram popularizados pelo livro 
    /// Design Patterns: Elements of Reusable Object-Oriented Software, 
    /// escrito pelo Gang of Four(GoF), composto por Erich Gamma, Richard Helm, 
    /// Ralph Johnson e John Vlissides.
    /// 
    /// Os padrões são divididos em três categorias principais:
    /// Padrões Criacionais – Definem formas flexíveis de criar objetos, evitando a criação direta por new.
    /// Padrões Estruturais – Ajudam a estruturar classes e objetos para formar sistemas robustos.
    /// Padrões Comportamentais – Definem a comunicação e interação entre objetos.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Padrões Criacionais
            Console.WriteLine("Padrões Criacionais");
            Console.WriteLine("-------------------");

            #region Singleton
            Console.WriteLine("Singleton");

            Singleton instancia1 = Singleton.Instancia;
            Singleton instancia2 = Singleton.Instancia;

            instancia1.ExibirMensagem();

            Console.WriteLine(instancia1 == instancia2); // True
            Console.WriteLine("***");
            #endregion

            #region Factory Method
            Console.WriteLine("Factory Method");

            CriadorVeiculo criador1 = new CriadorCarro();
            CriadorVeiculo criador2 = new CriadorMoto();

            IVeiculo veiculo1 = criador1.CriarVeiculo();
            veiculo1.ExibirModelo();

            IVeiculo veiculo2 = criador2.CriarVeiculo();
            veiculo2.ExibirModelo();
            Console.WriteLine("***");
            #endregion

            #region Abstract Factory
            Console.WriteLine("Abstract Factory");

            IFabricaMoveis fabrica = new FabricaModerna();
            ICadeira cadeira = fabrica.CriarCadeira();
            ISofa sofa = fabrica.CriarSofa();

            cadeira.Sentar();
            sofa.Deitar();
            Console.WriteLine("***");
            #endregion

            #region Builder
            Console.WriteLine("Builder");

            Diretor diretor = new();
            IVeiculoBuilder builder = new VeiculoBuilder();

            Veiculo carro = diretor.ConstruirCarro(builder);
            carro.Exibir(); // Saída: Carro com motor V8 e 4 rodas.

            Veiculo moto = diretor.ConstruirMoto(builder);
            moto.Exibir(); // Saída: Moto com motor 350cc e 2 rodas.
            Console.WriteLine("***");
            #endregion

            #region Prototype
            Console.WriteLine("Prototype");

            PadroesGof.Criacionais.Pessoa pessoa1 = new() { Nome = "Flávio Klein", Cpf = "123.456.789-10" };
            PadroesGof.Criacionais.Pessoa pessoa2 = (PadroesGof.Criacionais.Pessoa)pessoa1.Clonar();

            Console.WriteLine($"Nome: {pessoa1.Nome} CPF: {pessoa1.Cpf}");
            Console.WriteLine($"Nome: {pessoa2.Nome} CPF: {pessoa2.Cpf}");
            Console.WriteLine("***");
            #endregion

            Console.WriteLine("");
            #endregion

            #region Padrões Estruturais
            Console.WriteLine("Padrões Estruturais");
            Console.WriteLine("-------------------");

            #region Adapter
            Console.WriteLine("Adapter");

            ITomada220V tomada = new AdaptadorTomada(new TomadaAntiga());
            tomada.ConectarTomada220V(); // Chama o método da tomada antiga através do adaptador

            Console.WriteLine("***");
            #endregion

            #region Bridge
            Console.WriteLine("Bridge");

            IDispositivo tv = new Televisao();
            ControleRemoto controle = new(tv);
            controle.Ligar();
            controle.Desligar();

            Console.WriteLine("***");
            #endregion

            #region Composite
            Console.WriteLine("Composite");

            Pasta raiz = new("Raiz");
            raiz.Adicionar(new Arquivo("Arquivo1.txt"));
            raiz.Adicionar(new Arquivo("Arquivo2.txt"));

            Pasta subPasta = new("SubPasta");
            subPasta.Adicionar(new Arquivo("Arquivo3.txt"));

            raiz.Adicionar(subPasta);
            raiz.Exibir();

            Console.WriteLine("***");
            #endregion

            #region Decorator
            Console.WriteLine("Decorator");

            ICafe cafe = new CafeSimples();
            cafe = new CafeComLeite(cafe);

            Console.WriteLine($"{cafe.Descricao()} custa {cafe.Custo()} reais.");

            cafe = new CafeComMel(cafe);

            Console.WriteLine($"{cafe.Descricao()} custa {cafe.Custo()} reais.");

            Console.WriteLine("***");
            #endregion

            #region Facade
            Console.WriteLine("Facade");

            ComputadorFacade computador = new();
            computador.LigarComputador();

            Console.WriteLine("***");
            #endregion

            #region Flyweight
            Console.WriteLine("Flyweight");

            FabricaCaractere fab = new();

            Caractere c1 = fab.ObterCaractere('A');
            Caractere c2 = fab.ObterCaractere('B');
            Caractere c3 = fab.ObterCaractere('A'); // Reutiliza a instância já criada

            c1.Exibir(); // Caractere: A
            c2.Exibir(); // Caractere: B
            c3.Exibir(); // Caractere: A

            Console.WriteLine(ReferenceEquals(c1, c3)); // True (mesma instância reutilizada)

            Console.WriteLine("***");
            #endregion

            #region Proxy
            Console.WriteLine("Proxy");

            IImagem imagem1 = new ProxyImagem("foto1.png");
            IImagem imagem2 = new ProxyImagem("foto2.png");

            // A imagem ainda não foi carregada do disco
            Console.WriteLine("Exibindo imagem 1...");
            imagem1.Exibir(); // Carrega e exibe

            Console.WriteLine("Exibindo imagem 1 novamente...");
            imagem1.Exibir(); // Apenas exibe (sem recarregar)

            Console.WriteLine("Exibindo imagem 2...");
            imagem2.Exibir(); // Carrega e exibe

            Console.WriteLine("***");
            #endregion

            Console.WriteLine("");
            #endregion

            #region Padrões Comportamentais
            Console.WriteLine("Padrões Comportamentais");
            Console.WriteLine("-------------------");

            #region Chain of Responsibility
            Console.WriteLine("Chain of Responsibility");

            Suporte atendente = new Atendente();
            Suporte supervisor = new Supervisor();
            Suporte gerente = new Gerente();

            atendente.DefinirProximo(supervisor);
            supervisor.DefinirProximo(gerente);

            Console.WriteLine("Pedido de nível 1:");
            atendente.ManipularPedido(1); // Atendente resolve

            Console.WriteLine("\nPedido de nível 2:");
            atendente.ManipularPedido(2); // Supervisor resolve

            Console.WriteLine("\nPedido de nível 3:");
            atendente.ManipularPedido(3); // Gerente resolve

            Console.WriteLine("***");
            #endregion

            #region Command
            Console.WriteLine("Command");

            TV tv1 = new TV();
            IComando ligarTV = new ComandoLigarTV(tv1);
            IComando desligarTV = new ComandoDesligarTV(tv1);

            CtrlRemoto ctrl = new CtrlRemoto();

            Console.WriteLine("Pressionando botão para LIGAR a TV...");
            ctrl.DefinirComando(ligarTV);
            ctrl.PressionarBotao();

            Console.WriteLine("Pressionando botão de DESFAZER...");
            ctrl.PressionarDesfazer();

            Console.WriteLine("Pressionando botão para DESLIGAR a TV...");
            ctrl.DefinirComando(desligarTV);
            ctrl.PressionarBotao();

            Console.WriteLine("***");
            #endregion

            #region Interpreter
            Console.WriteLine("Interpreter");

            // Expressão: (5 + 3) - 2
            IExpressao expressao = new Subtracao(
                new Adicao(new Numero(5), new Numero(3)),
                new Numero(2)
            );

            Console.WriteLine($"Resultado: {expressao.Interpretar()}"); // Saída: 6

            Console.WriteLine("***");
            #endregion

            #region Interpreter Exemplo 2
            Console.WriteLine("Interpreter");

            Contexto contexto = new Contexto();

            string[] comandosTexto =
            {
                "MOVE FORWARD 10",
                "TURN RIGHT",
                "MOVE FORWARD 5",
                "TURN LEFT",
                "MOVE BACKWARD 3"
            };

            List<IExpression> comandos = InterpretadorDeComandos.AnalisarComandos(comandosTexto);

            Console.WriteLine("Executando comandos...");
            foreach (var comando in comandos)
            {
                comando.Interpretar(contexto);
                contexto.ExibirEstado();
            }

            Console.WriteLine("***");
            #endregion

            #region Iterator
            Console.WriteLine("Iterator");

            ListaTarefas lista = new ListaTarefas();

            // Adicionando algumas tarefas à lista
            lista.AdicionarTarefa(new Tarefa("Estudar Padrões de Design", false));
            lista.AdicionarTarefa(new Tarefa("Escrever código", true));
            lista.AdicionarTarefa(new Tarefa("Revisar documentação", false));

            // Obtendo o iterador
            IteradorTarefa iterador = lista.GetIterator();

            // Iterando sobre as tarefas
            Console.WriteLine("Iterando sobre as tarefas:");
            do
            {
                Console.WriteLine($"{iterador.Current.Descricao} - {(iterador.Current.Concluida ? "Concluída" : "Pendente")}");
            } while (iterador.Next());

            Console.WriteLine("***");
            #endregion

            #region Mediator
            Console.WriteLine("Mediator");

            // Criando o mediador do chat
            ChatMediator mediador = new ChatMediator();

            // Criando os usuários e registrando-os no mediador
            Usuario usuario1 = new Usuario("João", mediador);
            Usuario usuario2 = new Usuario("Maria", mediador);
            Usuario usuario3 = new Usuario("Carlos", mediador);

            mediador.AdicionarUsuario(usuario1);
            mediador.AdicionarUsuario(usuario2);
            mediador.AdicionarUsuario(usuario3);

            // Enviando mensagens
            usuario1.EnviarMensagem("Olá, pessoal!");
            usuario2.EnviarMensagem("Oi João, tudo bem?");
            usuario3.EnviarMensagem("Oi Maria e João!");

            Console.WriteLine("***");
            #endregion

            #region Memento
            Console.WriteLine("Memento");

            // Criando o editor de texto
            EditorTexto editor = new EditorTexto("Texto inicial.");

            // Criando o cuidador de mementos
            Cuidadores cuidadores = new Cuidadores();

            // Salvando o estado inicial
            cuidadores.SalvarMemento(editor.CriarMemento());

            Console.WriteLine("Estado atual: " + editor);

            // Modificando o texto
            editor.Texto = "Texto alterado.";
            Console.WriteLine("Estado modificado: " + editor);

            // Salvando o novo estado
            cuidadores.SalvarMemento(editor.CriarMemento());

            // Modificando novamente o texto
            editor.Texto = "Outro texto.";
            Console.WriteLine("Estado modificado novamente: " + editor);

            // Restaurando o estado anterior (desfazendo a última modificação)
            editor.RestaurarMemento(cuidadores.RecuperarMemento(1));
            Console.WriteLine("Estado após restaurar (desfazer): " + editor);

            // Restaurando o estado inicial (desfazendo tudo)
            editor.RestaurarMemento(cuidadores.RecuperarMemento(0));
            Console.WriteLine("Estado após restaurar o inicial: " + editor);

            Console.WriteLine("***");
            #endregion

            #region Observer
            Console.WriteLine("Observer");

            // Criando o evento
            Evento evento = new Evento("Concerto de Rock");

            // Criando alguns observadores (pessoas)
            PadroesGof.Comportamentais.Pessoa pessoa01 = new PadroesGof.Comportamentais.Pessoa("João");
            PadroesGof.Comportamentais.Pessoa pessoa02 = new PadroesGof.Comportamentais.Pessoa("Maria");
            PadroesGof.Comportamentais.Pessoa pessoa03 = new PadroesGof.Comportamentais.Pessoa("Carlos");

            // Adicionando os observadores ao evento
            evento.AdicionarObservador(pessoa01);
            evento.AdicionarObservador(pessoa02);
            evento.AdicionarObservador(pessoa03);

            // O evento ocorre, e todos os observadores são notificados
            evento.OcorrerEvento();

            Console.WriteLine();

            // Removendo um observador
            evento.RemoverObservador(pessoa02);

            // O evento ocorre novamente, mas agora Maria não será notificada
            evento.OcorrerEvento();

            Console.WriteLine("***");
            #endregion

            #region State
            Console.WriteLine("State");

            MaquinaVendas maquina = new MaquinaVendas();

            // Iniciando com o estado "Esperando Moeda"
            maquina.EscolherProduto();  // Não pode escolher antes de inserir moeda
            maquina.InserirMoeda();     // Insere a moeda
            maquina.EscolherProduto();  // Escolhe o produto
            maquina.EntregarProduto();  // Produto é entregue

            // Voltando para o estado "Esperando Moeda"
            maquina.InserirMoeda();     // Insere outra moeda
            maquina.EscolherProduto();  // Escolhe outro produto
            maquina.EntregarProduto();  // Produto é entregue

            Console.WriteLine("***");
            #endregion

            #region Strategy
            Console.WriteLine("Strategy");

            Calculadora calculadora = new Calculadora();

            // Usando a estratégia de soma
            calculadora.DefinirEstrategia(new Somar());
            Console.WriteLine($"Soma: {calculadora.ExecutarCalculo(10, 5)}"); // 15

            // Usando a estratégia de subtração
            calculadora.DefinirEstrategia(new Subtrair());
            Console.WriteLine($"Subtração: {calculadora.ExecutarCalculo(10, 5)}"); // 5

            // Usando a estratégia de multiplicação
            calculadora.DefinirEstrategia(new Multiplicar());
            Console.WriteLine($"Multiplicação: {calculadora.ExecutarCalculo(10, 5)}"); // 50

            // Usando a estratégia de divisão
            calculadora.DefinirEstrategia(new Dividir());
            Console.WriteLine($"Divisão: {calculadora.ExecutarCalculo(10, 5)}"); // 2

            Console.WriteLine("***");
            #endregion

            #region TemplateMethod
            Console.WriteLine("TemplateMethod");

            Console.WriteLine("Preparando Café:");
            BebidaQuente coffee = new PadroesGof.Comportamentais.Cafe();
            coffee.PrepararBebida();

            Console.WriteLine("\nPreparando Chá:");
            BebidaQuente tea = new Cha();
            tea.PrepararBebida();

            Console.WriteLine("***");
            #endregion

            #region Visitor
            Console.WriteLine("Visitor");

            List<IElemento> funcionarios = new List<IElemento>
        {
            new Coordenador("Carlos", 5000),
            new Desenvolvedor("Ana", "C#"),
            new Desenvolvedor("Pedro", "Java")
        };

            IVisitor relatorio = new RelatorioVisitor();

            foreach (var funcionario in funcionarios)
            {
                funcionario.Aceitar(relatorio);
            }

            Console.WriteLine("***");
            #endregion

            #endregion

        }
    }
}
