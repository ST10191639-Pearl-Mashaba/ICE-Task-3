USE master
DROP DATABASE bands
CREATE DATABASE bands
USE bands

CREATE TABLE BandInfo (
BandID INT IDENTITY(1,1) primary key not null, 
Name varchar(25) not null,
MemberCount int not null,
DebutDate date not null,
);

Insert into BandInfo (Name, MemberCount, DebutDate)
Values 	('Star', 5, '2016-08-19'),
		('The Diamonds', 4,  '2015-04-28'),
        ('River', 6, '2016-03-02'),
        ('Sunshower', 7, '2015-07-15');

SELECT * FROM BandInfo