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
FOREIGN KEY(codigoTipoUsuario) REFERENCES tiposUsuarios(codigoTipoUsuario),
CONSTRAINT fkSuscripcion
FOREIGN KEY(codigoSuscripcion) REFERENCES suscripciones(codigoSuscripcion)
);

CREATE TABLE detallesFacturas(
codigoFactura CHAR(5) NOT NULL,
codigoUsuario CHAR(5) NOT NULL,
subtotal money NOT NULL,
CONSTRAINT fkFacturaDetalle 
FOREIGN KEY(codigoFactura) REFERENCES facturas(codigoFactura),
CONSTRAINT fkUsuarioDetalle
FOREIGN KEY(codigoUsuario) REFERENCES usuarios(codigoUsuario)
);

CREATE TABLE perfiles(
codigoPerfil CHAR(5) NOT NULL,
nombrePerfil VARCHAR(25) NOT NULL,
codigoUsuario CHAR(5) NOT NULL,
CONSTRAINT pkCodigoPerfil PRIMARY KEY(codigoPerfil),
CONSTRAINT fkUsuarioPerfil 
FOREIGN KEY(codigoUsuario) REFERENCES usuarios(codigoUsuario) 
);

CREATE TABLE comentarios(
codigoComentario CHAR(5) NOT NULL,
comentario VARCHAR(900) NOT NULL,
codigoPerfil CHAR(5) NOT NULL,
CONSTRAINT pkCodigoComentario PRIMARY KEY(codigoComentario),
CONSTRAINT fkPerfilComentario
FOREIGN KEY(codigoPerfil) REFERENCES perfiles(codigoPerfil)
);

CREATE TABLE historiales(
codigoHistorial CHAR(5) NOT NULL,
codigoPerfil CHAR(5) NOT NULL,
CONSTRAINT pkCodigoHistorial PRIMARY KEY(codigoHistorial),
CONSTRAINT fkPerfilHistorial 
FOREIGN KEY(codigoPerfil) REFERENCES perfiles(codigoPerfil)
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
);

CREATE TABLE detallesCategorias(
codigoDescripcion CHAR(5) NOT NULL,
codigoCategoria CHAR(5) NOT NULL,
CONSTRAINT fkDescripcionCategoria 
FOREIGN KEY(codigoDescripcion) REFERENCES descripciones(codigoDescripcion),
CONSTRAINT fkCategoria 
FOREIGN KEY(codigoCategoria) REFERENCES categorias(codigoCategoria)
);

CREATE TABLE detallesHistoriales(
codigoHistorial CHAR(5) NOT NULL,
codigoDescripcion CHAR(5) NOT NULL,
CONSTRAINT fkHistorialDetalle 
FOREIGN KEY(codigoHistorial) REFERENCES historiales(codigoHistorial),
CONSTRAINT fkDescripcionHistorial
FOREIGN KEY(codigoDescripcion) REFERENCES descripciones(codigoDescripcion)
);

CREATE TABLE detallesComentarios(
codigoComentario CHAR(5) NOT NULL,
codigoDescripcion CHAR(5) NOT NULL,
CONSTRAINT fkComentarioDetalle
FOREIGN KEY(codigoComentario) REFERENCES comentarios(codigoComentario),
CONSTRAINT fkDescripcionComentario 
FOREIGN KEY(codigoDescripcion) REFERENCES descripciones(codigoDescripcion)
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
);

CREATE TABLE capitulos(
codigoCapitulo CHAR(5) NOT NULL,
codigoTemporada CHAR(5) NOT NULL,
nombreCapitulo VARCHAR(100) NOT NULL,
CONSTRAINT pkCodigoCapitulo PRIMARY KEY(codigoCapitulo),
CONSTRAINT fkTemporadaCapitulo
FOREIGN KEY(codigoTemporada) REFERENCES temporadas(codigoTemporada)
);
GO

-- Trigger o disparador cuando se realiza una inserci�n en los Usuarios
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
			-- Primera letra del nombre + Primera letra del apellido + N�mero aleatorio de 3 d�gitos
            UPPER(LEFT(i.nombres, 1)) + UPPER(LEFT(i.apellidos, 1)) + RIGHT(CAST(ABS(CHECKSUM(NEWID())) AS VARCHAR(3)), 3), 
            i.nombres,   -- Usamos el nombre del usuario como nombre del perfil
            i.codigoUsuario  -- Usamos el c�digo del usuario reci�n insertado
        FROM inserted i;
    END
END;
GO

-- Trigger 2: Actualizar el total de la factura cuando se insertan, actualizan o eliminan detalles
CREATE TRIGGER trg_UpdateFacturaTotal
ON detallesFacturas
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @codigoFactura CHAR(5);

    -- Obtener el c�digo de factura afectado
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

-- Trigger 3: Prevenir la eliminaci�n de usuarios con perfiles asociados
CREATE TRIGGER trg_PreventDeleteUsuarioWithPerfiles
ON usuarios
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM deleted d
        INNER JOIN perfiles p ON d.codigoUsuario = p.codigoUsuario
    )
    BEGIN
        RAISERROR('No se puede eliminar el usuario porque tiene perfiles asociados.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        DELETE FROM usuarios
        WHERE codigoUsuario IN (SELECT codigoUsuario FROM deleted);
    END
END;
GO

-- Trigger 4: Prevenir la eliminaci�n de productoras con descripciones asociadas
CREATE TRIGGER trg_PreventDeleteProductoraWithDescripciones
ON productoras
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM deleted d
        INNER JOIN descripciones des ON d.codigoProductora = des.codigoProductora
    )
    BEGIN
        RAISERROR('No se puede eliminar la productora porque tiene descripciones asociadas.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        DELETE FROM productoras
        WHERE codigoProductora IN (SELECT codigoProductora FROM deleted);
    END
END;
GO

-- Trigger 5: Eliminar detalles de categor�as al eliminar una descripci�n
CREATE TRIGGER trg_DeleteDetallesCategoriasOnDescripcionDelete
ON descripciones
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DELETE dc
    FROM detallesCategorias dc
    INNER JOIN deleted d ON dc.codigoDescripcion = d.codigoDescripcion;
END;
GO

-- Trigger 6: Eliminar detalles de historiales al eliminar un historial
CREATE TRIGGER trg_DeleteDetallesHistorialesOnHistorialDelete
ON historiales
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DELETE dh
    FROM detallesHistoriales dh
    INNER JOIN deleted d ON dh.codigoHistorial = d.codigoHistorial;
END;
GO

-- Trigger 7: Prevenir la inserci�n de pel�culas con fecha de emisi�n futura
CREATE TRIGGER trg_PreventFutureFechaEmisionPelicula
ON peliculas
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM inserted WHERE fechaEmision > GETDATE())
    BEGIN
        RAISERROR('No se puede insertar una pel�cula con fecha de emisi�n en el futuro.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        INSERT INTO peliculas (codigoPelicula, nombrePelicula, codigoDescripcion, fechaEmision, duracion)
        SELECT codigoPelicula, nombrePelicula, codigoDescripcion, fechaEmision, duracion
        FROM inserted;
    END
END;
GO

-- Trigger 8: Prevenir la inserci�n de usuarios con fecha de nacimiento futura
CREATE TRIGGER trg_PreventFutureFechaNacimientoUsuario
ON usuarios
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM inserted WHERE fechaNacimiento > GETDATE())
    BEGIN
        RAISERROR('No se puede insertar un usuario con fecha de nacimiento en el futuro.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        INSERT INTO usuarios (codigoUsuario, nombres, apellidos, correo, clave, fechaNacimiento, estadoCuenta, codigoTipoUsuario, codigoSuscripcion)
        SELECT codigoUsuario, nombres, apellidos, correo, clave, fechaNacimiento, estadoCuenta, codigoTipoUsuario, codigoSuscripcion
        FROM inserted;
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

    -- El trigger Trg_InsertUsuario se activar� autom�ticamente despu�s de este insert si el usuario es de tipo 'cliente'
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

-- 1. Obtener usuarios que tienen m�s de un perfil
SELECT 
    u.codigoUsuario,
    u.nombres,
    u.apellidos,
    (SELECT COUNT(*) FROM perfiles p WHERE p.codigoUsuario = u.codigoUsuario) AS cantidadPerfiles
FROM usuarios u
WHERE (SELECT COUNT(*) FROM perfiles p WHERE p.codigoUsuario = u.codigoUsuario) > 1;
GO

-- 2. Listar pel�culas que pertenecen a m�s de una categor�a
SELECT 
    p.codigoPelicula,
    p.nombrePelicula,
    (SELECT COUNT(*) FROM detallesCategorias dc WHERE dc.codigoDescripcion = p.codigoDescripcion) AS cantidadCategorias
FROM peliculas p
WHERE (SELECT COUNT(*) FROM detallesCategorias dc WHERE dc.codigoDescripcion = p.codigoDescripcion) > 1;
GO

-- 3. Obtener el promedio de duraci�n de las pel�culas por categor�a
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

-- Tabla: historiales

CREATE PROCEDURE PA_InsertarHistorial
    @codigoHistorial CHAR(5),
    @codigoPerfil CHAR(5)
AS
BEGIN
    INSERT INTO historiales (codigoHistorial, codigoPerfil)
    VALUES (@codigoHistorial, @codigoPerfil);
END;
GO

CREATE PROCEDURE PA_ActualizarHistorial
    @codigoHistorial CHAR(5),
    @codigoPerfil CHAR(5)
AS
BEGIN
    UPDATE historiales
    SET codigoPerfil = @codigoPerfil
    WHERE codigoHistorial = @codigoHistorial;
END;
GO

CREATE PROCEDURE PA_EliminarHistorial
    @codigoHistorial CHAR(5)
AS
BEGIN
    DELETE FROM historiales
    WHERE codigoHistorial = @codigoHistorial;
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

-- Tabla: detallesHistoriales

CREATE PROCEDURE PA_InsertarDetalleHistorial
    @codigoHistorial CHAR(5),
    @codigoDescripcion CHAR(5)
AS
BEGIN
    INSERT INTO detallesHistoriales (codigoHistorial, codigoDescripcion)
    VALUES (@codigoHistorial, @codigoDescripcion);
END;
GO

CREATE PROCEDURE PA_EliminarDetalleHistorial
    @codigoHistorial CHAR(5),
    @codigoDescripcion CHAR(5)
AS
BEGIN
    DELETE FROM detallesHistoriales
    WHERE codigoHistorial = @codigoHistorial AND codigoDescripcion = @codigoDescripcion;
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
('S0001', 'B�sico', 'Acceso a contenido est�ndar'),
('S0002', 'Est�ndar', 'Contenido en HD y m�ltiples dispositivos'),
('S0003', 'Premium', 'Contenido en Ultra HD y m�ltiples perfiles'),
('S0004', 'Familiar', 'Hasta 5 perfiles y contenido exclusivo'),
('S0005', 'Estudiante', 'Descuento especial para estudiantes'),
('S0006', 'Mensual', 'Suscripci�n mensual sin contratos'),
('S0007', 'Anual', 'Suscripci�n anual con descuento'),
('S0008', 'Trial', 'Prueba gratuita por un mes'),
('S0009', 'VIP', 'Acceso anticipado a nuevos contenidos'),
('S0010', 'Deportes', 'Contenido deportivo en vivo'),
('S0011', 'Ni�os', 'Contenido seguro para ni�os'),
('S0012', 'Documentales', 'Acceso exclusivo a documentales'),
('S0013', 'Cine', 'Estrenos de cine en casa'),
('S0014', 'M�sica', 'Videos y conciertos en vivo'),
('S0015', 'Noticias', 'Noticias en tiempo real'),
('S0016', 'Comedia', 'Especiales de comedia y stand-up'),
('S0017', 'Drama', 'Series y pel�culas dram�ticas'),
('S0018', 'Acci�n', 'Pel�culas y series de acci�n'),
('S0019', 'Terror', 'Contenido de terror y suspenso'),
('S0020', 'Romance', 'Pel�culas y series rom�nticas'),
('S0021', 'Ciencia Ficci�n', 'Contenido de ciencia ficci�n'),
('S0022', 'Animaci�n', 'Series y pel�culas animadas'),
('S0023', 'Cl�sicos', 'Pel�culas cl�sicas'),
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
('TU008', 'B�sico'),
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
('P0013', 'Amazon Studios', '1620 26th St, Santa Monica, CA', 'studios@amazon.com', '3105732305'),
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
('C001', 'Acci�n'),
('C002', 'Aventura'),
('C003', 'Comedia'),
('C004', 'Drama'),
('C005', 'Terror'),
('C006', 'Ciencia Ficci�n'),
('C007', 'Romance'),
('C008', 'Thriller'),
('C009', 'Animaci�n'),
('C010', 'Documental'),
('C011', 'Fantas�a'),
('C012', 'Misterio'),
('C013', 'Musical'),
('C014', 'Deportes'),
('C015', 'Hist�rico'),
('C016', 'Crimen'),
('C017', 'Familia'),
('C018', 'Guerra'),
('C019', 'Biograf�a'),
('C020', 'Western'),
('C021', 'Noir'),
('C022', 'Reality'),
('C023', 'Game Show'),
('C024', 'Talk Show'),
('C025', 'Noticias');
GO

-- Insertar registros en la tabla 'descripciones'
INSERT INTO descripciones (codigoDescripcion, descripcion, clasificacionEdad, codigoProductora) VALUES
('D0001', 'Una aventura �pica en un mundo fant�stico.', 'PG-13', 'P0001'),
('D0002', 'Comedia rom�ntica que te har� re�r y llorar.', 'PG', 'P0002'),
('D0003', 'Documental sobre la vida marina.', 'G', 'P0004'),
('D0004', 'Pel�cula de acci�n llena de adrenalina.', 'R', 'P0003'),
('D0005', 'Serie de misterio con giros inesperados.', 'TV-14', 'P0005'),
('D0006', 'Animaci�n para toda la familia.', 'G', 'P0006'),
('D0007', 'Drama hist�rico basado en hechos reales.', 'PG-13', 'P0007'),
('D0008', 'Thriller psicol�gico que te mantendr� en suspenso.', 'R', 'P0008'),
('D0009', 'Comedia negra con humor �cido.', 'R', 'P0009'),
('D0010', 'Pel�cula de terror que te quitar� el sue�o.', 'R', 'P0010'),
('D0011', 'Serie de ciencia ficci�n en el espacio.', 'TV-14', 'P0012'),
('D0012', 'Biograf�a de un personaje influyente.', 'PG-13', 'P0011'),
('D0013', 'Documental sobre culturas ancestrales.', 'G', 'P0013'),
('D0014', 'Pel�cula musical con n�meros espectaculares.', 'PG', 'P0014'),
('D0015', 'Comedia familiar para todas las edades.', 'G', 'P0015'),
('D0016', 'Acci�n y aventura en un mundo post-apocal�ptico.', 'R', 'P0016'),
('D0017', 'Drama rom�ntico ambientado en los a�os 50.', 'PG-13', 'P0017'),
('D0018', 'Serie de cr�menes y detectives.', 'TV-MA', 'P0018'),
('D0019', 'Pel�cula de fantas�a con criaturas m�gicas.', 'PG', 'P0019'),
('D0020', 'Thriller de espionaje internacional.', 'PG-13', 'P0020'),
('D0021', 'Animaci�n japonesa con historias profundas.', 'PG-13', 'P0019'),
('D0022', 'Comedia de situaci�n en un entorno laboral.', 'TV-PG', 'P0022'),
('D0023', 'Pel�cula de guerra basada en eventos reales.', 'R', 'P0023'),
('D0024', 'Documental sobre avances tecnol�gicos.', 'G', 'P0024'),
('D0025', 'Serie de fantas�a �pica con m�ltiples tramas.', 'TV-MA', 'P0025');
GO

-- Insertar registros en la tabla 'usuarios'
INSERT INTO usuarios (codigoUsuario, nombres, apellidos, correo, clave, fechaNacimiento, estadoCuenta, codigoTipoUsuario, codigoSuscripcion) VALUES
('U0001', 'Juan', 'P�rez', 'juan.perez@example.com', 'clave123', '1985-06-15', 'Activo', 'TU001', 'S0001'),
('U0002', 'Mar�a', 'Gonz�lez', 'maria.gonzalez@example.com', 'password', '1990-08-22', 'Activo', 'TU001', 'S0002'),
('U0003', 'Carlos', 'L�pez', 'carlos.lopez@example.com', '123456', '1978-03-10', 'Inactivo', 'TU002', 'S0003'),
('U0004', 'Ana', 'Mart�nez', 'ana.martinez@example.com', 'ana2021', '1995-12-05', 'Activo', 'TU001', 'S0004'),
('U0005', 'Luis', 'Garc�a', 'luis.garcia@example.com', 'luispass', '1982-11-30', 'Activo', 'TU003', 'S0005'),
('U0006', 'Sof�a', 'Rodr�guez', 'sofia.rodriguez@example.com', 'sofiarocks', '1993-04-18', 'Activo', 'TU001', 'S0006'),
('U0007', 'Diego', 'Hern�ndez', 'diego.hernandez@example.com', 'diego123', '1987-09-25', 'Activo', 'TU001', 'S0007'),
('U0008', 'Luc�a', 'Fern�ndez', 'lucia.fernandez@example.com', 'lucy89', '1992-07-13', 'Activo', 'TU001', 'S0008'),
('U0009', 'Jorge', 'Ruiz', 'jorge.ruiz@example.com', 'jorgepass', '1980-01-20', 'Activo', 'TU004', 'S0009'),
('U0010', 'Elena', 'D�az', 'elena.diaz@example.com', 'elena2022', '1994-05-07', 'Activo', 'TU001', 'S0010'),
('U0011', 'Pedro', 'Torres', 'pedro.torres@example.com', 'pedro!', '1988-02-28', 'Activo', 'TU001', 'S0011'),
('U0012', 'Marta', 'Flores', 'marta.flores@example.com', 'marta123', '1991-10-16', 'Activo', 'TU001', 'S0012'),
('U0013', 'Alberto', '�lvarez', 'alberto.alvarez@example.com', 'alberto', '1979-08-09', 'Inactivo', 'TU005', 'S0013'),
('U0014', 'Isabel', 'Gim�nez', 'isabel.gimenez@example.com', 'isa2022', '1986-03-03', 'Activo', 'TU001', 'S0014'),
('U0015', 'Fernando', 'Santos', 'fernando.santos@example.com', 'fernando', '1996-12-21', 'Activo', 'TU006', 'S0015'),
('U0016', 'Laura', 'Castro', 'laura.castro@example.com', 'lauraC', '1984-11-11', 'Activo', 'TU001', 'S0016'),
('U0017', 'Ra�l', 'Ortiz', 'raul.ortiz@example.com', 'raul1234', '1990-06-27', 'Activo', 'TU001', 'S0017'),
('U0018', 'Patricia', 'Rubio', 'patricia.rubio@example.com', 'patri2021', '1993-09-14', 'Activo', 'TU001', 'S0018'),
('U0019', 'Andr�s', 'Mar�n', 'andres.marin@example.com', 'andresM', '1981-04-01', 'Activo', 'TU007', 'S0019'),
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
('PF002', 'Perfil Mar�a', 'U0002'),
('PF003', 'Perfil Ana', 'U0004'),
('PF004', 'Perfil Sof�a', 'U0006'),
('PF005', 'Perfil Diego', 'U0007'),
('PF006', 'Perfil Luc�a', 'U0008'),
('PF007', 'Perfil Elena', 'U0010'),
('PF008', 'Perfil Pedro', 'U0011'),
('PF009', 'Perfil Marta', 'U0012'),
('PF010', 'Perfil Isabel', 'U0014'),
('PF011', 'Perfil Laura', 'U0016'),
('PF012', 'Perfil Ra�l', 'U0017'),
('PF013', 'Perfil Patricia', 'U0018'),
('PF014', 'Perfil Sara', 'U0020'),
('PF015', 'Perfil Miguel', 'U0021'),
('PF016', 'Perfil Natalia', 'U0022'),
('PF017', 'Perfil Cristina', 'U0024'),
('PF018', 'Perfil David', 'U0025'),
('PF019', 'Perfil Luis', 'U0005'),
('PF020', 'Perfil Fernando', 'U0015'),
('PF021', 'Perfil Andr�s', 'U0019'),
('PF022', 'Perfil Jorge', 'U0009'),
('PF023', 'Perfil Jose', 'U0023'),
('PF024', 'Perfil Alberto', 'U0013'),
('PF025', 'Perfil Carlos', 'U0003');
GO

-- Insertar registros en la tabla 'historiales'
INSERT INTO historiales (codigoHistorial, codigoPerfil) VALUES
('H0001', 'PF001'),
('H0002', 'PF002'),
('H0003', 'PF003'),
('H0004', 'PF004'),
('H0005', 'PF005'),
('H0006', 'PF006'),
('H0007', 'PF007'),
('H0008', 'PF008'),
('H0009', 'PF009'),
('H0010', 'PF010'),
('H0011', 'PF011'),
('H0012', 'PF012'),
('H0013', 'PF013'),
('H0014', 'PF014'),
('H0015', 'PF015'),
('H0016', 'PF016'),
('H0017', 'PF017'),
('H0018', 'PF018'),
('H0019', 'PF019'),
('H0020', 'PF020'),
('H0021', 'PF021'),
('H0022', 'PF022'),
('H0023', 'PF023'),
('H0024', 'PF024'),
('H0025', 'PF025');
GO

-- Insertar registros en la tabla 'comentarios'
INSERT INTO comentarios (codigoComentario, comentario, codigoPerfil) VALUES
('CM001', 'Excelente pel�cula, la recomiendo.', 'PF001'),
('CM002', 'La serie me enganch� desde el primer cap�tulo.', 'PF002'),
('CM003', 'El documental es muy informativo.', 'PF003'),
('CM004', 'No me gust� el final.', 'PF004'),
('CM005', 'Gran actuaci�n del reparto.', 'PF005'),
('CM006', 'Esperaba m�s de esta pel�cula.', 'PF006'),
('CM007', 'La animaci�n es impresionante.', 'PF007'),
('CM008', 'La trama es un poco lenta.', 'PF008'),
('CM009', 'La m�sica es excelente.', 'PF009'),
('CM010', 'Me encant�, espero la pr�xima temporada.', 'PF010'),
('CM011', 'El gui�n es muy original.', 'PF011'),
('CM012', 'Los efectos especiales son sorprendentes.', 'PF012'),
('CM013', 'Una obra maestra del cine.', 'PF013'),
('CM014', 'El documental me hizo reflexionar.', 'PF014'),
('CM015', 'La pel�cula es muy emotiva.', 'PF015'),
('CM016', 'No es mi tipo de g�nero.', 'PF016'),
('CM017', 'La direcci�n es magn�fica.', 'PF017'),
('CM018', 'La serie tiene giros inesperados.', 'PF018'),
('CM019', 'La actuaci�n es un poco floja.', 'PF019'),
('CM020', 'Me re� mucho con esta comedia.', 'PF020'),
('CM021', 'La historia es confusa.', 'PF021'),
('CM022', 'Gran trabajo de producci�n.', 'PF022'),
('CM023', 'El final es muy predecible.', 'PF023'),
('CM024', 'Me aburri� desde el inicio.', 'PF024'),
('CM025', 'Un cl�sico que no pasa de moda.', 'PF025');
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
('P0003', 'El Oc�ano Profundo', 'D0003', '2021-02-10', '01:50:00'),
('P0004', 'Velocidad M�xima', 'D0004', '2018-11-05', '02:00:00'),
('P0005', 'La Sombra del Enigma', 'D0005', '2020-09-25', '01:40:00'),
('P0006', 'Mundo Animado', 'D0006', '2019-12-18', '01:20:00'),
('P0007', 'El Pasado Olvidado', 'D0007', '2021-07-30', '02:10:00'),
('P0008', 'Mentiras Ocultas', 'D0008', '2017-06-12', '01:55:00'),
('P0009', 'Risas y M�s Risas', 'D0009', '2019-03-22', '01:35:00'),
('P0010', 'Noche de Terror', 'D0010', '2020-10-31', '01:50:00'),
('P0011', 'Estrellas en el Universo', 'D0011', '2018-04-14', '02:05:00'),
('P0012', 'El Gran Genio', 'D0012', '2021-01-07', '01:45:00'),
('P0013', 'Ra�ces Ancestrales', 'D0013', '2019-11-29', '01:50:00'),
('P0014', 'Melod�as del Coraz�n', 'D0014', '2020-02-14', '01:25:00'),
('P0015', 'Familia Unida', 'D0015', '2017-08-03', '01:30:00'),
('P0016', 'Camino al Futuro', 'D0016', '2021-05-20', '02:15:00'),
('P0017', 'Recuerdos del Ayer', 'D0017', '2018-12-25', '01:55:00'),
('P0018', 'Bajo Sospecha', 'D0018', '2020-07-07', '02:00:00'),
('P0019', 'El Reino M�gico', 'D0019', '2019-09-15', '01:40:00'),
('P0020', 'C�digo Secreto', 'D0020', '2021-03-08', '02:05:00'),
('P0021', 'Almas Gemelas', 'D0021', '2017-10-19', '01:50:00'),
('P0022', 'Oficina en Caos', 'D0022', '2019-06-28', '01:35:00'),
('P0023', 'Batalla en el Frente', 'D0023', '2020-12-11', '02:10:00'),
('P0024', 'Innovaci�n Tecnol�gica', 'D0024', '2018-01-05', '01:45:00'),
('P0025', 'Leyendas Eternas', 'D0025', '2021-08-16', '02:20:00');
GO

-- Insertar registros en la tabla 'series'
INSERT INTO series (codigoSerie, nombreSerie, fechaEmisionInicio, fechaEmisionFin, codigoDescripcion) VALUES
('S0001', 'Misterios del Tiempo', '2017-01-10', '2019-12-20', 'D0005'),
('S0002', 'Universo Desconocido', '2018-05-15', '2020-11-25', 'D0011'),
('S0003', 'La Vida en el Espacio', '2019-03-22', '2021-07-30', 'D0018'),
('S0004', 'Historias de Amor', '2016-09-05', '2018-06-18', 'D0017'),
('S0005', 'Cr�nicas de Guerra', '2017-12-01', '2020-08-14', 'D0023'),
('S0006', 'Risas en la Oficina', '2018-04-10', '2021-02-28', 'D0022'),
('S0007', 'Fantas�a y Realidad', '2019-07-05', '2021-09-15', 'D0025'),
('S0008', 'El Detective', '2016-11-20', '2019-05-27', 'D0018'),
('S0009', 'Caminos Cruzados', '2017-08-14', '2020-03-22', 'D0017'),
('S0010', 'Leyendas Urbanas', '2018-02-05', '2020-10-10', 'D0025'),
('S0011', 'Mundo Animal', '2019-06-18', '2021-04-05', 'D0003'),
('S0012', 'Tecnolog�a Hoy', '2016-12-30', '2019-09-12', 'D0024'),
('S0013', 'El Arte de Cocinar', '2017-05-23', '2020-01-17', 'D0009'),
('S0014', 'Viajeros en el Tiempo', '2018-08-08', '2021-06-20', 'D0011'),
('S0015', 'Historias de la Vida', '2019-11-02', '2021-12-15', 'D0012'),
('S0016', 'La Aventura Contin�a', '2016-04-19', '2019-07-28', 'D0001'),
('S0017', 'Mentes Criminales', '2017-09-11', '2020-05-06', 'D0018'),
('S0018', 'Amistades Peligrosas', '2018-03-30', '2021-08-22', 'D0008'),
('S0019', 'El Universo y M�s All�', '2019-12-15', '2021-10-30', 'D0011'),
('S0020', 'Secretos del Pasado', '2016-06-25', '2019-02-18', 'D0017'),
('S0021', 'La Comedia de la Vida', '2017-11-07', '2020-09-14', 'D0009'),
('S0022', 'Mundo Virtual', '2018-05-19', '2021-01-31', 'D0024'),
('S0023', 'Leyendas del Futuro', '2019-09-03', '2021-07-19', 'D0025'),
('S0024', 'El Arte del Enga�o', '2016-10-28', '2019-06-05', 'D0008'),
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
('C0003', 'T0001', 'La B�squeda'),
('C0004', 'T0002', 'Nuevos Descubrimientos'),
('C0005', 'T0002', 'El Enigma'),
('C0006', 'T0003', 'La Revelaci�n'),
('C0007', 'T0003', 'El Final'),
('C0008', 'T0004', 'Universo Oculto'),
('C0009', 'T0004', 'Planetas Lejanos'),
('C0010', 'T0005', 'Estrellas y Galaxias'),
('C0011', 'T0005', 'Vida Extraterrestre'),
('C0012', 'T0006', 'El Misterio del Espacio'),
('C0013', 'T0007', 'La Estaci�n Espacial'),
('C0014', 'T0007', 'Misi�n a Marte'),
('C0015', 'T0008', 'Regreso a la Luna'),
('C0016', 'T0009', 'M�s All� del Sistema Solar'),
('C0017', 'T0010', 'Un Nuevo Amor'),
('C0018', 'T0011', 'Corazones Rotos'),
('C0019', 'T0011', 'Reencuentros'),
('C0020', 'T0012', 'La Primera Batalla'),
('C0021', 'T0013', 'Estrategias'),
('C0022', 'T0014', 'La Victoria'),
('C0023', 'T0015', 'D�a de Trabajo'),
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

-- Insertar registros en la tabla 'detallesHistoriales'
INSERT INTO detallesHistoriales (codigoHistorial, codigoDescripcion) VALUES
('H0001', 'D0001'),
('H0002', 'D0002'),
('H0003', 'D0003'),
('H0004', 'D0004'),
('H0005', 'D0005'),
('H0006', 'D0006'),
('H0007', 'D0007'),
('H0008', 'D0008'),
('H0009', 'D0009'),
('H0010', 'D0010'),
('H0011', 'D0011'),
('H0012', 'D0012'),
('H0013', 'D0013'),
('H0014', 'D0014'),
('H0015', 'D0015'),
('H0016', 'D0016'),
('H0017', 'D0017'),
('H0018', 'D0018'),
('H0019', 'D0019'),
('H0020', 'D0020'),
('H0021', 'D0021'),
('H0022', 'D0022'),
('H0023', 'D0023'),
('H0024', 'D0024'),
('H0025', 'D0025');
GO
