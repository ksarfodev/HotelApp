CREATE PROCEDURE [dbo].[spGuests_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50)
AS

begin
	set nocount on;

	if not exists (select 1 from dbo.Guests where FirstName = @firstName and LastName = @lastName) -- if p not exist in table insert
	begin
		insert into dbo.Guests(FirstName,LastName) values (@firstName,@lastName);
	end

	select top 1 [Id], [FirstName], [LastName] -- return record that matches
	from dbo.Guests
	where FirstName = @firstName and LastName = @lastName;

end
