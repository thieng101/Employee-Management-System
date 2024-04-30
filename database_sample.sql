DROP TABLE IF EXISTS `Employees`;
DROP TABLE IF EXISTS `Departments`;
DROP TABLE IF EXISTS `PayrollHistory`;

CREATE TABLE IF NOT EXISTS `Employees` (
    `ID` INT NOT NULL AUTO_INCREMENT,
    `FirstName` VARCHAR(50) NOT NULL,
    `LastName` VARCHAR(50) NOT NULL,
    `DOB` DATE NOT NULL,
    `DateJoined` DATE NOT NULL,
    `BaseSalary` DECIMAL(10, 2) NOT NULL,
    `DepartmentID` INT NOT NULL,
    PRIMARY KEY (`ID`),
    FOREIGN KEY (`DepartmentID`) REFERENCES `Departments`(`ID`) ON DELETE CASCADE
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `Departments` (
    `ID` INT NOT NULL AUTO_INCREMENT,
    `Name` VARCHAR(100) NOT NULL,
    `Description` TEXT,
    PRIMARY KEY (`ID`)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `PayrollHistory` (
    `EmployeeID` INT NOT NULL,
    `PaymentDate` DATE NOT NULL,
    `Amount` DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (`EmployeeID`) REFERENCES `Employees`(`ID`) ON DELETE CASCADE
) ENGINE = InnoDB;

# Insert dummy data for demonstration purposes
INSERT INTO `Departments` (`Name`, `Description`) VALUES
    ('Accounting', 'Handles company finances and transactions.'),
    ('HR', 'Manages employee records and hiring.');

INSERT INTO `Employees` (`FirstName`, `LastName`, `DOB`, `DateJoined`, `BaseSalary`, `DepartmentID`) VALUES
    ('John', 'Doe', '1980-04-01', '2020-01-15', 55000.00, 1),
    ('Jane', 'Smith', '1990-08-15', '2022-03-01', 65000.00, 2);

INSERT INTO `PayrollHistory` (`EmployeeID`, `PaymentDate`, `Amount`) VALUES
    (1, '2023-04-28', 4583.33),
    (2, '2023-04-28', 5416.67);
