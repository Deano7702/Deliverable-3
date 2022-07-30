create table offense_location
(
	x_pos int NOT NULL,
	y_pos int NOT NULL,
	offense_location varchar(40),
	road varchar(30),
	road_lane int,
	region varchar(20),
	road_surface varchar(10),
	speed_limit int,

	primary key(x_pos, y_pos),
)

create table infringement_notice
(
	notice_number varchar(20) NOT NULL,
	amount float(2),
	notice_status varchar(15) check(notice_status = 'paid' OR notice_status = 'outstanding'),
	issue_date date,

	primary key(notice_number),
)

create table vehicle
(
	registration_number varchar(6) NOT NULL,
	make varchar(20),
	model varchar(20),
	color varchar(20),
	registration_year varchar(4) check(registration_year like '[0-9][0-9][0-9][0-9]'),
	vehicle_year varchar(4) check(vehicle_year like '[0-9][0-9][0-9][0-9]'),

	primary key(registration_number),
)

create table license
(
	license_number varchar(20) NOT NULL,
	license_type varchar(20) check (license_type like 'Learner' OR license_type like 'Restricted' OR license_type like 'Full'),
	issue_date date,
	expire_date date,

	primary key(license_number)

)

create table offender
(
	offender_id varchar(20) NOT NULL,
	fname varchar(20),
	lname varchar(20),
	dateOfBirth date,
	gender varchar(10) check(gender = 'Male' OR gender = 'Female' OR gender = 'Other'),
	phone char(12) check(phone LIKE '(0[0-9])[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
	roadStreet_num int,
	roadStreet varchar(20),
	license_number varchar(20) NOT NULL,

	primary key(offender_id),
	foreign key(license_number) references license

)

create table offence
(
	offence_id varchar(20) NOT NULL,
	offense_description varchar(30),
	speed_alleged int,
	timedate datetime,
	icn varchar(10),
	x_pos int NOT NULL,
	y_pos int NOT NULL,
	notice_number varchar(20),
	registration_number varchar(6) NOT NULL,
	offender_id varchar(20) NOT NULL,
	weather varchar(10),

	primary key(offence_id),
	foreign key(offender_id) references offender,
	foreign key(notice_number) references infringement_notice,
	foreign key(x_pos, y_pos) references offense_location,
	foreign key(registration_number) references vehicle
)

SET DATEFORMAT dmy; 

INSERT INTO offense_location (x_pos,y_pos,offense_location,road,road_lane,region,road_surface, speed_limit)
VALUES
    ('1406914', '4915023', 'MIDLAND ST', 'PORTSMOUTH DRIVE', '2', 'Otago ', 'Sealed', '70'),
    ('1799023', '5814728', 'SH 1N', 'KILLARNEY ROAD', '4', 'Waikato ', 'Sealed', '60'),
    ('1741193', '5976099', 'SH 1N', 'SAUNDERS ROAD', '2', 'Auckland ', 'Sealed', '100'),
    ('1790288', '5837387', 'RIVERVIEW ROAD', 'HAKARIMATA ROAD', '2', 'Waikato ', 'Sealed', '100'),
    ('1615675', '5423627', 'TALBOT ST', 'ELIZABETH ST', '2', 'Tasman ', 'Sealed', '50'),
    ('1838932', '5519398', 'PAHIATUA MANGAHAO ROAD', 'RIDGE ROAD NORTH', '2', 'Manawatū-Whanganui ', 'Sealed', '100'),
    ('1893341', '5812746', 'JELLICOE ST', 'KING ST', '2', 'Bay of Plenty ', 'Sealed', '80'),
    ('1570406', '5178315', 'SH 73 BROUGHAM', 'DURHAM ST', '5', 'Canterbury ', 'Sealed', '60'),
    ('1702855', '5635351', 'ELTHAM ROAD', 'LOWER DUTHIE ROAD', '2', 'Taranaki ', 'Sealed', '100'),
    ('1766331', '5907432', 'SH 1N', 'EAST TAMAKI OBR', '4', 'Auckland ', 'Sealed', '100'),
    ('2037143', '5708472', 'GLADSTONE ROAD', 'DERBY ST', '2', 'Gisborne ', 'Sealed', '50'),
    ('1876231', '5820156', 'CAMERON ROAD', 'CORNWALL ST', '2', 'Bay of Plenty ', 'Sealed', '50'),
    ('1764151', '5588246', 'SH 3', 'RANGITATAU EAST ROAD', '2', 'Manawatū-Whanganui ', 'Sealed', '100'),
    ('1574177', '5179893', 'RASEN PLACE', 'JOLLIE ST', '1', 'Canterbury ', 'Sealed', '50'),
    ('1727746', '6012466', 'SH 1N', 'GLENMOHR ROAD', '2', 'Northland ', 'Sealed', '100'),
    ('1571772', '5179558', 'ST ASAPH ST', 'FITZGERALD AVENUE', '2', 'Canterbury ', 'Sealed', '50'),
    ('1768750', '5904546', 'REDOUBT ROAD', 'HOLLYFORD ROAD', '4', 'Auckland ', 'Sealed', '50'),
    ('1767091', '5912669', 'CARDIFF ROAD', 'CINDY PLACE', '2', 'Auckland ', 'Sealed', '50'),
    ('1746990', '5915134', 'GREAT NORTH ROAD', 'HEPBURN ROAD', '4', 'Auckland ', 'Sealed', '50'),
    ('1746749', '5919711', 'ROYAL VIEW ROAD', 'MILICH TERRACE', '2', 'Auckland ', 'Sealed', '50'),
    ('1746822', '5918596', 'TE ATATU ROAD', 'WAKELING AVENUE', '2', 'Auckland ', 'Sealed', '50'),
    ('1754254', '5918542', 'GREAT NORTH ROAD', 'BULLOCK TRACK', '4', 'Auckland ', 'Sealed', '50'),
    ('1756988', '5920099', 'COOK ST', 'MAYORAL DRIVE', '6', 'Auckland ', 'Sealed', '50'),
    ('1748980', '5424883', 'RIDDIFORD ST', 'CONSTABLE ST', '2', 'Wellington ', 'Sealed', '50'),
    ('1757842', '5918624', 'PARK ROAD', 'CARLTON GORE ROAD', '4', 'Auckland ', 'Sealed', '40'),
    ('1772739', '5896209', 'SERVICE LANE', 'WOOD ST S', '2', 'Auckland ', 'Sealed', '50'),
    ('1767320', '5901246', 'RUSSELL ROAD', 'KENT ROAD', '2', 'Auckland ', 'Sealed', '50'),
    ('1795738', '5821837', 'MAUI ST', 'CHANAN PLACE', '2', 'Waikato ', 'Sealed', '50'),
    ('1620461', '5428070', 'WHAKATU DRIVE', 'ANNESBROOK DRIVE', '2', 'Nelson ', 'Sealed', '50'),
    ('1573027', '5179936', 'CASHEL ST', 'OLLIVIERS ROAD', '2', 'Canterbury ', 'Sealed', '50'),
    ('1407260', '4917383', 'SH 88', 'RAVENSBOURNE ROAD W', '2', 'Otago ', 'Sealed', '50'),
    ('1405160', '4917081', 'ROSS ST', 'CITY ROAD', '2', 'Otago ', 'Sealed', '50'),
    ('1752196', '5947913', 'ROSARIO CRESCENT', 'THORBURN AVENUE', '1', 'Auckland ', 'Sealed', '50'),
    ('1821245', '5461836', 'SOUTH BELT', 'MANCHESTER ST', '2', 'Wellington ', 'Sealed', '50'),
    ('1749613', '5430810', 'BARNARD ST', 'ANNE ST', '2', 'Wellington ', 'Sealed', '50'),
    ('1792127', '5826359', 'GREAT SOUTH ROAD', 'PARK ROAD', '2', 'Waikato ', 'Sealed', '100'),
    ('1570298', '5182104', 'SPRINGFIELD ROAD', 'EDGEWARE ROAD', '2', 'Canterbury ', 'Sealed', '50'),
    ('1819887', '5531206', 'BENMORE AVENUE', 'WALTHAM COURT', '2', 'Manawatū-Whanganui ', 'Sealed', '50'),
    ('1755196', '5434483', 'SH 2', 'HOROKIWI ROAD', '4', 'Wellington ', 'Sealed', '100'),
    ('1691064', '5673772', 'OMATA ROAD', 'TUKAPA ST', '2', 'Taranaki ', 'Sealed', '50'),
    ('1751978', '5432494', 'CENTENNIAL NBD', 'SLIP ROAD', '2', 'Wellington ', 'Sealed', '80'),
    ('1801774', '5814937', 'BRIDGE ST', 'VON TEMPSKY ST', '2', 'Waikato ', 'Sealed', '50'),
    ('1770163', '5902044', 'CHARLES PREVOST DRIVE', 'HILL ROAD', '2', 'Auckland ', 'Sealed', '50'),
    ('1766663', '5912929', 'REEVES ROAD', 'TI RAKAU DRIVE', '2', 'Auckland ', 'Sealed', '50'),
    ('1887078', '5824220', 'PAPAMOA BEACH ROAD', 'PACIFIC VIEW ROAD', '2', 'Bay of Plenty ', 'Sealed', '60'),
    ('1803213', '5550233', 'SH 1N', 'CRITERION ST', '2', 'Manawatū-Whanganui ', 'Sealed', '50'),
    ('1756295', '5920546', 'VICTORIA ST WEST', 'FRANKLIN ROAD', '6', 'Auckland ', 'Sealed', '50'),
	('1978456', '5670137', 'SH 2', 'KIWI VALLEY ROAD', '2', 'Hawkes Bay ', 'Sealed', '100'),
    ('1759917', '5436791', 'MELLING LINK', 'RUTHERFORD ST', '2', 'Wellington ', 'Sealed', '50');

INSERT INTO vehicle (registration_number,make,model,color,registration_year,vehicle_year)
VALUES
    ('ABC102', 'FORD', 'ESCAPE', 'red', '2020', '2018'),
    ('BCD550', 'HONDA', 'CIVIC', 'white', '2019', '2017'),
    ('JJS108', 'MZADA', 'MX-5', 'red', '2018', '2016'),
    ('MKL090', 'MZADA', 'CX-3', 'green', '2016', '2015'),
    ('HIL567', 'NISSAN', 'LEAF', 'white', '2021', '2020'),
    ('KDD453', 'SUZUKI', 'IGNIS', 'black', '2016', '2014'),
    ('LSD786', 'TOYOTA', 'CAMRY', 'white', '2018', '2016'),
    ('GLG909', 'TOYOTA', 'COROLLA', 'black', '2017', '2016');

INSERT INTO license(license_number,license_type,issue_date,expire_date)
VALUES
    ('KA111112', 'full', '01-07-2016', '01-07-2026'),
    ('AB123456', 'full', '11-08-2014', '11-08-2024'),
    ('GD567789', 'restricted', '23-04-2018', '23-04-2023'),
    ('HG456789', 'learner', '11-02-2021', '11-02-2026'),
    ('BD345678', 'full', '22-07-2015', '22-07-2025'),
    ('EF123456', 'restricted', '05-11-2019', '05-11-2024'),
    ('PL123456', 'full', '01-03-2017', '01-03-2027'),
    ('KT142526', 'full', '14-09-2014', '14-09-2024'),
    ('UY122225', 'learner', '02-05-2021', '02-05-2026');


INSERT INTO offender(offender_id, fname, lname, dateOfBirth, gender, phone, roadStreet_num, roadStreet, license_number)
VALUES
	('282f91f3', 'David', 'Hookman', '02-07-1993', 'Male', '(07)324-2345', '34', 'TAURU ROAD', 'KA111112'),
	('ba29ce46', 'Peter', 'Simpson', '05-01-1987', 'Male', '(09)678-4568', '78', 'SIMPSON STREET', 'BD345678'),
	('2nzcyow2y', 'Dean', 'Mason', '07-07-2002', 'Male', '(09)678-4568', '64', 'REBECCA DRIVE', 'AB123456'),
	('q4wa31dfw', 'Rachael', 'Handy', '01-03-1995', 'Female', '(09)678-4568', '55', 'DARJON DRIVE', 'GD567789'),
	('zgzghaf59', 'Simon', 'Cowel', '22-10-1980', 'Male', '(09)678-4568', '59', 'HOLLYWOOD PARADE', 'HG456789'),
	('yh1mnzg1s', 'Una', 'Kamal', '12-03-1983', 'Female', '(09)678-4568', '11', 'FAIRFIELD ROAD', 'EF123456'),
	('5o3msmr5w', 'Kylie', 'Sander', '13-08-1993', 'Female', '(09)678-4568', '13', 'COSBY ROAD', 'PL123456'),
	('svmpnys29', 'Ben', 'Arby', '19-04-1989', 'Male', '(09)678-4568', '16', 'DISCOVERY DRIVE', 'KT142526'),
	('fe526d2c', 'Jessica', 'Kong', '08-03-2001', 'Female', '(07)824-1781', '12', 'FLOWER LANE', 'KT142526');

INSERT INTO infringement_notice(notice_number, amount, notice_status, issue_date)
VALUES
	('PC131227816', 120.00, 'outstanding', '12-04-1989'),
	('PC544785256', 160.00, 'paid', '07-03-1992'),
	('PC319606693', 95.00, 'paid', '01-11-1995'),
	('PC367609851', 60.00, 'outstanding', '05-08-1996'),
	('PC795323875', 45.00, 'paid', '09-09-1983'),
	('PC037087028', 160.00, 'outstanding', '01-06-2022'),
	('PC010242676 ', 240.00, 'paid', '12-06-2022'),
	('PC757900698 ', 20.00, 'outstanding', '02-06-2022'),
	('PC830755821', 25.00, 'outstanding', '16-09-1983'),
	('PC303065651', 65.00, 'paid', '01-05-2021'),
	('PC542100522', 130.00, 'outstanding', '09-09-1983'),
	('PC340733957', 160.00, 'paid', '09-09-1983'),
	('PC247484891', 70.00, 'outstanding', '09-09-1983'),
	('PC140873471', 180.00, 'paid', '01-02-2022'),
	('PC724358913', 45.00, 'outstanding', '02-06-2021'),
	('PC241944489', 65.00, 'paid', '09-09-1983'),
	('PC588657130', 75.00, 'outstanding', '06-06-2022'),
	('PC062536471', 95.00, 'outstanding', '06-02-2021'),
	('PC025588050 ', 110.00, 'paid', '09-09-1983'),
	('PC793228010', 120.00, 'outstanding', '09-09-1983');
	
INSERT INTO offence(offence_id, offense_description, speed_alleged, timedate, icn, x_pos, y_pos, notice_number, registration_number, offender_id, weather)
VALUES
	('e0d3f82d', 'Speeding', '113', '12-04-1989 17:52:00', '342103677', '1406914', '4915023', 'PC131227816', 'ABC102', '282f91f3', 'Overcast'),
	('43c4214f', 'Reckless Driving', '67', '07-03-1992 08:43:00', '867753988', '1799023', '5814728', 'PC544785256', 'BCD550', '282f91f3', 'Clear'),
	('7ff28f53', 'Speeding', '169', '01-11-1995 11:33:00', '839252351', '1741193','5976099', 'PC319606693', 'JJS108', 'ba29ce46', 'Raining'),
	('bca94079', 'Reckless Driving', '111', '05-08-1996 16:13:00', '306055735', '1790288', '5837387','PC367609851', 'HIL567', 'fe526d2c', 'Clear'),
	('c16f5342', 'Speeding', '104', '09-09-1983 20:02:00', '709722349', '1615675', '5423627', null , 'LSD786', 'ba29ce46', 'Overcast'),
	('bkkevg3mm', 'Racing', '112', '09-09-1983 20:02:00', '577080580', '1570406', '5178315', 'PC795323875' , 'KDD453', '2nzcyow2y', 'Overcast'),
	('15oay3ecn', 'Speeding', '134', '09-09-1983 20:02:00', '385709069', '1766331', '5907432', null , 'LSD786', 'q4wa31dfw', 'Overcast'),
	('hrhqaz0af', 'Racing', '125', '09-09-1983 20:02:00', '208220352', '2037143', '5708472', 'PC010242676' , 'GLG909', 'zgzghaf59', 'Clear'),
	('y96628kex', 'Reckless Driving', '165', '09-09-1983 20:02:00', '241706655', '1571772', '5179558', 'PC757900698' , 'ABC102', 'yh1mnzg1s', 'Raining'),
	('cgfyy9sx0', 'Speeding', '103', '09-09-1983 20:02:00', '029773473', '1768750', '5904546', null , 'BCD550', '5o3msmr5w', 'Raining'),
	('1dty9yxi2', 'Racing', '143', '09-09-1983 20:02:00', '902181197', '1767091', '5912669', 'PC340733957' , 'JJS108', 'svmpnys29', 'Overcast'),
	('i48r5eyv2', 'Speeding', '104', '09-09-1983 20:02:00', '170453038', '1746990', '5915134', 'PC724358913' , 'MKL090', 'fe526d2c', 'Clear'),
	('x9wkbsvc5', 'Reckless Driving', '113', '09-09-1983 20:02:00', '903105153', '1746749', '5919711', null , 'HIL567', 'fe526d2c', 'Raining'),
	('op71rtxh3', 'Speeding', '111', '09-09-1983 20:02:00', '291634925', '1746822', '5918596', null , 'KDD453', 'yh1mnzg1s', 'Overcast'),
	('tw55k9v0w', 'Racing', '122', '09-09-1983 20:02:00', '967542445', '1754254', '5918542', 'PC588657130', 'LSD786', '5o3msmr5w', 'Raining');
	

Select * from offence o join infringement_notice i on o.notice_number = i.notice_number where offence_id = '43c4214f'

UPDATE offence set offence_id = 'bca94079', offense_description = 'Reckless Driving', speed_alleged = '111', timedate = '05-08-1996 16:13:00', icn = '306055735', x_pos = '1790288', y_pos = '5837387', notice_number = 'PC367609851', registration_number = 'HIL567', offender_id = 'fe526d2c', weather = 'Clear'  where offence_id = 'bca94079'

DROP PROCEDURE infringementNoticeData

create procedure infringementNoticeData
@noticeNumber varchar(20)
AS
SELECT i.notice_number, icn, fname, lname, roadStreet_num, roadStreet, dateOfBirth, license_number, timedate, make, model, offense_location, road, region, o.registration_number, amount, speed_limit, speed_alleged, offense_description, speed_alleged - speed_limit, DATENAME(WEEKDAY, timedate)
FROM offence o join infringement_notice i on o.notice_number = i.notice_number join vehicle v on v.registration_number = o.registration_number join offender x on x.offender_id = o.offender_id join offense_location ol on ol.x_pos = o.x_pos AND ol.y_pos = o.y_pos where o.notice_number = @noticeNumber
GO

DROP PROCEDURE unpaidInfringements

create procedure unpaidInfringements
AS
SELECT * 
FROM offence o join infringement_notice i on o.notice_number = i.notice_number where i.notice_status = 'outstanding'
GO

DROP PROCEDURE withoutInfringementNotice

create procedure withoutInfringementNotice
AS
SELECT *
FROM offence o where o.notice_number IS NULL;
GO

exec withoutInfringementNotice


DROP PROCEDURE overdueInfringements

create procedure overdueInfringements
AS
SELECT DATEADD(day, 28, issue_date) as 'due_date', *
FROM offence o join infringement_notice i on o.notice_number = i.notice_number where GETDATE() > DATEADD(day, 28, issue_date) AND i.notice_status = 'outstanding'
GO

exec overdueInfringements

create procedure numOffenses
AS
SELECT count(*)
From offence
GO

exec numOffenses

create procedure sumOfInfringements
AS
SELECT sum(amount)
From infringement_notice
GO

exec sumOfInfringements


drop procedure averageExcessSpeed

create procedure averageExcessSpeed
AS
SELECT avg(CAST(speed_alleged AS INT) - CAST(speed_limit AS INT))
From offence o join offense_location ol on ol.x_pos = o.x_pos AND ol.y_pos = o.y_pos
GO

exec averageExcessSpeed


drop procedure offenceDayOfWeekCommon

create procedure offenceDayOfWeekCommon
AS
SELECT TOP 1 DATENAME(WEEKDAY, timedate) as 'Day_of_Week'
From offence
Order By 'Day_of_Week' DESC
GO

exec offenceDayOfWeekCommon

drop procedure offenceVehicleMakeCommon

create procedure offenceVehicleMakeCommon
AS
SELECT TOP 1 make as 'commonOffeseVehicleMake'
From vehicle
Order By 'commonOffeseVehicleMake' DESC
GO

exec offenceVehicleMakeCommon



DROP PROCEDURE OffenceByID

create procedure OffenceByID
@offenceID varchar(20)
AS
SELECT * From offence
where offence_id = @offenceID
GO

exec OffenceByID '7ff28f53' 