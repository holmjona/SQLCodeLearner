--DROP TABLE ProjectPeople
--DROP TABLE Projects
--DROP TABLE ProjectTypes
--DROP TABLE People

CREATE TABLE dbo.People(
	PersonID int IDENTITY(1,1) PRIMARY KEY
	,FirstName nvarchar(40) NOT NULL
	,LastName nvarchar(40)  NOT NULL
	,DateOfBirth datetime  NOT NULL
	,IsManager bit  NOT NULL
	,Prefix nvarchar(6)  NOT NULL
	,Postfix nvarchar(8)  NOT NULL
	,Phone nvarchar(15)  NOT NULL
	,Email nvarchar(250)  NOT NULL
	,Homepage nvarchar(400) NOT NULL
)

CREATE TABLE dbo.ProjectTypes(
	ProjectTypeID int IDENTITY(1,1) PRIMARY KEY
	,Name nvarchar(200) NOT NULL
)

CREATE TABLE dbo.Projects(
	ProjectID int IDENTITY(1,1) PRIMARY KEY
	,Name nvarchar(200) NOT NULL
	,ProjectTypeID int CONSTRAINT Project_Type
	 FOREIGN KEY REFERENCES ProjectTypes(ProjectTypeID)
	,DateStarted datetime NOT NULL
	,DateEnded datetime NOT NULL
)

CREATE TABLE dbo.ProjectPeople(
	ProjectPersonID int IDENTITY(1,1) PRIMARY KEY
	,ProjectID int CONSTRAINT Person_Project
	FOREIGN KEY REFERENCES Projects(ProjectID)
	,PersonID int CONSTRAINT Project_Person
	FOREIGN KEY REFERENCES People(PersonID)
	,DateAssigned datetime NOT NULL
)



SET IDENTITY_INSERT dbo.People ON
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(1, 'Nigel','Davidson','05/07/89','0','Dr.','Ph.D','1-895-712-2151','posuere.vulputate@orciin.ca','http://FNJ40FIZ1JD.tom')
						,(2,'Kylan','Mcbride','04/16/91','0','Mrs.','','1-966-258-9460','Nulla@nequenon.edu','http://KBN41XSW6NM.rom')
						,(3,'Ferris','Riley','02/19/79','0','Ms.','Esq.','1-421-997-5016','Suspendisse.eleifend.Cras@eteuismodet.org','http://UXB70AAW2QJ.qom')
						,(4,'Beau','Collins','04/09/74','1','Mr.','','1-529-312-8158','massa.lobortis@turpis.com','http://OCE23TIE5GV.fom')
						,(5,'Russell','Mccormick','07/25/90','0','','III','1-334-583-7350','dictum.cursus@neque.net','http://LRD77DSA7NG.bom')
						,(6,'Bianca','Chang','02/19/86','0','Ms.','MD','1-899-480-5833','consequat.nec@dapibusid.net','http://UCT24LXB0DU.som')
						,(7,'Cadman','Peterson','10/22/79','0','','','1-940-796-6389','In@Aeneanegestashendrerit.org','http://ULV81RSQ6ZQ.mom')
						,(8,'Mari','Levy','05/16/70','0','Mr.','Ph.D','1-877-914-3370','ridiculus@temporaugueac.net','http://OPV51SEK5YB.qom')
						,(9,'Hillary','Erickson','04/19/78','0','Mr.','Jr.','1-801-336-1650','ipsum@arcuVestibulum.edu','http://YDT98VCC0BE.yom')
						,(10,'Kevyn','Vang','10/14/78','0','','','1-116-913-1643','porttitor@et.co.uk','http://POL36QTD9ZC.com')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(11,'Logan','Bryan','12/17/69','0','Mr.','','1-486-462-4759','consectetuer.mauris.id@Suspendisse.co.uk','http://HFK84IFP9CQ.gom')
						,(12,'Lee','Perkins','07/24/90','0','Mrs.','','1-440-480-0091','ac@eleifendCrassed.net','http://YIO23GEC5QL.qom')
						,(13,'Deborah','Miles','12/25/70','0','','MD','1-743-925-4202','eget.magna.Suspendisse@lectusquis.org','http://PPC18BMJ8YK.gom')
						,(14,'Philip','Harvey','09/22/81','0','Sir','III','1-170-986-5875','auctor@Maecenasmalesuada.net','http://QIK66TME9GP.xom')
						,(15,'Aaron','Velez','10/23/73','1','Mr.','Ph.D','1-108-462-0944','Mauris.vel.turpis@luctus.com','http://HCN26DRW6JY.pom')
						,(16,'Keegan','Bentley','09/19/77','1','Dr.','III','1-961-595-5142','dictum.Phasellus@nunc.com','http://ZKD66XTZ5KW.mom')
						,(17,'Jacqueline','Jenkins','11/29/89','0','Mrs.','Jr.','1-571-731-0188','ut@adipiscinglobortisrisus.com','http://PLN91KAC3TX.nom')
						,(18,'Brenda','Camacho','08/14/90','0','','MD','1-145-482-8524','euismod.est@tellusidnunc.co.uk','http://CGA07TQG2HG.com')
						,(19,'Ann','Merrill','11/22/75','0','Mrs.','','1-447-787-2714','habitant.morbi@Praesent.net','http://SKP72XOZ2RW.dom')
						,(20,'Xena','Wagner','06/12/90','0','','MD','1-436-374-5952','id.sapien.Cras@Donec.org','http://RIJ36EUK8BE.wom')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(21,'Penelope','Conner','07/13/81','1','','','1-491-890-0390','in.molestie.tortor@justofaucibus.co.uk','http://IOE34GGJ6NV.xom')
						,(22,'Kessie','Bradford','11/20/74','0','Sir','Sr.','1-963-969-9951','sociis@felis.org','http://GLT90LAF1OK.yom')
						,(23,'Henry','Daniel','03/06/92','0','Dr.','MD','1-163-202-0700','ultrices.posuere.cubilia@leo.net','http://VLS06OOO8PM.dom')
						,(24,'Hector','Guerrero','10/08/86','0','Dr.','Sr.','1-892-125-1781','Cras.eget.nisi@parturient.co.uk','http://KFX23JLE3DC.hom')
						,(25,'Nelle','Lucas','11/22/90','0','Sir','MD','1-621-604-0008','at.fringilla.purus@enimSuspendisse.org','http://AHK02YRC2GU.wom')
						,(26,'Daryl','Lopez','02/13/91','0','Mrs.','Ph.D','1-423-551-9481','ut@mifelisadipiscing.ca','http://YXO02VRU0MV.xom')
						,(27,'Theodore','Harrison','02/24/78','0','Dr.','','1-623-373-9986','commodo.hendrerit@tellus.com','http://PHA99STR1NS.fom')
						,(28,'Illana','Porter','07/27/71','0','Dr.','MD','1-672-620-8958','augue.scelerisque@risusquisdiam.ca','http://VMY09KRN8QP.dom')
						,(29,'Donovan','Chase','10/16/80','0','Dr.','','1-971-424-1384','sodales.purus@luctuset.net','http://NDA69XYD3LL.xom')
						,(30,'Christine','Thornton','09/24/90','0','Mrs.','III','1-146-103-4470','ornare.elit@atlacus.edu','http://NDM72HYP5II.bom')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(31,'Evelyn','Craft','01/09/71','0','Dr.','','1-604-693-4980','purus@sedduiFusce.edu','http://GME01WGH3AR.fom')
						,(32,'Eagan','Mcleod','03/30/91','0','Mrs.','','1-766-975-8098','tortor@temporlorem.com','http://MRZ35KOP4SF.mom')
						,(33,'Grady','Giles','08/25/90','0','Mrs.','MD','1-300-803-4646','a.neque.Nullam@viverraDonec.edu','http://IOZ26FJM7UE.fom')
						,(34,'Haley','Conner','06/23/88','0','Dr.','MD','1-144-470-8545','nisl.Maecenas.malesuada@dolornonummy.edu','http://FRH12YQU6TM.gom')
						,(35,'Lester','Castaneda','10/23/89','1','Ms.','Ph.D','1-258-294-5357','Pellentesque.ut@dictummagna.co.uk','http://ICG22QGY9KH.vom')
						,(36,'Kevin','Oliver','06/02/89','0','Sir','Ph.D','1-502-652-2942','non.luctus.sit@dictum.ca','http://DKZ41HAR4KT.kom')
						,(37,'Gray','Nielsen','10/22/80','0','Mr.','Sr.','1-384-291-9331','sociis.natoque@luctusaliquetodio.ca','http://LQN78TVO7QG.gom')
						,(38,'Wang','Sweeney','12/28/86','0','Ms.','','1-292-940-2582','arcu.et.pede@Sedmalesuada.edu','http://UIW25VBN7TR.mom')
						,(39,'Alice','Reilly','02/06/70','0','Mr.','','1-258-364-5215','velit.Sed@odiotristique.ca','http://TYZ01YFK3AQ.xom')
						,(40,'Marsden','Rivera','05/16/90','1','Dr.','','1-357-380-3615','aliquam.arcu.Aliquam@egestas.ca','http://TDW20EDB1QX.zom')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(41,'Valentine','Winters','01/31/72','0','Dr.','MD','1-713-683-9781','mi.ac@elitpede.co.uk','http://HOT78IXA0YA.jom')
						,(42,'Gage','Bell','07/14/92','0','Mrs.','Ph.D','1-725-312-9316','Morbi.non.sapien@aliquam.ca','http://FNE46IGR7SX.wom')
						,(43,'Aidan','Coffey','04/01/83','0','Sir','','1-458-194-4024','mattis@semperauctor.ca','http://SDR52RXD5OK.yom')
						,(44,'Boris','Barnett','02/06/75','0','Mrs.','Jr.','1-719-176-7226','ipsum.dolor@Mauris.ca','http://BWY42EMJ3IR.som')
						,(45,'Francis','Shepherd','08/16/90','0','Dr.','III','1-362-419-9675','velit@augueid.org','http://ATA31TRG2AK.vom')
						,(46,'Hayden','Henson','10/11/84','1','Ms.','','1-693-740-4890','vulputate.posuere.vulputate@gravidaAliquamtincidunt.org','http://MEB87UMV8MX.jom')
						,(47,'Astra','Nixon','06/29/88','0','Mr.','','1-893-742-4689','vulputate@mi.com','http://KNH12SCT9YU.hom')
						,(48,'Carol','Ayala','07/13/71','0','Dr.','Ph.D','1-817-978-3044','natoque.penatibus.et@vitaepurus.net','http://EOE07WKH9RF.pom')
						,(49,'John','Emerson','11/06/69','0','Ms.','','1-536-152-1678','Sed.eget.lacus@volutpatNulladignissim.ca','http://UKS82GBF8SI.jom')
						,(50,'Davis','Burgess','04/14/69','0','Dr.','Ph.D','1-864-611-6840','Aenean.gravida.nunc@aarcu.org','http://EBS87LXC9WZ.jom')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(51,'Zeus','Boyd','10/03/71','0','','Jr.','1-734-157-7398','ipsum.non@urna.edu','http://MAV88HEW7KG.kom')
						,(52,'Freya','Noble','03/07/70','0','Mrs.','Esq.','1-395-860-0181','bibendum.Donec.felis@litoratorquentper.com','http://CVQ80LEX9ND.dom')
						,(53,'Mufutau','Mcpherson','03/03/77','0','Sir','','1-819-986-2054','nec.cursus@pedenonummy.com','http://AIM88GJY9JL.rom')
						,(54,'Gray','Bradford','07/03/90','1','','Ph.D','1-558-421-5977','lectus.pede@sitamet.org','http://AJA81HTB3LY.fom')
						,(55,'Nola','Mathews','05/02/78','0','Ms.','Esq.','1-303-486-6017','nec@hymenaeosMaurisut.net','http://VLF78QOB0AA.bom')
						,(56,'Connor','Dejesus','04/24/84','0','','MD','1-936-169-1900','lectus@nisl.org','http://TEV57UEK8PE.jom')
						,(57,'Chancellor','Cantrell','03/07/91','1','Dr.','III','1-762-882-3446','non.arcu@ullamcorper.co.uk','http://QDO06NTI9LL.jom')
						,(58,'Amber','Gonzales','03/09/89','1','Mrs.','','1-893-175-1176','egestas.urna.justo@diameu.edu','http://PRK28RSH9KP.rom')
						,(59,'Ima','Stevenson','02/17/76','0','Sir','','1-972-527-1008','posuere.at@Namnullamagna.co.uk','http://GOO90KUO5CK.vom')
						,(60,'Melodie','Gilbert','01/18/84','0','Ms.','Ph.D','1-923-514-5184','orci.sem@Namtempor.com','http://FDS04MLB8VO.pom')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(61,'Grant','Blankenship','01/31/90','0','Dr.','','1-266-419-7546','elit.Aliquam.auctor@tortordictumeu.co.uk','http://TNC41WOF5HW.rom')
						,(62,'Maggie','Byrd','03/30/69','0','Mrs.','','1-343-811-7992','accumsan@egestasa.edu','http://CBZ93LCZ3BQ.qom')
						,(63,'Derek','Welch','08/15/81','1','Dr.','Esq.','1-728-564-5603','Class.aptent.taciti@indolor.edu','http://JRP15MQT4EH.mom')
						,(64,'Abbot','Kline','09/08/71','0','Mr.','','1-902-375-8180','nec@adipiscingnon.edu','http://PYX16ZLO6DY.vom')
						,(65,'Graiden','Walker','12/21/86','0','Mrs.','','1-264-134-4446','scelerisque@metusVivamuseuismod.com','http://FGN66KRJ7UZ.mom')
						,(66,'Hanna','Matthews','08/12/89','1','Mrs.','Sr.','1-612-676-2225','quis.diam.Pellentesque@Fusce.org','http://XDF44XDB7QP.gom')
						,(67,'Natalie','Clark','03/12/91','0','Mrs.','III','1-595-994-5629','egestas.hendrerit@pharetra.co.uk','http://DWP55UKD8UR.dom')
						,(68,'Brian','Flynn','04/17/79','1','Mrs.','Jr.','1-747-369-6750','neque.sed@laoreetlectus.org','http://PIJ13ISQ4MU.lom')
						,(69,'Grace','Solomon','01/08/80','0','Dr.','','1-756-223-3327','Vivamus.nibh@Nunc.org','http://MVA97PIB3EA.nom')
						,(70,'Zelda','Pittman','01/05/81','0','Sir','MD','1-132-166-2982','bibendum@ipsumprimis.org','http://MWK60KJB3KU.com')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(71,'Ulric','Cruz','04/15/73','0','Sir','','1-116-118-1867','Phasellus@Quisque.org','http://SYK47BFE0RW.kom')
						,(72,'Kevyn','Lambert','03/08/73','0','Ms.','Esq.','1-172-107-0465','non.massa@tellussem.com','http://YKO98ZYQ9DD.nom')
						,(73,'Morgan','Williams','06/29/78','0','Mr.','MD','1-972-253-2550','cubilia.Curae@ornareIn.ca','http://QBU14OBF6VH.mom')
						,(74,'Clark','Ferrell','12/02/69','0','','Esq.','1-756-514-7096','In@tempuslorem.net','http://ZRS70AGD1GW.wom')
						,(75,'Samson','Bernard','05/15/70','0','Mrs.','','1-299-824-5535','accumsan.convallis@cursusin.org','http://ANH50BAT3KD.com')
						,(76,'Raja','Joyner','01/16/73','0','Mr.','','1-963-826-1145','sed@Vivamusmolestie.ca','http://BTT99JQD9LC.qom')
						,(77,'Penelope','Gamble','12/13/72','0','Mr.','MD','1-251-593-8369','Vivamus.sit@facilisisfacilisis.com','http://EOG03BXM3GZ.nom')
						,(78,'Vivien','Guerrero','07/17/74','0','Mrs.','','1-938-590-7348','adipiscing@ornarelibero.edu','http://YMN57PPH2DI.hom')
						,(79,'Claire','Avila','12/07/72','0','Ms.','','1-314-442-9586','non.enim@nonfeugiat.com','http://DHI51FAJ5XV.zom')
						,(80,'Quinlan','Ware','10/15/69','0','Dr.','','1-984-611-1523','vehicula.et@Nunclectus.com','http://IJS78WRO1CA.nom')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(81,'Clare','Porter','01/10/76','0','Mrs.','','1-341-933-1602','Sed.dictum@semmollis.co.uk','http://SOX90ZUB8LZ.nom')
						,(82,'Imani','Pacheco','05/13/69','0','Dr.','Esq.','1-619-425-9008','Cras@imperdietornareIn.net','http://FCQ29DAP6SB.qom')
						,(83,'Malachi','Dawson','03/24/80','0','Dr.','','1-341-937-4941','luctus.felis.purus@vulputate.net','http://HGX48OJH7UH.rom')
						,(84,'Indira','Snyder','10/25/70','0','Mr.','Jr.','1-860-423-9699','velit.Sed@Quisque.ca','http://NEK49YBD2YZ.kom')
						,(85,'Gay','Fisher','06/07/71','0','Dr.','','1-765-777-8008','tempus.mauris@nasceturridiculusmus.edu','http://RNM09KPJ8FE.jom')
						,(86,'Lysandra','Clayton','01/30/92','0','Mrs.','','1-562-688-6105','Cras.lorem@Vivamus.ca','http://KNC66ASM5LI.tom')
						,(87,'McKenzie','Perkins','08/05/92','0','Dr.','','1-588-960-6999','lectus.Cum.sociis@euaugue.net','http://VRT46TOM0FS.com')
						,(88,'Illiana','Herrera','11/19/85','0','','','1-267-151-3783','interdum.ligula.eu@pedeCrasvulputate.ca','http://SIV35UFN3TN.zom')
						,(89,'Elmo','Powers','04/23/83','0','Ms.','MD','1-937-154-3105','massa.rutrum@vestibulumnequesed.com','http://FMB99KZX9ZU.xom')
						,(90,'Ivory','Warren','01/12/87','0','Mr.','','1-100-663-7153','faucibus@ipsumprimis.ca','http://AZV43BPE0IC.wom')
INSERT INTO dbo.People (PersonID,FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
				   VALUES(91,'Bianca','Benjamin','09/02/89','0','Mr.','','1-218-253-7320','nunc.sed.libero@sollicitudinorcisem.co.uk','http://XJU87RND1MH.com')
						,(92,'Zenaida','Robbins','08/10/76','0','Ms.','','1-886-943-1404','nibh.lacinia.orci@ProindolorNulla.com','http://EWI99YAX4DL.nom')
						,(93,'Donna','Bauer','05/28/83','0','Ms.','','1-473-606-8341','pharetra.felis@iaculis.com','http://SLT58HOJ5BV.rom')
						,(94,'Troy','Santana','07/01/80','0','Mr.','Jr.','1-296-281-9501','magna.sed.dui@gravidamolestiearcu.edu','http://MTS72DAU4JB.yom')
						,(95,'Chaney','Young','12/14/86','0','Mr.','','1-512-359-8793','libero.Integer.in@sitametlorem.com','http://TON37RPM2XI.vom')
						,(96,'Naida','Ware','06/30/90','0','Mr.','','1-810-550-0112','justo@quam.edu','http://KYC04PLJ1AD.zom')
						,(97,'Oliver','Wyatt','05/05/89','0','Mr.','','1-138-578-3200','eu.augue@a.org','http://BIH28IKW6QU.gom')
						,(98,'Arden','Hayes','02/19/86','0','Dr.','III','1-250-795-2049','eget.tincidunt@Nullamut.edu','http://GCG10MRK0WJ.fom')
						,(99,'Jordan','Reid','01/10/76','0','Ms.','Jr.','1-642-145-5477','at@ullamcorper.co.uk','http://GVH27EKG0KR.tom')
						,(100,'Channing','Schultz','11/08/91','1','Mrs.','Sr.','1-144-170-4322','commodo.auctor@quisarcuvel.co.uk','http://IKP09UAJ5IC.som')
SET IDENTITY_INSERT dbo.People OFF

SET IDENTITY_INSERT dbo.ProjectTypes ON
INSERT INTO dbo.ProjectTypes (ProjectTypeID,Name)
				    VALUES(1,'Accounting')
							  ,(2,'Management')
							  ,(3,'Marketing')
							  ,(4,'Research')

SET IDENTITY_INSERT dbo.ProjectTypes OFF

SET IDENTITY_INSERT dbo.Projects ON
INSERT INTO dbo.Projects (ProjectID, Name, ProjectTypeID, DateStarted, DateEnded)
				    VALUES(1,'Time Keeper',2,'12/21/1989','12/31/9999')
						  ,(2,'Sales Reports',3,'1/1/1984','4/7/1986')
						  ,(3,'Customer Followup',3,'7/7/1999','2/21/2000')
						  ,(4,'Point Of Sales',1,'5/30/1984','3/26/2002')
						  ,(5,'Customer Rewards',1,'7/1/2003','12/31/9999')
						  ,(6,'Research Projects',4,'12/21/1990','12/31/9999')
SET IDENTITY_INSERT dbo.Projects OFF

SET IDENTITY_INSERT dbo.ProjectPeople ON
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				    VALUES(1,2,42,'10/04/1994'),(2,5,63,'10/04/1986'),(3,4,3,'12/07/1989'),(4,3,87,'05/14/2000'),(5,5,4,'06/30/2002')
							   ,(6,3,97,'05/02/1990'),(7,1,35,'09/08/1986'),(8,1,92,'02/28/1993'),(9,2,15,'08/06/1986'),(10,6,27,'06/05/1993')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(11,6,57,'10/01/2017'),(12,1,60,'03/15/2018'),(13,1,2,'12/21/2016'),(14,6,2,'10/22/2016'),(15,3,85,'03/25/2000')
							   ,(16,5,29,'08/26/1986'),(17,2,80,'01/12/2010'),(18,5,38,'06/08/2017'),(19,5,31,'12/22/2008'),(20,5,73,'01/16/2017')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(21,4,12,'01/27/1991'),(22,5,9,'06/18/2010'),(23,4,61,'08/30/2004'),(24,1,4,'02/29/2012'),(25,1,49,'01/21/2007')
							   ,(26,1,70,'11/12/2016'),(27,2,26,'10/05/2009'),(28,3,9,'02/24/2002'),(29,2,73,'06/21/2004'),(30,3,66,'06/29/1989')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(31,5,45,'11/23/2007'),(32,1,65,'06/02/2009'),(33,5,2,'05/10/1991'),(34,1,81,'03/17/2005'),(35,4,74,'02/23/1985')
							   ,(36,6,42,'05/03/2006'),(37,5,8,'07/10/1989'),(38,5,22,'01/11/2014'),(39,2,95,'07/26/1995'),(40,6,13,'03/01/2000')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(41,5,81,'01/03/2008'),(42,2,90,'01/04/1989'),(43,4,81,'01/21/2012'),(44,2,96,'08/01/2003'),(45,3,63,'09/22/2000')
							   ,(46,6,6,'08/29/2006'),(47,3,100,'07/21/1997'),(48,6,63,'06/19/2009'),(49,6,8,'09/21/1996'),(50,4,42,'09/29/1987')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(51,3,80,'10/30/1985'),(52,4,66,'03/28/2017'),(53,2,98,'06/25/2007'),(54,5,67,'03/15/1987'),(55,1,40,'04/17/2010')
							   ,(56,2,69,'07/11/1989'),(57,2,57,'09/13/1993'),(58,3,34,'10/29/1990'),(59,3,99,'06/01/2014'),(60,6,19,'05/16/2012')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(61,3,5,'02/19/1993'),(62,5,17,'05/01/1993'),(63,4,26,'07/10/2016'),(64,6,50,'07/08/1992'),(65,6,37,'04/21/2011')
							   ,(66,2,88,'08/23/1998'),(67,6,7,'04/07/1985'),(68,1,6,'01/26/2003'),(69,2,30,'09/01/2005'),(70,2,70,'01/31/1999')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(71,6,44,'06/22/1998'),(72,1,33,'08/26/1995'),(73,6,94,'03/26/2004'),(74,3,71,'12/28/1989'),(75,1,21,'12/06/1989')
							   ,(76,1,64,'01/10/2016'),(77,5,88,'03/23/1985'),(78,4,72,'05/07/2004'),(79,6,74,'04/18/1999'),(80,6,46,'08/13/2002')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(81,3,53,'06/05/1985'),(82,2,44,'11/14/2011'),(83,6,56,'06/29/1989'),(84,1,76,'03/31/2017'),(85,2,89,'04/28/2005')
							   ,(86,3,1,'09/08/2015'),(87,6,38,'10/15/2007'),(88,3,96,'09/14/2013'),(89,5,97,'12/14/1994'),(90,2,94,'06/12/2000')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(91,5,92,'07/17/2003'),(92,3,47,'10/14/1996'),(93,2,79,'08/26/2004'),(94,4,57,'11/18/1993'),(95,4,29,'02/05/1988')
							   ,(96,3,43,'10/18/2011'),(97,4,33,'11/25/2014'),(98,2,61,'03/31/1997'),(99,4,40,'02/25/2011'),(100,3,56,'09/14/2000')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(101,3,3,'02/17/2000'),(102,1,45,'01/05/2016'),(103,3,38,'04/30/1987'),(104,2,63,'03/29/2013'),(105,6,45,'09/15/2015')
							   ,(106,2,65,'04/22/2001'),(107,4,14,'02/20/1994'),(108,6,65,'08/13/1988'),(109,6,90,'07/01/2003'),(110,4,41,'07/01/1988')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(111,1,9,'11/06/1986'),(112,2,45,'05/02/1992'),(113,6,28,'02/07/2003'),(114,6,58,'01/26/1994'),(115,6,14,'09/04/1986')
							   ,(116,1,59,'11/22/2006'),(117,4,10,'09/01/1995'),(118,2,33,'09/06/2001'),(119,2,39,'11/15/1996'),(120,1,44,'03/24/1994')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(121,1,55,'04/28/1994'),(122,6,39,'01/20/1989'),(123,3,45,'03/12/1994'),(124,6,64,'01/10/2001'),(125,3,72,'06/09/1999')
							   ,(126,1,28,'01/08/2018'),(127,5,43,'04/13/2001'),(128,6,91,'01/25/2013'),(129,3,74,'09/19/1992'),(130,6,76,'05/04/2010')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(131,3,57,'08/06/1997'),(132,3,37,'10/12/1995'),(133,2,2,'11/12/1993'),(134,3,81,'10/06/2016'),(135,5,27,'11/23/1986')
							   ,(136,6,41,'08/11/1993'),(137,5,83,'05/09/2002'),(138,4,62,'02/01/2010'),(139,4,98,'09/27/1992'),(140,1,67,'04/09/2009')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(141,2,67,'06/15/2014'),(142,4,21,'04/25/2011'),(143,3,75,'07/02/1988'),(144,6,86,'09/22/2000'),(145,2,38,'01/11/2016')
							   ,(146,3,15,'04/08/2002'),(147,6,71,'05/27/1994'),(148,2,21,'03/13/1996'),(149,5,48,'03/09/2002'),(150,1,13,'04/03/2015')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(151,1,11,'11/21/1999'),(152,4,1,'11/03/2006'),(153,3,27,'02/02/1998'),(154,2,85,'03/19/1996'),(155,1,20,'01/16/2008')
							   ,(156,2,36,'03/24/1987'),(157,3,12,'10/06/2012'),(158,2,27,'04/15/1996'),(159,4,2,'01/11/1987'),(160,6,11,'01/01/1988')
INSERT INTO dbo.ProjectPeople (ProjectPersonID, ProjectID, PersonID)
				     VALUES(161,4,52,'02/05/1988'),(162,4,19,'07/01/1993'),(163,4,82,'08/02/1988'),(164,6,53,'10/31/1999'),(165,5,93,'06/10/1992')
							   ,(166,3,48,'05/23/1999'),(167,3,33,'06/20/2003'),(168,1,96,'02/03/1985'),(169,5,28,'08/08/2001'),(170,1,39,'04/14/1993')
							   ,(171,4,5,'12/04/2011'),(172,5,32,'05/18/2018'),(173,1,30,'08/16/2008'),(174,1,46,'06/11/1988')
SET IDENTITY_INSERT dbo.ProjectPeople OFF
GO


CREATE PROCEDURE sproc_PersonAdd
	@FirstName nvarchar(40)
	,@LastName nvarchar(40)
	,@DateOfBirth datetime
	,@IsManager bit 
	,@Prefix nvarchar(6)
	,@Postfix nvarchar(8)
	,@Phone nvarchar(15) 
	,@Email nvarchar(250)
	,@Homepage nvarchar(400)
AS
BEGIN
	INSERT INTO People (FirstName,LastName,DateOfBirth,IsManager,Prefix,Postfix,Phone,Email,Homepage)
		VALUES (@FirstName,@LastName,@DateOfBirth,@IsManager,@Prefix,@Postfix,@Phone,@Email,@Homepage)
END
GO