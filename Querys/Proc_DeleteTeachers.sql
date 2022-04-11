Create Proc usp_DeleteTeachers
@TeacherID int ,
@TeacherStatus tinyint  
AS
set nocount On 
Begin
select * from tbl_teachers
Update tbl_teachers
Set  
TeacherStatus = @TeacherStatus
where TeacherID = @TeacherID
END 
go
