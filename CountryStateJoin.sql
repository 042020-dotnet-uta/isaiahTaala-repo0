CREATE TABLE CountryTab(
	CountryID int PRIMARY KEY NOT NULL,
	Country nvarchar(255) NOT NULL
);

CREATE TABLE StateTab(
	StateId int PRIMARY KEY IDENTITY,
	CountryId int FOREIGN KEY REFERENCES CountryTab,
	State nvarchar(255)
);

INSERT INTO CountryTab( CountryID, Country )
VALUES ( 100, 'USA' );

INSERT INTO CountryTab( CountryID, Country )
VALUES ( 0, 'Mexico' );

INSERT INTO CountryTab( CountryID, Country )
VALUES ( 50, 'Japan' );

INSERT INTO CountryTab( CountryID, Country )
VALUES ( 20, 'Australia' );

INSERT INTO CountryTab( CountryID, Country )
VALUES ( 80, 'France' );


INSERT INTO StateTab( CountryId, State )
VALUES ( 100, 'California' );

INSERT INTO StateTab( CountryId, State )
VALUES ( 100, 'New York' );

INSERT INTO StateTab( CountryId, State )
VALUES ( 0, 'Baja California' );

INSERT INTO StateTab( CountryId, State )
VALUES ( 20, 'South Australia' );

INSERT INTO StateTab( CountryId, State )
VALUES ( 50, 'Osaka' );

SELECT * FROM CountryTab
CROSS JOIN StateTab

SELECT * FROM CountryTab as c
INNER JOIN StateTab as s
ON s.CountryId=c.CountryID

SELECT * FROM CountryTab as c
LEFT OUTER JOIN StateTab as s
ON s.CountryId=c.CountryID

SELECT * FROM CountryTab as c
RIGHT OUTER JOIN StateTab as s
ON s.CountryId=c.CountryID

SELECT * FROM CountryTab as c
FULL OUTER JOIN StateTab as s
ON s.CountryId=c.CountryID