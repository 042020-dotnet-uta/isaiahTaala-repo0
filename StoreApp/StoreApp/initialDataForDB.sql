-- Script Date: 5/4/2020 5:26 PM  - ErikEJ.SqlCeScripting version 3.5.2.86
           
-- Names generated from http://random-name-generator.info/
INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Password)
     VALUES ( 0, 'Fernando', 'Roberson', 'frob@gmail.com', 'ferr06' ),
     		( 1, 'Mike', 'Mclaughlin', 'mmcl@yahoo.com', 'mikmc1' ),
     		( 2, 'Lena', 'Spencer', 'lspe@aol.com', 'lensp3' ),
     		( 3, 'Don', 'Webster', 'dweb@gmail.com', 'donwe6' ),
     		( 4, 'Arlene', 'Lawrence', 'alaw@yahoo.com', 'arlla3' );
	          
INSERT INTO Orders (OrderID, CustomerID, StoreLocationID, TimeStamp)
	VALUES ( 0, 3, 1, '2019-05-23T15:24:56.200' ),
		   ( 1, 3, 1, '2019-06-18T19:36:22.200' ),
		   ( 2, 1, 0, '2019-07-28T15:01:21.200' ),
		   ( 3, 2, 2, '2019-08-20T10:36:56.200' ), 
		   ( 4, 4, 0, '2019-08-22T15:30:34.200' ),
		   ( 5, 2, 1, '2019-08-28T15:36:50.200' ),
		   ( 6, 3, 1, '2020-01-28T15:37:04.200' );
		   
INSERT INTO ProductOrders ( ProductOrderID, OrderID, ProductID, Quantity )
	VALUES ( 0, 0, 3, 4 ),
		   ( 1, 0, 2, 2 ),
		   ( 2, 1, 3, 3 ),
		   ( 3, 2, 0, 2 ),
		   ( 4, 2, 1, 1 ),
		   ( 5, 2, 4, 1 ),
		   ( 6, 3, 0, 3 ),
		   ( 7, 4, 1, 4 ),
		   ( 8, 5, 2, 5 ),
		   ( 9, 5, 4, 2 ),
		   ( 10, 6, 3, 5 );
		   
INSERT INTO Product ( ProductID, Name, Price )
	VALUES ( 0, 'Toilet Paper', 10 ),
		   ( 1, 'Chocolate', 2 ),
		   ( 2, 'Headphones', 50 ),
		   ( 3, 'Lamp', 20 ),
		   ( 4, 'TV', 300 );
		   
INSERT INTO Stocks ( StockID, ProductID, Quantity, LocationID )
	VALUES ( 0, 0, 100, 0 ),
		   ( 1, 0, 200, 1 ),
		   ( 2, 0, 10, 2 ),
		   ( 3, 1, 500, 0 ),
		   ( 4, 1, 400, 1 ),
		   ( 5, 1, 300, 2 ),
		   ( 6, 2, 10, 0 ),
		   ( 7, 2, 5, 1 ),
		   ( 8, 2, 15, 2 ),
		   ( 9, 3, 20, 0 ),
		   ( 10, 3, 15, 1 ),
		   ( 11, 3, 4, 2 ),
		   ( 12, 4, 40, 0 ),
		   ( 13, 4, 30, 1 ),
		   ( 14, 4, 35, 2 );
		   
-- Locations generated from https://www.randomlists.com/random-addresses
INSERT INTO Location ( LocationID, Address, City, State )
	VALUES ( 0, '789 Hillcrest Ave.', 'Lawrenceville', 'GA' ),
		   ( 1, '498 North White Ave.', 'Ontario', 'CA' ),
		   ( 2, '56 Gainsway Drive', 'Fremont', 'OH' );
