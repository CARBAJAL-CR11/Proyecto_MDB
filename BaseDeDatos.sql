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
telefonoProductora VARCHAR(10),
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
imagenPelicula VARCHAR(MAX),
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