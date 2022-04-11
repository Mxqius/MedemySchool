Create Proc usp_DeleteStudents
@StudentID int ,
@StudentStatus tinyint  
AS
set nocount On 
Begin
select * from tbl_students
Update tbl_students
Set  
StudentStatus = @StudentStatus 
where StudentID = @StudentID
END 
go
