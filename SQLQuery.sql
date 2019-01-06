select * from Comments
select * from AspNetUsers where Id='359fbf2b-8c43-4cff-843d-7ba209b886ce'
select * from Dentists
select * from Reviews
insert into Events(Description,StartDate, DentistId)
values('Every sunday morning from 9 till 10 free of charge!', '20120618 09:00:00 AM', 1)
insert into Comments(UserId, Content, EventId)
values('05f9eaf6-6cb3-4dd9-90fa-17577ae25e44', "Great", 4)

insert into AspNetUsers(Id,DentistId, Rating)
values('359fbf2b-8c43-4cff-843d-7ba209b886ce',1, 5)

UPDATE AspNetUsers 
SET 
    PhoneNumber = 0875364587
WHERE
    DentistId=1