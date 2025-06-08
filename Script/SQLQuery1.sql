create database femiride
use femiride 
CREATE TABLE usuarios (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100),
    correo NVARCHAR(255) NOT NULL UNIQUE,
    contraseña_hash NVARCHAR(MAX) NOT NULL,
    estado BIT NOT NULL DEFAULT 1,
    creado_en DATETIME DEFAULT GETDATE()
);
SELECT * FROM usuarios;