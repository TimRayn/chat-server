USE [chatdb]
GO

INSERT INTO [dbo].[Users]
           ([Id]
           ,[NickName])
     VALUES
           ('8D92607B-C4F8-4660-81AD-C4F80AE94339'
           ,'Vasyl'),
		   ('6D6994FC-9126-4A6A-81B2-3C132F444200'
           ,'Petro')
GO

INSERT INTO [dbo].[RoomUser]
           ([RoomsRoomId]
           ,[UsersId])
     VALUES
           ('B7C83C21-09F2-46C2-9CB1-461AEA2565D4'
           ,'8D92607B-C4F8-4660-81AD-C4F80AE94339'),
		   ('B7C83C21-09F2-46C2-9CB1-461AEA2565D4'
           ,'6D6994FC-9126-4A6A-81B2-3C132F444200')
GO

INSERT INTO [dbo].[Messages]
           ([Id]
           ,[Date]
           ,[Content]
           ,[RoomId]
           ,[UserId]
           ,[IsDeletedForOwner]
           ,[RepliedMessageContent])
     VALUES
           ('D008AAF4-1EC4-4FF7-B443-FDA03419AF43'
           ,'2021-05-01 18:43:59.3960490'
           ,'Hi'
           ,'B7C83C21-09F2-46C2-9CB1-461AEA2565D4'
           ,'8D92607B-C4F8-4660-81AD-C4F80AE94339'
           ,0
           ,''),
		   ('00E62A13-C893-4674-AECA-DFB430DA746E'
           ,'2021-05-01 18:43:59.3960490'
           ,'Hello!'
           ,'B7C83C21-09F2-46C2-9CB1-461AEA2565D4'
           ,'6D6994FC-9126-4A6A-81B2-3C132F444200'
           ,0
           ,'Hi'),
           ('D9E58272-E2FE-4EA7-B3B2-4190E018D9EB'
           ,'2021-05-01 18:43:59.3960490'
           ,'What is your name?'
           ,'B7C83C21-09F2-46C2-9CB1-461AEA2565D4'
           ,'8D92607B-C4F8-4660-81AD-C4F80AE94339'
           ,0
           ,''),
		   ('4F9FDD1B-E547-4287-84ED-DABEE117F25B'
           ,'2021-05-01 18:43:59.3960490'
           ,'My name is Petro'
           ,'B7C83C21-09F2-46C2-9CB1-461AEA2565D4'
           ,'6D6994FC-9126-4A6A-81B2-3C132F444200'
           ,0
           ,'What is your name?'),
		   ('037275E4-2860-4D42-9454-7E8AADE33306'
           ,'2021-05-01 18:43:59.3960490'
           ,'Cool! Let`s be friends'
           ,'B7C83C21-09F2-46C2-9CB1-461AEA2565D4'
           ,'8D92607B-C4F8-4660-81AD-C4F80AE94339'
           ,0
           ,'')
GO

