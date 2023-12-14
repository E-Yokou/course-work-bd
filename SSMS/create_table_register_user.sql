create table register_user(
id_register_user int identity(1,1) PRIMARY KEY,
login_user varchar(50) NOT NULL,
password_user varchar(50) NOT NULL,
fio varchar(100) NOT NULL,
passport varchar(20) NOT NULL,
birthday varchar(50) NOT NULL,
)
