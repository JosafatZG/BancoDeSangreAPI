
#CREANDO LA BASE DE DATOS
drop database if exists db_a8e1de_bsangre;
CREATE DATABASE db_a8e1de_bsangre;
USE db_a8e1de_bsangre;


#TABLA TIPOS DE SANGRE

DROP TABLE IF EXISTS TipoSangre;
CREATE TABLE TipoSangre
(
Id INT NOT NULL auto_increment,
NombreTS TEXT NOT NULL,

PRIMARY KEY (Id)
);

INSERT INTO TipoSangre(NombreTS) VALUES ('AB');
INSERT INTO TipoSangre(NombreTS) VALUES ('A');
INSERT INTO TipoSangre(NombreTS) VALUES ('B');
INSERT INTO TipoSangre(NombreTS) VALUES ('O');

#TABLA TIPOS DE RH

DROP TABLE IF EXISTS TipoRH;
CREATE TABLE TipoRH
(
Id INT NOT NULL auto_increment,
NombreRH TEXT NOT NULL,

PRIMARY KEY (Id)
);

INSERT INTO TipoRH(NombreRH) VALUES ('Positivo');
INSERT INTO TipoRH(NombreRH) VALUES ('Negativo');

#TABLA GÉNERO

DROP TABLE IF EXISTS Genero;
CREATE TABLE Genero
(
Id INT NOT NULL auto_increment,
NombreGenero TEXT NOT NULL,

PRIMARY KEY (Id)
);

INSERT INTO Genero(NombreGenero) VALUES ('Masculino');
INSERT INTO Genero(NombreGenero) VALUES ('Femenino');
INSERT INTO Genero(NombreGenero) VALUES ('Otro');
INSERT INTO Genero(NombreGenero) VALUES ('Prefiero no responder');

#TABLA TipoBolsa

DROP TABLE IF EXISTS TipoBolsa;
CREATE TABLE TipoBolsa
(
Id INT NOT NULL auto_increment,
Tipo TEXT NOT NULL,

PRIMARY KEY(Id)
);

INSERT INTO TipoBolsa(Tipo) VALUES ('Sangre');
INSERT INTO TipoBolsa(Tipo) VALUES ('Plasma');
INSERT INTO TipoBolsa(Tipo) VALUES ('Plaquetas');

#TABLA PACIENTE

DROP TABLE IF EXISTS Paciente;
CREATE TABLE Paciente
(
Id INT NOT NULL auto_increment,
Nombres VARCHAR(60) NOT NULL,
Apellidos VARCHAR(60) NOT NULL,
FechaNac date NOT NULL,
GeneroId INT NOt NULL,
Edad INT NOT NULL,
TipoSangreId INT NOT NULL,
TipoRHId INT NOT NULL,

PRIMARY KEY(Id),

FOREIGN KEY (GeneroId) REFERENCES Genero(Id),
FOREIGN KEY (TipoSangreId) REFERENCES TipoSangre(Id),
FOREIGN KEY (TipoRHId) REFERENCES TipoRH(Id)
);

#SELECT * FROM Paciente

#TABLA BolsasSangre

DROP TABLE IF EXISTS Bolsas;
CREATE TABLE Bolsas
(
Id INT NOT NULL auto_increment,
TipoBolsaId INT NOT NULL,
Cantidadml INT NOT NULL,
DonanteId INT NOT NULL,
ReceptorId INT,
FechaDonacion DATE NOT NULL,
FechaAplicacion DATE,

PRIMARY KEY(Id),

FOREIGN KEY (TipoBolsaId) REFERENCES TipoBolsa(Id),
FOREIGN KEY (DonanteId) REFERENCES Paciente(Id),
FOREIGN KEY (ReceptorId) REFERENCES Paciente(Id)
);

#TABLA Usuario

DROP TABLE IF EXISTS Usuario;
CREATE TABLE Usuario
(
Id INT NOT NULL auto_increment,
NombreUsuario VARCHAR(100) NOT NULL,
Correo VARCHAR(255) NOT NULL,
Pwd CHAR(60) NOT NULL,
CodigoRecuperacion CHAR(15),

PRIMARY KEY(Id)
);

#INSERT INTO Bolsas (TipoBolsa, Cantidadml, Donante, Receptor, FechaDonacion, FechaAplicacion) VALUES (1, 450, 2, 1, '16/01/2022', '16/01/2022')
#SELECT * FROM Bolsas

#DELETE FROM Bolsas 

#DBCC CHECKIDENT ('Bolsas', RESEED, 0)

