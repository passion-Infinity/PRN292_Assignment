USE PRN292_Assignment
GO

Create proc spRegisterAccount
(
	@userID varchar(100),
	@fullName varchar(50),
	@password varchar(50),
	@phone varchar(15),
	@email varchar(50),
	@identityCard varchar(20),
	@gender varchar(10),
	@address varchar(200),
	@role varchar(10),
	@status bit,
	@createdDate date
)
As
	Insert tblUsers(UserID,FullName,Password,Phone,Email,IdentityCard,Gender,Address,Role,Status,CreatedDate)
	Values(@userID,@fullName,@password,@phone,@email,@identityCard,@gender,@address,@role,@status,@createdDate)
Return
GO

Create proc spUpdateAccount
(
	@userID varchar(100),
	@fullName varchar(50),
	@password varchar(50),
	@phone varchar(15),
	@email varchar(50),
	@identityCard varchar(20),
	@gender varchar(10),
	@address varchar(200),
	@role varchar(10),
	@status bit,
	@modifiedDate date
)
As
	Update tblUsers 
	Set FullName=@fullName, Password=@password, Phone=@phone, Email=@email, IdentityCard=@identityCard,
		Gender=@gender, Address=@address, Role=@role, Status=@status, ModifiedDate=@modifiedDate
	Where UserID=@userID
Return
GO


Create proc spUpdateStatusAccount
(
	@userID varchar(100),
	@status bit,
	@modifiedDate date
)
As
	Update tblUsers 
	Set Status=@status, ModifiedDate=@modifiedDate
	Where UserID=@userID
Return
GO


Create proc spAddNewRoom
(
	@roomTypeID int,
	@roomName varchar(50),
	@price float,
	@status bit,
	@createdDate date
)
As
	Insert tblRooms (RoomTypeID,RoomName,Price,Status,CreatedDate)
	Values (@roomTypeID,@roomName,@price,@status,@createdDate)
Return
GO


Create proc spAddNewRoomType
(
	@roomTypeName varchar(50),
	@people int
)
As
	Insert tblRoomType(RoomTypeName, People)
	Values (@roomTypeName, @people)
Return
GO


Create proc spUpdateRoom
(
	@roomID int,
	@roomTypeID int,
	@roomName varchar(50),
	@price float,
	@status bit,
	@modifiedDate date
)
As
	Update tblRooms Set RoomTypeID=@roomTypeID ,RoomName=@roomName, Price=@price, Status=@status, ModifiedDate=@modifiedDate
	Where RoomID=@roomID
Return
GO


Create proc spUpdateRoomType
(
	@roomTypeID int,
	@roomTypeName varchar(50),
	@people int
)
As
	Update tblRoomType Set RoomTypeName=@roomTypeName, People=@people
	Where RoomTypeID=@roomTypeID
Return
GO


Create proc spUpdateStatusRoom
(
	@roomID int,
	@status bit,
	@modifiedDate date
)
As
	Update tblRooms Set Status=@status, ModifiedDate=@modifiedDate
	Where RoomID=@roomID
Return
GO
