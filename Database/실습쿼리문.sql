use [MyWebSite_(CSB)]
go
select * from MemberTbl
go

insert into MemberTbl(userid,passWd,name,address)values('sky','skypass','홍길동','경기도 파주시')
go
insert MemberTbl (userid,PassWd,name,address)values('sea','seapass','갑순이','경기도 고양시')
go
insert MemberTbl values('sky','skypass', '홍길동', '경기도 파주시')
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
where address like '%파주%'
go
select * from MemberTbl where address like '경기%'
go
select * from MemberTbl where name like '%갑%'
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

