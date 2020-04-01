using System;
using TreeStructure;

namespace Busca
{
    class Program
    {
        static void Main (string[] args)
        {
            Tree<int> tree = new Tree<int> ();

            /*
             *                25root
             *              /       \
             *             /         \
             *            20a         36b
             *           /   \       /   \
             *          10c   22d   30e   \
             *         /   \        |      40f
             *        5g    12h     28i   /   \
             *       /  \    |           38j   48k
             *      1l   8m  15n             /  |  \
             *                              45o 49p 50q
             */

            tree.Root = new Node<int> (25);

            var nodeA = tree.Root.AddChild (20);
            var nodeB = tree.Root.AddChild (36);

            var nodeC = nodeA.AddChild (10);
            var nodeD = nodeA.AddChild (22);

            var nodeE = nodeB.AddChild (30);
            var nodeF = nodeB.AddChild (40);

            var nodeG = nodeC.AddChild (5);
            var nodeH = nodeC.AddChild (12);

            var nodeI = nodeE.AddChild (28);

            var nodeJ = nodeF.AddChild (38);
            var nodeK = nodeF.AddChild (48);

            var nodeL = nodeG.AddChild (1);
            var nodeM = nodeG.AddChild (8);

            var nodeN = nodeH.AddChild (15);

            var nodeO = nodeK.AddChild (45);
            var nodeP = nodeK.AddChild (49);
            var nodeQ = nodeK.AddChild (50);

            Console.WriteLine ("Insira o dado int que deseja buscar:");
            int dataToSearch = Int32.Parse (Console.ReadLine ());

            // para fins de medição
            var stopwatch = System.Diagnostics.Stopwatch.StartNew ();

            Predicate<Node<int>> match = (Node<int> node) => node.Data == dataToSearch;
            var result = tree.Profundidade (tree.Root, match);

            if (result != null)
            {
                Console.WriteLine ("\nCaminho partindo da raíz:");
                foreach (Node<int> parent in result.GetRootPath (true))
                    Console.WriteLine (parent.ToString ());
            }
            else Console.WriteLine ("Nódulo não encontrado");

            Console.WriteLine ($"\nExecution Time: {stopwatch.ElapsedMilliseconds}ms");

            Console.WriteLine ("\n[PRESSIONE PARA SAIR]");
            Console.ReadKey ();
        }
    }
}