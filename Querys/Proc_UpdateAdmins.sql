Create Proc usp_UpdateAdmins
@AdminID int ,
@AdminName nvarchar(50)  ,
@AdminPassword nvarchar(128)  ,
@AdminFirstName nvarchar(20)  ,
@AdminLastName nvarchar(30)  ,
@AdminPhoneNumber nvarchar(20)   ,
@AdminEmail nvarchar(50) ,
@AdminAddress nvarchar(128)  ,
@AdminNationalCode nvarchar(15)   ,
@AdminGender tinyint  , 
@AdminStatus tinyint  ,
@AdminPicture image ,
@AdminBirthDay Date  ,
@AdminRole tinyint,
@AdminCreateDate nvarchar(50)  ,
@AdminCreateTime nvarchar (50) 

AS
set nocount On 
Begin
select * from tbl_admins
Update tbl_admins
Set 
AdminName = @AdminName,
AdminPassword = @AdminPassword ,
AdminFirstName = @AdminFirstName ,
AdminLastName = @AdminLastName ,
AdminPhoneNumber = @AdminPhoneNumber ,
AdminEmail = @AdminEmail ,
AdminAddress = @AdminAddress ,
AdminNationalCode = @AdminNationalCode  ,
AdminGender = @AdminGender , 
AdminStatus = @AdminStatus ,
AdminPicture = @AdminPicture  ,
AdminBirthDay = @AdminBirthDay,
AdminRole = @AdminRole ,
AdminCreateDate = @AdminCreateDate ,
AdminCreateTime = @AdminCreateTime 
where AdminID = @AdminID
END 
go
