using System;
using System.Collections.Generic;

class Livro
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }
    public int Quantidade { get; set; }
}

class Program
{
    static List<Livro> estoque = new List<Livro>();

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("[1] Novo");
            Console.WriteLine("[2] Listar Produtos");
            Console.WriteLine("[3] Remover Produtos");
            Console.WriteLine("[4] Entrada Estoque");
            Console.WriteLine("[5] Saída Estoque");
            Console.WriteLine("[0] Sair");

            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarLivro();
                    break;
                case 2:
                    ListarLivros();
                    break;
                case 3:
                    RemoverLivro();
                    break;
                case 4:
                    AdicionarEstoque();
                    break;
                case 5:
                    RemoverEstoque();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 0);
    }

    static void AdicionarLivro()
    {
        Livro livro = new Livro();

        Console.WriteLine("Informe o nome do Livro:");
        livro.Nome = Console.ReadLine();

        Console.WriteLine("Informe o preço:");
        livro.Preco = double.Parse(Console.ReadLine());

        Console.WriteLine("Informe o autor(a):");
        livro.Autor = Console.ReadLine();

        Console.WriteLine("Informe o Gênero:");
        livro.Genero = Console.ReadLine();

        livro.Quantidade = 0;

        estoque.Add(livro);

        Console.WriteLine("Livro adicionado!");
    }

    static void ListarLivros()
    {
        for (int i = 0; i < estoque.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {estoque[i].Nome} ({estoque[i].Preco}) - {estoque[i].Quantidade} no estoque");
        }
    }

    static void RemoverLivro()
    {
        ListarLivros();
        Console.WriteLine("Informe a posição do livro a ser removido:");
        int posicao = int.Parse(Console.ReadLine()) - 1;

        if (posicao >= 0 && posicao < estoque.Count)
        {
            estoque.RemoveAt(posicao);
            Console.WriteLine("Livro removido!");
        }
        else
        {
            Console.WriteLine("Posição inválida!");
        }
    }

    static void AdicionarEstoque()
    {
        ListarLivros();
        Console.WriteLine("Informe a posição do livro:");
        int posicao = int.Parse(Console.ReadLine()) - 1;

        if (posicao >= 0 && posicao < estoque.Count)
        {
            Console.WriteLine("Informe a quantidade de Entrada:");
            int quantidade = int.Parse(Console.ReadLine());
            estoque[posicao].Quantidade += quantidade;
            Console.WriteLine("Entrada de estoque realizada com sucesso!");
        }
        else
        {
            Console.WriteLine("Posição inválida!");
        }
    }

    static void RemoverEstoque()
    {
        ListarLivros();
        Console.WriteLine("Informe a posição do livro:");
        int posicao = int.Parse(Console.ReadLine()) - 1;

        if (posicao >= 0 && posicao < estoque.Count)
        {
            Console.WriteLine("Informe a quantidade de Saída:");
            int quantidade = int.Parse(Console.ReadLine());

            if (estoque[posicao].Quantidade >= quantidade)
            {
                estoque[posicao].Quantidade -= quantidade;
                Console.WriteLine("Saída de estoque realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Quantidade indisponível em estoque!");
            }
        }
        else
        {
            Console.WriteLine("Posição inválida!");
        }
    }
}
