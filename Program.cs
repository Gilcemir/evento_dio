using System;
using cadastroEventos_dio;

class Program
{
    static RepositorioEvento meusEventos = new RepositorioEvento();

    private static string menu()
    {
        Console.WriteLine();
        Console.WriteLine("Informe a opção: ");
        Console.WriteLine("1 - Listar Eventos");
        Console.WriteLine("2 - Inserir Evento");
        Console.WriteLine("3 - Atualizar Evento existente");
        Console.WriteLine("4 - Excluir evento");
        Console.WriteLine("5 - Dados sobre determinado Evento");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string str = Console.ReadLine().ToLower();
        return str;
    }

    private static void ListarEventos()
    {
        var eventos = meusEventos.Lista();

        if (eventos.Count == 0)
        {
            Console.WriteLine("Não há eventos cadastrados");
            return;
        }
        foreach (var elem in eventos)
        {
            Console.WriteLine (elem);
            Console.WriteLine(elem.Excluido()?"ATENÇÃO -- EVENTO CANCELADO":"");
        }
    }

    private static void AddEvento()
    {
        int id = meusEventos.NextId();

        Console.WriteLine("Título: " + Environment.NewLine);
        string titulo = Console.ReadLine();

        Console.WriteLine("Escolha a Modalidade: " + Environment.NewLine);
        foreach (int i in Enum.GetValues(typeof (Modalidade)))
        {
            Console.WriteLine($"{i} - {Enum.GetName(typeof (Modalidade), i)}");
        }
        int modalidade = int.Parse(Console.ReadLine());

        Console.WriteLine("Ano: " + Environment.NewLine);
        int ano = int.Parse(Console.ReadLine());

        Console.WriteLine("Organizador: " + Environment.NewLine);
        string organizador = Console.ReadLine();

        Evento evento =
            new Evento(id,
                titulo,
                modalidade: (Modalidade) modalidade,
                organizador,
                ano);

        meusEventos.Insere (evento);
    }

    private static void AtualizaEvento()
    {
        Console.WriteLine("Informe o ID do evento: " + Environment.NewLine);
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Título: " + Environment.NewLine);
        string titulo = Console.ReadLine();

        Console.WriteLine("Escolha a Modalidade: " + Environment.NewLine);
        foreach (int i in Enum.GetValues(typeof (Modalidade)))
        {
            Console.WriteLine($"{i} - {Enum.GetName(typeof (Modalidade), i)}");
        }
        int modalidade = int.Parse(Console.ReadLine());

        Console.WriteLine("Ano: " + Environment.NewLine);
        int ano = int.Parse(Console.ReadLine());

        Console.WriteLine("Organizador: " + Environment.NewLine);
        string organizador = Console.ReadLine();

        Evento evento =
            new Evento(id,
                titulo,
                modalidade: (Modalidade) modalidade,
                organizador,
                ano);

        meusEventos.Atualiza (id, evento);
    }

    private static void ExcluiEvento()
    {
        Console
            .WriteLine("Informe o ID do evento que deseja excluir: " +
            Environment.NewLine);
        int id = int.Parse(Console.ReadLine());

        meusEventos.Exclui (id);
    }

    private static void DetalhesEvento()
    {
        Console
            .WriteLine("Informe o ID do evento que deseja visualizar: " +
            Environment.NewLine);
        int id = int.Parse(Console.ReadLine());

        Evento evento = meusEventos.GetById(id);

        Console.WriteLine (evento);
        Console.WriteLine(evento.Excluido()?"ATENÇÃO -- EVENTO CANCELADO":"");
    }

    public static void Main()
    {
        string opcao;

        opcao = menu();
        while (opcao.ToLower() != "x")
        {
            switch (opcao)
            {
                case "1":
                    ListarEventos();
                    break;
                case "2":
                    AddEvento();
                    break;
                case "3":
                    AtualizaEvento();
                    break;
                case "4":
                    ExcluiEvento();
                    break;
                case "5":
                    DetalhesEvento();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcao = menu();
        }

        Console.WriteLine("---------");
    }
}
