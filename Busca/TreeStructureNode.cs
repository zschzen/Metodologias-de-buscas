using System.Collections.Generic;

namespace TreeStructure
{

    /// <summary>
    /// Classe dedicada aos nódulos da árvore
    /// Parte dos estudo de Leandro Peres, Março de 2020
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="https://youtube.com/watch?v=K0-qs--naUo"/>
    [System.Serializable]
    public class Node<T>
    {
        #region Vars

        public T Data { get; set; }                         // Dado do nódulo
        public Node<T> Parent { get; set; }                 // Nódulo pai
        public ICollection<Node<T>> Children { get; set; }  // Implementação da lista de nódulos filhos

        #endregion

        /// <summary>
        /// Construtor da classe Node
        /// </summary>
        /// <param name="data">Dado a ser registrado no módulo</param>
        /// <param name="parent">Nódulo pai. deixar nulo para nódulo raiz</param>
        public Node(T data, Node<T> parent = null)
        {
            this.Data = data;
            this.Children = new List<Node<T>>();
            this.Parent = parent;
        }

        /// <summary>
        /// Método dedicado à adição de nódulos filhos
        /// </summary>
        /// <param name="child">Dados a serem adicionados</param>
        /// <returns>Nódulo filho criado</returns>
        public Node<T> AddChild(T child)
        {
            Node<T> newChild = new Node<T>(child, this);
            this.Children.Add(newChild);

            return newChild;
        }

        /// <summary>
        /// Partindo do nódulo atual, calcula o tamanho total da árvore
        /// </summary>
        /// <returns>Inteiro representando o tamanho da árvore</returns>
        public int GetHeight()
        {
            int height = 1;
            Node<T> current = this;

            while (current.Parent != null)
            {
                height++;
                current = current.Parent;
            }

            return height;
        }

        /// <summary>
        /// Relata os dados do objeto nódulo como string
        /// </summary>
        /// <returns>Dado registrado no nódulo</returns>
        public override string ToString()
        {
            return $"Node: {Data}, Parent: {Parent.Data}, Height: {GetHeight()}";
        }
    }

    /// <summary>
    /// Classe dedicada para o escopo da árvore de dados
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public class Tree<T>
    {
        public Node<T> Root { get; set; }
    }
}
