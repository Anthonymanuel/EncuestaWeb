Create Table Usuarios
(
    UsuarioId Int Primary key Identity(1,1),
    Nombres Varchar(70),
    Apellidos Varchar(70),
    NombreUsuario Varchar(50),
    Email Varchar(70),
    Telefono Varchar(15),
    Contrasena Varchar(40),
    FechaInicio Date,
    TipoDeUsuario Varchar(20)
)

Create Table RespuestasAbiertas
(
    RespuestaAbiertaId Int Primary Key Identity(1,1),
	PreguntaId Int Foreign Key References Preguntas(PreguntaId),
    Descripcion Varchar(1000)
)

Create Table Preguntas
(
    PreguntaId Int Primary Key Identity(1,1),
    Descripcion Varchar(500),
	TipoDePregunta Int,
	SubTipoDePregunta Int,
)


Create Table RespuestasPosibles
(
	RespuestaPosibleId Int Primary key Identity(1,1),
	PreguntaId Int Foreign Key References Preguntas(PreguntaId),
	Respuestas Varchar(100)
)

Create Table RespuestasCerradas
(
	RespuestasCerradaId Int Primary Key Identity(1,1),
	PreguntaId Int Foreign Key References Preguntas(PreguntaId),
	Respuesta Int
)

Create Table Encuestas
(
	EncuestaId Int Primary Key Identity(1,1),
	Entidad Varchar(200),
	Descripcion Varchar(200),
	Fecha Date
)

Create Table EncuestasPreguntas
(
    EncuestaPreguntaId Int Primary Key Identity(1,1),
    EncuestaId Int Foreign Key References Encuestas(EncuestaId),
	PreguntaId Int Foreign Key References Preguntas(PreguntaId)
)
