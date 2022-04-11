Create Proc usp_UpdateTeachers
@TeacherID int ,
@TeacherName nvarchar(50)  ,
@TeacherPassword nvarchar(128)  ,
@TeacherFirstName nvarchar(20)  ,
@TeacherLastName nvarchar(30)  ,
@TeacherPhoneNumber nvarchar(20)   ,
@TeacherEmail nvarchar(50) ,
@TeacherAddress nvarchar(128)  ,
@TeacherNationalCode nvarchar(15)   ,
@TeacherGender tinyint  , 
@TeacherStatus tinyint  ,
@TeacherPicture image ,
@TeacherBirthDay Date  ,
@TeacherCreateDate nvarchar(50)  ,
@TeacherCreateTime nvarchar (50) 

AS
set nocount On 
Begin
select * from tbl_teachers
Update tbl_teachers
Set 
TeacherName = @TeacherName,
TeacherPassword = @TeacherPassword ,
TeacherFirstName = @TeacherFirstName ,
TeacherLastName = @TeacherLastName ,
TeacherPhoneNumber = @TeacherPhoneNumber ,
TeacherEmail = @TeacherEmail ,
TeacherAddress = @TeacherAddress ,
TeacherNationalCode = @TeacherNationalCode  ,
TeacherGender = @TeacherGender , 
TeacherStatus = @TeacherStatus ,
TeacherPicture = @TeacherPicture  ,
TeacherBirthDay = @TeacherBirthDay,
TeacherCreateDate = @TeacherCreateDate ,
TeacherCreateTime = @TeacherCreateTime 
where TeacherID = @TeacherID
END 
go
