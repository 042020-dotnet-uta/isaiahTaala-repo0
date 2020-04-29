-- basic exercises in groups of 3 (Chinook database)
-- 1. List all customers (full names, customer ID, and country) who are not in the US
SELECT FirstName, LastName, CustomerId, Country FROM Customer
WHERE Country != 'USA';

-- 2. List all customers from brazil
SELECT * FROM Customer
WHERE Country = 'Brazil';

-- 3. List all sales agents
SELECT * FROM Employee
WHERE Title LIKE '%Sales%Agent%';

-- 4. Show a list of all countries in billing addresses on invoices.
SELECT DISTINCT BillingCountry FROM Invoice;

-- 5. How many invoices were there in 2009, and what was the sales total for that year?
SELECT Count(CustomerId) as TotalCustomers, SUM(Total) as SumTotal FROM Invoice
WHERE InvoiceDate LIKE '%2009%';

-- 6. How many line items were there for invoice #37?
SELECT Count(InvoiceId) as LineItems FROM Invoice
WHERE InvoiceId = 37;

-- 7. How many invoices per country?
SELECT BillingCountry, Count(BillingCountry) as TotalInvoices from Invoice 
Group by BillingCountry;

-- 8. Show total sales per country, ordered by highest sales first.
SELECT BillingCountry, SUM( Total ) as TotalSales from Invoice
Group By BillingCountry
Order By Sum(Total) DESC;