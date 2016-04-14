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
Insert into Usuarios(NombreUsuario,Contrasena) values('Anthonymanuel','anthony01')
select * from Usuarios
select * from PreguntasCerradas
Use Encuesta
use Encuesta
insert into EncuestaPreguntasAbiertas(Descripcion)Values('hola')
Create Table PreguntasAbiertas
(
    PreguntaAbiertaId Int Primary Key Identity(1,1),
    Descripcion Varchar(500),
)

select * from PreguntasAbiertas where Descripcion like'%hola%'

Create Table RespuestasAbiertas
(
    RespuestaAbiertaId Int Primary Key Identity(1,1),
	PreguntaAbiertaId Int Foreign Key References PreguntasAbiertas(PreguntaAbiertaId),
    Descripcion Varchar(1000)
)

select * from RepuestasAbiertas

use EncuestasWebForm
Create Table PreguntasCerradas
(
    PreguntaCerradaId Int Primary Key Identity(1,1),
    Descripcion Varchar(500),
	TipoDePreguntaCerrada Int,
)

select p.PreguntaCerradaId,p.Descripcion,p.TipoDePreguntaCerrada,r.Respuestas from PreguntasCerradas p inner join RespuestasPosibles r on p.PreguntaCerradaId = r.PreguntaCerradaId where p.PreguntaCerradaId =2

Create Table RespuestasPosibles
(
	RespuestaPosibleId Int Primary key Identity(1,1),
	PreguntaCerradaId Int Foreign Key References PreguntasCerradas(PreguntaCerradaId),
	Respuestas Varchar(100)
)
Create Table RespuestasCerradas
(
	RespuestasCerradaId Int Primary Key Identity(1,1),
	PreguntaCerradaId Int Foreign Key References PreguntasCerradas(PreguntaCerradaId),
	Respuesta Int
)


select * from RespuestasCerradas
Update RespuestasCerradas Set Respuesta =Respuesta+1  Where PreguntaCerradaId = 1 and RespuestasCerradaId=1

select r.RespuestasCerradaId,p.Respuestas,c.PreguntaCerradaId from RespuestasPosibles p inner join PreguntasCerradas c on c.PreguntaCerradaId = p.PreguntaCerradaId inner join RespuestasCerradas r on r.PreguntaCerradaId = c.PreguntaCerradaId  where r.PreguntaCerradaId =2 
select * from RespuestasPosibles
select * from RespuestasCerradas
Create Table Encuestas
(
	EncuestaId Int Primary Key Identity(1,1),
	Entidad Varchar(200),
	Descripcion Varchar(200),
	Fecha Date
)

select * from RespuestasAbiertas

PreguntaCerradaId Int Foreign Key References PreguntasCerradas(PreguntaCerradaId),
Create Table EncuestaPreguntasAbiertas
(
    EncuestaPreguntaAbiertaId Int Primary Key Identity(1,1),
    EncuestaId Int Foreign Key References Encuestas(EncuestaId),
	PreguntaAbiertaId Int Foreign Key References PreguntasAbiertas(PreguntaAbiertaId),
	Descripcion Varchar(1000)
)


select * from EncuestaPreguntasAbiertas
Create Table EncuestaPreguntasCerradas
(
    EncuestaPreguntaCerradaId Int Primary Key Identity(1,1),
    EncuestaId Int Foreign Key References Encuestas(EncuestaId),
	PreguntaCerradaId Int Foreign Key References PreguntasCerradas(PreguntaCerradaId),
	Descripcion Varchar(500)
)
select  e.EncuestaId,e.Entidad,e.Descripcion,e.Fecha,a.Descripcion,c.Descripcion from Encuestas e inner join EncuestaPreguntasAbiertas a on  a.EncuestaId = e.EncuestaId 
inner join EncuestaPreguntasCerradas c on c.EncuestaId = e.EncuestaId where e.EncuestaId = 13



select  e.EncuestaId,e.Entidad,c.Descripcion,e.Fecha ,r.Respuestas  from Encuestas e  
inner join EncuestaPreguntasCerradas c on c.EncuestaId = e.EncuestaId inner join RespuestasPosibles r 
on r.PreguntaCerradaId = c.PreguntaCerradaId inner join PreguntasCerradas p on p.PreguntaCerradaId = r.PreguntaCerradaId  
where  p.TipoDePreguntaCerrada = 1 And e.EncuestaId = 12

select  e.EncuestaId,e.Entidad,c.Descripcion,e.Fecha ,r.Respuestas  from Encuestas e  
inner join EncuestaPreguntasCerradas c on c.EncuestaId = e.EncuestaId inner join RespuestasPosibles r 
on r.PreguntaCerradaId = c.PreguntaCerradaId inner join PreguntasCerradas p on p.PreguntaCerradaId = r.PreguntaCerradaId  
where p.TipoDePreguntaCerrada = 2 and e.EncuestaId = 13 

select  e.EncuestaId,e.Entidad,e.Descripcion,e.Fecha,p.Descripcion,r.Descripcion  from Encuestas e  
inner join EncuestaPreguntasAbiertas a on a.EncuestaId = e.EncuestaId inner join PreguntasAbiertas p on p.PreguntaAbiertaId = a.PreguntaAbiertaId inner join RespuestasAbiertas r on r.PreguntaAbiertaId = p.PreguntaAbiertaId   
where e.EncuestaId = 1