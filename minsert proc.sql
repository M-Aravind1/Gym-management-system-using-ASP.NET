create proc minsert(@Name varchar(50),@Duration int,@Goal varchar(100),@Membership_type varchar(50),@Fees bigint)
as begin 
Insert into member values(@Name,@Duration,@Goal,@Membership_type,@Fees)
select * from member
end 