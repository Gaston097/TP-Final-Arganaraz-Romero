using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Diccionario
    {
        public static string CONEXION_SERVER = "server =.\\SQLEXPRESS; database=ECommerce; integrated security = true";

        public static string LISTAR_MARCAS = "select id, Nombre from MARCA ";

        public static string MODIFICAR_MARCA = "UPDATE Marca SET Nombre = @nombre WHERE ID = @id";

        public static string LISTAR_CATEGORIAS = "select id, Nombre from CATEGORIA ";

        public static string MODIFICAR_CATEGORIA = "UPDATE Categoria SET Nombre = @nombre WHERE ID = @id";

        public static string LISTAR_ARTICULOS = "select A.Id, A.Codigo as Codigo, A.Nombre as Nombre, A.Descripcion as Descripcion, M.Nombre as Marca, M.Id as IdMarca, C.Nombre as Categoria, C.Id as IdCategoria, A.Precio as Precio, A.Imagen , A.EstadoComercial, E.Nombre AS NombreE, A.Descuento FROM ARTICULO A inner join MARCA M on M.Id = A.IdMarca inner join CATEGORIA C on C.Id = A.IdCategoria inner join Estado_Comercial E on E.Id= A.EstadoComercial ";

        public static string CONSULTA_FILTRO_AVANZADO = "select A.Id, A.Codigo as Codigo, A.Nombre , A.Descripcion , M.Descripcion as Marca, M.Id as IdMarca, C.Descripcion as Categoria, C.Id as IdCategoria, A.ImagenUrl, A.Precio from ARTICULOS A inner join MARCAS M on M.Id = A.IdMarca inner join CATEGORIAS C on C.Id = A.IdCategoria where A.";

        public static string MODIFICAR_ARTICULO = "update articulos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @imagenUrl, Precio = @precio where ID = @ID";

        public static string AGREGAR_ARTICULO = "insert into articulos values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagen, @precio)";

        public static string BAJA_ARTICULO = "update articulos set Estado = 0 where ID = @ID";

        public static string ELIMINAR_ARTICULO = "delete from articulos where ID = @ID";

        public static string ELIMINAR_MARCA = "delete from MARCA where ID = @ID";

        public static string ALTA_ARTICULO = "update articulos set Estado = 1 where ID = @ID";

        public static string AGREGAR_CATEGORIA = "INSERT INTO Categoria VALUES (@nombre)";

        public static string AGREGAR_MARCA = "INSERT INTO Marca VALUES (@nombre)";






        public static string Buscar = "select A.Id, A.Codigo as Codigo, A.Nombre , A.Descripcion , M.Descripcion as Marca, M.Id as IdMarca, C.Descripcion as Categoria, C.Id as IdCategoria, A.ImagenUrl, A.Precio from ARTICULOS A inner join MARCAS M on M.Id = A.IdMarca inner join CATEGORIAS C on C.Id = A.IdCategoria where A.ID = @ID";

    }
}
