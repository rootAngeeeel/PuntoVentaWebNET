CREATE DATABASE PVEF;

USE PV_Angel;

CREATE TABLE venta(
	id_venta int IDENTITY(1,1),
	total float,
	fecha datetime
);
GO 
ALTER TABLE venta ADD PRIMARY KEY (id_venta);

CREATE TABLE detalle_venta(
	id_detalle_venta int IDENTITY(1,1),
	id_venta int,
	precio_x_pieza float,
	cantidad int,
	descripcion varchar(150),
	importe float
);
GO
ALTER TABLE detalle_venta ADD PRIMARY KEY (id_detalle_venta);
ALTER TABLE detalle_venta ADD FOREIGN KEY (id_venta) REFERENCES venta(id_venta);

CREATE TABLE producto(
	id_producto int IDENTITY(1,1),
	nombre varchar(50),
	proveedor varchar(50)
);
GO
ALTER TABLE producto ADD PRIMARY KEY (id_producto);
INSERT INTO producto VALUES ('Bujias Gonher','Gonher','Bujia de alto rendimiento');
INSERT INTO producto VALUES ('Faro LED','Tamiya','Faro para cuartos led amarillo');
INSERT INTO producto VALUES ('Lantas R23','Pirelli','Llantas compuesto medio para doble proposito');
INSERT INTO producto VALUES ('Amortiguador','Boge','Amortiguador de aceite trasero');
INSERT INTO producto VALUES ('Carburador','Tomco','Carburador para volkswagen');
SELECT * FROM producto;
TRUNCATE TABLE producto;

SELECT * FROM venta;
SELECT * FROM detalle_venta;

TRUNCATE TABLE venta;
TRUNCATE TABLE detalle_venta;

DELETE FROM venta;
DELETE FROM detalle_venta WHERE id_detalle_venta = 75;

IF OBJECT_ID('ACTUALIZA') IS NOT NULL
BEGIN
       DROP TRIGGER ACTUALIZA
       PRINT 'TRIGGER ELIMINADO CORRECTAMENTE'
END
ELSE
       PRINT 'TRIGGER NO EXISTE'
GO

GO
CREATE TRIGGER ACTUALIZA
ON venta AFTER INSERT AS
BEGIN
	-- Obtener el valor actual de id_principal insertado en TablaPrincipal
    DECLARE @NuevoIdPrincipal INT;
    SELECT @NuevoIdPrincipal = id_venta FROM venta;
    
    -- Obtener el siguiente valor de id_principal
    DECLARE @SiguienteIdPrincipal INT;
    SELECT @SiguienteIdPrincipal = IDENT_CURRENT('venta') + 1;
    
    -- Actualizar id_secundario en TablaSecundaria
    UPDATE detalle_venta
    SET detalle_venta.id_venta = CASE
        WHEN detalle_venta.id_venta IS NULL THEN @NuevoIdPrincipal
        ELSE @SiguienteIdPrincipal
    END
    FROM detalle_venta 
    WHERE detalle_venta.id_venta IS NULL OR detalle_venta.id_venta = @NuevoIdPrincipal;

END


GO
ALTER TABLE venta
ENABLE TRIGGER ACTUALIZA