create table register_employee(
id_employee int identity(1,1) PRIMARY KEY,
login_employee varchar(50) NOT NULL,
password_employee varchar(50) NOT NULL
)