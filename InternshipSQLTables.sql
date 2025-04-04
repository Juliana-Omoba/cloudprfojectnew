-- Create Students table 
CREATE TABLE Students (
	Id INT IDENTITY(1,1) PRIMARY KEY, 
	Name NVARCHAR(100) NOT NULL, 
	Email NVARCHAR(100) UNIQUE NOT NULL, 
	DegreeProgram NVARCHAR(100) NOT NULL, 
	YearOfStudy INT NOT NULL 
);


-- Create Company table 
CREATE TABLE Company (
	Id INT IDENTITY(1,1) PRIMARY KEY, 
	Name NVARCHAR(100) NOT NULL,
	Industry VARCHAR(100) NOT NULL, 
	Location NVARCHAR(255) NOT NULL, 
	ContactEmail NVARCHAR(100) UNIQUE NOT NULL 

);


--Create Internships table (linking Students and Companies) 
CREATE TABLE Internships (  
	Id INT IDENTITY(1,1) PRIMARY KEY, 
	StudentId INT NOT NULL, 
	CompanyId INT NOT NULL, 
	Position NVARCHAR(108) NOT NULL, 
	StartDate DATE NOT NULL, 
	EndDate DATE NOT NULL, 
	HoursLogged INT DEFAULT 0, 
	SupervisorFeedback NVARCHAR(500), 
	CONSTRAINT FK_Internships_Students FOREIGN KEY (StudentId) REFERENCES Students(Id), 
	CONSTRAINT FK_Internships_Companies FOREIGN KEY (CompanyId) REFERENCES Company(Id) 
);




--Insert sample data 
INSERT INTO Students (Name, Email, DegreeProgram, YearOfStudy) 
VALUES ('Bob Smith', 'bob@example.com', 'Computer Science', 2),
('Johnson Alice', 'johnson@example.com', 'Information systems', 3);




INSERT INTO Company (Name, Industry, Location, ContactEmail)
VALUES ('TechCorp', 'Software Devel Development', 'New York, USA', 'contact@techcorp.com'), 
('HealthCare Inc.', 'Healthcare Technology', 'Los Angeles, USA', 'info@healthcareinc.com');

INSERT INTO Internships (StudentId, CompanyId, Position, StartDate, EndDate, HoursLogged, SupervisorFeedback) 
VALUES (1, 1, 'Software Developer Intern', '2025-06-01', '2025-09-01', 120, 'Great progress on API development.'), 
(2, 2, 'Data Analyst Intern', '2015-06-15', '2025-09-15', 80, 'Strong analytical skills.' ); 

SELECT * FROM Students;
SELECT * FROM Company;
SELECT * FROM Internships;

--drop table Internships;
--drop table Students;
--drop table Company;

-- Below codes work for Azure database to drop tables
--drop table Internships;
--drop table [dbo].Students;
--drop table [dbo].Company;