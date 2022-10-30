use FARMACIA
go

insert into Provincias values('Cordoba');
insert into Provincias values('Buenos Aires');
insert into Provincias values('Santa Fe');
insert into Provincias values('Entre Rios');

insert into Localidades values('Cordoba', 1);
insert into Localidades values('Rio Cuarto',1);
insert into Localidades values('Villa María',1)
insert into Localidades values('CABA',2);
insert into Localidades values('La plata',2);
insert into Localidades values('Rosario',3);

insert into Barrios values('Alta Córdoba',1)
insert into Barrios values('Marquez de Sobremonte',1)
insert into Barrios values('Centro',1)
insert into Barrios values('Banda Norte',2)
insert into Barrios values('Los Olmos',3)
insert into Barrios values('Monserrat',4)
insert into Barrios values('Plaza España',6)

insert into Calles values('Jose Baigorri',1)
insert into Calles values('Nicolas Avellaneda',1)
insert into Calles values('Isabel la Catolica',1)
insert into Calles values('Tristan de tejeda',2)
insert into Calles values('27 de Abril',3)
insert into Calles values('Roberto Payro',4)
insert into Calles values('Av Belgrano',5)
insert into Calles values('25 de Mayo',6)
insert into Calles values('Hertiate',6)
insert into Calles values('Av Saavedra',7)

insert into Proveedores values('Marcus inc', 1, 133)
insert into Proveedores values('Mestarus', 4, 2555)
insert into Proveedores values('Head an should', 6, 345)
insert into Proveedores values('Tartane', 2, 222)
insert into Proveedores values('Pablitos inc', 8, 1001)

insert into Sucursales values(2, 1020)
insert into Sucursales values(7, 900)
insert into Sucursales values(10, 555)
insert into Sucursales values(3, 1213)
insert into Sucursales values(9, 3211)

insert into Clientes values('Juan','Bautista',    4431231,'4542645734',      'javier367@gmail.com');
insert into Clientes values('Tomas','Manasur',    4576757,'4542645734',   'tomasss389@outlook.com')
insert into Clientes values('Federico','Nortel',  3588888,'3514657444',						  null)
insert into Clientes values( 'Facundo','Cobrador', 4545453,'1238797973', 'facucobrador@hotmail.com')
insert into Clientes values( 'Maria','Sabina',     6555231,'6345889797', 					  null)
insert into Clientes values( 'Elon','Musk',        1431231,'3517878878',  'elon.musk4777@gmail.com')
insert into Clientes values( 'Beatriz','Alanel',   4768435,'3510707676',   'beabeaalanel@gmail.com')
insert into Clientes values( 'Javier','Jackson',   2545231,'4347886686', 					  null)

insert into Empleados values( 'Melina','Bautista',  9888831,'4120808090', 'bautistelena@hotmail.com','supervisor',1)
insert into Empleados values( 'Maximo','Peron',     4897893,'4909966999', 					    null,'supervisor',1)
insert into Empleados values( 'Nair','Trenia',      7881231,'3512272772', 'nair35634555@outlook.com','vendedor',2)
insert into Empleados values( 'Sebastian','Montero',5431231,'3512128777', 					    null,'vendedor',3)
insert into Empleados values( 'Carlos','Alto',      3689089,'3516454566',  'carlitos12124@gmail.com','vendedor',4)
insert into Empleados values( 'Benito','Deiz',      3689089,'3516454566',  'deizssss12124@gmail.com','vendedor',5)

insert into Formas_pago values('Efectivo')
insert into Formas_pago values('Tarjeta')
insert into Formas_pago values('Cuenta Bancaria')


insert into Compras values('02/01/2022', 3,   1,  'Marculin Perez', 1)
insert into Compras values('02/03/2022', 2,   1,  'Marculin Perez', 2)
insert into Compras values('02/01/2022', 1,   3,  'Tremos Pereira', 3)
insert into Compras values('14/02/2022', 4,   4,  'Paclito Mara', 1)
insert into Compras values('02/01/2022', 5,   2,  'Merlusa Perez', 3)
insert into Compras values('02/10/2022', 6,   5,  'Tomas Rere', 2)
insert into Compras values('20/02/2022', 2,   5,  'Mercado Perez', 1)
	
insert into Tipos_suministros values('Medicamentos')
insert into Tipos_suministros values('Perfumes')
insert into Tipos_suministros values('Otros')
	 
insert into Suministros values('Simvastatina', 120.5, 0, 1)
insert into Suministros values('Aspirina', 200, 1, 1)
insert into Suministros values('Omeprazol', 150.5, 0, 1)
insert into Suministros values('Paracetamol', 500.5, 1, 1)
insert into Suministros values('Ramipril', 100, 0, 1)
insert into Suministros values('Amlodipina', 125.5, 0, 1)
insert into Suministros values('One Million EDT', 500.5, null, 2)
insert into Suministros values('Atonio Banderas', 700.5, null, 2)
insert into Suministros values('Vendas', 400, null, 3)


insert into Detalles_compras values(1,1, 10, 1200)
insert into Detalles_compras values(1,2, 1, 180)
insert into Detalles_compras values(2,7, 10, 5000)
insert into Detalles_compras values(2,8, 10, 7000)
insert into Detalles_compras values(3,4, 3, 1500)
insert into Detalles_compras values(4,6, 1, 120)
insert into Detalles_compras values(5,3, 20, 3000)
insert into Detalles_compras values(6,5, 7, 700)
insert into Detalles_compras values(7,5, 7, 700)

insert into Obras_sociales values('Pami')
insert into Obras_sociales values('OSDOP')
insert into Obras_sociales values('OSDOP SADOP')
insert into Obras_sociales values('Union Personal')
insert into Obras_sociales values('Apross')

insert into Medicos values('Jose','Torres',17265)
insert into Medicos values('Yanina','Sandoval',19854)
insert into Medicos values('Miguel','Martinez',37950)
insert into Medicos values('Ricardo','Acosta',38563)
insert into Medicos values('Daniela','Garcia',218795)
insert into Medicos values('Lucas','Gonzales',207879)

insert into Cubiertos values(1,1,50,1)
insert into Cubiertos values(2,1,80,2)
insert into Cubiertos values(3,1,40,3)
insert into Cubiertos values(4,1,100,4)
insert into Cubiertos values(5,1,50,5)
insert into Cubiertos values(1,3,40,2)
insert into Cubiertos values(5,3,50,3)
insert into Cubiertos values(3,3,80,5)
insert into Cubiertos values(2,3,100,6)
insert into Cubiertos values(4,3,50,1)
insert into Cubiertos values(1,4,50,1)
insert into Cubiertos values(2,4,40,3)
insert into Cubiertos values(5,4,80,2)


insert into Ventas values('03/04/2022',1,3,1)
insert into Ventas values('03/08/2022',2,3,3)
insert into Ventas values('03/12/2022',2,3,1)
insert into Ventas values('03/08/2022',1,3,2)
insert into Ventas values('03/04/2022',4,4,1)
insert into Ventas values('04/05/2022',4,4,2)
insert into Ventas values('19/04/2022',5,4,2)
insert into Ventas values('15/04/2022',6,5,3)
insert into Ventas values('06/10/2022',3,6,1)
insert into ventas values('05/01/2022',8,6,1)

insert into Detalles_ventas values(1,1,2,180)
insert into Detalles_ventas values(1,9,2,1200)
insert into Detalles_ventas values(1,4,1,630)
insert into Detalles_ventas values(2,7,1,880)
insert into Detalles_ventas values(2,8,1,1120)
insert into Detalles_ventas values(3,5,8,150)
insert into Detalles_ventas values(3,2,10,250)
insert into Detalles_ventas values(4,6,7,180)
insert into Detalles_ventas values(5,3,2,200)
insert into Detalles_ventas values(5,2,1,250)
insert into Detalles_ventas values(5,9,1,1200)
insert into Detalles_ventas values(5,6,1,180)
insert into Detalles_ventas values(6,3,2,200)
insert into Detalles_ventas values(6,4,1,630)
insert into Detalles_ventas values(7,8,1,1120)
insert into Detalles_ventas values(8,1,2,380)
insert into Detalles_ventas values(8,9,1,1200)
insert into Detalles_ventas values(9,2,4,250)
insert into Detalles_ventas values(9,4,1,630)
insert into Detalles_ventas values(10,4,2,630)

insert into Lotes_Rembolso values(2,'15/05/2022',1)
insert into Lotes_Rembolso values(3,'15/05/2022',1)
insert into Lotes_Rembolso values(3,'15/06/2022',1)
insert into Lotes_Rembolso values(4,'30/05/2022',1)
insert into Lotes_Rembolso values(5,'30/11/2022',0)
insert into Lotes_Rembolso values(5,'01/03/2022',1)


insert into recetas values(1,6,1,1,2,150)
insert into recetas values(1,6,1,11,1,630)
insert into recetas values(5,5,2,8,2,580)
insert into recetas values(6,4,3,9,2,180)
insert into recetas values(6,4,3,12,1,130)
insert into recetas values(8,3,4,5,2,600)
insert into recetas values(9,2,5,11,1,270)
insert into recetas values(10,1,6,13,2,525)
