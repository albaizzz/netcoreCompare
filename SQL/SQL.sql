select * from student

create procedure usp_Update_Student
	@studentid int,
	@firstname varchar(100),
	@lastname varchar(100),
	@gender varchar(10),
	@email varchar(100),
	@ipaddress varchar(100)
as
begin
	update student
	set FirstName = @firstname,
	LastName = @lastname,
	Gender = @gender,
	Email = @email,
	IPAddress = @ipaddress
	where studentid = @studentid
end

create procedure usp_Delete_Student
	@studentid int
as
begin
	delete from student
	where studentid = @studentid
end

drop table trackingSQL
select * from trackingSQL
create table trackingSQL
(
	id int identity(1,1) primary key,
	proxyServer varchar(100),
	platform	varchar(100),
	operation	varchar(100),
	startProc datetime,
	endProd   datetime,
	periodInSec decimal(18,5)
)

alter procedure usp_Insert_TrackingSQL
	@proxyServer varchar(100), @platform varchar(100), @operation varchar(100), @startproc datetime, @endproc datetime, @periodInSec decimal(18,5)
as
begin
	insert into trackingSQL values(@proxyServer, @platform, @operation, @startproc, @endproc, @periodInSec)
end

create table trackingMongo
(
	id int identity(1,1) primary key,
	proxyServer varchar(100),
	platform	varchar(100),
	operation	varchar(100),
	startProc datetime,
	endProd   datetime,
	periodInSec int
)

create table trackingOracle
(
	id int identity(1,1) primary key,
	proxyServer varchar(100),
	platform	varchar(100),
	operation	varchar(100),
	startProc datetime,
	endProd   datetime,
	periodInSec int
)

select * from Student
select * from trackingSQL

truncate table student
truncate table trackingSQL