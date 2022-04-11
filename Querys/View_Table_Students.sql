USE MedemySchool
GO


CREATE VIEW [dbo].[uvw_ShowStudents]
AS
SELECT
StudentID, StudentName,StudentPassword, StudentFirstName,StudentLastName,StudentEmail,StudentPhoneNumber,StudentNationalCode,StudentAddress,StudentBirthDay,StudentPicture,
case StudentGender 
when 1 then N'Male'
else N'Female'
End as GenderStudent,
case StudentStatus
when 1 then N'Active'
else N'Deactive'
End As StatusStudent ,
StudentCreateDate,StudentCreateTime
FROM   tbl_students
GO


