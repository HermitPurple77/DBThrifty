SELECT 
    pay.PaymentID,
    c.CustomerName,
    c.Phone AS Contact,
    o.OrderID,
    p.ProductName,
    o.Quantity AS QtyOrdered,
    o.TotalAmount AS OrderTotal,
    pay.PaymentMethod,
    pay.AmountPaid,
    pay.PaymentDate
FROM Payments pay
JOIN Customers c ON pay.CustomerID = c.CustomerID
LEFT JOIN Orders o ON pay.OrderID = o.OrderID
LEFT JOIN Products p ON o.ProductID = p.ProductID
ORDER BY pay.PaymentDate DESC;
