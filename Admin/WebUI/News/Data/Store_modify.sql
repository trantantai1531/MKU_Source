alter table CAT_WebsiteUseful add id_Format int
alter table CAT_WebsiteUseful add id_Lexile int
alter table CAT_WebsiteUseful add id_Language int
alter table CAT_WebsiteUseful add id_Grade int


alter proc CAT_WebsiteUseful_up 
@Loai nvarchar(200),@id int,@NN char(10),@id_L int,
@Anh nvarchar(500),@Hot bit,@GioiThieu ntext,
@Link nvarchar(500),@Author nvarchar(200),
@id_Format int, @id_Lexile int,@id_Language int,@id_Grade int
as
declare @tam int
	select @tam=id_L from CAT_WebsiteUseful where id=@id
if(@id_L<>@tam)
begin
declare @vt int
	select @vt=vi_tri from CAT_WebsiteUseful where id=@id
	update CAT_WebsiteUseful set Vi_tri=vi_tri -1 where id_L=@tam and vi_tri>@vt and NN=@NN
	update CAT_WebsiteUseful set Vi_tri=vi_tri +1 where id_L=@id_L  and NN=@NN
	update CAT_WebsiteUseful set Vi_tri=1 where id=@id
end
	update CAT_WebsiteUseful set Loai=@Loai,id_L=@id_L,Anh=@Anh,Hot=@Hot,GioiThieu=@GioiThieu,Link=@Link,Author=@Author,
	id_Format = @id_Format,
	id_Lexile =@id_Lexile,
	id_Language = @id_Language,
	id_Grade  = @id_Grade
	where id=@id
go


alter proc CAT_WebsiteUseful_sl @NN char(10),@id_L int
as
	select web.*,ty.Loai as 'Format',ty_Lexile.Loai as 'Lexile',
	ty_Language.Loai as 'Language', ty_Grade.Loai as 'Grade'
	from CAT_WebsiteUseful web 
	inner join 
	(
		select * from CAT_Type where id_L = 2
	)ty on ty.id = web.id_Format
	inner join 
	(
		select * from CAT_Type where id_L = 3
	)ty_Lexile on ty_Lexile.id = web.id_Lexile
	inner join 
	(
		select * from CAT_Type where id_L = 4
	)ty_Language on ty_Language.id = web.id_Language
	inner join 
	(
		select * from CAT_Type where id_L = 5
	)ty_Grade on ty_Grade.id = web.id_Grade
	where web.NN=@NN and web.id_L=@id_L order by vi_tri
go


create proc CAT_WebsiteUseful_Search @id_L int, @id_Format int,@id_Lexile int,@id_Language int, @id_Grade int
as
begin
	select * from CAT_Type 
	where id in (select distinct id from 
	(
		Select distinct ty.id,web.id_Format,id_Grade,id_Language,id_Lexile,ty.Loai from CAT_Type ty
		inner join CAT_WebsiteUseful web on ty.id = web.id_L
		where ty.id_L = 1 and ty.Status = 1  
		and web.id_L = @id_L and web.id_Format = @id_Format
		and web.id_Grade = @id_Grade and id_Language = @id_Language
		and web.id_Lexile = @id_Lexile
	)data)
end


create proc CAT_WebsiteUseful_Search_InRepeater @id_L int, @id_Format int,@id_Lexile int,@id_Language int, @id_Grade int
as
begin
	select web.*,ty.Loai as 'Format',ty_Lexile.Loai as 'Lexile',
	ty_Language.Loai as 'Language', ty_Grade.Loai as 'Grade'
	from CAT_WebsiteUseful web 
	inner join 
	(
		select * from CAT_Type where id_L = 2
	)ty on ty.id = web.id_Format
	inner join 
	(
		select * from CAT_Type where id_L = 3
	)ty_Lexile on ty_Lexile.id = web.id_Lexile
	inner join 
	(
		select * from CAT_Type where id_L = 4
	)ty_Language on ty_Language.id = web.id_Language
	inner join 
	(
		select * from CAT_Type where id_L = 5
	)ty_Grade on ty_Grade.id = web.id_Grade
	where  web.id_L=@id_L  and web.id_Format = @id_Format
		and web.id_Grade = @id_Grade and id_Language = @id_Language
		and web.id_Lexile = @id_Lexile
	order by vi_tri
end

 alter proc CAT_WebsiteUseful_add 
	@Loai nvarchar(200),@NN char(10),@id_L int,@Anh nvarchar(500),
	@Hot bit ,
	@GioiThieu ntext,@id int output,
	@Link nvarchar(500),
	@Author nvarchar(200),
	@DuoiAnh char(10),
	@id_Format int, @id_Lexile int,@id_Language int,@id_Grade int
as
--Lấy vị trí lớn nhất hiện tại
	declare @vt int
	set @vt=0
	select top 1 @vt=vi_tri from CAT_WebsiteUseful where id_L=@id_L and NN=@NN order by vi_tri desc
	set @vt=@vt+1

	insert into CAT_WebsiteUseful(id_L,Loai,Vi_tri,NN,Anh,Hot,GioiThieu,Link,Author,id_Format,id_Lexile,id_Language,id_Grade) 
	values(@id_L,@Loai,@vt,@NN,@Anh,@Hot,@GioiThieu,@Link,@Author,@id_Format,@id_Lexile,@id_Language,@id_Grade)	
	select @id=@@identity
	if(@DuoiAnh<>'')
		update CAT_WebsiteUseful set Anh=@Anh+cast(@id as nvarchar(1000))+@DuoiAnh where id=@id
go