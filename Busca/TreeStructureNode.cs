using System.Collections.Generic;
using System.Linq;

namespace TreeStructure
{

    /// <summary>
    /// Classe dedicada aos nódulos da árvore
    /// Parte dos estudo de Leandro Peres e Geovani Alves, Março de 2020
    /// Disciplina: Inteligência Aftificial Aplicada
    /// Doscente: Gustavo
    /// 
    /// TODO:
    ///     - Revisar e otimizar métodos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="https://youtube.com/watch?v=K0-qs--naUo"/>
    [System.Serializable]
    public class Node<T>
    {
        #region Vars

        public T Data { get; set; } // Dado do nódulo
        public Node<T> Parent { get; set; } // Nódulo pai
        public ICollection<Node<T>> Children { get; set; } // Implementação da lista de nódulos filhos

        #endregion

        /// <summary>
        /// Construtor da classe Node
        /// </summary>
        /// <param name="data">Dado a ser registrado no módulo</param>
        /// <param name="parent">Nódulo pai. deixar nulo para nódulo raiz</param>
        public Node(T data, Node<T> parent = default(Node<T>))
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

            while (current.Parent != default(Node<T>))
            {
                height++;
                current = current.Parent;
            }

            return height;
        }

        /// <summary>
        /// Partindo do nódulo atual, calcula o caminho até o nódulo raiz
        /// 
        /// TODO:
        ///     - Revisar
        /// </summary>
        /// <param name="reverse">true para um caminho descendente</param>
        /// <returns>Lista de nódulos representando o caminho partindo do nódulo raiz</returns>
        public List<Node<T>> GetRootPath(bool reverse = false)
        {
            var current = this;
            List<Node<T>> path = new List<Node<T>>();

            do
            {
                path.Add(current);
                current = current.Parent;
            } while (current.Parent != default(Node<T>));

            // add root
            path.Add(current);

            if (reverse)
                path.Reverse();

            return path;
        }

        /// <summary>
        /// Relata os dados do objeto nódulo como string
        /// </summary>
        /// <returns>Dado registrado no nódulo</returns>
        public override string ToString()
        {
            return $"Node: {Data}, Height: {GetHeight()}";
        }
    }

    /// <summary>
    /// Classe dedicada para o escopo da árvore de dados
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        private readonly List<Node<T>> visitados;

        public Tree()
        {
            visitados = new List<Node<T>>();
        }

        #region Search

        /// <summary>
        /// Busca não recursiva em profundidade
        /// </summary>
        /// <param name="node">Nódulo pai para início da busca</param>
        /// <param name="match">Condição de iltragem</param>
        /// <returns>Nódulo encontrado na busca</returns>
        public Node<T> Profundidade(Node<T> node, System.Predicate<Node<T>> match)
        {
            var fila = new Stack<Node<T>>();
            // adiciona o nódulo raiz no topo da lista
            fila.Push(node);

            Node<T> current;

            while (fila.Any())
            {
                // retira da fila e o retorna
                current = fila.Pop();

                if (match(current)) return current;

                if (current.Children == default(Node<T>)) continue;

                // reverse garante um caminho da esquerda para direita
                foreach (Node<T> child in current.Children.Reverse())
                    fila.Push(child);

#if DEBUG
                System.Diagnostics.Debug.WriteLine(current.ToString());
#endif
            } // while
            return default(Node<T>);
        }

        /// <summary>
        /// Busca recursiva em profundidade
        /// </summary>
        /// <param name="node">Nódulo pai para início da busca</param>
        /// <param name="match">Condição de filtragem</param>
        /// <returns>Nódulo encontrado na busca</returns>
        public Node<T> ProfundidadeRecursiva(Node<T> node, System.Predicate<Node<T>> match)
        {
            if (match(node)) return node;
            visitados.Remove(node);

            foreach (Node<T> child in node.Children)
            {
                visitados.Add(child);
            }

            while (visitados.Count > 0)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(node.ToString());
#endif
                if (ProfundidadeRecursiva(visitados[0], match) != default(Node<T>)) return visitados[0];
                visitados.RemoveAt(0);
            }

            return default(Node<T>);
        }

        /// <summary>
        /// Busca em largura
        /// </summary>
        /// <param name="node">Nódulo pai para início da busca</param>
        /// <param name="match">Condição de filtragem</param>
        /// <returns>Nódulo encontrado na busca</returns>
        public Node<T> Largura(Node<T> node, System.Predicate<Node<T>> match)
        {
            var fila = new Queue<Node<T>>();
            fila.Enqueue(node);

            while (fila.Any())
            {
                node = fila.Dequeue();

#if DEBUG
                System.Diagnostics.Debug.WriteLine(node.ToString());
#endif

                if (match(node)) return node;

                foreach (Node<T> child in node.Children)
                    fila.Enqueue(child);
            }

            return default(Node<T>);
        }

        #endregion

    }
}