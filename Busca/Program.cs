using System;
using TreeStructure;

namespace Busca
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Root = new Node<int>(25);

            var nodeA = tree.Root.AddChild(20);
            var nodeB = tree.Root.AddChild(36);

            var nodeC = nodeA.AddChild(10);
            var nodeD = nodeA.AddChild(22);

            var nodeE = nodeB.AddChild(30);
            var nodeF = nodeB.AddChild(40);

            var nodeG = nodeC.AddChild(5);
            var nodeH = nodeC.AddChild(12);

            var nodeI = nodeE.AddChild(28);

            var nodeJ = nodeF.AddChild(38);
            var nodeK = nodeF.AddChild(48);

            var nodeL = nodeG.AddChild(1);
            var nodeM = nodeG.AddChild(8);

            var nodeN = nodeH.AddChild(15);

            var nodeO = nodeK.AddChild(45);
            var nodeP = nodeK.AddChild(49);
            var nodeQ = nodeK.AddChild(50);

            tree.Root.PrintTree();

            Console.WriteLine("Insira o dado int que deseja buscar:");
            int dataToSearch = Int32.Parse(Console.ReadLine());

            // para fins de medição
            System.Diagnostics.Stopwatch stopwatch = null;

            Predicate<Node<int>> match = (Node<int> node) => node.Data == dataToSearch;

            Console.WriteLine("\nInsira o modo de busca:");
            Console.WriteLine("0 - Profundidade usando pilhas");
            Console.WriteLine("1 - Profundidade usando recursividade");
            Console.WriteLine("2 - Largura");

            Node<int> result = default(Node<int>);

            int a = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nPassos:");

            switch (a)
            {
                case 0:
                    stopwatch = System.Diagnostics.Stopwatch.StartNew();
                    result = tree.Root.Profundidade(match);
                    break;
                case 1:
                    stopwatch = System.Diagnostics.Stopwatch.StartNew();
                    result = tree.ProfundidadeRecursiva(tree.Root, match); // revisar
                    break;

                case 2:
                    stopwatch = System.Diagnostics.Stopwatch.StartNew();
                    result = tree.Root.Largura(match);
                    break;

                default:
                    Console.WriteLine("Não reconhecido. Saindo...");
                    System.Environment.Exit(0);
                    break;
            }

            if (result != null)
            {
                Console.WriteLine("\nResultado");
                Console.WriteLine(result.ToString());

                Console.WriteLine("\nCaminho (em profundidade) partindo da raíz:");
                foreach (Node<int> parent in result.GetRootPath(true))
                {
                    Console.WriteLine(parent.ToString());
                }

            }

            else Console.WriteLine("Nódulo não encontrado");

            Console.WriteLine($"\nExecution Time: {stopwatch.ElapsedMilliseconds}ms");

            Console.WriteLine("\n[PRESSIONE PARA SAIR]");
            Console.ReadKey();
        }
    }
}