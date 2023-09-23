CREATE DATABASE MyDB;
GO

USE MyDB;
GO

CREATE TABLE [Student] (
	[Id]				nvarchar(32) NOT NULL,
    [Name] 				nvarchar(64) NOT NULL,
    PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Subject] (
	[Id]				nvarchar(32) NOT NULL,
    [Title] 			nvarchar(64) NOT NULL,
    PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Result] (
	[Id]				int NOT NULL IDENTITY, 
	[StudentId]			nvarchar(32),
	[Year]				int,
	[Cgpa]				DECIMAL(3, 2),
    PRIMARY KEY ([Id]),
	FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id])
);
GO


CREATE TABLE [ResultSubject] (
	[ResultId]				int,
    [SubjectId] 			nvarchar(32),
	[Level]					nvarchar(32),
	[Mark]					DECIMAL(5, 2),
	[Weightage]				DECIMAL(5, 2),
    PRIMARY KEY ([ResultId], [SubjectId]),
	FOREIGN KEY ([ResultId]) REFERENCES [Result]([Id]),
	FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id])
);
GO

CREATE TABLE [MetricData] (
	[Type]			nvarchar(64),
	[Mark]			DECIMAL(5, 2),
	[Weightage]		DECIMAL(5, 2),
	[ResultId]		int,
	PRIMARY KEY ([ResultId] ,[Type]),
	FOREIGN KEY ([ResultId]) REFERENCES [Result]([Id])
);
GO

CREATE TABLE [Assessment] (
	[Type]				nvarchar(64),
	[Mark]				DECIMAL(5, 2),
	[Weightage]			DECIMAL(5, 2),
	[SubjectId]			nvarchar(32),
	[ResultId]			int,
    PRIMARY KEY ([ResultId], [SubjectId],[Type]),
	FOREIGN KEY ([ResultId]) REFERENCES [Result]([Id]),
	FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id])
);
GO

--Poupulate date in the table
Insert Into [Student] (Id,Name) Values('A19EC0001', 'Amjad Bin Rushdan');
Insert Into [Student] (Id,Name) Values('A19EC0002', 'Amir Hakim Bin Ahmed Maher');

Insert Into [Subject] (Id,Title) Values('SECJ2023', 'Software Engineering');
Insert Into [Subject] (Id,Title) Values('SECJ2035', 'Architecture Design');

--Result  without CGPA Value
Insert Into [Result] (StudentId, Year, Cgpa) Values('A19EC0001', 2019, NULL);
Insert Into [Result] (StudentId, Year, Cgpa) Values('A19EC0002', 2019, NULL);

--Update CGPA Value
UPDATE [Result] SET Cgpa = 3.02 WHERE Id = 1;
UPDATE [Result] SET Cgpa = 4.00 WHERE Id = 2;

Insert Into [ResultSubject] (ResultId, SubjectId, Level, Weightage, Mark) Values(1, 'SECJ2023', 'Beginner', 0.05, 80.00);
Insert Into [ResultSubject] (ResultId, SubjectId, Level, Weightage, Mark) Values(1, 'SECJ2035', 'Intermediate', 0.02, 70.00);

Insert Into [ResultSubject] (ResultId, SubjectId, Level, Weightage, Mark) Values(2, 'SECJ2023', 'Beginner', 0.05, 60.0);
Insert Into [ResultSubject] (ResultId, SubjectId, Level, Weightage, Mark) Values(2, 'SECJ2035', 'Intermediate', 0.02, 100.0);


Insert Into [MetricData] (Type, Mark, Weightage, ResultId) Values('Internship', 80.0, 0.02, 1);
Insert Into [MetricData] (Type, Mark, Weightage, ResultId) Values('Cocuriculum', 100.0, 0.02, 1);
Insert Into [MetricData] (Type, Mark, Weightage, ResultId) Values('Attitude', 100.0, 0.01, 1);
Insert Into [MetricData] (Type, Mark, Weightage, ResultId) Values('GPA', NULL, 0.05, 1);

Insert Into [MetricData] (Type, Mark, Weightage, ResultId) Values('Internship', 100.0, 0.02, 2);
Insert Into [MetricData] (Type, Mark, Weightage, ResultId) Values('Cocuriculum', 50.0, 0.02, 2);
Insert Into [MetricData] (Type, Mark, Weightage, ResultId) Values('Attitude', 50.0, 0.01, 2);
Insert Into [MetricData] (Type, Mark, Weightage, ResultId) Values('GPA', NULL, 0.05, 2);

--Update the value of GPA
UPDATE [MetricData] SET Mark = 80.00 WHERE ResultId = 1 AND Type = 'GPA';
UPDATE [MetricData] SET Mark = 100.00 WHERE ResultId = 2 AND Type = 'GPA';


Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Quiz', 100.00, 0.02, 'SECJ2023' , 1);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('CaseStudy', 60.00, 0.03, 'SECJ2023' , 1);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Assingment', 100.00, 0.01, 'SECJ2023' , 1);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Test', 75.00, 0.02, 'SECJ2023' , 1);

Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Quiz', 86.00, 0.02, 'SECJ2035' , 1);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('CaseStudy', 45.00, 0.03, 'SECJ2035' , 1);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Assingment', 96.00, 0.01, 'SECJ2035' , 1);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Test', 66.00, 0.02, 'SECJ2035' , 1);

Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Quiz', 100.00, 0.02, 'SECJ2023' , 2);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('CaseStudy', 60.00, 0.03, 'SECJ2023' , 2);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Assingment', 100.00, 0.01, 'SECJ2023' , 2);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Test', 75.00, 0.02, 'SECJ2023' , 2);

Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Quiz', 86.00, 0.02, 'SECJ2035' , 2);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('CaseStudy', 45.00, 0.03, 'SECJ2035' , 2);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Assingment', 96.00, 0.01, 'SECJ2035' , 2);
Insert Into [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) Values('Test', 66.00, 0.02, 'SECJ2035' , 2);

SELECT * FROM [Student];
SELECT * FROM [Subject];
SELECT * FROM [Result];
SELECT * FROM [ResultSubject];
SELECT * FROM [MetricData];
SELECT * FROM [Assessment];
GO
