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
exec comprobarUsuario 'Carlos', 'aguanteBOCA12'

-- proxima factura
CREATE PROCEDURE proximaFactura
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


CREATE PROCEDURE consultarVentas
	@fecha1 datetime,
	@fecha2 datetime,
	@cliente varchar(255)
AS
BEGIN
	
	SELECT * from Ventas
	where fecha between @fecha1 and @fecha2 
	and cliente like '%'+@cliente+'%'
END
GO

exec consultarVentas '1/1/2000', '12/12/2022', ''

alter PROCEDURE consultarVenta
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

exec consultarVenta 1

-- Maestro
create PROCEDURE insertarMaestro
	@fecha datetime,
	@cliente varchar(255), 
	@formaPago int,
	@codigoOS int,
	@nro_venta int OUTPUT
AS
BEGIN
	INSERT INTO Ventas (fecha, cliente, cod_forma_pago, cod_obra_social)
    VALUES (@fecha,@cliente, @formaPago, @codigoOS);
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
	@venta_libre bit,
	@cod_tipo_sum int,
	@stock int
AS
BEGIN
	insert into suministros values( @descripcion,
		@precio_unitario,
		@venta_libre,
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
	if exists(select cod_detalle_venta from Detalles_ventas where nro_venta=@nro_venta and cod_suministro=@cod_suministro)
	begin
		if @cantidad>0
		begin
			update Detalles_ventas 
			set cantidad=@cantidad,precio_venta=@precio,cubierto=@cubierto
			where nro_venta=@nro_venta and cod_suministro=@cod_suministro
		end
		else
		begin 
			delete Detalles_ventas 
			where nro_venta=@nro_venta and cod_suministro=@cod_suministro
		end
	end
	else
	begin
		INSERT INTO Detalles_ventas (nro_venta,cod_suministro,cantidad,precio_venta,cubierto)
		VALUES (@nro_venta, @cod_suministro, @cantidad, @precio,@cubierto);
	end
END
GO

create PROCEDURE modificarSuministro
	@cod_suministro int,
	@descripcion varchar(255),
	@precio_unitario money, 
	@venta_libre bit,
	@cod_tipo_sum int,
	@stock int
AS
BEGIN
	if exists(select cod_suministro from suministros where cod_suministro=@cod_suministro)
		update suministros 
		set descripcion=@descripcion,
		precio_unitario=@precio_unitario,
		venta_libre=@venta_libre,
		cod_tipo_sum=@cod_tipo_sum,
		stock=@stock
		where cod_suministro=@cod_suministro
END
GO


create PROCEDURE eliminarMaestro
	@nro_venta int
AS
BEGIN
	if exists(select nro_venta from ventas where nro_venta=@nro_venta)
	begin
		delete detalles_ventas where nro_venta=@nro_venta
		delete ventas where nro_venta=@nro_venta
	end
END
GO

create PROCEDURE eliminarSuministro
	@cod_suministro int
AS
BEGIN
	if exists(select cod_suministro from suministros where cod_suministro=@cod_suministro)
	begin
		delete suministros where cod_suministro=@cod_suministro
	end
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

exec consultar_ventas '1/1/2000','1/1/2023'
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
