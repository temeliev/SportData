USE [SportDataDB]
GO

ALTER TABLE LocationCultures ADD CONSTRAINT DF_CDATE  
DEFAULT GETDATE() FOR CDate ; 

ALTER TABLE IdentityUsers ADD CONSTRAINT DF_Users_CDATE  
DEFAULT GETDATE() FOR CDate ; 

INSERT INTO Locations(Abbreviation)
VALUES('EUR'), ('ASI'), ('AFC'),('NCA'),('SAA'),('AOA'),('WOR')

INSERT INTO LocationCultures(LocationId,Name,CultureId)
VALUES 
       (1,'Европа',1), (1,'Europe',2),
	   (2,'Азия',1), (2,'Asia',2),
	   (3,'Африка',1), (3,'Africa',2),
	   (4, 'Северна и Централна Америка', 1), (4, 'North & Central America', 2),
	   (5,'Южна Америка',1), (5,'South America',2),
	   (6,'Австралия и Океания',1), (6,'Australia & Oceania',2),
	   (7,'Свят',1), (7,'World',2)

--update Locations
--set Abbreviation = 'ASI'
--WHERE Id = 2

SELECT * FROM Locations
SELECT * FROM LocationCultures


INSERT INTO PlayerStatuses(Name)
VALUES ('Договор'), ('Под наем'), ('Даден под наем')

INSERT INTO CompetitionTypes(Name)
VALUES ('Лига'), ('Купа'), ('Приятелски мач')



