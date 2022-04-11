Create Proc usp_UpdateStudents
@StudentID int ,
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
Update tbl_students
Set 
StudentName = @StudentName,
StudentPassword = @StudentPassword ,
StudentFirstName = @StudentFirstName ,
StudentLastName = @StudentLastName ,
StudentPhoneNumber = @StudentPhoneNumber ,
StudentEmail = @StudentEmail ,
StudentAddress = @StudentAddress ,
StudentNationalCode = @StudentNationalCode  ,
StudentGender = @StudentGender , 
StudentStatus = @StudentStatus ,
StudentPicture = @StudentPicture  ,
StudentBirthDay = @StudentBirthDay,
StudentCreateDate = @StudentCreateDate ,
StudentCreateTime = @StudentCreateTime 
where StudentID = @StudentID
END 
go
