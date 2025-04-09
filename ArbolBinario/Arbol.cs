using System;

namespace Arbol
{
    // Nodo del árbol
    public class NodoArbol
    {
        public int Key;
        public NodoArbol Left, Right;

        public NodoArbol(int item)
        {
            Key = item;
            Left = Right = null;
        }
    }

    //Arbol
    public class ArbolBinario
    {
        private NodoArbol root;

        public ArbolBinario()
        {
            root = null;
        }

        // Búsqueda pública
        public bool Buscar(int key)
        {
            return BuscarRecursivo(root, key);
        }

        private bool BuscarRecursivo(NodoArbol root, int key)
        {
            if (root == null) return false;
            if (root.Key == key) return true;
            else if (key > root.Key) return BuscarRecursivo(root.Right, key);
            else return BuscarRecursivo(root.Left, key);
        }

        // Inserción pública
        public void Insert(int key)
        {
            root = InsertRecursive(root, key);
        }

        private NodoArbol InsertRecursive(NodoArbol root, int key)
        {
            if (root == null)
            {
                return new NodoArbol(key);
            }

            if (key < root.Key)
                root.Left = InsertRecursive(root.Left, key);
            else if (key > root.Key)
                root.Right = InsertRecursive(root.Right, key);

            return root;
        }

        // Eliminación pública
        public void Delete(int key)
        {
            root = DeleteRecursive(root, key);
        }

        private NodoArbol DeleteRecursive(NodoArbol root, int key)
        {
            if (root == null) return root;

            if (key < root.Key)
                root.Left = DeleteRecursive(root.Left, key);
            else if (key > root.Key)
                root.Right = DeleteRecursive(root.Right, key);
            else
            {
                //sin hijos
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                //con hijos
                root.Key = MinValue(root.Right);
                root.Right = DeleteRecursive(root.Right, root.Key);
            }

            return root;
        }

        private int MinValue(NodoArbol root)
        {
            int min = root.Key;
            while (root.Left != null)
            {
                min = root.Left.Key;
                root = root.Left;
            }
            return min;
        }

        //inorden
        public void InOrder()
        {
            InOrderRecursivo(root);
            Console.WriteLine();
        }

        private void InOrderRecursivo(NodoArbol root)
        {
            if (root != null)
            {
                InOrderRecursivo(root.Left);
                Console.Write(root.Key + " ");
                InOrderRecursivo(root.Right);
            }
        }

        // Recorrido preorden
        public void PreOrder()
        {
            PreOrderRecursivo(root);
            Console.WriteLine();
        }

        private void PreOrderRecursivo(NodoArbol root)
        {
            if (root != null)
            {
                Console.Write(root.Key + " ");
                PreOrderRecursivo(root.Left);
                PreOrderRecursivo(root.Right);
            }
        }

        // Recorrido postorden
        public void PostOrder()
        {
            PostOrderRecursivo(root);
            Console.WriteLine();
        }

        private void PostOrderRecursivo(NodoArbol root)
        {
            if (root != null)
            {
                PostOrderRecursivo(root.Left);
                PostOrderRecursivo(root.Right);
                Console.Write(root.Key + " ");
            }
        }
    }
}
