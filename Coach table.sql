create database gym
use gym
create table Coach(Id int identity(1001,1),Name varchar(50),Gender varchar(50),Phone bigint,Experience int,Local_Address varchar(50),Pass_Word varchar(50),Email varchar(100))
select * from coach
exec sp_rename 'Coach.Id','CoachId'