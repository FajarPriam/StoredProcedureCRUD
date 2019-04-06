CREATE proc sp_supplier_add
@Name nvarchar(max),
@CreateDate date
as
begin
insert into Supplier values(
@Name,
@CreateDate
)
end

create proc sp_supplier_all
as
begin
select * from Supplier
end

CREATE proc sp_supplier_delete
@Id int
as
begin
delete from Supplier where Id=@Id
end

CREATE proc sp_supplier_id
@Id int
as
begin
select * from Supplier where Id=@Id
end

CREATE proc sp_supplier_update
@Id int,
@Name nvarchar(max)
as
begin
update Supplier set
Name = @Name
where Id=@Id
end