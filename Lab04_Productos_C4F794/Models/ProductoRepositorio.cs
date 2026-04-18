using System.Collections.Generic;
using System.Linq;

namespace Lab04_Productos_C4F794.Models
{
    public class ProductoRepositorio
    {
        private static List<Producto> listaProductos = new List<Producto>();
        private static int siguienteId = 1;

        public List<Producto> ObtenerTodos()
        {
            return listaProductos;
        }

        public Producto ObtenerPorId(int id)
        {
            return listaProductos.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {
            producto.Id = siguienteId;
            siguienteId = siguienteId + 1;

            listaProductos.Add(producto);
        }

        public void Actualizar(Producto producto)
        {
            Producto existente = ObtenerPorId(producto.Id);

            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.Precio = producto.Precio;
                existente.Categoria = producto.Categoria;
            }
        }

        public void Eliminar(int id)
        {
            Producto producto = ObtenerPorId(id);

            if (producto != null)
            {
                listaProductos.Remove(producto);
            }
        }
    }
}
