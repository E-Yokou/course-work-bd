CREATE TABLE transation (
id int identity(1,1) PRIMARY KEY,
id_route int NOT NULL,
id_client int  NOT NULL,
number_route varchar(20) NOT NULL,
city_start varchar(20) NOT NULL,
city_finish varchar(20) NOT NULL,
time_travel varchar(20) NOT NULL,
date_ varchar(20) NOT NULL,
price int NOT NULL,
confirm varchar(25) NOT NULL
)
