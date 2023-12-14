CREATE TABLE ticket (
    id INT IDENTITY(1,1) PRIMARY KEY,
	id_bus INT NOT NULL,
	id_route INT NOT NULL,
    registration_number VARCHAR(50) NOT NULL,
    fio_client VARCHAR(100) NOT NULL,
	passport_client VARCHAR(50) NOT NULL,
	birthday_client VARCHAR(50) NOT NULL,
    city_start VARCHAR(50) NOT NULL,   
	city_finish VARCHAR(50) NOT NULL,
    seat_number INT NOT NULL,
	date_start varchar(50) NOT NULL,
    date_ varchar(50) NOT NULL,
    date_sale DATE NOT NULL,
    price INT NOT NULL,
	confirm VARCHAR(40) NOT NULL
);