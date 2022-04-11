Create Proc usp_AddStudents
@StudentName nvarchar(50)  ,
@StudentPassword nvarchar(128)  ,
@StudentFirstName nvarchar(20)  ,
@StudentLastName nvarchar(30)  ,
@StudentPhoneNumber nvarchar(20)   ,
@StudentEmail nvarchar(50) ,
@StudentAddress nvarchar(128)  ,
@StudentNationalCode nvarchar(15)   ,
@StudentGender tinyint  , 
@StudentStatus tinyint  ,
@StudentPicture image ,
@StudentBirthDay Date  ,
@StudentCreateDate nvarchar(50)  ,
@StudentCreateTime nvarchar (50) 

AS
set nocount On 
Begin
select * from tbl_students
insert into tbl_students(
StudentName,StudentPassword,StudentFirstName,StudentLastName,StudentPhoneNumber,StudentEmail,StudentAddress,StudentNationalCode,StudentGender,
StudentStatus,StudentPicture,StudentBirthDay,StudentCreateDate,StudentCreateTime)
values (
@StudentName,
@StudentPassword ,
@StudentFirstName ,
@StudentLastName ,
@StudentPhoneNumber ,
@StudentEmail ,
@StudentAddress ,
@StudentNationalCode  ,
@StudentGender , 
@StudentStatus ,
@StudentPicture  ,
@StudentBirthDay,
@StudentCreateDate ,
@StudentCreateTime )
END 
go
