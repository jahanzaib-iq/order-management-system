SET IDENTITY_INSERT [order].OrderStatus ON
	INSERT INTO [order].OrderStatus (status_id, [name]) values (1, 'PENDING'), (2, 'COMPLETED'),(3, 'CANCELLED')
SET IDENTITY_INSERT [order].OrderStatus OFF
