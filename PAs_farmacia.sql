--0.1

alter proc pa_consultar_ventas 
	@fecha1 datetime,
	@fecha2 datetime,
	@cliente varchar(100)=''
as
begin
	if @fecha1 < @fecha2
	begin
		select v.nro_venta,
		fecha,
		cod_forma_pago,
		cod_cliente,
		cod_empleado
		from Ventas v
		where fecha between @fecha1 and @fecha2 and v.nro_venta like '%'+@cliente+'%'
		order by 2 desc
	end
	else
	begin
		raiserror('Valores incorrectos',16,1)
	end
end
go

exec pa_consultar_ventas '1/1/2000', '10/12/2022'
go


--0.2
create proc pa_consultar_compras
	@fecha1 datetime,
	@fecha2 datetime 
as
begin
	if @fecha1 < @fecha2
	begin
		select c.nro_compra,
		fecha,
		nom_repartidor repartidor,
		nombre proveedor,
		ape_empleado + ', ' + nom_empleado empleado,
		forma_pago,
		sum(dv.cantidad) cantidad,
		sum(dv.cantidad * dv.precio_venta) importe_total		
		from Compras c
		join Detalles_compras dv on c.nro_compra = dv.nro_compra
		join Proveedores p on c.cod_proveedor = p.cod_proveedor
		join Empleados e on c.cod_empleado = e.cod_empleado
		join Formas_pago f on c.cod_forma_pago = f.cod_forma_pago
		where fecha between @fecha1 and @fecha2
		group by c.nro_compra,fecha,
		nom_repartidor,
		nombre,
		ape_empleado, nom_empleado,
		forma_pago
		order by 2
	end
	else
	begin
		raiserror('Valores incorrectos',16,1)
	end
end
go

exec pa_consultar_compras'1/1/2000', '10/12/2022'
go


alter proc pa_ventas_vendedor
	@vendedor varchar(100),
	@minimo int,
	@fecha1 datetime,
	@fecha2 datetime
as
begin 
	select ape_empleado + ', ' + nom_empleado empleado,
	isnull(sum(r.gasto_total),0) importe_receta,
	sum(dv.gasto_total) importe_comun,
	sum(dv.gasto_total)+isnull(sum(r.gasto_total),0) importe_total,
	isnull(sum(r.cantidad_total),0) cantidad_receta,
	sum(dv.cantidad_total) cantidad_comun,
	sum(dv.cantidad_total)+isnull(sum(r.cantidad_total),0) cantidad_total
	from Empleados e
	join Ventas v on v.cod_empleado=e.cod_empleado
	left join (select nro_venta,sum(precio_venta*cantidad) gasto_total,
	sum(cantidad) cantidad_total from Detalles_ventas
	group by nro_venta) dv
	on v.nro_venta = dv.nro_venta
	left join (select nro_venta,
	sum(cantidad*precio_venta*(1-descuento*0.01)) gasto_total,
	sum(cantidad) cantidad_total from Recetas r
	join Cubiertos cu on cu.cod_cubierto = r.cod_cubierto
	group by nro_venta) r
	on v.nro_venta = r.nro_venta
	group by e.cod_empleado, ape_empleado + ', ' + nom_empleado
	having @minimo < (select count(distinct nro_venta) from ventas
	where fecha between @fecha1 and @fecha2 and e.cod_empleado=cod_empleado)
	and ape_empleado + ', ' + nom_empleado like '%'+@vendedor+'%'
end
go

exec pa_ventas_vendedor '', 0, '1/1/2000', '1/12/2022'
go

--3
alter procedure pa_reembolso_obrasocial

@fecha1 datetime,
@fecha2 datetime
as
 begin
if @fecha1 < @fecha2 
select year(fecha) anio, MONTH(fecha)mes, day(fecha)dia,
nom_obra_social obra_social,
count(r.cod_recetas) cantidad_recetas,
sum(precio_venta*(descuento*0.01))total_cobrado,
IIF(rembolsado=1,'Si', IIF(rembolsado=0,'No','Indefinido')) reembolso
from Lotes_Rembolso lr
join Recetas r on lr.cod_lote=r.cod_lote
join Cubiertos c on c.cod_cubierto=r.cod_cubierto
join Obras_sociales os on os.cod_obra_social=c.cod_obra_social
where  fecha between @fecha1 and @fecha2
group by fecha, nom_obra_social, rembolsado
order by fecha desc, nom_obra_social
end
go
exec pa_reembolso_obrasocial '1/1/2000', '1/12/2022'
go


--Login
create proc comprobarUsuario
@nombreUsuario varchar(100), @contrasenia varchar(100)
as
begin
	if(exists (select * from Usuarios where nombre=@nombreUsuario  and PWDCOMPARE(@contrasenia, 
	constraseña) = 1))
	begin
		return 1
	end
	else
	begin
		raiserror('Nombre de usuario o constraseña incorrecta', 16, 1)
		return 0
	end
end

-- proxima factura
CREATE PROCEDURE proximaFactura
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(nro_venta)+1  FROM Ventas);
END
GO
/****** Object:  StoredProcedure proximaFactura ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Suministros
CREATE PROCEDURE consultarSuministros
AS
BEGIN
	
	SELECT * from suministros;
END
GO
/****** Object:  StoredProcedure consultarSuministro ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Maestro
CREATE PROCEDURE insertarMaestro
	@fecha datetime,
	@cliente varchar(255), 
	@formaPago numeric(5,2),
	@codigoOS numeric(8,2),
	@presupuesto_nro int OUTPUT
AS
BEGIN
	INSERT INTO Ventas (fecha, cliente, cod_forma_pago, cod_obra_social)
    VALUES (@fecha,@cliente, @formaPago, @codigoOS);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @presupuesto_nro = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure insertarMaestro ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----- Detalle
create PROCEDURE insertarDetalle
	@nro_venta int,
	@cod_suministro int, 
	@cantidad int, 
	@precio int,
	@cubierto bit
AS
BEGIN
	INSERT INTO Detalles_ventas (nro_venta,cod_suministro,cantidad,precio_venta,cubierto)
	
    VALUES (@nro_venta, @cod_suministro, @cantidad, @precio,@cubierto);
  
END
GO
/****** Object:  StoredProcedure insetarDetalle ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
		cod_forma_pago,
		cod_obra_social
		from Ventas v
		where fecha between @fecha1 and @fecha2 
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

----- trigger modificacino stock
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
