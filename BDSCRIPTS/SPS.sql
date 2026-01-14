-- ========================================
-- PROCEDIMIENTOS ALMACENADOS RESTANTES
-- ========================================

-- ========================================
-- CICLOS
-- ========================================
CREATE PROCEDURE SP_recCiclos
AS
BEGIN
    SELECT * FROM Ciclos
END
GO

CREATE PROCEDURE SP_insCiclo @nombre_ciclo VARCHAR(50), @descripcion TEXT
AS
BEGIN
    INSERT INTO Ciclos(nombre_ciclo, descripcion) VALUES (@nombre_ciclo, @descripcion)
END
GO

CREATE PROCEDURE SP_modCiclo @id_ciclo INT, @nombre_ciclo VARCHAR(50), @descripcion TEXT
AS
BEGIN
    UPDATE Ciclos SET nombre_ciclo = @nombre_ciclo, descripcion = @descripcion WHERE id_ciclo = @id_ciclo
END
GO

CREATE PROCEDURE SP_delCiclo @id_ciclo INT
AS
BEGIN
    DELETE FROM Ciclos WHERE id_ciclo = @id_ciclo
END
GO

CREATE PROCEDURE SP_recCicloPorId @id_ciclo INT AS
BEGIN SELECT * FROM Ciclos WHERE id_ciclo = @id_ciclo; END; GO


-- ========================================
-- SECCIONES
-- ========================================
CREATE PROCEDURE SP_recSecciones
AS
BEGIN
    SELECT * FROM Secciones
END
GO

CREATE PROCEDURE SP_recSeccionesPorCiclo @id_ciclo INT
AS
BEGIN
    SELECT * FROM Secciones WHERE id_ciclo = @id_ciclo
END
GO

CREATE PROCEDURE SP_insSeccion @nombre_seccion VARCHAR(20), @id_ciclo INT
AS
BEGIN
    INSERT INTO Secciones(nombre_seccion, id_ciclo) VALUES (@nombre_seccion, @id_ciclo)
END
GO

CREATE PROCEDURE SP_modSeccion @id_seccion INT, @nombre_seccion VARCHAR(20), @id_ciclo INT
AS
BEGIN
    UPDATE Secciones SET nombre_seccion = @nombre_seccion, id_ciclo = @id_ciclo WHERE id_seccion = @id_seccion
END
GO

CREATE PROCEDURE SP_delSeccion @id_seccion INT
AS
BEGIN
    DELETE FROM Secciones WHERE id_seccion = @id_seccion
END
GO

CREATE PROCEDURE SP_recSeccionPorId @id_seccion INT AS
BEGIN SELECT * FROM Secciones WHERE id_seccion = @id_seccion; END; GO


-- ========================================
-- ESTUDIANTES
-- ========================================
CREATE OR ALTER PROCEDURE SP_recEstudiantes 
AS
BEGIN
  SELECT 
    E.id_estudiante,
    E.cedula,
    E.nombre,
    E.direccion,
    E.telefono,
    E.id_seccion, 
    S.nombre_seccion AS seccion
  FROM Estudiantes E
  INNER JOIN Secciones S ON E.id_seccion = S.id_seccion;
END;
GO

CREATE OR ALTER PROCEDURE SP_recEstudiantesPorSeccion
  @id_seccion INT
AS
BEGIN
  SELECT 
    E.id_estudiante,
    E.cedula,
    E.nombre,
    E.direccion,
    E.telefono,
    S.nombre_seccion AS seccion
  FROM Estudiantes E
  INNER JOIN Secciones S ON E.id_seccion = S.id_seccion
  WHERE E.id_seccion = @id_seccion;
END;
GO
CREATE OR ALTER PROCEDURE SP_recEstudiantePorCedula 
  @cedula VARCHAR(20) 
AS
BEGIN
  SELECT 
    E.id_estudiante,
    E.cedula,
    E.nombre,
    E.direccion,
    E.telefono,
    S.nombre_seccion AS seccion
  FROM Estudiantes E
  INNER JOIN Secciones S ON E.id_seccion = S.id_seccion
  WHERE E.cedula = @cedula;
END;
GO

CREATE PROCEDURE SP_insEstudiante
    @cedula VARCHAR(20),
    @nombre VARCHAR(100),
    @direccion VARCHAR(255),
    @telefono VARCHAR(20),
    @id_seccion INT
AS
BEGIN
    INSERT INTO Estudiantes (cedula, nombre, direccion, telefono, id_seccion)
    VALUES (@cedula, @nombre, @direccion, @telefono, @id_seccion)
END
GO

CREATE PROCEDURE SP_modEstudiante
    @id_estudiante INT,
    @cedula VARCHAR(20),
    @nombre VARCHAR(100),
    @direccion VARCHAR(255),
    @telefono VARCHAR(20),
    @id_seccion INT
AS
BEGIN
    UPDATE Estudiantes
    SET cedula = @cedula,
        nombre = @nombre,
        direccion = @direccion,
        telefono = @telefono,
        id_seccion = @id_seccion
    WHERE id_estudiante = @id_estudiante
END
GO

CREATE PROCEDURE SP_delEstudiante @id_estudiante INT
AS
BEGIN
    DELETE FROM Padres_Estudiantes WHERE id_estudiante = @id_estudiante
    DELETE FROM Usuarios WHERE id_estudiante = @id_estudiante
    DELETE FROM Estudiantes WHERE id_estudiante = @id_estudiante
END
GO

CREATE OR ALTER PROCEDURE SP_recEstudiantePorId 
  @id_estudiante INT 
AS
BEGIN
  SELECT 
    E.id_estudiante,
    E.cedula,
    E.nombre,
    E.direccion,
    E.telefono,
    E.id_seccion, 
    S.nombre_seccion AS seccion
  FROM Estudiantes E
  INNER JOIN Secciones S ON E.id_seccion = S.id_seccion
  WHERE E.id_estudiante = @id_estudiante;
END;
GO


CREATE OR ALTER PROCEDURE SP_asignarEstudianteAPadre
  @id_padre INT,
  @id_estudiante INT
AS
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM Padres_Estudiantes 
    WHERE id_padre = @id_padre AND id_estudiante = @id_estudiante
  )
  BEGIN
    INSERT INTO Padres_Estudiantes(id_padre, id_estudiante)
    VALUES (@id_padre, @id_estudiante);
  END
END;
GO

-- SP: Quitar estudiante de padre

CREATE OR ALTER PROCEDURE SP_quitarEstudianteDePadre
  @id_padre INT,
  @id_estudiante INT
AS
BEGIN
  DELETE FROM Padres_Estudiantes
  WHERE id_padre = @id_padre AND id_estudiante = @id_estudiante;
END;
GO

-- SP: Obtener estudiantes por padre

CREATE OR ALTER PROCEDURE SP_recEstudiantesPorPadre
  @id_padre INT
AS
BEGIN
  SELECT 
    E.id_estudiante,
    E.cedula,
    E.nombre,
    E.direccion,
    E.telefono,
    S.nombre_seccion AS seccion
  FROM Padres_Estudiantes PE
  INNER JOIN Estudiantes E ON PE.id_estudiante = E.id_estudiante
  INNER JOIN Secciones S ON E.id_seccion = S.id_seccion
  WHERE PE.id_padre = @id_padre;
END;
GO

-- ========================================
-- PADRES
-- ========================================
CREATE PROCEDURE SP_recPadres
AS
BEGIN
    SELECT * FROM Padres
END
GO

CREATE OR ALTER PROCEDURE SP_recPadrePorCedula 
  @cedula VARCHAR(20)
AS
BEGIN
  SELECT * FROM Padres WHERE cedula = @cedula;
END;
GO

-- Recuperar padre por ID
CREATE OR ALTER PROCEDURE SP_recPadrePorId 
  @id_padre INT
AS
BEGIN
  SELECT * FROM Padres WHERE id_padre = @id_padre;
END;
GO

CREATE PROCEDURE SP_insPadre @cedula VARCHAR(20), @nombre VARCHAR(100), @telefono VARCHAR(20)
AS
BEGIN
    INSERT INTO Padres(cedula, nombre, telefono) VALUES (@cedula, @nombre, @telefono)
END
GO

CREATE PROCEDURE SP_modPadre @id_padre INT, @cedula VARCHAR(20), @nombre VARCHAR(100), @telefono VARCHAR(20)
AS
BEGIN
    UPDATE Padres SET cedula = @cedula, nombre = @nombre, telefono = @telefono WHERE id_padre = @id_padre
END
GO

CREATE PROCEDURE SP_delPadre @id_padre INT
AS
BEGIN
    DELETE FROM Padres_Estudiantes WHERE id_padre = @id_padre
    DELETE FROM Padres WHERE id_padre = @id_padre
END
GO

CREATE PROCEDURE SP_relPadreEstudiante @id_padre INT, @id_estudiante INT
AS
BEGIN
    INSERT INTO Padres_Estudiantes (id_padre, id_estudiante) VALUES (@id_padre, @id_estudiante)
END
GO

CREATE PROCEDURE SP_quitarRelacionPadreEstudiante @id_padre INT, @id_estudiante INT
AS
BEGIN
    DELETE FROM Padres_Estudiantes WHERE id_padre = @id_padre AND id_estudiante = @id_estudiante
END
GO

CREATE PROCEDURE SP_recPadresPorEstudiante @id_estudiante INT
AS
BEGIN
    SELECT p.*
    FROM Padres p
    INNER JOIN Padres_Estudiantes pe ON p.id_padre = pe.id_padre
    WHERE pe.id_estudiante = @id_estudiante
END
GO


-- ========================================
-- PROFESORES
-- ========================================
CREATE PROCEDURE SP_recProfesores
AS
BEGIN
    SELECT * FROM Profesores
END
GO

CREATE OR ALTER PROCEDURE SP_recProfesoresConMaterias
AS
BEGIN
  SELECT 
    p.id_profesor,
    p.nombre AS nombre_profesor,
    m.id_materia,
    m.nombre_materia
  FROM Profesores p
  INNER JOIN Materias_Profesores mp ON p.id_profesor = mp.id_profesor
  INNER JOIN Materias m ON mp.id_materia = m.id_materia
END;
GO

CREATE PROCEDURE SP_recProfesorPorId @id_profesor INT AS
BEGIN SELECT * FROM Profesores WHERE id_profesor = @id_profesor; END; GO

CREATE OR ALTER PROCEDURE SP_recProfesoresPorMateria
  @id_materia INT
AS
BEGIN
  SELECT 
    p.id_profesor, 
    p.nombre AS nombre_profesor,
    m.id_materia,
    m.nombre_materia
  FROM Profesores p
  INNER JOIN Materias_Profesores mp ON p.id_profesor = mp.id_profesor
  INNER JOIN Materias m ON mp.id_materia = m.id_materia
  WHERE m.id_materia = @id_materia;
END;
GO

CREATE PROCEDURE SP_insProfesor @cedula VARCHAR(20), @nombre VARCHAR(100)
AS
BEGIN
    INSERT INTO Profesores(cedula, nombre) VALUES (@cedula, @nombre)
END
GO

CREATE PROCEDURE SP_modProfesor @id_profesor INT, @cedula VARCHAR(20), @nombre VARCHAR(100)
AS
BEGIN
    UPDATE Profesores SET cedula = @cedula, nombre = @nombre WHERE id_profesor = @id_profesor
END
GO

CREATE PROCEDURE SP_delProfesor @id_profesor INT
AS
BEGIN
    DELETE FROM Materias_Profesores WHERE id_profesor = @id_profesor
    DELETE FROM Usuarios WHERE id_profesor = @id_profesor
    DELETE FROM Profesores WHERE id_profesor = @id_profesor
END
GO

CREATE PROCEDURE SP_asignarMateriaProfesor @id_profesor INT, @id_materia INT
AS
BEGIN
    INSERT INTO Materias_Profesores (id_profesor, id_materia) VALUES (@id_profesor, @id_materia)
END
GO

CREATE PROCEDURE SP_quitarMateriaProfesor @id_profesor INT, @id_materia INT
AS
BEGIN
    DELETE FROM Materias_Profesores WHERE id_profesor = @id_profesor AND id_materia = @id_materia
END
GO


-- ========================================
-- MATERIAS
-- ========================================

CREATE OR ALTER PROCEDURE SP_insMateria 
  @nombre_materia VARCHAR(100)
AS
BEGIN
  INSERT INTO Materias(nombre_materia)
  VALUES (@nombre_materia);

  RETURN 1;
END;
GO


CREATE OR ALTER PROCEDURE SP_modMateria 
  @id_materia INT, 
  @nombre_materia VARCHAR(100)
AS
BEGIN
  UPDATE Materias
  SET nombre_materia = @nombre_materia
  WHERE id_materia = @id_materia;

  RETURN 1;
END;
GO


CREATE OR ALTER PROCEDURE SP_delMateria 
  @id_materia INT
AS
BEGIN
  DELETE FROM Materias
  WHERE id_materia = @id_materia;

  RETURN 1;
END;
GO

CREATE OR ALTER PROCEDURE SP_recMaterias 
AS
BEGIN
  SELECT * FROM Materias;
END;
GO


CREATE OR ALTER PROCEDURE SP_recMateriaPorId 
  @id_materia INT
AS
BEGIN
  SELECT * FROM Materias WHERE id_materia = @id_materia;
END;
GO

CREATE OR ALTER PROCEDURE SP_recMateriasPorProfesor
  @id_profesor INT
AS
BEGIN
  SELECT 
    m.id_materia, 
    m.nombre_materia,
    p.id_profesor,
    p.nombre AS nombre_profesor
  FROM Materias m
  INNER JOIN Materias_Profesores mp ON m.id_materia = mp.id_materia
  INNER JOIN Profesores p ON mp.id_profesor = p.id_profesor
  WHERE mp.id_profesor = @id_profesor;
END;
GO



CREATE OR ALTER PROCEDURE SP_recMateriasConProfesores
AS
BEGIN
  SELECT 
    m.id_materia,
    m.nombre_materia,
    STRING_AGG(p.nombre, ', ') AS profesores
  FROM Materias m
  LEFT JOIN Materias_Profesores mp ON m.id_materia = mp.id_materia
  LEFT JOIN Profesores p ON mp.id_profesor = p.id_profesor
  GROUP BY m.id_materia, m.nombre_materia;
END;
GO

CREATE OR ALTER PROCEDURE SP_asignarMateriaAProfesor
  @id_profesor INT,
  @id_materia INT
AS
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM Materias_Profesores WHERE id_profesor = @id_profesor AND id_materia = @id_materia
  )
  BEGIN
    INSERT INTO Materias_Profesores(id_profesor, id_materia) VALUES (@id_profesor, @id_materia);
  END
END;
GO

CREATE OR ALTER PROCEDURE SP_quitarMateriaDeProfesor
  @id_profesor INT,
  @id_materia INT
AS
BEGIN
  DELETE FROM Materias_Profesores WHERE id_profesor = @id_profesor AND id_materia = @id_materia;
END;
GO


-- ========================================
-- USUARIOS
-- ========================================
CREATE PROCEDURE SP_insUsuario @usuario VARCHAR(50), @contrasena VARCHAR(100), @rol VARCHAR(20), @id_estudiante INT = NULL, @id_profesor INT = NULL AS
BEGIN INSERT INTO Usuarios(usuario, contrasena, rol, id_estudiante, id_profesor) VALUES (@usuario, @contrasena, @rol, @id_estudiante, @id_profesor); END; GO

CREATE PROCEDURE SP_modUsuario @id_usuario INT, @usuario VARCHAR(50), @contrasena VARCHAR(100), @rol VARCHAR(20), @activo BIT AS
BEGIN UPDATE Usuarios SET usuario = @usuario, contrasena = @contrasena, rol = @rol, activo = @activo WHERE id_usuario = @id_usuario; END; GO

CREATE PROCEDURE SP_delUsuario @id_usuario INT AS
BEGIN DELETE FROM Usuarios WHERE id_usuario = @id_usuario; END; GO

CREATE PROCEDURE SP_recUsuarios AS
BEGIN SELECT * FROM Usuarios; END; GO

CREATE PROCEDURE SP_recUsuarioPorId @id_usuario INT AS
BEGIN SELECT * FROM Usuarios WHERE id_usuario = @id_usuario; END; GO

CREATE PROCEDURE SP_loginUsuario
    @usuario VARCHAR(50),
    @contrasena VARCHAR(100)
AS
BEGIN
    SELECT * FROM Usuarios
    WHERE usuario = @usuario
      AND contrasena = @contrasena
      AND activo = 1;
END;
GO

EXEC SP_insUsuario
	@usuario = 'admin',
	@contrasena = 'adminlBa2003MM',
	@rol = 'Administrativo',
	@id_estudiante = NULL,
	@id_profesor = NULL;

EXEC SP_insUsuario
	@usuario = 'estudiante',
	@contrasena = 'estuLBA2025',
	@rol = 'Estudiante',
	@id_estudiante = NULL,
	@id_profesor = NULL;

	SELECT * FROM Usuarios WHERE usuario = 'admin' AND contrasena = 'adminlBa2003MM' AND activo = 1;
select * from Usuarios
-- ========================================
-- NOTICIAS
-- ========================================

-- Insertar noticia
CREATE PROCEDURE SP_insNoticia
    @titulo VARCHAR(100),
    @contenido TEXT,
    @fecha_publicacion DATE,
    @imagen_url VARCHAR(255)
AS
BEGIN
    INSERT INTO Noticias (titulo, contenido, fecha_publicacion, imagen_url)
    VALUES (@titulo, @contenido, @fecha_publicacion, @imagen_url);
END
GO

-- Modificar noticia
CREATE PROCEDURE SP_modNoticia
    @id_noticia INT,
    @titulo VARCHAR(100),
    @contenido TEXT,
    @fecha_publicacion DATE,
    @imagen_url VARCHAR(255)
AS
BEGIN
    UPDATE Noticias
    SET titulo = @titulo,
        contenido = @contenido,
        fecha_publicacion = @fecha_publicacion,
        imagen_url = @imagen_url
    WHERE id_noticia = @id_noticia;
END
GO

-- Eliminar noticia
CREATE PROCEDURE SP_delNoticia
    @id_noticia INT
AS
BEGIN
    DELETE FROM Noticias
    WHERE id_noticia = @id_noticia;
END
GO

-- Recuperar todas las noticias
CREATE PROCEDURE SP_recNoticias
AS
BEGIN
    SELECT * FROM Noticias
    ORDER BY fecha_publicacion DESC;
END
GO

-- Recuperar una noticia por ID
CREATE PROCEDURE SP_recNoticiaPorId
    @id_noticia INT
AS
BEGIN
    SELECT * FROM Noticias
    WHERE id_noticia = @id_noticia;
END
GO

SELECT *FROM Noticias

-- ========================================
-- MATRICULA
-- ========================================

CREATE PROCEDURE SP_insMatricula
    @nombre_estudiante VARCHAR(100),
    @cedula_estudiante VARCHAR(20),
    @escuela_procedencia VARCHAR(100),
    @fecha_nacimiento DATE,
    @telefono_estudiante VARCHAR(20),
    @nivel VARCHAR(20),
    @nombre_padre VARCHAR(100),
    @cedula_padre VARCHAR(20),
    @telefono_padre VARCHAR(20),
    @direccion_padre VARCHAR(300),
    @parentesco VARCHAR(50),
    @fecha_cita DATE,
    @hora_cita VARCHAR(10)
AS
BEGIN
    INSERT INTO Matricula (
        nombre_estudiante,
        cedula_estudiante,
        escuela_procedencia,
        fecha_nacimiento,
        telefono_estudiante,
        nivel,
        nombre_padre,
        cedula_padre,
        telefono_padre,
        direccion_padre,
        parentesco,
        fecha_cita,
        hora_cita
    )
    VALUES (
        @nombre_estudiante,
        @cedula_estudiante,
        @escuela_procedencia,
        @fecha_nacimiento,
        @telefono_estudiante,
        @nivel,
        @nombre_padre,
        @cedula_padre,
        @telefono_padre,
        @direccion_padre,
        @parentesco,
        @fecha_cita,
        @hora_cita
    );
END;
