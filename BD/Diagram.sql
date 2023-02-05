create database votations;
go

use votations;
go

create table permitions (
	id int not null identity (1,1) primary key,
	name varchar (150) not null,
	description varchar (250)
);

create table generations (
	id int not null identity (1,1) primary key,
	name varchar (50) not null,
	description varchar (150)
);

create table sections (
	id int not null identity (1,1) primary key,
	name varchar (50) not null,
	description varchar (150),
	id_gen int not null,
	constraint generation foreign key (id_gen) references generations (id)
);

create table users (
	id int not null identity (1,1) primary key,
	identification varchar (10) not null,
	name varchar (150) not null,
	last_name varchar (150) not null,
	second_last_name varchar (150) not null,
	email varchar (200),
	picture_url varchar (2500),
	section int not null,

	constraint sec foreign key (section) references sections (id)	
);

create table users_permitions (
	
)

