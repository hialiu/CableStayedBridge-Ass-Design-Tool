CREATE DATABASE cableStayedBridge
GO
USE cableStayedBridge
GO
CREATE TABLE bridgeDesigner(
	userID  VARCHAR(10) NOT NULL PRIMARY KEY,
	psw		VARCHAR(12) NOT NULL
			CHECK(len(psw) >= 8),
)


CREATE TABLE bridge(
	bridgeID	CHAR(5) NOT NULL PRIMARY KEY
				CHECK(bridgeID LIKE 'cb[0-9][0-9][0-9]'),
	bridgeName	VARCHAR(20),
	builtYear	CHAR(4),
	span		VARCHAR(20) NOT NULL,
	towerHeight	DECIMAL(10,3) NOT NULL,
	towerCrosswide	VARCHAR(5)
					CHECK(towerCrosswide IN('A', '��ʯ', 'H', '��Y', '����')),
	section		VARCHAR(10)
				CHECK(section IN ('����', '����ʽ����', '����ʵ����', '���')),
	materialTower	VARCHAR(6)
					CHECK(materialTower IN('��', '��')),
	materialBeam	VARCHAR(2)
					CHECK(materialBeam IN('��', '��','���', '����')),
	bridgeImg		IMAGE,
	briefIntro		VARCHAR(200),
)

CREATE TABLE bridgeModel(
	modelID	CHAR(5) NOT NULL PRIMARY KEY,
	userID	VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES bridgeDesigner,
	modifyDate	DATE,
	remark	VARCHAR(50),
	modelSpan	CHAR(20) NOT NULL,
	modelToerHeight	DECIMAL(5,3),
	modelTowerCrosswide	VARCHAR(5)
						CHECK(modelTowerCrosswide IN('A', '��ʯ', 'H', '��Y')),
	modelSection	VARCHAR(10)
					CHECK(modelSection IN ('����', '��������', '����ʵ����')),
	cableDisBeam	DECIMAL(2,2),
	cableDisTower	DECIMAL(2,2),
	cableBeginLocTower	VARCHAR(5)
						CHECK(cableBeginLocTower LIKE '[0-9]/[0-9]'),

)

CREATE TABLE userComment(
	userID VARCHAR(10) NOT NULL FOREIGN KEY(userID) REFERENCES bridgeDesigner(userID),
	bridgeID CHAR(5) NOT NULL PRIMARY KEY
			 CHECK(bridgeID LIKE 'cb[0-9][0-9][0-9]')
			 FOREIGN KEY
			 REFERENCES bridge(bridgeID),
	comment	VARCHAR(50)
)


CREATE TABLE bridgeAdmin(
	userID  VARCHAR(10) NOT NULL PRIMARY KEY,
	psw		VARCHAR(12) NOT NULL
			CHECK(len(psw) >= 8),
)


INSERT INTO bridgeDesigner
VALUES ('NanxiChen', '123456789')


INSERT INTO bridgeAdmin
VALUES ('ADMIN', 'BRIDGEADMIN')