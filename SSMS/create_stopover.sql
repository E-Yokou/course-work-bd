create table stopover (
id int identity (1,1) PRIMARY KEY,
number_route varchar(30) NOT NULL,
city varchar(50) NOT NULL,
arrive varchar(50) NOT NULL,
price int
)