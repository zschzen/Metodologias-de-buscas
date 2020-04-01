using System;
using TreeStructure;

namespace Busca
{
    class Program
    {
        static void Main(string[] args)
        {

            Tree<int> tree = new Tree<int>();

            /*
            *                25
            *              /    \
            *             /      \ 
            *            20       36
            *           /  \     /  \    
            *          10   22  30   \
            *         /  \      |     40   
            *        5    12    28   /  \
            *       / \   |         38  48
            *      1   8  15           /  \
            *                        45    50
            */

            tree.Root = new Node<int>(25);

            Node<int> nodeA = tree.Root.AddChild(20);
            Node<int> nodeB = tree.Root.AddChild(36);

            Node<int> nodeC = nodeA.AddChild(10);
            Node<int> nodeD = nodeA.AddChild(22);

            Node<int> nodeE = nodeB.AddChild(30);
            Node<int> nodeF = nodeB.AddChild(40);

            Node<int> nodeG = nodeC.AddChild(5);
            Node<int> nodeH = nodeC.AddChild(12);

            Node<int> nodeI = nodeE.AddChild(28);

            Node<int> nodeJ = nodeF.AddChild(38);
            Node<int> nodeK = nodeF.AddChild(48);

            Node<int> nodeL = nodeG.AddChild(1);
            Node<int> nodeM = nodeG.AddChild(8);

            Node<int> nodeN = nodeH.AddChild(15);

            Node<int> nodeO = nodeK.AddChild(45);
            Node<int> nodeP = nodeK.AddChild(50);

            Console.ReadKey();
        }
    }
}
