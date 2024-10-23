CREATE DATABASE dbStreaming;
USE dbStreaming;

CREATE TABLE suscripciones(
codigoSuscripcion CHAR(5) NOT NULL,
nombreSuscripcion varchar(50) NOT NULL,
descripcion varchar(100) NOT NULL,
CONSTRAINT pkCodigoSuscripcion
PRIMARY KEY(codigoSuscripcion)
);

CREATE TABLE tiposUsuarios(
codigoTipoUsuario CHAR(5) NOT NULL,
tipoUsuario varchar(50) NOT NULL,
CONSTRAINT pkCodigoTipoUsuario 
PRIMARY KEY(codigoTipoUsuario)
);

CREATE TABLE facturas(
codigoFactura char(5) NOT NULL,
total money NOT NULL,
CONSTRAINT pkCodigoFactura 
PRIMARY KEY(codigoFactura)
);

CREATE TABLE usuarios(
codigoUsuario CHAR(5) NOT NULL,
nombres varchar(50) NOT NULL,
apellidos varchar(50) NOT NULL,
correo varchar(75) NOT NULL,
clave varchar(20) NOT NULL, -- Clave de usuario
fechaNacimiento date NOT NULL,
estadoCuenta varchar(25) NOT NULL,
codigoTipoUsuario CHAR(5) NOT NULL,
codigoSuscripcion CHAR(5) NOT NULL,
CONSTRAINT pkCodigoUsuario
PRIMARY KEY(codigoUsuario),
CONSTRAINT fkTipoUsuario
FOREIGN KEY(codigoTipoUsuario) REFERENCES tiposUsuarios(codigoTipoUsuario)
ON UPDATE CASCADE
ON DELETE CASCADE,
CONSTRAINT fkSuscripcion
FOREIGN KEY(codigoSuscripcion) REFERENCES suscripciones(codigoSuscripcion)
ON UPDATE CASCADE
ON DELETE CASCADE
);

CREATE TABLE detallesFacturas(
codigoFactura CHAR(5) NOT NULL,
codigoUsuario CHAR(5) NOT NULL,
subtotal money NOT NULL,
CONSTRAINT fkFacturaDetalle 
FOREIGN KEY(codigoFactura) REFERENCES facturas(codigoFactura)
ON UPDATE CASCADE
ON DELETE CASCADE,
CONSTRAINT fkUsuarioDetalle
FOREIGN KEY(codigoUsuario) REFERENCES usuarios(codigoUsuario)
ON UPDATE CASCADE
ON DELETE CASCADE
);

CREATE TABLE perfiles(
codigoPerfil CHAR(5) NOT NULL,
nombrePerfil VARCHAR(25) NOT NULL,
codigoUsuario CHAR(5) NOT NULL,
CONSTRAINT pkCodigoPerfil PRIMARY KEY(codigoPerfil),
CONSTRAINT fkUsuarioPerfil 
FOREIGN KEY(codigoUsuario) REFERENCES usuarios(codigoUsuario) 
ON UPDATE CASCADE
ON DELETE CASCADE
);

CREATE TABLE comentarios(
codigoComentario CHAR(5) NOT NULL,
comentario VARCHAR(900) NOT NULL,
codigoPerfil CHAR(5) NOT NULL,
CONSTRAINT pkCodigoComentario PRIMARY KEY(codigoComentario),
CONSTRAINT fkPerfilComentario
FOREIGN KEY(codigoPerfil) REFERENCES perfiles(codigoPerfil)
ON UPDATE CASCADE
ON DELETE CASCADE
);

CREATE TABLE categorias(
codigoCategoria CHAR(5) NOT NULL,
nombreCategoria VARCHAR(50) NOT NULL,
CONSTRAINT pkCodigoCategoria PRIMARY KEY(codigoCategoria)
);

CREATE TABLE productoras(
codigoProductora CHAR(5),
nombreProductora VARCHAR(100),
direccionProductora VARCHAR(200),
correoProductora VARCHAR(100),
telefonoProductora VARCHAR(15),
CONSTRAINT pkCodigoProductora PRIMARY KEY(codigoProductora)
);

CREATE TABLE descripciones(
codigoDescripcion CHAR(5) NOT NULL,
descripcion VARCHAR(500) NOT NULL,
clasificacionEdad VARCHAR(10) NOT NULL,
codigoProductora CHAR(5) NOT NULL,
CONSTRAINT pkCodigoDescripcion PRIMARY KEY(codigoDescripcion),
CONSTRAINT fkProductora 
FOREIGN KEY(codigoProductora) REFERENCES productoras(codigoProductora)
ON UPDATE CASCADE
ON DELETE CASCADE
);

CREATE TABLE detallesCategorias(
codigoDescripcion CHAR(5) NOT NULL,
codigoCategoria CHAR(5) NOT NULL,
CONSTRAINT fkDescripcionCategoria 
FOREIGN KEY(codigoDescripcion) REFERENCES descripciones(codigoDescripcion)
ON UPDATE CASCADE
ON DELETE CASCADE,
CONSTRAINT fkCategoria 
FOREIGN KEY(codigoCategoria) REFERENCES categorias(codigoCategoria)
ON UPDATE CASCADE
ON DELETE CASCADE
);



CREATE TABLE detallesComentarios(
codigoComentario CHAR(5) NOT NULL,
codigoDescripcion CHAR(5) NOT NULL,
CONSTRAINT fkComentarioDetalle
FOREIGN KEY(codigoComentario) REFERENCES comentarios(codigoComentario)
ON UPDATE CASCADE
ON DELETE CASCADE,
CONSTRAINT fkDescripcionComentario 
FOREIGN KEY(codigoDescripcion) REFERENCES descripciones(codigoDescripcion)
ON UPDATE CASCADE
ON DELETE CASCADE
);

CREATE TABLE peliculas(
codigoPelicula CHAR(5) NOT NULL,
nombrePelicula VARCHAR(100) NOT NULL,
codigoDescripcion CHAR(5) NOT NULL,
fechaEmision DATE NOT NULL,
duracion TIME NOT NULL,
CONSTRAINT pkCodigoPelicula PRIMARY KEY(codigoPelicula),
CONSTRAINT fkDescripcionPelicula
FOREIGN KEY(codigoDescripcion) REFERENCES descripciones(codigoDescripcion)
ON UPDATE CASCADE
ON DELETE CASCADE
);


CREATE TABLE series(
codigoSerie CHAR(5) NOT NULL,
nombreSerie VARCHAR(100) NOT NULL,
fechaEmisionInicio DATE NOT NULL,
fechaEmisionFin DATE NOT NULL,
codigoDescripcion CHAR(5) NOT NULL,
CONSTRAINT pkCodigoSerie PRIMARY KEY(codigoSerie),
CONSTRAINT fkDescripcionSerie 
FOREIGN KEY(codigoDescripcion) REFERENCES descripciones(codigoDescripcion)
ON UPDATE CASCADE
ON DELETE CASCADE
);

CREATE TABLE temporadas(
codigoTemporada CHAR(5) NOT NULL,
nombreTemporada VARCHAR(100) NOT NULL,
codigoSerie CHAR(5) NOT NULL,
fechaEmisionInicio DATE NOT NULL,
fechaEmisionFin DATE NOT NULL,
CONSTRAINT pkCodigoTemporada PRIMARY KEY(codigoTemporada),
CONSTRAINT fkSerieTemporada 
FOREIGN KEY(codigoSerie) REFERENCES series(codigoSerie)
ON UPDATE CASCADE
ON DELETE CASCADE
);

CREATE TABLE capitulos(
codigoCapitulo CHAR(5) NOT NULL,
codigoTemporada CHAR(5) NOT NULL,
nombreCapitulo VARCHAR(100) NOT NULL,
CONSTRAINT pkCodigoCapitulo PRIMARY KEY(codigoCapitulo),
CONSTRAINT fkTemporadaCapitulo
FOREIGN KEY(codigoTemporada) REFERENCES temporadas(codigoTemporada)
ON UPDATE CASCADE
ON DELETE CASCADE
);
GO

-- Trigger o disparador cuando se realiza una inserción en los Usuarios
CREATE TRIGGER Trg_InsertUsuario
ON usuarios
AFTER INSERT
AS
BEGIN
    -- Verificamos si el nuevo usuario es de tipo 'cliente'
    IF EXISTS (SELECT * FROM inserted WHERE codigoTipoUsuario = 'cliente') -- Corregir este codigo
    BEGIN
        -- Insertamos un nuevo perfil para el usuario
        INSERT INTO perfiles (codigoPerfil, nombrePerfil, codigoUsuario)
        SELECT 
            -- Generamos el codigoPerfil: 
			-- Primera letra del nombre + Primera letra del apellido + Número aleatorio de 3 dígitos
            UPPER(LEFT(i.nombres, 1)) + UPPER(LEFT(i.apellidos, 1)) + RIGHT(CAST(ABS(CHECKSUM(NEWID())) AS VARCHAR(3)), 3), 
            i.nombres,   -- Usamos el nombre del usuario como nombre del perfil
            i.codigoUsuario  -- Usamos el código del usuario recién insertado
        FROM inserted i;
    END
END;
GO

-- Trigger. Actualizar el total de la factura cuando se insertan, actualizan o eliminan detalles
CREATE TRIGGER trg_UpdateFacturaTotal
ON detallesFacturas
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @codigoFactura CHAR(5);

    -- Obtener el código de factura afectado
    IF EXISTS (SELECT 1 FROM inserted)
        SELECT TOP 1 @codigoFactura = codigoFactura FROM inserted;
    ELSE IF EXISTS (SELECT 1 FROM deleted)
        SELECT TOP 1 @codigoFactura = codigoFactura FROM deleted;

    -- Actualizar el total de la factura
    UPDATE facturas
    SET total = (
        SELECT ISNULL(SUM(subtotal), 0)
        FROM detallesFacturas
        WHERE codigoFactura = @codigoFactura
    )
    WHERE codigoFactura = @codigoFactura;
END;
GO

-- Trigger Actualizar el estado de la cuenta a 'Inactivo' cuando un usuario elimina su suscripción
CREATE TRIGGER trg_UpdateEstadoCuentaOnSuscripcionDelete
ON usuarios
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(codigoSuscripcion)
    BEGIN
        UPDATE u
        SET estadoCuenta = 'Inactivo'
        FROM usuarios u
        INNER JOIN inserted i ON u.codigoUsuario = i.codigoUsuario
        WHERE i.codigoSuscripcion IS NULL;
    END
END;
GO



-- Procedimiento almacenado para insertar un Usuario
CREATE PROCEDURE PA_InsertarUsuario
    @codigoUsuario CHAR(5),
    @nombres VARCHAR(50),
    @apellidos VARCHAR(50),
    @correo VARCHAR(75),
    @clave VARCHAR(20),
    @fechaNacimiento DATE,
    @estadoCuenta VARCHAR(25),
    @codigoTipoUsuario CHAR(5),
    @codigoSuscripcion CHAR(5)
AS
BEGIN
    -- Insertamos el nuevo usuario en la tabla usuarios
    INSERT INTO usuarios (codigoUsuario, nombres, apellidos, correo, clave, fechaNacimiento, estadoCuenta, codigoTipoUsuario, codigoSuscripcion)
    VALUES (@codigoUsuario, @nombres, @apellidos, @correo, @clave, @fechaNacimiento, @estadoCuenta, @codigoTipoUsuario, @codigoSuscripcion);

    -- El trigger Trg_InsertUsuario se activará automáticamente después de este insert si el usuario es de tipo 'cliente'
END;
GO

-- Procedimiento almacenado para actualizar un Usuario
CREATE PROCEDURE PA_ActualizarUsuario
    @codigoUsuario CHAR(5),
    @nombres VARCHAR(50),
    @apellidos VARCHAR(50),
    @correo VARCHAR(75),
    @clave VARCHAR(20),
    @fechaNacimiento DATE,
    @estadoCuenta VARCHAR(25),
    @codigoTipoUsuario CHAR(5),
    @codigoSuscripcion CHAR(5)
AS
BEGIN
    -- Actualizamos los datos del usuario en la tabla usuarios
    UPDATE usuarios
    SET 
        nombres = @nombres,
        apellidos = @apellidos,
        correo = @correo,
        clave = @clave,
        fechaNacimiento = @fechaNacimiento,
        estadoCuenta = @estadoCuenta,
        codigoTipoUsuario = @codigoTipoUsuario,
        codigoSuscripcion = @codigoSuscripcion
    WHERE codigoUsuario = @codigoUsuario;
END;
GO

-- Procedimiento almacenado para Eliminar un Usuario
CREATE PROCEDURE PA_EliminarUsuario
    @codigoUsuario CHAR(5)
AS
BEGIN
    -- Eliminar el perfil asociado al usuario
    DELETE FROM perfiles
    WHERE codigoUsuario = @codigoUsuario;

    -- Eliminar el usuario de la tabla usuarios
    DELETE FROM usuarios
    WHERE codigoUsuario = @codigoUsuario;
END;
GO

-- Vistas

CREATE VIEW vw_UsuariosDetalles AS
SELECT 
    u.codigoUsuario,
    u.nombres,
    u.apellidos,
    u.correo,
    u.fechaNacimiento,
    u.estadoCuenta,
    tu.tipoUsuario,
    s.nombreSuscripcion,
    s.descripcion AS descripcionSuscripcion
FROM usuarios u
INNER JOIN tiposUsuarios tu ON u.codigoTipoUsuario = tu.codigoTipoUsuario
INNER JOIN suscripciones s ON u.codigoSuscripcion = s.codigoSuscripcion;
GO

CREATE VIEW vw_PeliculasDetalles AS
SELECT 
    p.codigoPelicula,
    p.nombrePelicula,
    p.fechaEmision,
    p.duracion,
    d.descripcion,
    d.clasificacionEdad,
    pr.nombreProductora,
    c.nombreCategoria
FROM peliculas p
INNER JOIN descripciones d ON p.codigoDescripcion = d.codigoDescripcion
INNER JOIN productoras pr ON d.codigoProductora = pr.codigoProductora
INNER JOIN detallesCategorias dc ON d.codigoDescripcion = dc.codigoDescripcion
INNER JOIN categorias c ON dc.codigoCategoria = c.codigoCategoria;
GO

CREATE VIEW vw_SeriesDetalles AS
SELECT 
    s.codigoSerie,
    s.nombreSerie,
    s.fechaEmisionInicio AS serieFechaInicio,
    s.fechaEmisionFin AS serieFechaFin,
    t.codigoTemporada,
    t.nombreTemporada,
    t.fechaEmisionInicio AS temporadaFechaInicio,
    t.fechaEmisionFin AS temporadaFechaFin,
    c.codigoCapitulo,
    c.nombreCapitulo
FROM series s
INNER JOIN temporadas t ON s.codigoSerie = t.codigoSerie
INNER JOIN capitulos c ON t.codigoTemporada = c.codigoTemporada;
GO

CREATE VIEW vw_ComentariosDetalles AS
SELECT 
    com.codigoComentario,
    com.comentario,
    p.nombrePerfil,
    u.nombres AS nombreUsuario,
    u.apellidos AS apellidoUsuario,
    d.descripcion AS descripcionContenido
FROM comentarios com
INNER JOIN perfiles p ON com.codigoPerfil = p.codigoPerfil
INNER JOIN usuarios u ON p.codigoUsuario = u.codigoUsuario
INNER JOIN detallesComentarios dc ON com.codigoComentario = dc.codigoComentario
INNER JOIN descripciones d ON dc.codigoDescripcion = d.codigoDescripcion;
GO

-- Subconsultas

-- 1. Obtener usuarios que tienen más de un perfil
SELECT 
    u.codigoUsuario,
    u.nombres,
    u.apellidos,
    (SELECT COUNT(*) FROM perfiles p WHERE p.codigoUsuario = u.codigoUsuario) AS cantidadPerfiles
FROM usuarios u
WHERE (SELECT COUNT(*) FROM perfiles p WHERE p.codigoUsuario = u.codigoUsuario) > 1;
GO

-- 2. Listar películas que pertenecen a más de una categoría
SELECT 
    p.codigoPelicula,
    p.nombrePelicula,
    (SELECT COUNT(*) FROM detallesCategorias dc WHERE dc.codigoDescripcion = p.codigoDescripcion) AS cantidadCategorias
FROM peliculas p
WHERE (SELECT COUNT(*) FROM detallesCategorias dc WHERE dc.codigoDescripcion = p.codigoDescripcion) > 1;
GO

-- 3. Obtener el promedio de duración de las películas por categoría
SELECT 
    c.nombreCategoria,
    (SELECT AVG(DATEDIFF(MINUTE, '00:00:00', p.duracion))
     FROM peliculas p
     INNER JOIN descripciones d ON p.codigoDescripcion = d.codigoDescripcion
     INNER JOIN detallesCategorias dc ON d.codigoDescripcion = dc.codigoDescripcion
     WHERE dc.codigoCategoria = c.codigoCategoria) AS promedioDuracionMinutos
FROM categorias c;
GO

-- Procedimientos Almacenados

-- Tabla: suscripciones

CREATE PROCEDURE PA_InsertarSuscripcion
    @codigoSuscripcion CHAR(5),
    @nombreSuscripcion VARCHAR(50),
    @descripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO suscripciones (codigoSuscripcion, nombreSuscripcion, descripcion)
    VALUES (@codigoSuscripcion, @nombreSuscripcion, @descripcion);
END;
GO

CREATE PROCEDURE PA_ActualizarSuscripcion
    @codigoSuscripcion CHAR(5),
    @nombreSuscripcion VARCHAR(50),
    @descripcion VARCHAR(100)
AS
BEGIN
    UPDATE suscripciones
    SET 
        nombreSuscripcion = @nombreSuscripcion,
        descripcion = @descripcion
    WHERE codigoSuscripcion = @codigoSuscripcion;
END;
GO

CREATE PROCEDURE PA_EliminarSuscripcion
    @codigoSuscripcion CHAR(5)
AS
BEGIN
    DELETE FROM suscripciones
    WHERE codigoSuscripcion = @codigoSuscripcion;
END;
GO

-- Tabla: tiposUsuarios

CREATE PROCEDURE PA_InsertarTipoUsuario
    @codigoTipoUsuario CHAR(5),
    @tipoUsuario VARCHAR(50)
AS
BEGIN
    INSERT INTO tiposUsuarios (codigoTipoUsuario, tipoUsuario)
    VALUES (@codigoTipoUsuario, @tipoUsuario);
END;
GO

CREATE PROCEDURE PA_ActualizarTipoUsuario
    @codigoTipoUsuario CHAR(5),
    @tipoUsuario VARCHAR(50)
AS
BEGIN
    UPDATE tiposUsuarios
    SET tipoUsuario = @tipoUsuario
    WHERE codigoTipoUsuario = @codigoTipoUsuario;
END;
GO

CREATE PROCEDURE PA_EliminarTipoUsuario
    @codigoTipoUsuario CHAR(5)
AS
BEGIN
    DELETE FROM tiposUsuarios
    WHERE codigoTipoUsuario = @codigoTipoUsuario;
END;
GO

-- Tabla: facturas

CREATE PROCEDURE PA_InsertarFactura
    @codigoFactura CHAR(5),
    @total MONEY
AS
BEGIN
    INSERT INTO facturas (codigoFactura, total)
    VALUES (@codigoFactura, @total);
END;
GO

CREATE PROCEDURE PA_ActualizarFactura
    @codigoFactura CHAR(5),
    @total MONEY
AS
BEGIN
    UPDATE facturas
    SET total = @total
    WHERE codigoFactura = @codigoFactura;
END;
GO

CREATE PROCEDURE PA_EliminarFactura
    @codigoFactura CHAR(5)
AS
BEGIN
    DELETE FROM facturas
    WHERE codigoFactura = @codigoFactura;
END;
GO

-- Tabla: detallesFacturas

CREATE PROCEDURE PA_InsertarDetalleFactura
    @codigoFactura CHAR(5),
    @codigoUsuario CHAR(5),
    @subtotal MONEY
AS
BEGIN
    INSERT INTO detallesFacturas (codigoFactura, codigoUsuario, subtotal)
    VALUES (@codigoFactura, @codigoUsuario, @subtotal);
END;
GO

CREATE PROCEDURE PA_ActualizarDetalleFactura
    @codigoFactura CHAR(5),
    @codigoUsuario CHAR(5),
    @subtotal MONEY
AS
BEGIN
    UPDATE detallesFacturas
    SET subtotal = @subtotal
    WHERE codigoFactura = @codigoFactura AND codigoUsuario = @codigoUsuario;
END;
GO

CREATE PROCEDURE PA_EliminarDetalleFactura
    @codigoFactura CHAR(5),
    @codigoUsuario CHAR(5)
AS
BEGIN
    DELETE FROM detallesFacturas
    WHERE codigoFactura = @codigoFactura AND codigoUsuario = @codigoUsuario;
END;
GO

-- Tabla: perfiles

CREATE PROCEDURE PA_InsertarPerfil
    @codigoPerfil CHAR(5),
    @nombrePerfil VARCHAR(25),
    @codigoUsuario CHAR(5)
AS
BEGIN
    INSERT INTO perfiles (codigoPerfil, nombrePerfil, codigoUsuario)
    VALUES (@codigoPerfil, @nombrePerfil, @codigoUsuario);
END;
GO

CREATE PROCEDURE PA_ActualizarPerfil
    @codigoPerfil CHAR(5),
    @nombrePerfil VARCHAR(25),
    @codigoUsuario CHAR(5)
AS
BEGIN
    UPDATE perfiles
    SET 
        nombrePerfil = @nombrePerfil,
        codigoUsuario = @codigoUsuario
    WHERE codigoPerfil = @codigoPerfil;
END;
GO

CREATE PROCEDURE PA_EliminarPerfil
    @codigoPerfil CHAR(5)
AS
BEGIN
    DELETE FROM perfiles
    WHERE codigoPerfil = @codigoPerfil;
END;
GO

-- Tabla: comentarios

CREATE PROCEDURE PA_InsertarComentario
    @codigoComentario CHAR(5),
    @comentario VARCHAR(900),
    @codigoPerfil CHAR(5)
AS
BEGIN
    INSERT INTO comentarios (codigoComentario, comentario, codigoPerfil)
    VALUES (@codigoComentario, @comentario, @codigoPerfil);
END;
GO

CREATE PROCEDURE PA_ActualizarComentario
    @codigoComentario CHAR(5),
    @comentario VARCHAR(900),
    @codigoPerfil CHAR(5)
AS
BEGIN
    UPDATE comentarios
    SET 
        comentario = @comentario,
        codigoPerfil = @codigoPerfil
    WHERE codigoComentario = @codigoComentario;
END;
GO

CREATE PROCEDURE PA_EliminarComentario
    @codigoComentario CHAR(5)
AS
BEGIN
    DELETE FROM comentarios
    WHERE codigoComentario = @codigoComentario;
END;
GO


-- Tabla: categorias

CREATE PROCEDURE PA_InsertarCategoria
    @codigoCategoria CHAR(5),
    @nombreCategoria VARCHAR(50)
AS
BEGIN
    INSERT INTO categorias (codigoCategoria, nombreCategoria)
    VALUES (@codigoCategoria, @nombreCategoria);
END;
GO

CREATE PROCEDURE PA_ActualizarCategoria
    @codigoCategoria CHAR(5),
    @nombreCategoria VARCHAR(50)
AS
BEGIN
    UPDATE categorias
    SET nombreCategoria = @nombreCategoria
    WHERE codigoCategoria = @codigoCategoria;
END;
GO

CREATE PROCEDURE PA_EliminarCategoria
    @codigoCategoria CHAR(5)
AS
BEGIN
    DELETE FROM categorias
    WHERE codigoCategoria = @codigoCategoria;
END;
GO

-- Tabla: productoras

CREATE PROCEDURE PA_InsertarProductora
    @codigoProductora CHAR(5),
    @nombreProductora VARCHAR(100),
    @direccionProductora VARCHAR(200),
    @correoProductora VARCHAR(100),
    @telefonoProductora VARCHAR(15)
AS
BEGIN
    INSERT INTO productoras (codigoProductora, nombreProductora, direccionProductora, correoProductora, telefonoProductora)
    VALUES (@codigoProductora, @nombreProductora, @direccionProductora, @correoProductora, @telefonoProductora);
END;
GO

CREATE PROCEDURE PA_ActualizarProductora
    @codigoProductora CHAR(5),
    @nombreProductora VARCHAR(100),
    @direccionProductora VARCHAR(200),
    @correoProductora VARCHAR(100),
    @telefonoProductora VARCHAR(15)
AS
BEGIN
    UPDATE productoras
    SET 
        nombreProductora = @nombreProductora,
        direccionProductora = @direccionProductora,
        correoProductora = @correoProductora,
        telefonoProductora = @telefonoProductora
    WHERE codigoProductora = @codigoProductora;
END;
GO

CREATE PROCEDURE PA_EliminarProductora
    @codigoProductora CHAR(5)
AS
BEGIN
    DELETE FROM productoras
    WHERE codigoProductora = @codigoProductora;
END;
GO

-- Tabla: descripciones

CREATE PROCEDURE PA_InsertarDescripcion
    @codigoDescripcion CHAR(5),
    @descripcion VARCHAR(500),
    @clasificacionEdad VARCHAR(10),
    @codigoProductora CHAR(5)
AS
BEGIN
    INSERT INTO descripciones (codigoDescripcion, descripcion, clasificacionEdad, codigoProductora)
    VALUES (@codigoDescripcion, @descripcion, @clasificacionEdad, @codigoProductora);
END;
GO

CREATE PROCEDURE PA_ActualizarDescripcion
    @codigoDescripcion CHAR(5),
    @descripcion VARCHAR(500),
    @clasificacionEdad VARCHAR(10),
    @codigoProductora CHAR(5)
AS
BEGIN
    UPDATE descripciones
    SET 
        descripcion = @descripcion,
        clasificacionEdad = @clasificacionEdad,
        codigoProductora = @codigoProductora
    WHERE codigoDescripcion = @codigoDescripcion;
END;
GO

CREATE PROCEDURE PA_EliminarDescripcion
    @codigoDescripcion CHAR(5)
AS
BEGIN
    DELETE FROM descripciones
    WHERE codigoDescripcion = @codigoDescripcion;
END;
GO

-- Tabla: detallesCategorias

CREATE PROCEDURE PA_InsertarDetalleCategoria
    @codigoDescripcion CHAR(5),
    @codigoCategoria CHAR(5)
AS
BEGIN
    INSERT INTO detallesCategorias (codigoDescripcion, codigoCategoria)
    VALUES (@codigoDescripcion, @codigoCategoria);
END;
GO

CREATE PROCEDURE PA_EliminarDetalleCategoria
    @codigoDescripcion CHAR(5),
    @codigoCategoria CHAR(5)
AS
BEGIN
    DELETE FROM detallesCategorias
    WHERE codigoDescripcion = @codigoDescripcion AND codigoCategoria = @codigoCategoria;
END;
GO


-- Tabla: detallesComentarios

CREATE PROCEDURE PA_InsertarDetalleComentario
    @codigoComentario CHAR(5),
    @codigoDescripcion CHAR(5)
AS
BEGIN
    INSERT INTO detallesComentarios (codigoComentario, codigoDescripcion)
    VALUES (@codigoComentario, @codigoDescripcion);
END;
GO

CREATE PROCEDURE PA_EliminarDetalleComentario
    @codigoComentario CHAR(5),
    @codigoDescripcion CHAR(5)
AS
BEGIN
    DELETE FROM detallesComentarios
    WHERE codigoComentario = @codigoComentario AND codigoDescripcion = @codigoDescripcion;
END;
GO

-- Tabla: peliculas

CREATE PROCEDURE PA_InsertarPelicula
    @codigoPelicula CHAR(5),
    @nombrePelicula VARCHAR(100),
    @codigoDescripcion CHAR(5),
    @fechaEmision DATE,
    @duracion TIME
AS
BEGIN
    INSERT INTO peliculas (codigoPelicula, nombrePelicula, codigoDescripcion, fechaEmision, duracion)
    VALUES (@codigoPelicula, @nombrePelicula, @codigoDescripcion, @fechaEmision, @duracion);
END;
GO

CREATE PROCEDURE PA_ActualizarPelicula
    @codigoPelicula CHAR(5),
    @nombrePelicula VARCHAR(100),
    @codigoDescripcion CHAR(5),
    @fechaEmision DATE,
    @duracion TIME
AS
BEGIN
    UPDATE peliculas
    SET 
        nombrePelicula = @nombrePelicula,
        codigoDescripcion = @codigoDescripcion,
        fechaEmision = @fechaEmision,
        duracion = @duracion
    WHERE codigoPelicula = @codigoPelicula;
END;
GO

CREATE PROCEDURE PA_EliminarPelicula
    @codigoPelicula CHAR(5)
AS
BEGIN
    DELETE FROM peliculas
    WHERE codigoPelicula = @codigoPelicula;
END;
GO

-- Tabla: series

CREATE PROCEDURE PA_InsertarSerie
    @codigoSerie CHAR(5),
    @nombreSerie VARCHAR(100),
    @fechaEmisionInicio DATE,
    @fechaEmisionFin DATE,
    @codigoDescripcion CHAR(5)
AS
BEGIN
    INSERT INTO series (codigoSerie, nombreSerie, fechaEmisionInicio, fechaEmisionFin, codigoDescripcion)
    VALUES (@codigoSerie, @nombreSerie, @fechaEmisionInicio, @fechaEmisionFin, @codigoDescripcion);
END;
GO

CREATE PROCEDURE PA_ActualizarSerie
    @codigoSerie CHAR(5),
    @nombreSerie VARCHAR(100),
    @fechaEmisionInicio DATE,
    @fechaEmisionFin DATE,
    @codigoDescripcion CHAR(5)
AS
BEGIN
    UPDATE series
    SET 
        nombreSerie = @nombreSerie,
        fechaEmisionInicio = @fechaEmisionInicio,
        fechaEmisionFin = @fechaEmisionFin,
        codigoDescripcion = @codigoDescripcion
    WHERE codigoSerie = @codigoSerie;
END;
GO

CREATE PROCEDURE PA_EliminarSerie
    @codigoSerie CHAR(5)
AS
BEGIN
    DELETE FROM series
    WHERE codigoSerie = @codigoSerie;
END;
GO

-- Tabla: temporadas

CREATE PROCEDURE PA_InsertarTemporada
    @codigoTemporada CHAR(5),
    @nombreTemporada VARCHAR(100),
    @codigoSerie CHAR(5),
    @fechaEmisionInicio DATE,
    @fechaEmisionFin DATE
AS
BEGIN
    INSERT INTO temporadas (codigoTemporada, nombreTemporada, codigoSerie, fechaEmisionInicio, fechaEmisionFin)
    VALUES (@codigoTemporada, @nombreTemporada, @codigoSerie, @fechaEmisionInicio, @fechaEmisionFin);
END;
GO

CREATE PROCEDURE PA_ActualizarTemporada
    @codigoTemporada CHAR(5),
    @nombreTemporada VARCHAR(100),
    @codigoSerie CHAR(5),
    @fechaEmisionInicio DATE,
    @fechaEmisionFin DATE
AS
BEGIN
    UPDATE temporadas
    SET 
        nombreTemporada = @nombreTemporada,
        codigoSerie = @codigoSerie,
        fechaEmisionInicio = @fechaEmisionInicio,
        fechaEmisionFin = @fechaEmisionFin
    WHERE codigoTemporada = @codigoTemporada;
END;
GO

CREATE PROCEDURE PA_EliminarTemporada
    @codigoTemporada CHAR(5)
AS
BEGIN
    DELETE FROM temporadas
    WHERE codigoTemporada = @codigoTemporada;
END;
GO

-- Tabla: capitulos

CREATE PROCEDURE PA_InsertarCapitulo
    @codigoCapitulo CHAR(5),
    @codigoTemporada CHAR(5),
    @nombreCapitulo VARCHAR(100)
AS
BEGIN
    INSERT INTO capitulos (codigoCapitulo, codigoTemporada, nombreCapitulo)
    VALUES (@codigoCapitulo, @codigoTemporada, @nombreCapitulo);
END;
GO

CREATE PROCEDURE PA_ActualizarCapitulo
    @codigoCapitulo CHAR(5),
    @codigoTemporada CHAR(5),
    @nombreCapitulo VARCHAR(100)
AS
BEGIN
    UPDATE capitulos
    SET 
        codigoTemporada = @codigoTemporada,
        nombreCapitulo = @nombreCapitulo
    WHERE codigoCapitulo = @codigoCapitulo;
END;
GO

CREATE PROCEDURE PA_EliminarCapitulo
    @codigoCapitulo CHAR(5)
AS
BEGIN
    DELETE FROM capitulos
    WHERE codigoCapitulo = @codigoCapitulo;
END;
GO


-- Insertar registros en la tabla 'suscripciones'
INSERT INTO suscripciones (codigoSuscripcion, nombreSuscripcion, descripcion) VALUES
('S0001', 'Básico', 'Acceso a contenido estándar'),
('S0002', 'Estándar', 'Contenido en HD y múltiples dispositivos'),
('S0003', 'Premium', 'Contenido en Ultra HD y múltiples perfiles'),
('S0004', 'Familiar', 'Hasta 5 perfiles y contenido exclusivo'),
('S0005', 'Estudiante', 'Descuento especial para estudiantes'),
('S0006', 'Mensual', 'Suscripción mensual sin contratos'),
('S0007', 'Anual', 'Suscripción anual con descuento'),
('S0008', 'Trial', 'Prueba gratuita por un mes'),
('S0009', 'VIP', 'Acceso anticipado a nuevos contenidos'),
('S0010', 'Deportes', 'Contenido deportivo en vivo'),
('S0011', 'Niños', 'Contenido seguro para niños'),
('S0012', 'Documentales', 'Acceso exclusivo a documentales'),
('S0013', 'Cine', 'Estrenos de cine en casa'),
('S0014', 'Música', 'Videos y conciertos en vivo'),
('S0015', 'Noticias', 'Noticias en tiempo real'),
('S0016', 'Comedia', 'Especiales de comedia y stand-up'),
('S0017', 'Drama', 'Series y películas dramáticas'),
('S0018', 'Acción', 'Películas y series de acción'),
('S0019', 'Terror', 'Contenido de terror y suspenso'),
('S0020', 'Romance', 'Películas y series románticas'),
('S0021', 'Ciencia Ficción', 'Contenido de ciencia ficción'),
('S0022', 'Animación', 'Series y películas animadas'),
('S0023', 'Clásicos', 'Películas clásicas'),
('S0024', 'Internacional', 'Contenido de todo el mundo'),
('S0025', 'Educativo', 'Contenido educativo y cursos');
GO

-- Insertar registros en la tabla 'tiposUsuarios'
INSERT INTO tiposUsuarios (codigoTipoUsuario, tipoUsuario) VALUES
('TU001', 'Cliente'),
('TU002', 'Administrador'),
('TU003', 'Moderador'),
('TU004', 'Editor'),
('TU005', 'Invitado'),
('TU006', 'Colaborador'),
('TU007', 'Premium'),
('TU008', 'Básico'),
('TU009', 'VIP'),
('TU010', 'Estudiante'),
('TU011', 'Familiar'),
('TU012', 'Empleado'),
('TU013', 'Proveedor'),
('TU014', 'Desarrollador'),
('TU015', 'Tester'),
('TU016', 'Soporte'),
('TU017', 'Marketing'),
('TU018', 'Ventas'),
('TU019', 'Recursos Humanos'),
('TU020', 'Finanzas'),
('TU021', 'Legal'),
('TU022', 'Seguridad'),
('TU023', 'Operaciones'),
('TU024', 'Consultor'),
('TU025', 'Analista');
GO

-- Insertar registros en la tabla 'productoras'
INSERT INTO productoras (codigoProductora, nombreProductora, direccionProductora, correoProductora, telefonoProductora) VALUES
('P0001', 'DreamWorks', '1000 Flower St, Glendale, CA', 'contacto@dreamworks.com', '8181234567'),
('P0002', 'Pixar', '1200 Park Ave, Emeryville, CA', 'info@pixar.com', '5101234567'),
('P0003', 'Warner Bros', '4000 Warner Blvd, Burbank, CA', 'contact@warnerbros.com', '8185551234'),
('P0004', 'Universal Pictures', '100 Universal City Plaza, Universal City, CA', 'info@universal.com', '8187771000'),
('P0005', 'Paramount Pictures', '5555 Melrose Ave, Los Angeles, CA', 'contact@paramount.com', '3239565000'),
('P0006', 'Sony Pictures', '10202 W Washington Blvd, Culver City, CA', 'info@sonypictures.com', '3102444000'),
('P0007', '20th Century Studios', '10201 W Pico Blvd, Los Angeles, CA', 'contact@20thcentury.com', '3103691000'),
('P0008', 'Lionsgate', '2700 Colorado Ave, Santa Monica, CA', 'info@lionsgate.com', '3104499200'),
('P0009', 'MGM Studios', '245 N Beverly Dr, Beverly Hills, CA', 'contact@mgm.com', '3104493000'),
('P0010', 'New Line Cinema', '116 N Robertson Blvd, Los Angeles, CA', 'info@newline.com', '3108545811'),
('P0011', 'Studio Ghibli', '1-4-25 Kajino-cho, Koganei, Tokyo', 'contact@ghibli.jp', '8131234567'),
('P0012', 'Netflix Studios', '100 Winchester Cir, Los Gatos, CA', 'studios@netflix.com', '4085403700'),
('P0013', 'Amazon Studios', '1620 25th St, Santa Monica, CA', 'studios@amazon.com', '3105732305'),
('P0014', 'HBO Films', '30 Hudson Yards, New York, NY', 'contact@hbo.com', '2125121000'),
('P0015', 'Apple Studios', 'One Apple Park Way, Cupertino, CA', 'studios@apple.com', '4089961010'),
('P0016', 'BBC Studios', 'Television Centre, London', 'info@bbcstudios.com', '442087433000'),
('P0017', 'Gaumont', '30 Avenue Charles de Gaulle, Neuilly-sur-Seine', 'contact@gaumont.fr', '33146439100'),
('P0018', 'Canal+', '1 Place du Spectacle, Issy-les-Moulineaux', 'info@canalplus.fr', '33171406000'),
('P0019', 'Toei Animation', '2-10-5 Higashi-Ohizumi, Nerima, Tokyo', 'contact@toei-anim.co.jp', '81359289100'),
('P0020', 'Columbia Pictures', '10202 W Washington Blvd, Culver City, CA', 'info@columbia.com', '3102444000'),
('P0021', 'Focus Features', '100 Universal City Plaza, Universal City, CA', 'contact@focusfeatures.com', '8187777373'),
('P0022', 'A24', '31 W 27th St, New York, NY', 'info@a24films.com', '6465686015'),
('P0023', 'Blumhouse Productions', '2401 Beverly Blvd, Los Angeles, CA', 'contact@blumhouse.com', '3239569000'),
('P0024', 'Bad Robot', '1221 Olympic Blvd, Santa Monica, CA', 'info@badrobot.com', '3106643456'),
('P0025', 'Legendary Pictures', '2900 W Alameda Ave, Burbank, CA', 'contact@legendary.com', '8186887003');
GO

-- Insertar registros en la tabla 'categorias'
INSERT INTO categorias (codigoCategoria, nombreCategoria) VALUES
('C001', 'Acción'),
('C002', 'Aventura'),
('C003', 'Comedia'),
('C004', 'Drama'),
('C005', 'Terror'),
('C006', 'Ciencia Ficción'),
('C007', 'Romance'),
('C008', 'Thriller'),
('C009', 'Animación'),
('C010', 'Documental'),
('C011', 'Fantasía'),
('C012', 'Misterio'),
('C013', 'Musical'),
('C014', 'Deportes'),
('C015', 'Histórico'),
('C016', 'Crimen'),
('C017', 'Familia'),
('C018', 'Guerra'),
('C019', 'Biografía'),
('C020', 'Western'),
('C021', 'Noir'),
('C022', 'Reality'),
('C023', 'Game Show'),
('C024', 'Talk Show'),
('C025', 'Noticias');
GO

-- Insertar registros en la tabla 'descripciones'
INSERT INTO descripciones (codigoDescripcion, descripcion, clasificacionEdad, codigoProductora) VALUES
('D0001', 'Una aventura épica en un mundo fantástico.', 'PG-13', 'P0001'),
('D0002', 'Comedia romántica que te hará reír y llorar.', 'PG', 'P0002'),
('D0003', 'Documental sobre la vida marina.', 'G', 'P0004'),
('D0004', 'Película de acción llena de adrenalina.', 'R', 'P0003'),
('D0005', 'Serie de misterio con giros inesperados.', 'TV-14', 'P0005'),
('D0006', 'Animación para toda la familia.', 'G', 'P0006'),
('D0007', 'Drama histórico basado en hechos reales.', 'PG-13', 'P0007'),
('D0008', 'Thriller psicológico que te mantendrá en suspenso.', 'R', 'P0008'),
('D0009', 'Comedia negra con humor ácido.', 'R', 'P0009'),
('D0010', 'Película de terror que te quitará el sueño.', 'R', 'P0010'),
('D0011', 'Serie de ciencia ficción en el espacio.', 'TV-14', 'P0012'),
('D0012', 'Biografía de un personaje influyente.', 'PG-13', 'P0011'),
('D0013', 'Documental sobre culturas ancestrales.', 'G', 'P0013'),
('D0014', 'Película musical con números espectaculares.', 'PG', 'P0014'),
('D0015', 'Comedia familiar para todas las edades.', 'G', 'P0015'),
('D0016', 'Acción y aventura en un mundo post-apocalíptico.', 'R', 'P0016'),
('D0017', 'Drama romántico ambientado en los años 50.', 'PG-13', 'P0017'),
('D0018', 'Serie de crímenes y detectives.', 'TV-MA', 'P0018'),
('D0019', 'Película de fantasía con criaturas mágicas.', 'PG', 'P0019'),
('D0020', 'Thriller de espionaje internacional.', 'PG-13', 'P0020'),
('D0021', 'Animación japonesa con historias profundas.', 'PG-13', 'P0019'),
('D0022', 'Comedia de situación en un entorno laboral.', 'TV-PG', 'P0022'),
('D0023', 'Película de guerra basada en eventos reales.', 'R', 'P0023'),
('D0024', 'Documental sobre avances tecnológicos.', 'G', 'P0024'),
('D0025', 'Serie de fantasía épica con múltiples tramas.', 'TV-MA', 'P0025');
GO

-- Insertar registros en la tabla 'usuarios'
INSERT INTO usuarios (codigoUsuario, nombres, apellidos, correo, clave, fechaNacimiento, estadoCuenta, codigoTipoUsuario, codigoSuscripcion) VALUES
('U0001', 'Juan', 'Pérez', 'juan.perez@example.com', 'clave123', '1985-06-15', 'Activo', 'TU001', 'S0001'),
('U0002', 'María', 'González', 'maria.gonzalez@example.com', 'password', '1990-08-22', 'Activo', 'TU001', 'S0002'),
('U0003', 'Carlos', 'López', 'carlos.lopez@example.com', '123456', '1978-03-10', 'Inactivo', 'TU002', 'S0003'),
('U0004', 'Ana', 'Martínez', 'ana.martinez@example.com', 'ana2021', '1995-12-05', 'Activo', 'TU001', 'S0004'),
('U0005', 'Luis', 'García', 'luis.garcia@example.com', 'luispass', '1982-11-30', 'Activo', 'TU003', 'S0005'),
('U0006', 'Sofía', 'Rodríguez', 'sofia.rodriguez@example.com', 'sofiarocks', '1993-04-18', 'Activo', 'TU001', 'S0006'),
('U0007', 'Diego', 'Hernández', 'diego.hernandez@example.com', 'diego123', '1987-09-25', 'Activo', 'TU001', 'S0007'),
('U0008', 'Lucía', 'Fernández', 'lucia.fernandez@example.com', 'lucy89', '1992-07-13', 'Activo', 'TU001', 'S0008'),
('U0009', 'Jorge', 'Ruiz', 'jorge.ruiz@example.com', 'jorgepass', '1980-01-20', 'Activo', 'TU004', 'S0009'),
('U0010', 'Elena', 'Díaz', 'elena.diaz@example.com', 'elena2022', '1994-05-07', 'Activo', 'TU001', 'S0010'),
('U0011', 'Pedro', 'Torres', 'pedro.torres@example.com', 'pedro!', '1988-02-28', 'Activo', 'TU001', 'S0011'),
('U0012', 'Marta', 'Flores', 'marta.flores@example.com', 'marta123', '1991-10-16', 'Activo', 'TU001', 'S0012'),
('U0013', 'Alberto', 'Álvarez', 'alberto.alvarez@example.com', 'alberto', '1979-08-09', 'Inactivo', 'TU005', 'S0013'),
('U0014', 'Isabel', 'Giménez', 'isabel.gimenez@example.com', 'isa2022', '1986-03-03', 'Activo', 'TU001', 'S0014'),
('U0015', 'Fernando', 'Santos', 'fernando.santos@example.com', 'fernando', '1996-12-21', 'Activo', 'TU006', 'S0015'),
('U0016', 'Laura', 'Castro', 'laura.castro@example.com', 'lauraC', '1984-11-11', 'Activo', 'TU001', 'S0016'),
('U0017', 'Raúl', 'Ortiz', 'raul.ortiz@example.com', 'raul1234', '1990-06-27', 'Activo', 'TU001', 'S0017'),
('U0018', 'Patricia', 'Rubio', 'patricia.rubio@example.com', 'patri2021', '1993-09-14', 'Activo', 'TU001', 'S0018'),
('U0019', 'Andrés', 'Marín', 'andres.marin@example.com', 'andresM', '1981-04-01', 'Activo', 'TU007', 'S0019'),
('U0020', 'Sara', 'Sanz', 'sara.sanz@example.com', 'saraSS', '1992-11-19', 'Activo', 'TU001', 'S0020'),
('U0021', 'Miguel', 'Iglesias', 'miguel.iglesias@example.com', 'miguel', '1989-07-06', 'Activo', 'TU001', 'S0021'),
('U0022', 'Natalia', 'Mendoza', 'natalia.mendoza@example.com', 'natalia', '1995-02-23', 'Activo', 'TU001', 'S0022'),
('U0023', 'Jose', 'Romero', 'jose.romero@example.com', 'joseR', '1983-05-30', 'Inactivo', 'TU008', 'S0023'),
('U0024', 'Cristina', 'Vargas', 'cristina.vargas@example.com', 'cristinaV', '1991-09-08', 'Activo', 'TU001', 'S0024'),
('U0025', 'David', 'Cano', 'david.cano@example.com', 'davidC', '1987-12-17', 'Activo', 'TU009', 'S0025');
GO

-- Insertar registros en la tabla 'perfiles'
INSERT INTO perfiles (codigoPerfil, nombrePerfil, codigoUsuario) VALUES
('PF001', 'Perfil Juan', 'U0001'),
('PF002', 'Perfil María', 'U0002'),
('PF003', 'Perfil Ana', 'U0004'),
('PF004', 'Perfil Sofía', 'U0006'),
('PF005', 'Perfil Diego', 'U0007'),
('PF006', 'Perfil Lucía', 'U0008'),
('PF007', 'Perfil Elena', 'U0010'),
('PF008', 'Perfil Pedro', 'U0011'),
('PF009', 'Perfil Marta', 'U0012'),
('PF010', 'Perfil Isabel', 'U0014'),
('PF011', 'Perfil Laura', 'U0016'),
('PF012', 'Perfil Raúl', 'U0017'),
('PF013', 'Perfil Patricia', 'U0018'),
('PF014', 'Perfil Sara', 'U0020'),
('PF015', 'Perfil Miguel', 'U0021'),
('PF016', 'Perfil Natalia', 'U0022'),
('PF017', 'Perfil Cristina', 'U0024'),
('PF018', 'Perfil David', 'U0025'),
('PF019', 'Perfil Luis', 'U0005'),
('PF020', 'Perfil Fernando', 'U0015'),
('PF021', 'Perfil Andrés', 'U0019'),
('PF022', 'Perfil Jorge', 'U0009'),
('PF023', 'Perfil Jose', 'U0023'),
('PF024', 'Perfil Alberto', 'U0013'),
('PF025', 'Perfil Carlos', 'U0003');
GO


-- Insertar registros en la tabla 'comentarios'
INSERT INTO comentarios (codigoComentario, comentario, codigoPerfil) VALUES
('CM001', 'Excelente película, la recomiendo.', 'PF001'),
('CM002', 'La serie me enganchó desde el primer capítulo.', 'PF002'),
('CM003', 'El documental es muy informativo.', 'PF003'),
('CM004', 'No me gustó el final.', 'PF004'),
('CM005', 'Gran actuación del reparto.', 'PF005'),
('CM006', 'Esperaba más de esta película.', 'PF006'),
('CM007', 'La animación es impresionante.', 'PF007'),
('CM008', 'La trama es un poco lenta.', 'PF008'),
('CM009', 'La música es excelente.', 'PF009'),
('CM010', 'Me encantó, espero la próxima temporada.', 'PF010'),
('CM011', 'El guión es muy original.', 'PF011'),
('CM012', 'Los efectos especiales son sorprendentes.', 'PF012'),
('CM013', 'Una obra maestra del cine.', 'PF013'),
('CM014', 'El documental me hizo reflexionar.', 'PF014'),
('CM015', 'La película es muy emotiva.', 'PF015'),
('CM016', 'No es mi tipo de género.', 'PF016'),
('CM017', 'La dirección es magnífica.', 'PF017'),
('CM018', 'La serie tiene giros inesperados.', 'PF018'),
('CM019', 'La actuación es un poco floja.', 'PF019'),
('CM020', 'Me reí mucho con esta comedia.', 'PF020'),
('CM021', 'La historia es confusa.', 'PF021'),
('CM022', 'Gran trabajo de producción.', 'PF022'),
('CM023', 'El final es muy predecible.', 'PF023'),
('CM024', 'Me aburrió desde el inicio.', 'PF024'),
('CM025', 'Un clásico que no pasa de moda.', 'PF025');
GO

-- Insertar registros en la tabla 'facturas'
INSERT INTO facturas (codigoFactura, total) VALUES
('F0001', 15.99),
('F0002', 9.99),
('F0003', 19.99),
('F0004', 12.99),
('F0005', 17.99),
('F0006', 8.99),
('F0007', 22.99),
('F0008', 11.99),
('F0009', 14.99),
('F0010', 16.99),
('F0011', 13.99),
('F0012', 10.99),
('F0013', 18.99),
('F0014', 9.49),
('F0015', 20.99),
('F0016', 7.99),
('F0017', 21.99),
('F0018', 12.49),
('F0019', 19.49),
('F0020', 14.49),
('F0021', 16.49),
('F0022', 11.49),
('F0023', 13.49),
('F0024', 17.49),
('F0025', 15.49);
GO

-- Insertar registros en la tabla 'detallesFacturas'
INSERT INTO detallesFacturas (codigoFactura, codigoUsuario, subtotal) VALUES
('F0001', 'U0001', 15.99),
('F0002', 'U0002', 9.99),
('F0003', 'U0004', 19.99),
('F0004', 'U0006', 12.99),
('F0005', 'U0007', 17.99),
('F0006', 'U0008', 8.99),
('F0007', 'U0010', 22.99),
('F0008', 'U0011', 11.99),
('F0009', 'U0012', 14.99),
('F0010', 'U0014', 16.99),
('F0011', 'U0016', 13.99),
('F0012', 'U0017', 10.99),
('F0013', 'U0018', 18.99),
('F0014', 'U0020', 9.49),
('F0015', 'U0021', 20.99),
('F0016', 'U0022', 7.99),
('F0017', 'U0024', 21.99),
('F0018', 'U0025', 12.49),
('F0019', 'U0005', 19.49),
('F0020', 'U0015', 14.49),
('F0021', 'U0019', 16.49),
('F0022', 'U0009', 11.49),
('F0023', 'U0023', 13.49),
('F0024', 'U0013', 17.49),
('F0025', 'U0001', 15.49);
GO

-- Insertar registros en la tabla 'peliculas'
INSERT INTO peliculas (codigoPelicula, nombrePelicula, codigoDescripcion, fechaEmision, duracion) VALUES
('P0001', 'Aventura en el Bosque', 'D0001', '2020-05-15', '01:45:00'),
('P0002', 'Amor de Verano', 'D0002', '2019-08-20', '01:30:00'),
('P0003', 'El Océano Profundo', 'D0003', '2021-02-10', '01:50:00'),
('P0004', 'Velocidad Máxima', 'D0004', '2018-11-05', '02:00:00'),
('P0005', 'La Sombra del Enigma', 'D0005', '2020-09-25', '01:40:00'),
('P0006', 'Mundo Animado', 'D0006', '2019-12-18', '01:20:00'),
('P0007', 'El Pasado Olvidado', 'D0007', '2021-07-30', '02:10:00'),
('P0008', 'Mentiras Ocultas', 'D0008', '2017-06-12', '01:55:00'),
('P0009', 'Risas y Más Risas', 'D0009', '2019-03-22', '01:35:00'),
('P0010', 'Noche de Terror', 'D0010', '2020-10-31', '01:50:00'),
('P0011', 'Estrellas en el Universo', 'D0011', '2018-04-14', '02:05:00'),
('P0012', 'El Gran Genio', 'D0012', '2021-01-07', '01:45:00'),
('P0013', 'Raíces Ancestrales', 'D0013', '2019-11-29', '01:50:00'),
('P0014', 'Melodías del Corazón', 'D0014', '2020-02-14', '01:25:00'),
('P0015', 'Familia Unida', 'D0015', '2017-08-03', '01:30:00'),
('P0016', 'Camino al Futuro', 'D0016', '2021-05-20', '02:15:00'),
('P0017', 'Recuerdos del Ayer', 'D0017', '2018-12-25', '01:55:00'),
('P0018', 'Bajo Sospecha', 'D0018', '2020-07-07', '02:00:00'),
('P0019', 'El Reino Mágico', 'D0019', '2019-09-15', '01:40:00'),
('P0020', 'Código Secreto', 'D0020', '2021-03-08', '02:05:00'),
('P0021', 'Almas Gemelas', 'D0021', '2017-10-19', '01:50:00'),
('P0022', 'Oficina en Caos', 'D0022', '2019-06-28', '01:35:00'),
('P0023', 'Batalla en el Frente', 'D0023', '2020-12-11', '02:10:00'),
('P0024', 'Innovación Tecnológica', 'D0024', '2018-01-05', '01:45:00'),
('P0025', 'Leyendas Eternas', 'D0025', '2021-08-16', '02:20:00');
GO

-- Insertar registros en la tabla 'series'
INSERT INTO series (codigoSerie, nombreSerie, fechaEmisionInicio, fechaEmisionFin, codigoDescripcion) VALUES
('S0001', 'Misterios del Tiempo', '2017-01-10', '2019-12-20', 'D0005'),
('S0002', 'Universo Desconocido', '2018-05-15', '2020-11-25', 'D0011'),
('S0003', 'La Vida en el Espacio', '2019-03-22', '2021-07-30', 'D0018'),
('S0004', 'Historias de Amor', '2016-09-05', '2018-06-18', 'D0017'),
('S0005', 'Crónicas de Guerra', '2017-12-01', '2020-08-14', 'D0023'),
('S0006', 'Risas en la Oficina', '2018-04-10', '2021-02-28', 'D0022'),
('S0007', 'Fantasía y Realidad', '2019-07-05', '2021-09-15', 'D0025'),
('S0008', 'El Detective', '2016-11-20', '2019-05-27', 'D0018'),
('S0009', 'Caminos Cruzados', '2017-08-14', '2020-03-22', 'D0017'),
('S0010', 'Leyendas Urbanas', '2018-02-05', '2020-10-10', 'D0025'),
('S0011', 'Mundo Animal', '2019-06-18', '2021-04-05', 'D0003'),
('S0012', 'Tecnología Hoy', '2016-12-30', '2019-09-12', 'D0024'),
('S0013', 'El Arte de Cocinar', '2017-05-23', '2020-01-17', 'D0009'),
('S0014', 'Viajeros en el Tiempo', '2018-08-08', '2021-06-20', 'D0011'),
('S0015', 'Historias de la Vida', '2019-11-02', '2021-12-15', 'D0012'),
('S0016', 'La Aventura Continúa', '2016-04-19', '2019-07-28', 'D0001'),
('S0017', 'Mentes Criminales', '2017-09-11', '2020-05-06', 'D0018'),
('S0018', 'Amistades Peligrosas', '2018-03-30', '2021-08-22', 'D0008'),
('S0019', 'El Universo y Más Allá', '2019-12-15', '2021-10-30', 'D0011'),
('S0020', 'Secretos del Pasado', '2016-06-25', '2019-02-18', 'D0017'),
('S0021', 'La Comedia de la Vida', '2017-11-07', '2020-09-14', 'D0009'),
('S0022', 'Mundo Virtual', '2018-05-19', '2021-01-31', 'D0024'),
('S0023', 'Leyendas del Futuro', '2019-09-03', '2021-07-19', 'D0025'),
('S0024', 'El Arte del Engaño', '2016-10-28', '2019-06-05', 'D0008'),
('S0025', 'Historias de Terror', '2017-02-13', '2020-11-27', 'D0010');
GO

-- Insertar registros en la tabla 'temporadas'
INSERT INTO temporadas (codigoTemporada, nombreTemporada, codigoSerie, fechaEmisionInicio, fechaEmisionFin) VALUES
('T0001', 'Temporada 1', 'S0001', '2017-01-10', '2017-06-15'),
('T0002', 'Temporada 2', 'S0001', '2018-01-20', '2018-06-25'),
('T0003', 'Temporada 3', 'S0001', '2019-01-30', '2019-06-30'),
('T0004', 'Temporada 1', 'S0002', '2018-05-15', '2018-11-20'),
('T0005', 'Temporada 2', 'S0002', '2019-05-25', '2019-11-28'),
('T0006', 'Temporada 3', 'S0002', '2020-05-30', '2020-11-25'),
('T0007', 'Temporada 1', 'S0003', '2019-03-22', '2019-09-15'),
('T0008', 'Temporada 2', 'S0003', '2020-03-27', '2020-09-18'),
('T0009', 'Temporada 3', 'S0003', '2021-03-30', '2021-07-30'),
('T0010', 'Temporada 1', 'S0004', '2016-09-05', '2017-03-10'),
('T0011', 'Temporada 2', 'S0004', '2017-09-15', '2018-03-18'),
('T0012', 'Temporada 1', 'S0005', '2017-12-01', '2018-06-05'),
('T0013', 'Temporada 2', 'S0005', '2018-12-10', '2019-06-12'),
('T0014', 'Temporada 3', 'S0005', '2019-12-15', '2020-08-14'),
('T0015', 'Temporada 1', 'S0006', '2018-04-10', '2019-01-15'),
('T0016', 'Temporada 2', 'S0006', '2019-04-20', '2020-01-25'),
('T0017', 'Temporada 3', 'S0006', '2020-04-30', '2021-02-28'),
('T0018', 'Temporada 1', 'S0007', '2019-07-05', '2020-02-10'),
('T0019', 'Temporada 2', 'S0007', '2020-07-15', '2021-02-20'),
('T0020', 'Temporada 3', 'S0007', '2021-07-25', '2021-09-15'),
('T0021', 'Temporada 1', 'S0008', '2016-11-20', '2017-05-25'),
('T0022', 'Temporada 2', 'S0008', '2017-11-30', '2018-05-27'),
('T0023', 'Temporada 3', 'S0008', '2018-11-05', '2019-05-27'),
('T0024', 'Temporada 1', 'S0009', '2017-08-14', '2018-02-18'),
('T0025', 'Temporada 2', 'S0009', '2018-08-24', '2019-03-22');
GO

-- Insertar registros en la tabla 'capitulos'
INSERT INTO capitulos (codigoCapitulo, codigoTemporada, nombreCapitulo) VALUES
('C0001', 'T0001', 'El Inicio'),
('C0002', 'T0001', 'El Misterio'),
('C0003', 'T0001', 'La Búsqueda'),
('C0004', 'T0002', 'Nuevos Descubrimientos'),
('C0005', 'T0002', 'El Enigma'),
('C0006', 'T0003', 'La Revelación'),
('C0007', 'T0003', 'El Final'),
('C0008', 'T0004', 'Universo Oculto'),
('C0009', 'T0004', 'Planetas Lejanos'),
('C0010', 'T0005', 'Estrellas y Galaxias'),
('C0011', 'T0005', 'Vida Extraterrestre'),
('C0012', 'T0006', 'El Misterio del Espacio'),
('C0013', 'T0007', 'La Estación Espacial'),
('C0014', 'T0007', 'Misión a Marte'),
('C0015', 'T0008', 'Regreso a la Luna'),
('C0016', 'T0009', 'Más Allá del Sistema Solar'),
('C0017', 'T0010', 'Un Nuevo Amor'),
('C0018', 'T0011', 'Corazones Rotos'),
('C0019', 'T0011', 'Reencuentros'),
('C0020', 'T0012', 'La Primera Batalla'),
('C0021', 'T0013', 'Estrategias'),
('C0022', 'T0014', 'La Victoria'),
('C0023', 'T0015', 'Día de Trabajo'),
('C0024', 'T0016', 'La Fiesta de la Oficina'),
('C0025', 'T0017', 'Nuevos Empleados');
GO

-- Insertar registros en la tabla 'detallesCategorias'
INSERT INTO detallesCategorias (codigoDescripcion, codigoCategoria) VALUES
('D0001', 'C002'),
('D0002', 'C007'),
('D0003', 'C010'),
('D0004', 'C001'),
('D0005', 'C012'),
('D0006', 'C009'),
('D0007', 'C015'),
('D0008', 'C008'),
('D0009', 'C003'),
('D0010', 'C005'),
('D0011', 'C006'),
('D0012', 'C019'),
('D0013', 'C010'),
('D0014', 'C013'),
('D0015', 'C017'),
('D0016', 'C006'),
('D0017', 'C004'),
('D0018', 'C016'),
('D0019', 'C011'),
('D0020', 'C008'),
('D0021', 'C009'),
('D0022', 'C003'),
('D0023', 'C018'),
('D0024', 'C010'),
('D0025', 'C011');
GO

-- Insertar registros en la tabla 'detallesComentarios'
INSERT INTO detallesComentarios (codigoComentario, codigoDescripcion) VALUES
('CM001', 'D0001'),
('CM002', 'D0005'),
('CM003', 'D0003'),
('CM004', 'D0004'),
('CM005', 'D0007'),
('CM006', 'D0002'),
('CM007', 'D0006'),
('CM008', 'D0008'),
('CM009', 'D0014'),
('CM010', 'D0017'),
('CM011', 'D0012'),
('CM012', 'D0016'),
('CM013', 'D0015'),
('CM014', 'D0013'),
('CM015', 'D0010'),
('CM016', 'D0009'),
('CM017', 'D0011'),
('CM018', 'D0018'),
('CM019', 'D0020'),
('CM020', 'D0022'),
('CM021', 'D0019'),
('CM022', 'D0024'),
('CM023', 'D0021'),
('CM024', 'D0023'),
('CM025', 'D0025');
GO

-- **CONSULTAS DE BÚSQUEDA (SELECT)**

-- 1. Seleccionar todos los usuarios que tienen estado 'Activo'
SELECT * FROM usuarios WHERE estadoCuenta = 'Activo';
GO

-- 2. Seleccionar todas las películas estrenadas después de 2020
SELECT * FROM peliculas WHERE fechaEmision > '2020-12-31';
GO

-- 3. Seleccionar todos los comentarios realizados por 'Perfil Paula'
SELECT c.*
FROM comentarios c
INNER JOIN perfiles p ON c.codigoPerfil = p.codigoPerfil
WHERE p.nombrePerfil = 'Perfil Paula';
GO

-- 4. Seleccionar todos los perfiles asociados con 'Paula Morales'
SELECT p.*
FROM perfiles p
INNER JOIN usuarios u ON p.codigoUsuario = u.codigoUsuario
WHERE u.nombres = 'Paula' AND u.apellidos = 'Morales';
GO

-- 5. Seleccionar todas las películas de la categoría 'Educación'
SELECT pel.*
FROM peliculas pel
INNER JOIN descripciones d ON pel.codigoDescripcion = d.codigoDescripcion
INNER JOIN detallesCategorias dc ON d.codigoDescripcion = dc.codigoDescripcion
INNER JOIN categorias c ON dc.codigoCategoria = c.codigoCategoria
WHERE c.nombreCategoria = 'Educación';
GO

-- 6. Seleccionar todas las series y sus temporadas
SELECT s.nombreSerie, t.nombreTemporada
FROM series s
INNER JOIN temporadas t ON s.codigoSerie = t.codigoSerie;
GO

-- 7. Seleccionar el monto total de cada factura
SELECT f.codigoFactura, f.total
FROM facturas f;
GO

-- 8. Seleccionar los usuarios junto con el nombre de su suscripción
SELECT u.nombres, u.apellidos, s.nombreSuscripcion
FROM usuarios u
INNER JOIN suscripciones s ON u.codigoSuscripcion = s.codigoSuscripcion;
GO

-- 9. Seleccionar todas las productoras ubicadas en 'Los Angeles, CA'
SELECT * FROM productoras WHERE direccionProductora LIKE '%Los Angeles, CA%';
GO

-- 10. Calcular la duración promedio de las películas
SELECT AVG(DATEDIFF(MINUTE, '00:00:00', duracion)) AS PromedioDuracionMinutos
FROM peliculas;
GO

-- **CONSULTAS DE ELIMINACIÓN (DELETE)**

-- 1. Eliminar el comentario con código 'CM025'
DELETE FROM comentarios WHERE codigoComentario = 'CM025';
GO

-- 2. Eliminar el perfil con código 'PF025'
DELETE FROM perfiles WHERE codigoPerfil = 'PF025';
GO

-- 3. Eliminar el usuario con código 'U0025'
DELETE FROM usuarios WHERE codigoUsuario = 'U0025';
GO

-- 4. Eliminar la película con código 'P0025'
DELETE FROM peliculas WHERE codigoPelicula = 'P0025';
GO

-- 5. Eliminar la descripción con código 'D0025'
DELETE FROM descripciones WHERE codigoDescripcion = 'D0025';
GO

-- 6. Eliminar la categoría con código 'C025'
DELETE FROM categorias WHERE codigoCategoria = 'C025';
GO

-- 7. Eliminar la productora con código 'P0025'
DELETE FROM productoras WHERE codigoProductora = 'P0025';
GO

-- 8. Eliminar todos los usuarios que tienen estado 'Inactivo'
DELETE FROM usuarios WHERE estadoCuenta = 'Inactivo';
GO


-- 9. Eliminar todos los comentarios realizados antes del año 2000
DELETE FROM comentarios WHERE codigoComentario IN (
    SELECT c.codigoComentario
    FROM comentarios c
    INNER JOIN perfiles p ON c.codigoPerfil = p.codigoPerfil
    INNER JOIN usuarios u ON p.codigoUsuario = u.codigoUsuario
    WHERE u.fechaNacimiento < '2000-01-01'
);
GO

-- 10. Eliminar todos los detalles de facturas para el usuario 'U0001'
DELETE FROM detallesFacturas WHERE codigoUsuario = 'U0001';
GO

-- **CONSULTAS DE ACTUALIZACIÓN (UPDATE)**

-- 1. Actualizar el correo electrónico de 'Paula Morales'
UPDATE usuarios SET correo = 'paula.m@example.com' WHERE codigoUsuario = 'U0025';
GO

-- 2. Actualizar el nombre de la suscripción 'Gaming' a 'eSports'
UPDATE suscripciones SET nombreSuscripcion = 'eSports' WHERE codigoSuscripcion = 'S0025';
GO

-- 3. Actualizar el estado de todos los usuarios 'Inactivo' a 'Activo'
UPDATE usuarios SET estadoCuenta = 'Activo' WHERE estadoCuenta = 'Inactivo';
GO

-- 4. Actualizar la duración de 'Viaje al Universo' a '01:45:00'
UPDATE peliculas SET duracion = '01:45:00' WHERE codigoPelicula = 'P0025';
GO

-- 5. Actualizar la descripción con código 'D0025'
UPDATE descripciones SET descripcion = 'Documental actualizado sobre el espacio' WHERE codigoDescripcion = 'D0025';
GO

-- 6. Actualizar la contraseña del usuario 'U0001' a 'nuevaClave123'
UPDATE usuarios SET clave = 'nuevaClave123' WHERE codigoUsuario = 'U0001';
GO

-- 7. Actualizar el estado de la cuenta del usuario 'U0003' a 'Activo'
UPDATE usuarios SET estadoCuenta = 'Activo' WHERE codigoUsuario = 'U0003';
GO

-- 8. Actualizar el nombre de la categoría 'C025' a 'Educativo'
UPDATE categorias SET nombreCategoria = 'Educativo' WHERE codigoCategoria = 'C025';
GO

-- 9. Actualizar el nombre de la productora 'P0025' a 'EduFilms'
UPDATE productoras SET nombreProductora = 'EduFilms' WHERE codigoProductora = 'P0025';
GO

-- 10. Actualizar el total de la factura 'F0001' a 20.99
UPDATE facturas SET total = 20.99 WHERE codigoFactura = 'F0001';
GO


CREATE VIEW vw_Series AS
SELECT s.codigoSerie,s.nombreSerie,s.fechaEmisionInicio,s.fechaEmisionFin,s.codigoDescripcion,d.descripcion,d.clasificacionEdad,p.codigoProductora
FROM series s
INNER JOIN descripciones d
ON s.codigoDescripcion=d.codigoDescripcion
INNER JOIN productoras p
ON d.codigoProductora=p.codigoProductora;
GO

-- Crear una vista llamada 'VistaSuscripcionesConUsuarios'
CREATE VIEW vw_suscripcionesUsuarios AS

-- Seleccionar los campos necesarios de la tabla 'suscripciones' y contar los usuarios
SELECT 
    s.codigoSuscripcion,             -- Seleccionamos el c�digo de la suscripci�n
    s.nombreSuscripcion,             -- Seleccionamos el nombre de la suscripci�n
    s.descripcion,                   -- Seleccionamos la descripci�n de la suscripci�n
    COUNT(u.codigoUsuario) AS cantidadUsuarios  -- Contamos cu�ntos usuarios tienen esta suscripci�n
FROM 
    suscripciones s                  -- Tabla de suscripciones con alias 's'
    
-- Hacemos un LEFT JOIN con la tabla 'usuarios' para incluir todos los registros de 'suscripciones', 
-- incluso aquellos que no tienen usuarios asociados
LEFT JOIN 
    usuarios u 
ON 
    s.codigoSuscripcion = u.codigoSuscripcion  -- Unimos las tablas por el campo com�n 'codigoSuscripcion'

-- Agrupar los resultados por los campos de la tabla 'suscripciones'
GROUP BY 
    s.codigoSuscripcion,             -- Agrupamos por el c�digo de la suscripci�n
    s.nombreSuscripcion,             -- Agrupamos por el nombre de la suscripci�n
    s.descripcion;                   -- Agrupamos por la descripci�n de la suscripci�n
GO