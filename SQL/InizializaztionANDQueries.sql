use Artworks
go

-- 1 CREATE
create table Museum (
Id_Museum int primary key not null,
MuseumName nvarchar(50) not null,
City nvarchar (50) not null
)

create table Artist (
Id_Artist int primary key not null,
[Name] nvarchar(50) not null,
Country nvarchar(50) not null,
)

create table [Character] (
Id_Character int primary key not null,
[Name] nvarchar(50) 
)

create table Artwork (
Id_Artwork int primary key  not null,
[Name] nvarchar(50) not null,
Id_Museum int references Museum (Id_Museum) not null,
Id_Artist int references Artist (Id_Artist) not null,
Id_Character int references [Character] (Id_Character)
)

-- 2 FILL
insert into Museum (Id_Museum, MuseumName, City)
values
(1,'Santa Maria Gloriosa dei Frari','Venezia'),
(2,'Louvre','Parigi'),
(3,'Galleria Borghese','Roma'),
(4,'Art Institute of Chicago','Chicago')

insert into Artist (Id_Artist, [Name], Country)
values
(1,'Tiziano Vecellio','Italia'),
(2,'Caravaggio','Italia'),
(3,'Picasso','Spagna')

insert into Character (Id_Character, [Name])
values 
(1,'Flora'),
(2,'Davide'),
(3,'Chitarrista')

insert into Artwork (Id_Artwork, [Name], Id_Museum, Id_Artist, Id_Character)
values
(1,'Flora', 1, 1, 1),
(2,'Concerto campestre',2 ,1, NULL),
(3,'Davide con la testa di Golia',3,2,2),
(4,'Il vecchio chitarrista cieco',4,3,3)

-- 3 QUERIES
--Scrivere una query "select" per recuperare la lista contenete: museo, nome opera, nome 
--personaggio degli artisti italiani.

select m.MuseumName, aw.Name as ArtworkName, c.Name as CharacterName
from Museum m
inner join Artwork aw on m.Id_Museum = aw.Id_Museum
inner join Artist a on aw.Id_Artist = a.Id_Artist
left join Character c on aw.Id_Character = c.Id_Character
where a.Country = 'Italia'

-- Scrivere una query per recuperare i nomi degli artisti le cui opere sono conservate a Parigi.
select distinct Artist.Name
from Artist
join Artwork on Artist.Id_Artist = Artwork.Id_Artist
join Museum on Artwork.Id_Museum = Museum.Id_Museum
where Museum.City = 'Parigi'

-- Scrivere una query “select” per recuperare la città in quale è conservato quadro "Flora".
select Museum.City
from Artwork
join Museum on Artwork.Id_Museum = Museum.Id_Museum
where Artwork.Name = 'Flora'