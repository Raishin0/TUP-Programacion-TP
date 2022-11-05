--create database FARMACIA_progra
--go
--use FARMACIA_progra
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
cod_tipo_sum int
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
cod_obra_social int
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

alter trigger NoRepetirNombres
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