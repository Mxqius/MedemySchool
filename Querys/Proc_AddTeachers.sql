Create Proc usp_AddTeachers
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
insert into tbl_teachers(
TeacherName,TeacherPassword,TeacherFirstName,TeacherLastName,TeacherPhoneNumber,TeacherEmail,TeacherAddress,TeacherNationalCode,TeacherGender,
TeacherStatus,TeacherPicture,TeacherBirthDay,TeacherCreateDate,TeacherCreateTime)
values (
@TeacherName,
@TeacherPassword ,
@TeacherFirstName ,
@TeacherLastName ,
@TeacherPhoneNumber ,
@TeacherEmail ,
@TeacherAddress ,
@TeacherNationalCode  ,
@TeacherGender , 
@TeacherStatus ,
@TeacherPicture  ,
@TeacherBirthDay,
@TeacherCreateDate ,
@TeacherCreateTime )
END 
go
