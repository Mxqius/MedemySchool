Create Proc usp_AddAdmins
@AdminName nvarchar(50)  ,
@AdminPassword nvarchar(128)  ,
@AdminFirstName nvarchar(20)  ,
@AdminLastName nvarchar(30)  ,
@AdminPhoneNumber nvarchar(20)   ,
@AdminEmail nvarchar(50) ,
@AdminAddress nvarchar(128)  ,
@AdminNationalCode nvarchar(20)   ,
@AdminGender tinyint  , 
@AdminStatus tinyint  ,
@AdminPicture image ,
@AdminBirthDay Date  ,
@AdminRole Tinyint  ,
@AdminCreateDate nvarchar(50)  ,
@AdminCreateTime nvarchar (50) 

AS
set nocount On 
Begin
select * from tbl_admins
insert into tbl_admins(
AdminName,AdminPassword,AdminFirstName,AdminLastName,AdminPhoneNumber,AdminEmail,AdminAddress,AdminNationalCode,AdminGender,
AdminStatus,AdminPicture,AdminBirthDay,AdminRole,AdminCreateDate,AdminCreateTime)
values (
@AdminName,
@AdminPassword ,
@AdminFirstName ,
@AdminLastName ,
@AdminPhoneNumber ,
@AdminEmail ,
@AdminAddress ,
@AdminNationalCode  ,
@AdminGender , 
@AdminStatus ,
@AdminPicture  ,
@AdminBirthDay,
@AdminRole,
@AdminCreateDate ,
@AdminCreateTime )
END 
go
