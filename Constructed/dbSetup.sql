CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS contractors(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name TEXT NOT NULL
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS companies(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name TEXT NOT NULL,
  location TEXT NOT NULL
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS jobs(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  contractorId INT NOT NULL,
  companyId INT NOT NULL,
  FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE,
  FOREIGN KEY (companyId) REFERENCES companies(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
DROP TABLE jobs;
-- Contractors
SELECT
  *
FROM
  contractors;
INSERT INTO
  contractors (name)
VALUES
  ('Ty');
DELETE from
  contractors
WHERE
  id = 2;
-- Companies
SELECT
  *
FROM
  companies;
DELETE from
  companies
WHERE
  id = 2;
INSERT INTO
  companies (name, location)
VALUES
  ('Prestige World Wide', 'Catalina Island');
-- Jobs
SELECT
  *
FROM
  jobs;
INSERT INTO
  jobs (contractorId, companyId)
VALUES
  (4, 4);
SELECT
  con.*,
  comp.*,
  j.id AS jobId,
  j.contractorId AS contractorId,
  j.companyId AS companyId
FROM
  jobs j
  JOIN companies comp ON comp.id = j.companyId
  JOIN contractors con ON con.id = j.contractorId
WHERE
  j.companyId = 4;