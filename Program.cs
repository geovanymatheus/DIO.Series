using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        InativarSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;
                    
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
                        
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Suas Series App");
            Console.WriteLine("Informa a opção desejada:");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Dados da Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Exibir Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
            }
            else
            {
                Console.WriteLine("Listar Séries");
                foreach (var serie in lista)
                {
                    Console.WriteLine($"Id: {serie.getId()} - Título: {serie.getTitulo()} - Ativo: {serie.getAtivo()}");
                }
                Console.WriteLine("");
                Console.WriteLine($"Total de séries cadastradas: {lista.Count}");   
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");
            Console.Write("Informe o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Informe a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{item} - {Enum.GetName(typeof(Genero), item)}");
            }
            Console.Write("Informe o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            while (Enum.IsDefined(typeof(Genero), entradaGenero) == false)
            {
                Console.WriteLine("Opção inválida!");
                Console.Write("Informe o gênero dentre as opções exibidas: ");
                entradaGenero = int.Parse(Console.ReadLine());
            }

            Console.Write("Informe o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(repositorio.ProximoId(),
                                        entradaTitulo,
                                        entradaDescricao,
                                        (Genero)entradaGenero,
                                        entradaAno);
            
            repositorio.Inserir(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Qual ID da série a ser atualizada? ");
            int indiceSerie = int.Parse(Console.ReadLine());
            if (repositorio.Lista().Count > indiceSerie)
            {
                Console.Write("Informe o título da série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Informe a descrição da série: ");
                string entradaDescricao = Console.ReadLine();

                foreach (int item in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine($"{item} - {Enum.GetName(typeof(Genero), item)}");
                }
                Console.Write("Informe o gênero dentre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                while (Enum.IsDefined(typeof(Genero), entradaGenero) == false)
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Informe o gênero dentre as opções exibidas: ");
                    entradaGenero = int.Parse(Console.ReadLine());
                }

                Console.Write("Informe o ano de lançamento: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Serie atualizaSerie = new Serie(indiceSerie,
                                        entradaTitulo,
                                        entradaDescricao,
                                        (Genero)entradaGenero,
                                        entradaAno);
            
                repositorio.Atualizar(indiceSerie, atualizaSerie);
            }
            else
            {
                Console.WriteLine("Série não localizada!");
            }
            
            
        }
        private static void InativarSerie()
        {
            Console.WriteLine("Qual ID deseja inativar? ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);
            
            if (repositorio.Lista().Count > indiceSerie)
            {
                Console.WriteLine($"Deseja inativar o cadastro da série #{indiceSerie} - { serie.getTitulo() }");
                Console.WriteLine("S ou N?");
                char confirmacao = char.Parse(Console.ReadLine().ToUpper());
                if (confirmacao.Equals("S"))
                {
                    repositorio.Inativar(indiceSerie);
                }
                else
                {
                    Console.WriteLine("Processo cancelado!");
                }
            }
            else
            {
                Console.WriteLine("Série não localizada!");
            }
            
        }
        private static void VisualizarSerie()
        {
            Console.Write("Informe o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornarPorId(indiceSerie);
            
            if (repositorio.Lista().Count > indiceSerie)
            {
                Console.WriteLine(serie);
            }
            else
            {
                Console.WriteLine("Série não localizada!");
            }

            
            
        }


    }
}
