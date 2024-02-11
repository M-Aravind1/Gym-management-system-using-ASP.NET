create proc cinsert(@Name varchar(50),@Gender varchar(50),@Phone bigint,@Experience int,@Local_Address varchar(50),@Pass_Word varchar(50),@Email varchar(100))
as begin 
Insert into Coach values(@Name,@Gender,@Phone,@Experience,@Local_Address,@Pass_Word,@Email)
select * from Coach
end