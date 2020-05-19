create table _user (
id serial primary key,
firstName varchar(50) not null,
lastName varchar(50) not null,
cnpj varchar(14) not null,
email varchar (50) not null,
senha varchar (50) not null
);

insert into "_user" (firstName,lastName,cnpj,email,senha) 
values ('Julinho','Rodrigues','12345678938275','email.com','senha')
;