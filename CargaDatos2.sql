
INSERT INTO Metodo_Pago VALUES ('Efectivo'), ('Credito'), ('Debito'), ('Transferencia Bancaria')
INSERT INTO Categoria VALUES ('Aire Acondicionado'), ('Televisor'), ('Celular'), ('Heladera'), ('Lavarropas'), ('Ventilador'), ('Notebook'), ('Tablet'), ('Licuadora'), ('Cocina')
INSERT INTO Marca VALUES ('Philips'), ('Drean'), ('Lenovo'), ('LG'), ('Gafa'), ('BGH'), ('Electrolux'), ('Noblex'), ('Samsung'), ('Atma')
INSERT INTO Usuario_Tipo VALUES ('Invitado'), ('Usuario'), ('Empleado'), ('Admin')
INSERT INTO Estado_Comercial VALUES ('En Stock'), ('Oferta'), ('Agotado')

INSERT INTO Articulo VALUES ('A22', 'Viva Coleccion', '800 W/ jarra 2,4 L/ cuchillas ProBlend6.', 9, 1, 12000.00,'https://static.cotodigital3.com.ar/sitios/fotos/full/00187000/00187090.jpg?3.0.141b' , 1, 0, 1)
INSERT INTO Articulo VALUES ('P02', 'LG GC-X247CQBV', '400L / No Frost/ Color Negro Mate', 4, 4, 200000.99, 'https://castillo.com.ar/Image/0/500_500-13871130-1.jpg' , 1, 0, 1)
INSERT INTO Articulo VALUES ('B11', 'LG UltraC22', '800W / 2L / Solo en negro ', 9, 4, 17000.00, 'https://images.fravega.com/f300/400759134cdb46d65c503fd12ffb399e.jpg' , 1, 0, 1)
INSERT INTO Articulo VALUES ('A25', 'MiniPimer Saturno', '400W/ cuchillas de acero', 9, 1, 10000.00, 'https://saturnohogar.com.ar/2797/mixer-minipimer-philips-hr253150.jpg' , 1 , 0, 1)
INSERT INTO Articulo VALUES ('J02', 'HORNO ELÉCTRICO HG-2010N', ' 17 LTS - 1200 W CON GRILL', 10, 10, 70000.00, 'https://d2r9epyceweg5n.cloudfront.net/stores/489/847/products/horno-electrico-atma-hg-2010n1-f385b4cd0cb617e99615982891954137-1024-1024.jpg' , 1, 0, 1)

INSERT INTO Usuario VALUES (2, 'test@test.com', '1234', CAST(GETDATE() AS DATE), 'testy')
INSERT INTO Usuario VALUES (4, 'mod@mod.com', '4321', CAST(GETDATE() AS DATE), 'modmin')

INSERT INTO Metodo_Pago VALUES ('Mercado_Pago')


select A.Id, A.Codigo as Codigo, A.Nombre as Nombre, A.Descripcion as Descripcion, M.Nombre as Marca, M.Id as IdMarca, C.Nombre as Categoria, C.Id as IdCategoria, A.Precio as Precio,
A.Imagen , A.EstadoComercial, E.Nombre AS NombreE, A.Descuento, A.EstadoActivo FROM ARTICULO A
inner join MARCA M on M.Id = A.IdMarca
inner join CATEGORIA C on C.Id = A.IdCategoria
inner join Estado_Comercial E on E.Id= A.EstadoComercial 


SELECT * FROM Articulo A
INNER JOIN Marca M ON M.ID = A.IdMarca
inner join CATEGORIA C on C.Id = A.IdCategoria
inner join Estado_Comercial E on E.Id= A.EstadoComercial 



SELECT * from Categoria
SELECT * FROM Marca
SELECT * FROM Articulo
Select * FROM Estado_Comercial
SELECT * FROM Usuario
SELECT * FROM Domicilio
SELECT * FROM Metodo_Pago
