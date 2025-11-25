-- =======================
-- CREACIÓN DE TABLAS LIMPIAS
-- =======================

-- 1. CICLOS
CREATE TABLE Ciclos (
    id_ciclo INT IDENTITY(1,1) PRIMARY KEY,
    nombre_ciclo VARCHAR(50),
    descripcion TEXT
);

-- 2. SECCIONES
CREATE TABLE Secciones (
    id_seccion INT IDENTITY(1,1) PRIMARY KEY,
    nombre_seccion VARCHAR(20),
    id_ciclo INT,
    FOREIGN KEY (id_ciclo) REFERENCES Ciclos(id_ciclo)
);

-- 3. ESTUDIANTES
CREATE TABLE Estudiantes (
    id_estudiante INT IDENTITY(1,1) PRIMARY KEY,
    cedula VARCHAR(20) UNIQUE NOT NULL,
    nombre VARCHAR(100),
    direccion VARCHAR(255),
    telefono VARCHAR(20),
    id_seccion INT,
    FOREIGN KEY (id_seccion) REFERENCES Secciones(id_seccion)
);

-- 4. PADRES
CREATE TABLE Padres (
    id_padre INT IDENTITY(1,1) PRIMARY KEY,
    cedula VARCHAR(20) UNIQUE NOT NULL,
    nombre VARCHAR(100),
    telefono VARCHAR(20)
);

-- 5. RELACIÓN PADRES - ESTUDIANTES
CREATE TABLE Padres_Estudiantes (
    id_padre INT,
    id_estudiante INT,
    PRIMARY KEY (id_padre, id_estudiante),
    FOREIGN KEY (id_padre) REFERENCES Padres(id_padre),
    FOREIGN KEY (id_estudiante) REFERENCES Estudiantes(id_estudiante)
);

-- 6. PROFESORES
CREATE TABLE Profesores (
    id_profesor INT IDENTITY(1,1) PRIMARY KEY,
    cedula VARCHAR(20) UNIQUE NOT NULL,
    nombre VARCHAR(100)
);

-- 7. MATERIAS
CREATE TABLE Materias (
    id_materia INT IDENTITY(1,1) PRIMARY KEY,
    nombre_materia VARCHAR(100)
);

-- 8. RELACIÓN MATERIAS - PROFESORES
CREATE TABLE Materias_Profesores (
    id_profesor INT,
    id_materia INT,
    PRIMARY KEY (id_profesor, id_materia),
    FOREIGN KEY (id_profesor) REFERENCES Profesores(id_profesor),
    FOREIGN KEY (id_materia) REFERENCES Materias(id_materia)
);

-- 9. HORARIOS
CREATE TABLE Horarios (
    id_horario INT IDENTITY(1,1) PRIMARY KEY,
    id_seccion INT,
    dia_semana VARCHAR(10),
    hora_inicio TIME, 
    hora_fin TIME,
    id_materia INT,
    FOREIGN KEY (id_seccion) REFERENCES Secciones(id_seccion),
    FOREIGN KEY (id_materia) REFERENCES Materias(id_materia)
);

-- 10. USUARIOS
CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    usuario VARCHAR(50) UNIQUE,
    contrasena VARCHAR(100),
    rol VARCHAR(20),
    id_estudiante INT NULL,
    id_profesor INT NULL,
    activo BIT DEFAULT 1,
    FOREIGN KEY (id_estudiante) REFERENCES Estudiantes(id_estudiante),
    FOREIGN KEY (id_profesor) REFERENCES Profesores(id_profesor)
);

-- 11. NOTICIAS
CREATE TABLE Noticias (
    id_noticia INT PRIMARY KEY IDENTITY(1,1),
    titulo VARCHAR(100) NOT NULL,
    contenido TEXT NOT NULL,
    fecha_publicacion DATE NOT NULL DEFAULT GETDATE(),
    imagen_url VARCHAR(255) NULL
);

CREATE TABLE Matricula (
    id_matricula INT PRIMARY KEY IDENTITY(1,1),
    nombre_estudiante VARCHAR(100),
    cedula_estudiante VARCHAR(20),
    escuela_procedencia VARCHAR(100),
    fecha_nacimiento DATE,
    telefono_estudiante VARCHAR(20),
    nivel VARCHAR(20),
    nombre_padre VARCHAR(100),
    cedula_padre VARCHAR(20),
    telefono_padre VARCHAR(20),
    direccion_padre VARCHAR(300),
    parentesco VARCHAR(50),
    fecha_cita DATE,
    hora_cita VARCHAR(10)
);
