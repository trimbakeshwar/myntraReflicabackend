create table UserData (
UserId int PRIMARY KEY IDENTITY,
Name varchar(50),
Email varchar(50),
MobileNumber varchar(10),
Password varchar(50)


);

create table Address (
UserId int,
AddressId int PRIMARY KEY IDENTITY,
Address varchar(100),
PinCode int,
state varchar(100),
TypeOfAddress varchar(100),
city varchar(100),
Locality varchar(100),
IsThisDefaultAddress bit
FOREIGN KEY (UserId) REFERENCES UserData(UserId)
)