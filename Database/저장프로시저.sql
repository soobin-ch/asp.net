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


exec procAddMemberTbl 'sky', 'pass', 'ȫ�浿','��⵵ ���ֽ�'
go
exec procAddMemberTbl 'sun', 'pass','ȫ���', '��⵵ ����'
go
exec procAddMemberTbl 'moon','pass','������','����� ���α�'
go
exec procAddMemberTbl 'venus','pass','������','����� ����'
go
exec procAddMemberTbl 'sky','pass','ȫ�浿','����� ���α�'
go

select * from memberTbl