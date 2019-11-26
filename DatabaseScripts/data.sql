SET IDENTITY_INSERT [dbo].[TrackingInfo] ON
INSERT INTO [dbo].[TrackingInfo] ([Id], [Description], [DeliveryStatus], [DispatchedOn]) VALUES (1, N'Documents', N'Shipped', N'2019-11-27 09:00:00')
INSERT INTO [dbo].[TrackingInfo] ([Id], [Description], [DeliveryStatus], [DispatchedOn]) VALUES (2, N'Gold plates', N'Delivered', N'2019-11-29 10:00:00')
INSERT INTO [dbo].[TrackingInfo] ([Id], [Description], [DeliveryStatus], [DispatchedOn]) VALUES (3, N'Laptop', N'Pending', N'2019-11-30 17:00:00')
SET IDENTITY_INSERT [dbo].[TrackingInfo] OFF
