-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop 
-- --------------------------------------------------------------------------------
--Drop Stored Procedures
IF OBJECT_ID('uspAddGolfer')			IS NOT NULL DROP PROCEDURE uspAddGolfer
IF OBJECT_ID('uspAddEvent')				IS NOT NULL DROP PROCEDURE uspAddEvent
IF OBJECT_ID('uspAddGolferEvent')		IS NOT NULL DROP PROCEDURE uspAddGolferEvent
IF OBJECT_ID('uspUpdateGolfer')		IS NOT NULL DROP PROCEDURE uspUpdateGolfer
IF OBJECT_ID('uspDeleteGolfer')		IS NOT NULL DROP PROCEDURE uspDeleteGolfer
IF OBJECT_ID('uspDeleteEvent')		IS NOT NULL DROP PROCEDURE uspDeleteEvent
IF OBJECT_ID('uspDeleteEventGolfer')		IS NOT NULL DROP PROCEDURE uspDeleteEventGolfer
IF OBJECT_ID('uspAddSponsor')		IS NOT NULL DROP PROCEDURE uspAddSponsor
IF OBJECT_ID('uspDeleteSponsor')		IS NOT NULL DROP PROCEDURE uspDeleteSponsor
IF OBJECT_ID('uspUpdateSponsor')		IS NOT NULL DROP PROCEDURE uspUpdateSponsor
IF OBJECT_ID('uspAddGolferEventYearSponsor')		IS NOT NULL DROP PROCEDURE uspAddGolferEventYearSponsor


--DROP VIEWS
IF OBJECT_ID('vCurrentEventYear')		IS NOT NULL DROP VIEW vCurrentEventYear
IF OBJECT_ID('vCurrentEventGolfers')		IS NOT NULL DROP VIEW vCurrentEventGolfers
IF OBJECT_ID('vAvailableGolfers')		IS NOT NULL DROP VIEW vAvailableGolfers
IF OBJECT_ID('vGolferGender')		IS NOT NULL DROP VIEW vGolferGender
IF OBJECT_ID('vGolferEventYearSponsors')		IS NOT NULL DROP VIEW vGolferEventYearSponsors
IF OBJECT_ID('vGolferEvents')		IS NOT NULL DROP VIEW vGolferEvents
IF OBJECT_ID('vGolferEvents')		IS NOT NULL DROP VIEW vGolferEvents
IF OBJECT_ID('vGolferEvents')		IS NOT NULL DROP VIEW vGolferEvents
IF OBJECT_ID('vGolferEvents')		IS NOT NULL DROP VIEW vGolferEvent
--Drop Tables
IF OBJECT_ID( 'TGolferEventYearSponsors' )		IS NOT NULL DROP TABLE	TGolferEventYearSponsors
IF OBJECT_ID( 'TGolferEventYears' )				IS NOT NULL DROP TABLE	TGolferEventYears
IF OBJECT_ID( 'TEventYears' )					IS NOT NULL DROP TABLE	TEventYears
IF OBJECT_ID( 'TGolfers' )						IS NOT NULL DROP TABLE	TGolfers
IF OBJECT_ID( 'TGenders' )						IS NOT NULL DROP TABLE	TGenders
IF OBJECT_ID( 'TShirtSizes' )					IS NOT NULL DROP TABLE	TShirtSizes
IF OBJECT_ID( 'TPaymentTypes' )					IS NOT NULL DROP TABLE	TPaymentTypes
IF OBJECT_ID( 'TSponsors' )						IS NOT NULL DROP TABLE	TSponsors
IF OBJECT_ID( 'TSponsorTypes' )					IS NOT NULL DROP TABLE	TSponsorTypes


-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TEventYears
(
	 intEventYearID		INTEGER			NOT NULL
	,intEventYear		INTEGER			NOT NULL
	,CONSTRAINT TEventYears_PK PRIMARY KEY ( intEventYearID	)
)

CREATE TABLE TGenders
(
	 intGenderID		INTEGER			NOT NULL
	,strGenderDesc			VARCHAR(50)		NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TShirtSizes
(
	 intShirtSizeID			INTEGER			NOT NULL
	,strShirtSizeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TShirtSizes_PK PRIMARY KEY ( intShirtSizeID )
)

CREATE TABLE TGolfers
(
	 intGolferID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,intShirtSizeID		INTEGER			NOT NULL
	,intGenderID		INTEGER			NOT NULL
	,CONSTRAINT TGolfers_PK PRIMARY KEY ( intGolferID )
)

CREATE TABLE TSponsors
(
	 intSponsorID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsors_PK PRIMARY KEY ( intSponsorID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID		INTEGER			NOT NULL
	,strPaymentTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TGolferEventYears
(
	 intGolferEventYearID	INTEGER		NOT NULL
	,intGolferID			INTEGER			NOT NULL
	,intEventYearID			INTEGER			NOT NULL
	,CONSTRAINT TGolferEventYears_UQ UNIQUE ( intGolferID, intEventYearID )
	,CONSTRAINT TGolferEventYears_PK PRIMARY KEY ( intGolferEventYearID )
)


CREATE TABLE TGolferEventYearSponsors
(
	 intGolferEventYearSponsorID	INTEGER			NOT NULL
	,intGolferID					INTEGER			NOT NULL
	,intEventYearID					INTEGER			NOT NULL
	,intSponsorID					INTEGER			NOT NULL
	,monPledgeAmount				MONEY			NOT NULL
	,intSponsorTypeID				INTEGER			NOT NULL
	,intPaymentTypeID				INTEGER			NOT NULL
	,blnPaid						BIT			NOT NULL
	,CONSTRAINT TGolferEventYearSponsors_UQ UNIQUE ( intGolferID, intEventYearID, intSponsorID )
	,CONSTRAINT TGolferEventYearSponsors_PK PRIMARY KEY ( intGolferEventYearSponsorID )
)

CREATE TABLE TSponsorTypes
(
	 intSponsorTypeID		INTEGER			NOT NULL
	,strSponsorTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsorTypes_PK PRIMARY KEY ( intSponsorTypeID )
)


-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TGolfers						TGenders					intGenderID
-- 2	TGolfers						TShirtSizes					intShirtSizeID
-- 3    TGolferEventYears				TGolfers					intGolferID
-- 4	TGolferEventYearSponsors		TGolferEventYears			intGolferID, intEventYearID
-- 5	TGolferEventYears				TEventYears					intEventYearID
-- 6    TGolferEventYearSponsors		TSponsors					intSponsorID
-- 7	TGolferEventYearSponsors		TSponsorTypes				intSponsorTypeID
-- 8	TGolferEventYearSponsors		TPaymentTypes				intPaymentTypeID

-- 1
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID )

-- 2
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY ( intShirtSizeID ) REFERENCES TShirtSizes ( intShirtSizeID )

-- 3
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TGolfers_FK
FOREIGN KEY ( intGolferID ) REFERENCES TGolfers ( intGolferID )

-- 4
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TGolferEventYears_FK
FOREIGN KEY ( intGolferID, intEventYearID ) REFERENCES TGolferEventYears ( intGolferID, intEventYearID )

-- 5
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TEventYears_FK
FOREIGN KEY ( intEventYearID ) REFERENCES TEventYears ( intEventYearID )

-- 6
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsors_FK
FOREIGN KEY ( intSponsorID ) REFERENCES TSponsors ( intSponsorID )

-- 7
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsorTypes_FK
FOREIGN KEY ( intSponsorTypeID ) REFERENCES TSponsorTypes ( intSponsorTypeID )

-- 8
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )

-- --------------------------------------------------------------------------------
-- Step #3: Add data to Gender
-- --------------------------------------------------------------------------------

INSERT INTO TGenders( intGenderID, strGenderDesc)
VALUES		(1, 'Female')
		,(2, 'Male')

---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TShirtSizes( intShirtSizeID, strShirtSizeDesc)
VALUES		(1, 'Mens Small')
		,(2, 'Mens Medium')
		,(3, 'Mens Large')
		,(4, 'Mens XLarge')
		,(5, 'Womens Small')
		,(6, 'Womens Medium')
		,(7, 'Womens Large')
		,(8, 'Womens XLarge')

---- --------------------------------------------------------------------------------
---- Step #5: Add years
---- --------------------------------------------------------------------------------
INSERT INTO TEventYears ( intEventYearID, intEventYear )
	VALUES	 ( 1, 2018)
		,( 2, 2019)
		,(3, 2020)
		

---- --------------------------------------------------------------------------------
---- Step #6: Add sponsor types
---- --------------------------------------------------------------------------------
INSERT INTO TSponsorTypes ( intSponsorTypeID, strSponsorTypeDesc)
	VALUES (1, 'Parent')
		,(2, 'Alumni')
		,(3, 'Friend')
		,(4, 'Business')

---- --------------------------------------------------------------------------------
---- Step #7: Add payment types
---- --------------------------------------------------------------------------------
INSERT INTO TPaymentTypes ( intPaymentTypeID, strPaymentTypeDesc)
	VALUES (1, 'Check')
		,(2, 'Cash')
		,(3, 'Credit Card')
---- --------------------------------------------------------------------------------
---- Step #8: Add sponsors
---- --------------------------------------------------------------------------------

INSERT INTO TSponsors ( intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
VALUES	 ( 1, 'Jim', 'Smith', '1979 Wayne Trace Rd.', 'Willow', 'OH', '42368', '5135551212', 'jsmith@yahoo.com' )
		,( 2, 'Sally', 'Jones', '987 Mills Rd.', 'Cincinnati', 'OH', '45202', '5135551234', 'sjones@yahoo.com' )

---- --------------------------------------------------------------------------------
---- Step #9: Add golfers
---- --------------------------------------------------------------------------------

INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID )
VALUES	 ( 1, 'Bill', 'Goldstein', '156 Main St.', 'Mason', 'OH', '45040', '5135559999', 'bGoldstein@yahoo.com', 1, 2 )
		,( 2, 'Tara', 'Everett', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101', 'teverett@yahoo.com', 6, 1 )
		,( 3, 'Tiger', 'Woods', '1234 Street Rd', 'Dayton', 'OH', '65432', '1234567890', 'Twoods@yahoo.com', 2, 2 )

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------

INSERT INTO TGolferEventYears ( intGolferEventYearID, intGolferID, intEventYearID)
	VALUES (1, 1, 1)
		,(2, 2, 1)
		,(3, 1, 2)
		,(4,3,3)
		,(5,1,3)
		
		 
		
		


---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------
INSERT INTO TGolferEventYearSponsors ( intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid )
VALUES	 ( 1, 1, 1, 1, 25.00, 1, 1, 1 )
		,( 2, 1, 2, 1, 25.00, 1, 1, 1 )
		,(3, 1, 1, 2, 25.00, 1, 1, 1)
		,(4, 2, 1, 2, 75.00, 1, 1, 1)
		--,( 5, 3, 3, 1, 95.00, 1, 1, 1 )


		



GO 

---------------------------------------------------------
--ADD EVENT
---------------------------------------------------------

CREATE PROCEDURE uspAddEvent
	 @intEventYearID	AS INTEGER OUTPUT
	,@intEventYear		AS VARCHAR(50)

AS 
SET XACT_ABORT ON 

BEGIN TRANSACTION

	SELECT @intEventYearID = MAX(intEventYearID) + 1
	From TEventYears (TABLOCKX)

	SELECT @intEventYearID = COALESCE(@intEventYearID, 1)
	INSERT INTO TEventYears (intEventYearID,intEventYear)
	VALUES (@intEventYearID, @intEventYear)
COMMIT TRANSACTION
GO

---------------------------------------------------------
--DELETE EVENT
---------------------------------------------------------
CREATE PROCEDURE uspDeleteEvent
	@EventYearID AS INTEGER OUTPUT

AS 
SET XACT_ABORT ON 

BEGIN TRANSACTION
DELETE FROM TGolferEventYearSponsors
DELETE FROM TGolferEventYears
DELETE FROM TEventYears

Where intEventYearID = @EventYearID

Commit Transaction
GO


---------------------------------------------------------
--ADD GOLFER
---------------------------------------------------------

GO 
Create PROCEDURE uspAddGolfer
		 @intGolferID		AS INTEGER OUTPUT
		,@strFirstName		AS VARCHAR(50)
		,@strLastName		AS VARCHAR(50)
		,@strStreetAddress	AS VARCHAR(50)
		,@strCity			AS VARCHAR(50)
		,@strState			AS VARCHAR(50)
		,@strZip			AS VARCHAR(50)
		,@strPhoneNumber	AS VARCHAR(50)
		,@strEmail			AS VARCHAR(50)
		,@intGenderID		AS INTEGER
		,@intShirtSizeID	AS INTEGER
		

AS 

SET XACT_ABORT ON

BEGIN TRANSACTION 

	SELECT @intGolferID = MAX(intGolferID) + 1
	FROM TGolfers (TABLOCKX) -- LOCK TABLE UNITL END OF TRANSACTION

	

	--SET DEFAULT TO 1 IF TABLE IS EMPTY
	SELECT @intGolferID = COALESCE(@intGolferID, 1)
	INSERT INTO TGolfers (intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail,intShirtSizeID, intGenderID)
	VALUES (@intGolferID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID) 

COMMIT TRANSACTION 

GO
DECLARE @intGolferID AS INTEGER = 0 
EXECUTE uspAddGolfer @intGolferID OUTPUT, 'Corey','Adams','Beatty Rd','Hillsboro','Oh','45133','1234567890','EMAIL@EMAIL.com',2,2
--PRINT 'Golfer ID = ' + CONVERT(VARCHAR,@intGolferID)

GO 
---------------------------------------------------------
--DELETE GOLFER
---------------------------------------------------------
GO
Create PROCEDURE uspDeleteGolfer
	@GolferID as INTEGER OUTPUT

AS
SET XACT_ABORT ON

BEGIN Transaction
DELETE FROM TGolferEventYearSponsors 
DELETE FROM TGolferEventYears  
DELETE FROM TGolfers 

WHERE intGolferID = @GolferID

Commit Transaction
GO
---------------------------------------------------------
--ADD Sponsor
---------------------------------------------------------

GO 
Create PROCEDURE uspAddSponsor
		 @intSponsorID	AS INTEGER OUTPUT
		,@strFirstName		AS VARCHAR(50)
		,@strLastName		AS VARCHAR(50)
		,@strStreetAddress	AS VARCHAR(50)
		,@strCity			AS VARCHAR(50)
		,@strState			AS VARCHAR(50)
		,@strZip			AS VARCHAR(50)
		,@strPhoneNumber	AS VARCHAR(50)
		,@strEmail			AS VARCHAR(50)

		

AS 

SET XACT_ABORT ON

BEGIN TRANSACTION 

	SELECT @intSponsorID = MAX(intSponsorID) + 1
	FROM TSponsors (TABLOCKX) -- LOCK TABLE UNITL END OF TRANSACTION

	

	--SET DEFAULT TO 1 IF TABLE IS EMPTY
	SELECT @intSponsorID = COALESCE(@intSponsorID, 1)
	INSERT INTO TSponsors(intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail)
	VALUES (@intSponsorID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail) 

COMMIT TRANSACTION 

GO

DECLARE @intSponsorID AS INTEGER = 0 
EXECUTE uspAddSponsor @intSponsorID OUTPUT, 'Billy','Bob','Tucker Rd','Leesburg','Oh','75355','1234567890','Billy@EMAIL.com'

GO 
---------------------------------------------------------
--Update GOLFER
---------------------------------------------------------
CREATE PROCEDURE uspUpdateGolfer
	@GolferID			AS INTEGER OUTPUT,
	@strFirstName		AS VARCHAR(50),
	@strLastName		AS VARCHAR(50),
	@strStreetAddress	AS VARCHAR(50),
	@strCity			AS VARCHAR(50),
	@strState			AS VARCHAR(50),
	@strZip				AS VARCHAR(50),
	@strPhoneNumber		AS VARCHAR(50),
	@strEmail			AS VARCHAR(50), 
	@intShirtSizeID		AS INTEGER, 
	@intGenderID		AS INTEGER

	AS 
	
	SET XACT_ABORT ON
	
	BEGIN TRANSACTION
	
	UPDATE TGolfers
	
	SET strFirstName =		@strFirstName ,
		strLastName =		@strLastName,
		strStreetAddress =	@strStreetAddress , 
		strCity =			@strCity , 
		strState =			@strState ,
		strZip =			@strZip ,
		strPhoneNumber =	@strPhoneNumber , 
		strEmail =			@strEmail,	
		intShirtSizeID =	@intShirtSizeID,
		intGenderID =		@intGenderID
	
	WHERE intGolferID = @GolferID
	
	COMMIT TRANSACTION

GO

---------------------------------------------------------
--Update Sponsor
---------------------------------------------------------
CREATE PROCEDURE uspUpdateSponsor
	@intSponsorID			AS INTEGER OUTPUT,
	@strFirstName		AS VARCHAR(50),
	@strLastName		AS VARCHAR(50),
	@strStreetAddress	AS VARCHAR(50),
	@strCity			AS VARCHAR(50),
	@strState			AS VARCHAR(50),
	@strZip				AS VARCHAR(50),
	@strPhoneNumber		AS VARCHAR(50),
	@strEmail			AS VARCHAR(50) 
	

	AS 
	
	SET XACT_ABORT ON
	
	BEGIN TRANSACTION
	
	UPDATE TSponsors
	
	SET strFirstName =		@strFirstName ,
		strLastName =		@strLastName,
		strStreetAddress =	@strStreetAddress , 
		strCity =			@strCity , 
		strState =			@strState ,
		strZip =			@strZip ,
		strPhoneNumber =	@strPhoneNumber , 
		strEmail =			@strEmail	

	WHERE intSponsorID = @intSponsorID
	
	COMMIT TRANSACTION

GO
---------------------------------------------------------
--DELETE Sponsor
---------------------------------------------------------
GO
Create PROCEDURE uspDeleteSponsor
	@SponsorID as INTEGER OUTPUT

AS
SET XACT_ABORT ON

BEGIN Transaction

DELETE FROM TGolferEventYearSponsors
DELETE FROM TSponsors 

WHERE intSponsorID = @SponsorID 

Commit Transaction
GO

---------------------------------------------------------
--ADD GOLFER EVENT
---------------------------------------------------------
CREATE PROCEDURE uspAddGolferEvent
	@intGolferEventYearID	AS INTEGER OUTPUT
	,@intGolferID		AS INTEGER
	,@intEventYearID		AS INTEGER

AS

SET XACT_ABORT ON

BEGIN TRANSACTION

	Select @intGolferEventYearID = MAX( intGolferEventYearID) + 1 
	FROM TGolferEventYears (TABLOCKX)

	SELECT @intGolferEventYearID = COALESCE(@intGolferEventYearID,1)
	INSERT INTO TGolferEventYears (intGolferEventYearID, intGolferID ,intEventYearID)
	VALUES (@intGolferEventYearID, @intGolferID, @intEventYearID)

Commit Transaction

GO

CREATE PROCEDURE uspAddGolferEventYearSponsor
	@intGolferEventYearSponsorID AS INTEGER OUTPUT
	,@intGolferID AS INTEGER
	,@intEventYearID AS INTEGER
	,@intSponsorID AS INTEGER
	,@monPledgeAmount AS MONEY
	,@intSponsorTypeID AS INTEGER
	,@intPaymentTypeID AS INTEGER
	,@blnPAID AS INTEGER

AS

SET XACT_ABORT ON

BEGIN TRANSACTION

	SELECT @intGolferEventYearSponsorID = MAX(intGolferEventYearSponsorID) + 1 
	FROM TGolferEventYearSponsors (TABLOCKX)

	SELECT  @intGolferEventYearSponsorID = COALESCE(@intGolferEventYearSponsorID, 1)
	INSERT INTO TGolferEventYearSponsors (intGolferEventYearSponsorID, intGolferID, intEventYearID,intSponsorID,monPledgeAmount,intSponsorTypeID,intPaymentTypeID,blnPaid)
	VALUES (@intGolferEventYearSponsorID, @intGolferID,@intEventYearID, @intSponsorID,@monPledgeAmount,@intSponsorTypeID,@intPaymentTypeID,@blnPaid)
COMMIT TRANSACTION
GO


---------------------------------------------------------
--DELETE GOLFER EVENT
---------------------------------------------------------
GO 
CREATE PROCEDURE uspDeleteEventGolfer
	@GolferID as Integer OUTPUT
	,@intEventYearID as Integer

AS 
SET XACT_ABORT ON

BEGIN Transaction

DELETE FROM TGolferEventYears

WHERE intGolferID = @GolferID and intEventYearID = @intEventYearID

Commit Transaction
Go

---------------------------------------------------------
--VIEW GolferEvents
---------------------------------------------------------
CREATE VIEW vGolferEvents
as
SELECT
TG.intGolferID as GolferID,
TG.strLastName,
TEY.intEventYear,
TEY.intEventYearID

From 
TGolfers as TG
Join TGolferEventYears as TGEY
	ON TG.intGolferID = TGEY.intGolferID
Join TEventYears as TEY
	ON TGEY.intEventYearID = TEY.intEventYearID
GO

SELECT * FROM vGolferEvents WHERE GolferID = 4
GO
---------------------------------------------------------
--VIEW CURRENT EVENT YEAR
---------------------------------------------------------
CREATE VIEW vCurrentEventYear
AS
SELECT
	intEventYearID ,intEventYear
FROM
	TEventYears
WHERE intEventYear =  (SELECT MAX(intEventYear) From TEventYears)	
GO


		

---------------------------------------------------------
--VIEW CURRENT EVENT GOLFERS
---------------------------------------------------------
Create VIEW vCurrentEventGolfers
AS 
SELECT
	  TG.intGolferID
	, TG.strLastName as CurrentGolfers
	, TEY.intEventYear as CurrentEventYear
FROM
	TGolfers as TG
		JOIN TGolferEventYears AS TGEY
			ON TG.intGolferID = TGEY.intGolferID
		JOIN TEventYears as TEY
			ON TEY.intEventYearID = TGEY.intEventYearID

WHERE intEventYear =  (SELECT MAX(intEventYear) From TEventYears)

GO



---------------------------------------------------------
--VIEW AVAILABLE GOLFERS
---------------------------------------------------------
CREATE VIEW vAvailableGolfers
AS 
SELECT
	intGolferID
	,strFirstName as AvailableGolfers
FROM
	TGolfers
Where 
	intGolferID NOT IN (SELECT intGolferID FROM vCurrentEventGolfers)
GO



---------------------------------------------------------
--VIEW Golfer Event Year Sponsors
---------------------------------------------------------
Create View vGolferEventYearSponsors 
as
SELECT 
	TEY.intEventYearID as EventYearID,
	TG.intGolferID as GolferID,
	TS.intSponsorID as SponsorID,
	TS.strLastName as Sponsor

From 
		TGolfers as TG
		JOIN TGolferEventYearSponsors as TGEYS
			ON TG.intGolferID = TGEYS.intGolferID
		JOIN TPaymentTypes as TPT
			ON TGEYS.intPaymentTypeID = TPT.intPaymentTypeID
		JOIN TSponsorTypes as TSP
			ON TGEYS.intSponsorTypeID = TSP.intSponsorTypeID
		JOIN TEventYears as TEY
			ON TGEYS.intEventYearID = TEY.intEventYearID
		JOIN TSponsors as TS
			ON TS.intSponsorID = TGEYS.intSponsorID

Go

Select Sponsor from vGolferEventYearSponsors Where GolferID = 1 and EventYearID = 1


SELECT SUM(TGEYS.monPledgeAmount) as EventPledgeSum FROM TGolfers as TG JOIN TGolferEventYearSponsors as TGEYS ON TG.intGolferID = TGEYS.intGolferID Where  TGEYS.intEventYearID = 1

go


SELECT SUM(TGEYS.monPledgeAmount) as EventGolferPledgeSum FROM TGolfers as TG JOIN TGolferEventYearSponsors as TGEYS ON TG.intGolferID = TGEYS.intGolferID Where TG.intGolferID = 2 and TGEYS.intEventYearID = 1
GO

SELECT SUM(TGEYS.monPledgeAmount) as EventSponsorPledgeSum FROM TSponsors as TS JOIN TGolferEventYearSponsors as TGEYS ON TS.intSponsorID = TGEYS.intSponsorID Where TS.intSponsorID = 2 and TGEYS.intEventYearID = 1
go



Select * From vAvailableGolfers

Select * From vCurrentEventGolfers

Select * From vCurrentEventYear


GO

SELECT intSponsorTypeID, strSponsorTypeDesc From TSponsorTypes
GO
SELECT intPaymentTypeID, strPaymentTypeDesc From TPaymentTypes
GO

SELECT
	  TG.intGolferID
	, TG.strLastName as Golfers
	, TEY.intEventYear as EventYear
	,TGEYS.intSponsorID as SponsorID
	 ,TGEYS.monPledgeAmount as Pledge 
	 ,TGEYS.blnPaid as PaidStatus  
	,TS.strLastName as Sponsor
	,TPT.strPaymentTypeDesc as PaymentType
	,TSP.strSponsorTypeDesc as SponserType
FROM
	TGolfers as TG
		JOIN TGolferEventYearSponsors as TGEYS
			ON TG.intGolferID = TGEYS.intGolferID
		JOIN TPaymentTypes as TPT
			ON TGEYS.intPaymentTypeID = TPT.intPaymentTypeID
		JOIN TSponsorTypes as TSP
			ON TGEYS.intSponsorTypeID = TSP.intSponsorTypeID
		JOIN TEventYears as TEY
			ON TGEYS.intEventYearID = TEY.intEventYearID
		JOIN TSponsors as TS
			ON TS.intSponsorID = TGEYS.intSponsorID



GO
SELECT SUM(TGEYS.monPledgeAmount) as EventPledgeSum FROM TGolfers as TG JOIN TGolferEventYearSponsors as TGEYS ON TG.intGolferID = TGEYS.intGolferID Where TGEYS.intEventYearID = 3