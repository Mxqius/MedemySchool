Create Proc usp_DeleteAdmins
@AdminID int ,
@AdminStatus tinyint  
AS
set nocount On 
Begin
select * from tbl_admins
Update tbl_admins
Set  
AdminStatus = @AdminStatus 
where AdminID = @AdminID
END 
go
