select * from reservation

delete from reservation


create or alter procedure SelectAllReservations
as
	select * from reservation

exec SelectAllReservations
