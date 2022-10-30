create database FARMACIA
go
use FARMACIA
go

CREATE TABLE Provincias
(id_provincia int identity(1,1),
nom_provincia varchar(50)
constraint pk_id_pronvias primary key (id_provincia))

create table Localidades
(cod_localidad int identity(1,1),
nom_localidad varchar (50),
id_provincia int
constraint pk_cod_localidad primary key (cod_localidad),
constraint fk_id_provincia foreign key (id_provincia)
references provincias (id_provincia))

create table Barrios
(cod_barrio int identity(1,1),
barrio varchar(50),
cod_localidad int
constraint pk_cod_barrio primary key (cod_barrio),
constraint fk_cod_localidad_barrio foreign key (cod_localidad)
references localidades (cod_localidad))

create table Calles
(cod_calle int identity(1,1),
calle varchar(50),
cod_barrio int
constraint pk_cod_calle primary key (cod_calle),
constraint fk_cod_barrio_calle foreign key (cod_barrio)
references barrios (cod_barrio))

create table Proveedores
(cod_proveedor int identity(1,1),
nombre varchar (50),
cod_direccion int,
altura int
constraint pk_cod_proveedor primary key (cod_proveedor),
constraint fk_cod_direccion_p foreign key (cod_direccion)
references calles (cod_calle))

create table Sucursales
(cod_sucursal int identity(1,1),
cod_direccion int,
altura int
constraint pk_cod_sucursal primary key (cod_sucursal),
constraint fk_cod_direccion_s foreign key (cod_direccion)
references calles (cod_calle))

create table Clientes
(cod_cliente int identity(1,1),
nom_cliente varchar(50),
ape_cliente varchar(50),
nro_doc int,
telefono varchar(50),
[e-mail] varchar(100)
constraint cod_cliente primary key (cod_cliente))

create table Empleados
(cod_empleado int identity(1,1),
nom_empleado varchar(50),
ape_empleado varchar(50),
nro_doc int,
telefono varchar(50),
[e-mail] varchar(100),
puesto varchar (100),
cod_sucursal int
constraint pk_cod_empleado primary key (cod_empleado)
constraint fk_cod_sucursal foreign key (cod_sucursal)
references sucursales (cod_sucursal))

create table Formas_pago
(cod_forma_pago int identity(1,1),
forma_pago varchar(100)
constraint pk_forma_pago primary key (cod_forma_pago))

create table Compras
(nro_compra int identity(1,1),
fecha datetime,
cod_empleado int,
cod_proveedor int,
nom_repartidor varchar(100),
cod_forma_pago int
constraint pk_nro_compra primary key (nro_compra)
constraint fk_cod_empleado foreign key (cod_empleado)
references empleados(cod_empleado),
constraint fk_cod_proveedor foreign key (cod_proveedor)
references proveedores(cod_proveedor),
constraint fk_pago foreign key (cod_forma_pago)
references formas_pago (cod_forma_pago))
	
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
constraint pk_suministro primary key(cod_suministro),
constraint fk_tipo foreign key (cod_tipo_sum)
references Tipos_suministros (cod_tipo_sum)
)


create table Detalles_compras
(cod_detalle_compra int identity(1,1),
nro_compra int,
cod_suministro int,
cantidad int,
precio_venta money
constraint pk_detalle primary key (cod_detalle_compra),
constraint fk_nro_compra foreign key (nro_compra)
references compras (nro_compra),
constraint fk_cod_suministro foreign key (cod_suministro)
references suministros (cod_suministro)
)
	
create table Lotes_Rembolso
(cod_lote int identity (1,1),
cod_sucursal int,
fecha datetime,
rembolsado  bit
constraint ok_cod_lote primary key (cod_lote),
constraint fk_cod_sucursal_r foreign key (cod_sucursal)
references sucursales(cod_sucursal))
	
create table Ventas
(nro_venta int identity(1,1),
fecha datetime,
cod_cliente int,
cod_empleado int,
cod_forma_pago int
constraint pk_venta primary key(nro_venta),
constraint fk_cliente foreign key (cod_cliente)
references clientes (cod_cliente),
constraint fk_empleado foreign key (cod_empleado)
references empleados(cod_empleado),
constraint fk_pago_v foreign key (cod_forma_pago)
references formas_pago(cod_forma_pago)
)
	
create table Detalles_ventas
(cod_detalle_venta int identity(1,1),
nro_venta int,
cod_suministro int,
cantidad int,
precio_venta money,
constraint pk_detalle_venta primary key (cod_detalle_venta),
constraint fk_venta foreign key (nro_venta)
references ventas(nro_venta),
constraint fk_cod_suministro_d foreign key (cod_suministro)
references suministros(cod_suministro),
)
create table Obras_sociales
(cod_obra_social int identity(1,1),
nom_obra_social varchar(100),
constraint pk_obra_social primary key (cod_obra_social)) 

create table Medicos
(cod_medico int identity(1,1),
nom_medico varchar (100),
ape_medico varchar (100),
matricula int
constraint pk_medico primary key (cod_medico)
)

create table Cubiertos
(cod_cubierto int identity(1,1),
cod_obra_social int,
cod_suministro int,
descuento int,
cod_localidad int
constraint pk_cubierto primary key (cod_cubierto),
constraint fk_obra_social_c foreign key (cod_obra_social)
references obras_sociales (cod_obra_social),
constraint fk_localidad_c foreign key (cod_localidad)
references localidades(cod_localidad)
)

create table Recetas
(cod_recetas int identity(1,1),
nro_venta int,
cod_medico int,
cod_lote int,
cod_cubierto int,
cantidad int,
precio_venta money 
constraint pk_receta primary key (cod_recetas),
constraint fk_venta_re foreign key (nro_venta)
references ventas (nro_venta),
constraint fk_medico_re foreign key (cod_medico)
references medicos (cod_medico),
constraint fk_lote_re foreign key (cod_lote)
references lotes_rembolso (cod_lote),
constraint fk_cod_cubierto_re foreign key (cod_cubierto)
references cubiertos (cod_cubierto)
)