use [MyWebSite_(CSB)]
go
select * from MemberTbl
go

insert into MemberTbl(userid,passWd,name,address)values('sky','skypass','ȫ�浿','��⵵ ���ֽ�')
go
insert MemberTbl (userid,PassWd,name,address)values('sea','seapass','������','��⵵ ����')
go
insert MemberTbl values('sky','skypass', 'ȫ�浿', '��⵵ ���ֽ�')
go
select * from MemberTbl
go

select * from MemberTbl
go
select userid, name from MemberTbl 
go
select Passwd, userid, address, [name] from MemberTbl
go


select * from MemberTbl where userid='sky'
go


select * from MemberTbl
where address like '%����%'
go
select * from MemberTbl where address like '���%'
go
select * from MemberTbl where name like '%��%'
go



select * from MemberTbl order by userid 
go
select * from MemberTbl order by userid asc 
go
select * from memberTbl order by userid desc 
go


update memberTbl set passWd = 'pass' where userid='sea'
go
select * from memberTbl
go


delete from memberTbl where userid='sky' 
go
select * from memberTbl
go
delete from memberTbl
go

select *from memberTbl
go

