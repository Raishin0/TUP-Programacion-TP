create database FARMACIA_progra
go
use FARMACIA_progra
go

create table Formas_pago
(cod_forma_pago int identity(1,1),
forma_pago varchar(100)
constraint pk_forma_pago primary key (cod_forma_pago))

create table Tipos_suministros
(cod_tipo_sum int identity(1,1),
tipo_sum varchar(100)
constraint pk_tipo_sum primary key (cod_tipo_sum))
	 
create table Suministros
(cod_suministro int identity(1,1),
descripcion varchar(100),
precio_unitario money,
venta_libre bit,
cod_tipo_sum int,
stock int,
constraint pk_suministro primary key(cod_suministro),
constraint fk_tipo foreign key (cod_tipo_sum)
references Tipos_suministros (cod_tipo_sum)
)

create table Obras_sociales
(cod_obra_social int identity(1,1),
nom_obra_social varchar(100),
constraint pk_obra_social primary key (cod_obra_social)) 

create table Ventas
(nro_venta int identity(1,1),
fecha datetime,
cliente varchar(100),
cod_forma_pago int,
cod_obra_social int,
habilitada bit
constraint pk_venta primary key(nro_venta),
constraint fk_pago_v foreign key (cod_forma_pago)
references formas_pago(cod_forma_pago),
constraint fk_obra_v foreign key (cod_obra_social)
references Obras_sociales
)

create table Detalles_ventas
(cod_detalle_venta int identity(1,1),
nro_venta int,
cod_suministro int,
cantidad int,
precio_venta money,
cubierto bit
constraint pk_detalle_venta primary key (cod_detalle_venta),
constraint fk_venta foreign key (nro_venta)
references ventas(nro_venta),
constraint fk_cod_suministro_d foreign key (cod_suministro)
references suministros(cod_suministro)
)

create table Usuarios
(cod_usuario int identity(1,1),
nombre varchar(100) not null,
constraseña varbinary(max) not null
constraint pk_usuario primary key (cod_usuario)
)
go

--Inserts
use FARMACIA_progra
go

insert into Formas_pago values('Efectivo')
insert into Formas_pago values('Tarjeta')
insert into Formas_pago values('Cuenta Bancaria')

insert into Tipos_suministros values('Medicamentos')
insert into Tipos_suministros values('Perfumes')
insert into Tipos_suministros values('Otros')
	 
insert into Suministros values('Aspirina', 200, 1, 1, 25)
insert into Suministros values('Omeprazol', 150.5, 0, 1, 20)
insert into Suministros values('Ramipril', 100, 0, 1, 15)
insert into Suministros values('Paracetamol', 500.5, 1, 1, 17)
insert into Suministros values('Simvastatina', 120.5, 0, 1, 7)
insert into Suministros values('Amlodipina', 125.5, 0, 1, 40)
insert into Suministros values('One Million EDT', 500.5, null, 2,12)
insert into Suministros values('Atonio Banderas', 700.5, null, 2,21)
insert into Suministros values('Vendas', 400, null, 3,14)

insert into Obras_sociales values('Sin OS')
insert into Obras_sociales values('Pami')
insert into Obras_sociales values('OSDOP')
insert into Obras_sociales values('OSDOP SADOP')
insert into Obras_sociales values('Union Personal')
insert into Obras_sociales values('Apross')

set dateformat DMY
insert into Ventas values('03/04/2022','Raul',3,1,1)
insert into Ventas values('03/08/2022','Javier',3,3,1)
insert into Ventas values('03/12/2022','Alberto',3,1,1)
insert into Ventas values('03/08/2022','Cristina',3,2,1)
insert into Ventas values('03/04/2022','Mauracio',1,1,1)
insert into Ventas values('04/05/2022','Sergio',2,4,1)
insert into Ventas values('19/04/2022','Patricia',2,4,1)
insert into Ventas values('15/04/2022','Sergio',1,3,1)
insert into Ventas values('06/10/2022','Juan',1,2,1)
insert into ventas values('05/01/2022','Anibal',2,5,1)

insert into Detalles_ventas values(1,1,1,180,1)
insert into Detalles_ventas values(1,9,1,1200,1)
insert into Detalles_ventas values(1,4,5,630,0)
insert into Detalles_ventas values(2,7,5,880,0)
insert into Detalles_ventas values(2,8,5,1120,0)
insert into Detalles_ventas values(3,5,8,150,0)
insert into Detalles_ventas values(3,2,10,250,0)
insert into Detalles_ventas values(4,6,7,180,0)
insert into Detalles_ventas values(5,3,2,200,1)
insert into Detalles_ventas values(5,2,1,250,0)
insert into Detalles_ventas values(6,3,3,200,1)
insert into Detalles_ventas values(6,4,1,630,0)
insert into Detalles_ventas values(7,8,1,1120,0)
insert into Detalles_ventas values(8,1,2,380,0)
insert into Detalles_ventas values(8,9,1,1200,0)
insert into Detalles_ventas values(9,2,4,250,0)
insert into Detalles_ventas values(9,4,1,630,0)
insert into Detalles_ventas values(10,4,2,630,0)

insert into Usuarios(nombre, constraseña) values('Carlos', PWDENCRYPT('aguanteBOCA12'))
insert into Usuarios(nombre, constraseña) values('Lucia', PWDENCRYPT('hola123'))
insert into Usuarios(nombre, constraseña) values('Ad', PWDENCRYPT('123'))

--Procedimientos almacenados y triggers
use FARMACIA_progra
go

--Login
create proc comprobarUsuario
@nombreUsuario varchar(100), @contrasenia varchar(100)
as
begin
	if(exists (select * from Usuarios where nombre=@nombreUsuario  and PWDCOMPARE(@contrasenia, 
	constraseña) = 1))
	begin
		select 1 as correcto
	end
	else
	begin
		select 0 as correcto
	end
end
go

-- proxima factura
CREATE PROCEDURE proximaVenta
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(nro_venta)+1  FROM Ventas);
END
GO

CREATE PROCEDURE consultarFormasPago
AS
BEGIN
	
	SELECT * from formas_pago;
END
GO

CREATE PROCEDURE consultarObrasSociales
AS
BEGIN
	
	SELECT * from obras_sociales;
END
GO

CREATE PROCEDURE consultarTiposSuministros
AS
BEGIN
	
	SELECT * from tipos_suministros;
END
GO

--Suministros
CREATE PROCEDURE consultarSuministros
AS
BEGIN
	
	SELECT * from suministros;
END
GO


create PROCEDURE consultarVentas
	@fecha1 datetime,
	@fecha2 datetime,
	@cliente varchar(255) = ''
AS
BEGIN
	
	SELECT * from Ventas
	where fecha between @fecha1 and @fecha2 
	and cliente like '%'+@cliente+'%' and habilitada=1
END
GO

create PROCEDURE consultarVentasDeshabilitadas
	@fecha1 datetime,
	@fecha2 datetime,
	@cliente varchar(255)=''
AS
BEGIN
	
	SELECT * from Ventas
	where fecha between @fecha1 and @fecha2 
	and cliente like '%'+@cliente+'%' and (habilitada=0 or habilitada is null)
END
Go

create PROCEDURE consultarVenta
	@nro_venta int
AS
BEGIN
	SELECT Ventas.nro_venta, fecha, cliente,cod_forma_pago,cod_obra_social,
	cod_detalle_venta,cantidad,precio_venta,cubierto,
	suministros.cod_suministro, descripcion,precio_unitario,venta_libre,cod_tipo_sum,stock
	from Ventas join detalles_ventas on Ventas.nro_venta = detalles_ventas.nro_venta
	join suministros on detalles_ventas.cod_suministro = suministros.cod_suministro
	where @nro_venta = Ventas.nro_venta
END
GO

-- Maestro
create PROCEDURE insertarMaestro
	@fecha datetime,
	@cliente varchar(255), 
	@formaPago int,
	@codigoOS int,
	@nro_venta int OUTPUT
AS
BEGIN
	INSERT INTO Ventas 
    VALUES (@fecha,@cliente, @formaPago, @codigoOS, 1);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @nro_venta = SCOPE_IDENTITY();
END
GO

----- Detalle
create PROCEDURE insertarDetalle
	@nro_venta int,
	@cod_suministro int, 
	@cantidad int, 
	@precio money,
	@cubierto bit
AS
BEGIN
	INSERT INTO Detalles_ventas (nro_venta,cod_suministro,cantidad,precio_venta,cubierto)
	
    VALUES (@nro_venta, @cod_suministro, @cantidad, @precio,@cubierto);
  
END
GO

create PROCEDURE insertarSuministro
	@descripcion varchar(255),
	@precio_unitario money, 
	@venta_libre int,
	@cod_tipo_sum int,
	@stock int
AS
BEGIN
	declare @vl bit
	if @venta_libre =-1
		set @vl = null
	else
		set @vl = @venta_libre
	insert into suministros values( @descripcion,
		@precio_unitario,
		@vl,
		@cod_tipo_sum,
		@stock)
END
GO


create PROCEDURE modificarMaestro
	@nro_venta int,
	@fecha datetime,
	@cliente varchar(255), 
	@formaPago int,
	@codigoOS int
AS
BEGIN
	update Ventas 
	set fecha=@fecha, cliente=@cliente, cod_forma_pago=@formaPago, cod_obra_social=@codigoOS
    where @nro_venta=nro_venta

	delete Detalles_ventas where @nro_venta=nro_venta
END
GO

create PROCEDURE modificarDetalle
	@nro_venta int,
	@cod_suministro int, 
	@cantidad int, 
	@precio money,
	@cubierto bit
AS
BEGIN
	INSERT INTO Detalles_ventas (nro_venta,cod_suministro,cantidad,precio_venta,cubierto)
	VALUES (@nro_venta, @cod_suministro, @cantidad, @precio,@cubierto);
END
GO

create PROCEDURE modificarSuministro
	@cod_suministro int,
	@descripcion varchar(255),
	@precio_unitario money, 
	@venta_libre int,
	@cod_tipo_sum int,
	@stock int
AS
BEGIN
	declare @vl bit
	if @venta_libre =-1
		set @vl = null
	else
		set @vl = @venta_libre
	update suministros 
	set descripcion=@descripcion,
	precio_unitario=@precio_unitario,
	venta_libre=@vl,
	cod_tipo_sum=@cod_tipo_sum,
	stock=@stock
	where cod_suministro=@cod_suministro
END
GO

create PROCEDURE eliminarMaestro
	@nro_venta int
AS
BEGIN
		update ventas
		set habilitada = 0
		where nro_venta=@nro_venta
END
GO

create PROCEDURE eliminarSuministro
	@cod_suministro int
AS
BEGIN
		delete suministros where cod_suministro=@cod_suministro
END
GO

----- Formularios
create procedure consultar_ventas
	@fecha1 datetime,
	@fecha2 datetime
as
begin
	if @fecha1 < @fecha2
	begin
		select v.nro_venta,
		fecha,
		cliente,
		forma_pago,
		nom_obra_social,
		sum(cantidad) cantidad_total,
		sum(precio_venta*cantidad) importe_total
		from Ventas v
		join Formas_pago f on f.cod_forma_pago=v.cod_forma_pago
		join Obras_sociales o on o.cod_obra_social=v.cod_obra_social
		join Detalles_ventas dv on dv.nro_venta=v.nro_venta
		where fecha between @fecha1 and @fecha2 
		group by v.nro_venta,
		fecha,
		cliente,
		forma_pago,
		nom_obra_social
		order by 2 desc
	end
	else
	begin
		raiserror('Valores incorrectos',16,1)
	end
end
go

----2
create proc consultar_suministros

as
begin	
		select cod_suministro,
		descripcion,
		precio_unitario ,
		venta_libre,
		tipo_sum,
		stock 
		from Suministros s , Tipos_suministros t
		where t.cod_tipo_sum=s.cod_tipo_sum 
		order by 1 desc
	
end
go

--triggerss
create trigger NoRepetirNombres
on Usuarios
instead of insert
as
	if((select nombre from inserted) in (select nombre from usuarios))
	begin
		raiserror('Ese nombre se usuario ya ha sido utilizado', 16, 1)
	end
	else
	begin
		insert into Usuarios(nombre, constraseña) (select nombre, constraseña from inserted)
	end
go

create trigger dis_mod_stock
	on Detalles_ventas
	for insert
as
	declare @stock int
	select @stock= Stock from Suministros
	join inserted
	on inserted.cod_suministro=Suministros.cod_suministro
	if (@stock>=(select cantidad from inserted))
	update Suministros set Stock=Stock-inserted.cantidad
	from Suministros
	join inserted
	on inserted.cod_suministro=Suministros.cod_suministro
	else
	begin
	raiserror ('El stock en articulos es menor que la cantidad
	solicitada', 16, 1)
	rollback transaction
end
go

create trigger dis_del_stock
	on Detalles_ventas
	for delete
as
	update Suministros set Stock=Stock+deleted.cantidad
	from Suministros
	join deleted
	on deleted.cod_suministro=Suministros.cod_suministro
