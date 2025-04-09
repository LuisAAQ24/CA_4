using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arbol;

namespace TestArbolBinario
{
    [TestClass]
    public class ArbolBinarioTest
    {
        [TestMethod]
        public void InsertarElemento()
        {
            var bst = new ArbolBinario();
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(6);

            Assert.IsTrue(bst.Buscar(8));
            Assert.IsTrue(bst.Buscar(3));
            Assert.IsTrue(bst.Buscar(10));
            Assert.IsTrue(bst.Buscar(1));
            Assert.IsTrue(bst.Buscar(6));
            Assert.IsFalse(bst.Buscar(99));
        }

        [TestMethod]
        public void EliminarNodo()
        {
            var bst = new ArbolBinario();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(7);

            bst.Delete(3); // Nodo
            Assert.IsFalse(bst.Buscar(3));
        }

        [TestMethod]
        public void ReemplazarUnHijo()
        {
            var bst = new ArbolBinario();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(1); // hijo izquierdo de 3

            bst.Delete(3);
            Assert.IsFalse(bst.Buscar(3));
            Assert.IsTrue(bst.Buscar(1));
        }

        [TestMethod]
        public void ReemplazarDosHijos()
        {
            var bst = new ArbolBinario();
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(4);
            bst.Insert(7);

            bst.Delete(3); // tiene dos hijos

            Assert.IsFalse(bst.Buscar(3));
            Assert.IsTrue(bst.Buscar(4)); // El sucesor debería seguir estando
        }

        [TestMethod]
        public void BuscarVacio()
        {
            var bst = new ArbolBinario();
            Assert.IsFalse(bst.Buscar(10));
        }
    }
}
