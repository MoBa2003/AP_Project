-- create table tbl_employee(
-- id bigserial not null primary key,
-- personnel_number varchar(50) not null,
-- first_name varchar(50) not null,
-- last_Name varchar(50) not null,
-- email varchar(100) not null,
-- username varchar(50) not null,
-- password varchar(50) not null
-- );


-- select * from tbl_Employee

-- create table tbl_Customer(
-- id bigserial not null,
-- national_code varchar(10) not null primary key,
-- first_name varchar(50) not null,
-- last_Name varchar(50) not null,
-- email varchar(100) not null,
-- phone_number varchar(13) not null,
-- wallet float not null,
-- username varchar(50) not null,
-- password varchar(50) not null
-- );


-- drop table tbl_Customer


-- create table tbl_orders(
-- id bigserial not null primary key,
-- sender_national_code varchar(10) not null references tbl_customer (national_code), 
-- sender_address varchar(100) not null,
-- receiver_address varchar(100) not null,
-- content_type varchar(10) not null,
-- has_expensive_object bool not null,
-- weight float not null,
-- send_type varchar(10) not null,
-- price float not null,
-- status varchar(20) not null,
-- customer_comment varchar(100)
-- );

-- select * from tbl_orders


-- insert into tbl_employee(personnel_number,first_name,last_name,email,username,password) values ('401521372','MoBa','Bayani','MoBa2003@gmail.com','Moba2003','12345678')
-- select * from tbl_employee
-- insert into tbl_customer(national_code,first_name,last_name,email,phone_number,wallet,username,password) values(3333333333,'ahmad','poorreza','ahamd@gmail.com','09035671234',0,'ahmad123','87654321')
-- select * from tbl_customer
-- insert into tbl_orders(sender_national_code,sender_address,receiver_address,content_type,has_expensive_object,weight,send_type,price,status)values('3333333333','thr','tbz','breakable',true,100,'swift',40,'submitted')
-- select * from tbl_orders join tbl_customer on sender_national_code=tbl_customer.national_code

-- select * from tbl_orders

