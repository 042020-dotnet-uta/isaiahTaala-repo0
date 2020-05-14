-- Script Date: 5/4/2020 5:26 PM  - ErikEJ.SqlCeScripting version 3.5.2.86
           
INSERT INTO Customers ( FirstName, LastName, Email, Password)
     VALUES ( 'Fernando', 'Roberson', 'frob@gmail.com', 'ferr06' ),
     		( 'Mike', 'Mclaughlin', 'mmcl@yahoo.com', 'mikmc1' ),
     		( 'Lena', 'Spencer', 'lspe@aol.com', 'lensp3' ),
     		( 'Don', 'Webster', 'dweb@gmail.com', 'donwe6' ),
     		( 'Arlene', 'Lawrence', 'alaw@yahoo.com', 'arlla3' );
	          
INSERT INTO Orders ( CustomerID, LocationID, TimeStamp)
	VALUES ( 3, 2, '2019-05-23T15:24:56.200' ),
		   ( 3, 1, '2019-06-18T19:36:22.200' ),
		   ( 1, 3, '2019-07-28T15:01:21.200' ),
		   ( 2, 2, '2019-08-20T10:36:56.200' ), 
		   ( 4, 3, '2019-08-22T15:30:34.200' ),
		   ( 2, 1, '2019-08-28T15:36:50.200' ),
		   ( 3, 1, '2020-01-28T15:37:04.200' );
		   
INSERT INTO ProductOrders ( OrderID, ProductID, Quantity )
	VALUES ( 7, 3, 4 ),
		   ( 7, 2, 2 ),
		   ( 1, 3, 3 ),
		   ( 2, 5, 2 ),
		   ( 2, 1, 1 ),
		   ( 2, 4, 1 ),
		   ( 3, 5, 3 ),
		   ( 4, 1, 4 ),
		   ( 5, 2, 5 ),
		   ( 5, 4, 2 ),
		   ( 6, 3, 5 );
		   
INSERT INTO Products ( Name, Price )
	VALUES ( 'Toilet Paper', 10 ),
		   ( 'Chocolate', 2 ),
		   ( 'Headphones', 50 ),
		   ( 'Lamp', 20 ),
		   ( 'TV', 300 );
		   
INSERT INTO Inventories( ProductID, Quantity, LocationID )
	VALUES ( 5, 100, 3 ),
		   ( 5, 200, 1 ),
		   ( 5, 10, 2 ),
		   ( 1, 500, 3 ),
		   ( 1, 400, 1 ),
		   ( 1, 300, 2 ),
		   ( 2, 10, 3 ),
		   ( 2, 5, 1 ),
		   ( 2, 15, 2 ),
		   ( 3, 20, 3 ),
		   ( 3, 15, 1 ),
		   ( 3, 4, 2 ),
		   ( 4, 40, 3 ),
		   ( 4, 30, 1 ),
		   ( 4, 35, 2 );
		   
-- Locations generated from https://www.randomlists.com/random-addresses
INSERT INTO Locations ( Address, City, State )
	VALUES ( '789 Hillcrest Ave.', 'Lawrenceville', 'GA' ),
		   ( '498 North White Ave.', 'Ontario', 'CA' ),
		   ( '56 Gainsway Drive', 'Fremont', 'OH' );
