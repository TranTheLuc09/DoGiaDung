create procedure sp_login(@username varchar(50), @password varchar(50))
as
	begin
		select * from Accounts where username = @username AND password = @password
	end

CREATE PROCEDURE sp_register
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    INSERT INTO Accounts (username,password,level,money,address,phone,fullname) VALUES (@username,@password,'user',0,'','','');
END

create procedure sp_update_accounts(@fullname nvarchar(50), @address nvarchar(50), @phone varchar(50), @username varchar(50))
as
begin
	UPDATE Accounts SET fullname = @fullname, address = @address, phone = @phone WHERE username = @username;
end

create procedure sp_create_categorys(@name nvarchar(50))
as
begin
	INSERT INTO Categorys(name) VALUES (@name);
end

create procedure sp_update_categorys(@name nvarchar(50),@id int)
as
begin
	UPDATE Categorys SET name = @name WHERE id = @id
end

create procedure sp_delete_categorys(@id int)
as
begin
	DELETE FROM Categorys WHERE id = @id
end

create procedure sp_getlist_categorys
as
begin
	SELECT * FROM Categorys
end


/* products */
create procedure sp_create_product(@name nvarchar(MAX),@price int,@quantity int,@description nvarchar(MAX),@category_id int,@image nvarchar(50))
as
begin
	INSERT INTO Products(name,price,quantity,description,category_id,image) VALUES (@name,@price,@quantity,@description,@category_id,@image);
end

create procedure sp_update_product(@name nvarchar(MAX),@price int,@quantity int,@description nvarchar(MAX),@category_id int,@image nvarchar(50),@id int)
as
begin
	UPDATE Products SET name = @name,price = @price,quantity = @quantity,description = @description,category_id = @category_id,image = @image WHERE id = @id
end

create proc sp_delete_product(@id int)
as
begin
	DELETE FROM Products WHERE id = @id
end

create proc sp_getlist_product
as
begin
	SELECT * FROM Products
end	

create proc sp_getlist_product_by_id(@id int)
as
begin
	SELECT * FROM Products WHERE id = @id
end	

/* Orders */
drop proc sp_create_orders
select *from Orders
select * from Products
select * from OrderDetails
create proc sp_create_orders(@id varchar(50),@username varchar(50),@address nvarchar(MAX),@phone varchar(50),@status nvarchar(50))
as
begin
	INSERT INTO Orders (id,username,address,phone,status) VALUES (@id,@username,@address,@phone,@status);
end


drop proc sp_update_orders
create proc sp_update_orders(@status nvarchar(50),@id varchar(50))
as
begin 
	UPDATE Orders SET status = @status WHERE id = @id
end

drop proc sp_delete_orders
select * from OrderDetails
create proc sp_delete_orders(@id varchar(50))
as
begin 
	DELETE FROM OrderDetails WHERE order_id = @id
	DELETE FROM Orders WHERE id = @id
end

create proc sp_getlist_orders(@username varchar(50))
as
begin
	SELECT * FROM Orders WHERE username = @username
end

drop proc sp_getlist_orders_by_id
create proc sp_getlist_orders_by_id(@username varchar(50),@id varchar(50))
as
begin
	SELECT * FROM Orders WHERE username = @username AND id = @id
end

select * from Orders

create proc sp_get_order_details(@id varchar(50))
as
begin
	SELECT * FROM OrderDetails WHERE order_id = @id
end

select * from OrderDetails where order_id = 'y4tqge966b'
