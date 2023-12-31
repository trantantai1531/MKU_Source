
 create table CAT_WebsiteUseful
(
	id int identity(50,1) primary key ,	
	id_L int,
	Loai nvarchar(200),
	Vi_tri int,
	NN char(10) default 'vn',
	Status int default 1,
	Anh char(500),
	Hot bit default 0,
	GioiThieu ntext,
	Link nvarchar(500),
	Author nvarchar(256)
)
go




create proc CAT_WebsiteUseful_search @TK nvarchar(1000),@NN char(10),@id_L int
as
	select id,Loai from CAT_WebsiteUseful where [dbo].[fuChuyenCoDauThanhKhongDau](Loai) like '%'+[dbo].[fuChuyenCoDauThanhKhongDau](@TK)+'%' and NN=@NN and id_L=@id_L order by vi_tri asc
go

create proc CAT_WebsiteUseful_de @id int
as	
	--Lấy id Loại
declare @id_L int
select @id_L=id_L from CAT_WebsiteUseful where id=@id
	--Lấy NN 
declare @NN char(10)
select @NN=NN from CAT_WebsiteUseful where id=@id
--Lấy vị trí
	declare @vt int
	select @vt=Vi_tri from CAT_WebsiteUseful where id=@id
--Update vị trí
update CAT_WebsiteUseful set Vi_tri=Vi_tri-1 where Vi_tri>@vt and id_L=@id_L and NN=@NN
--Xóa dữ liệu
	delete CAT_WebsiteUseful where id=@id
go

create proc CAT_WebsiteUseful_sl_id @id int
as
	select * from CAT_WebsiteUseful where id=@id
go

create proc CAT_WebsiteUseful_up 
@Loai nvarchar(200),@id int,@NN char(10),@id_L int,
@Anh nvarchar(500),@Hot bit,@GioiThieu ntext,
@Link nvarchar(500),@Author nvarchar(200)
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
	update CAT_WebsiteUseful set Loai=@Loai,id_L=@id_L,Anh=@Anh,Hot=@Hot,GioiThieu=@GioiThieu,Link=@Link,Author=@Author where id=@id
go

create proc CAT_WebsiteUseful_sl_out @id_L int,@NN char(10)
as
	select*from CAT_WebsiteUseful where id_L=@id_L and NN=@NN and Status=1 order by vi_tri asc
go




create proc CAT_WebsiteUseful_sl @NN char(10),@id_L int
as
	select* from CAT_WebsiteUseful where NN=@NN and id_L=@id_L order by vi_tri
go

create proc CAT_WebsiteUseful_sl_all @NN char(10),@id_L int
as
	select 0 as id,0 as id_L,N'------Chọn chuyên mục--------'as Loai,0 as Vi_tri union
	select id,id_L,Loai,Vi_tri from CAT_WebsiteUseful where NN=@NN and id_L=@id_L order by vi_tri
go

create proc CAT_WebsiteUseful_up_vi_tri @Vi_tri int,@id int,@id_L int,@Loai nvarchar(1000)
as
declare @NN char(10)
	select @NN=NN from CAT_WebsiteUseful where id=@id

declare @kt int
	select @kt= max(vi_tri) from CAT_WebsiteUseful where id_L=@id_L and NN=@NN
if(@vi_tri<=@kt and @vi_tri>0)
begin
	declare @vt_dung int
	select @vt_dung=vi_tri from CAT_WebsiteUseful where id=@id 
	if(@vi_tri<@vt_dung)
	begin
		update CAT_WebsiteUseful set Vi_tri=Vi_tri+1 where vi_tri>=@vi_tri and Vi_tri<@vt_dung and id_L=@id_L and NN=@NN
		update CAT_WebsiteUseful set Vi_tri=@vi_tri,Loai=@Loai where id=@id 
	end
	else
	begin
		update CAT_WebsiteUseful set Vi_tri=Vi_tri-1 where vi_tri<=@vi_tri and Vi_tri>@vt_dung and id_L=@id_L and NN=@NN
		update CAT_WebsiteUseful set Vi_tri=@vi_tri,Loai=@Loai where id=@id
	end
end
go

create proc CAT_WebsiteUseful_up_vi_tri1 @Vi_tri int,@id int,@id_L int
as
declare @NN char(10)
	select @NN=NN from CAT_WebsiteUseful where id=@id

declare @kt int
	select @kt= max(vi_tri) from CAT_WebsiteUseful where id_L=@id_L and NN=@NN
if(@vi_tri<=@kt and @vi_tri>0)
begin
	declare @vt_dung int
	select @vt_dung=vi_tri from CAT_WebsiteUseful where id=@id 
	if(@vi_tri<@vt_dung)
	begin
		update CAT_WebsiteUseful set Vi_tri=Vi_tri+1 where vi_tri>=@vi_tri and Vi_tri<@vt_dung and id_L=@id_L and NN=@NN
		update CAT_WebsiteUseful set Vi_tri=@vi_tri where id=@id 
	end
	else
	begin
		update CAT_WebsiteUseful set Vi_tri=Vi_tri-1 where vi_tri<=@vi_tri and Vi_tri>@vt_dung and id_L=@id_L and NN=@NN
		update CAT_WebsiteUseful set Vi_tri=@vi_tri where id=@id
	end
end
go

create proc CAT_WebsiteUseful_update_Status @id int
as
	declare @tam int
	select @tam=status from CAT_WebsiteUseful where id=@id
	if(@tam=1)
		update CAT_WebsiteUseful set Status=0 where id=@id
	else update CAT_WebsiteUseful set Status=1 where id=@id
go


create proc CAT_WebsiteUsefulupdate_Hot @id int  
as  
 declare @tam int  
 select @tam=Hot from CAT_WebsiteUseful where id=@id  
 if(@tam=1)  
  update CAT_WebsiteUseful set Hot=0 where id=@id  
 else update CAT_WebsiteUseful set Hot=1 where id=@id  
 go
 
 create proc CAT_WebsiteUseful_add 
	@Loai nvarchar(200),@NN char(10),@id_L int,@Anh nvarchar(500),
	@Hot bit ,
	@GioiThieu ntext,@id int output,
	@Link nvarchar(500),
	@Author nvarchar(200),
	@DuoiAnh char(10)
as
--Lấy vị trí lớn nhất hiện tại
	declare @vt int
	set @vt=0
	select top 1 @vt=vi_tri from CAT_WebsiteUseful where id_L=@id_L and NN=@NN order by vi_tri desc
	set @vt=@vt+1

	insert into CAT_WebsiteUseful(id_L,Loai,Vi_tri,NN,Anh,Hot,GioiThieu,Link,Author) 
	values(@id_L,@Loai,@vt,@NN,@Anh,@Hot,@GioiThieu,@Link,@Author)	
	select @id=@@identity
	if(@DuoiAnh<>'')
		update CAT_WebsiteUseful set Anh=@Anh+cast(@id as nvarchar(1000))+@DuoiAnh where id=@id
go