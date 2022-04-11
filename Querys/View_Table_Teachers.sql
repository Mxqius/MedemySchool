USE MedemySchool
GO


CREATE VIEW [dbo].[uvw_ShowTeachers]
AS
SELECT
TeacherID, TeacherName,TeacherPassword, TeacherFirstName,TeacherLastName,TeacherEmail,TeacherPhoneNumber,TeacherNationalCode,TeacherAddress,TeacherBirthDay,TeacherPicture,
case TeacherGender 
when 1 then N'Male'
else N'Female'
End as GenderTeacher,
case TeacherStatus
when 1 then N'Active'
else N'Deactive'
End As StatusTeacher ,
TeacherCreateDate,TeacherCreateTime
FROM   tbl_teachers
GO


