create table member(Id int identity (2000,1),Name varchar(50),Duration int,Goal varchar(100),Membership_type varchar(50),Fees bigint)
select * from member
alter table member add CoachId int 
update member set CoachId = 3333 where Id =2001