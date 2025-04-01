create procedure procAddMemberTbl
(
@UserID char(10),
@PassWd char(20),
@Name nchar(10),
@Address nchar(50)
)
as begin
	insert into MemberTbl(UserID, PassWd, Name, Address) values ( @UserID, @PassWd,@Name, @Address)
end


exec procAddMemberTbl 'sky', 'pass', '홍길동','경기도 파주시'
go
exec procAddMemberTbl 'sun', 'pass','홍길순', '경기도 고양시'
go
exec procAddMemberTbl 'moon','pass','갑돌이','서울시 종로구'
go
exec procAddMemberTbl 'venus','pass','갑순이','서울시 은평구'
go
exec procAddMemberTbl 'sky','pass','홍길동','서울시 종로구'
go

select * from memberTbl