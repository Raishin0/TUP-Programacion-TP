use FARMACIA_progra
go

insert into Formas_pago values('Efectivo')
insert into Formas_pago values('Tarjeta')
insert into Formas_pago values('Cuenta Bancaria')

insert into Tipos_suministros values('Medicamentos')
insert into Tipos_suministros values('Perfumes')
insert into Tipos_suministros values('Otros')
	 
insert into Suministros values('Aspirina', 200, 1, 1)
insert into Suministros values('Omeprazol', 150.5, 0, 1)
insert into Suministros values('Ramipril', 100, 0, 1)
insert into Suministros values('Paracetamol', 500.5, 1, 1)
insert into Suministros values('Simvastatina', 120.5, 0, 1)
insert into Suministros values('Amlodipina', 125.5, 0, 1)
insert into Suministros values('One Million EDT', 500.5, null, 2)
insert into Suministros values('Atonio Banderas', 700.5, null, 2)
insert into Suministros values('Vendas', 400, null, 3)

insert into Obras_sociales values('Sin OS')
insert into Obras_sociales values('Pami')
insert into Obras_sociales values('OSDOP')
insert into Obras_sociales values('OSDOP SADOP')
insert into Obras_sociales values('Union Personal')
insert into Obras_sociales values('Apross')

set dateformat DMY
insert into Ventas values('03/04/2022','Raul',3,1)
insert into Ventas values('03/08/2022','Javier',3,3)
insert into Ventas values('03/12/2022','Alberto',3,1)
insert into Ventas values('03/08/2022','Cristina',3,2)
insert into Ventas values('03/04/2022','Mauracio',1,1)
insert into Ventas values('04/05/2022','Sergio',2,4)
insert into Ventas values('19/04/2022','Patricia',2,4)
insert into Ventas values('15/04/2022','Sergio',1,3)
insert into Ventas values('06/10/2022','Juan',1,2)
insert into ventas values('05/01/2022','Anibal',2,5)

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

insert into Usuarios(nombre, constraseņa) values('Carlos', PWDENCRYPT('aguanteBOCA12'))
insert into Usuarios(nombre, constraseņa) values('Lucia', PWDENCRYPT('hola123'))

exec comprobarUsuario 'Carlos', 'aguanteBOCA12'
exec comprobarUsuario 'Lucia', 'hola123'

