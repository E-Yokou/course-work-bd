CREATE TABLE transaction1 (
    id INT IDENTITY (1,1) PRIMARY KEY,
    id_route INT NOT NULL,
    id_client INT NOT NULL,
    number_route VARCHAR(50) NOT NULL,
    city_start VARCHAR(50) NOT NULL,
    city_finish VARCHAR(50) NOT NULL,
    time_travel VARCHAR(50) NOT NULL,
    date_ VARCHAR(50) NOT NULL,
    price INT NOT NULL,
    confirm VARCHAR(40) NOT NULL
);
