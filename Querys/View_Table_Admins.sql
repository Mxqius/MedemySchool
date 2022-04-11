USE MedemySchool
GO


CREATE VIEW [dbo].[uvw_ShowAdmins]
AS
SELECT
AdminID, AdminName,AdminPassword, AdminFirstName,AdminLastName,AdminEmail,AdminPhoneNumber,AdminNationalCode,AdminAddress,AdminBirthDay,AdminPicture,
case AdminGender 
when 1 then N'Male'
else N'Female'
End as GenderAdmin,
case AdminStatus
when 1 then N'Active'
else N'Deactive'
End As StatusAdmin ,
case AdminRole
when 1 then N'Manager'
else N'Admin'
End As RoleAdmin,
AdminCreateDate,AdminCreateTime
FROM   tbl_admins
GO


