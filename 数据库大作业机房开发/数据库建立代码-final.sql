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
	bridgeName	VARCHAR(40),
	builtYear	CHAR(4),
	span		VARCHAR(40) NOT NULL,
	towerHeight	DECIMAL(10,3) NOT NULL,
	towerCrosswide	VARCHAR(10)
					CHECK(towerCrosswide IN('A', '钻石', 'H', '倒Y', '独柱')),
	section		VARCHAR(20)
				CHECK(section IN ('箱形', '分离式箱形', '分离实主梁', '桁架')),
	materialTower	VARCHAR(10)
					CHECK(materialTower IN('钢', '砼')),
	materialBeam	VARCHAR(10)
					CHECK(materialBeam IN('钢', '砼','混合', '叠合')),
	briefIntro		VARCHAR(5000),
	bridgeImg		IMAGE,
)

CREATE TABLE bridgeModel(
	modelID	CHAR(5) NOT NULL PRIMARY KEY,
	userID	VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES bridgeDesigner,
	modifyDate	DATETIME,
	remark	VARCHAR(100),
	modelSpan	CHAR(40) NOT NULL,
	modelTowerHeight	DECIMAL(10,3),
	modelTowerCrosswide	VARCHAR(15)
						CHECK(modelTowerCrosswide IN('A形（1）', 'A形（2）', '宝塔式', '单柱式', '倒Y形', '花瓶式（1）', '花瓶式（2）', '门式', '双柱式', '钻石式')),
	modelSection	VARCHAR(30)
					CHECK(modelSection IN ('砼-边箱梁截面', '砼-带斜撑箱形截面','钢-边箱梁截面-1', '钢-边箱梁截面-2', '钢-分体式箱形截面', '钢-整体式箱形截面', '砼-肋板式截面', '砼-实心板截面', '砼-箱形截面')),
	modelTowerAlong	VARCHAR(10)
					CHECK(modelTowerAlong IN('A形', '单柱式', '倒Y形')),
	cableDisBeam	DECIMAL(10,2),
	cableDisTower	DECIMAL(10,2),
	cableBeginLocTower	VARCHAR(5)
						CHECK(cableBeginLocTower LIKE '[0-9]/[0-9]'),

)

CREATE TABLE userComment(
	userID VARCHAR(10) NOT NULL 
			FOREIGN KEY 
			REFERENCES bridgeDesigner(userID),
	bridgeID CHAR(5) NOT NULL
			 CHECK(bridgeID LIKE 'cb[0-9][0-9][0-9]')
			 FOREIGN KEY
			 REFERENCES bridge(bridgeID),
	comment	VARCHAR(50),
	commentTime DATETIME,
	PRIMARY KEY(bridgeID, userID, commentTime),
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

INSERT INTO bridge
VALUES	('cb001','泖港大桥','1982','85+200+85','44.0','H','箱形','砼','钢','泖港大桥位于上海市松江区泖港镇东侧，通航标准为5级航道，泖港大桥横跨大泖港承接叶新公路。',''),
		('cb002','上海闵浦二桥','2010','251+185.25','148.0','H','箱形','砼','钢','闵浦二桥（The Second Mingpu Bridge）是中国上海市境内连接闵行区与奉贤区的过江通道，位于黄浦江水道之上。',''),
		('cb003','天津塘沽海河大桥','2002','310+190','168.0','钻石','箱形','砼','混合','天津塘沽海河大桥天津塘沽海河大桥位于天津市塘沽区海河入海口，桥梁结构总长2230m，正桥500m，北引桥1099m ，南引桥680m，桥面宽度23m，四车道。',''),
		('cb004','洞庭湖大桥','2000','130+310+310+130','125.684','钻石','箱形','砼','砼','洞庭湖大桥（Dongting Lake Bridge）是中国湖南省岳阳市境内连接君山区和岳阳楼区的过江通道，位于洞庭湖水道之上，为岳阳市市区西北部城市主干道路的组成部分。',''),
		('cb005','台南高屏溪大桥','2000','330+180','183.5','A','箱形','砼','混合','台湾高屏溪桥位于台湾南部的南二高速公路高雄、屏东段，跨越高屏溪处。',''),
		('cb006','四川泸州泰安长江大桥','2003','208+335','159.3','H','箱形','砼','钢','1573长江大桥（1573 Yangtze River Bridge），又称“泰安长江大桥”，是中国四川省泸州市境内连接龙马潭区与江阳区的过江通道，位于长江水道之上，是广州—成都公路（国道G321）、泸州市绕城公路、泸州二环路的组成部分，建成时为亚洲单孔跨度最大的单塔双索面不等距离斜拉桥',''),
		('cb007','广州黄埔大桥','2008','322+383','226.114','H','箱形','砼','钢','黄埔大桥（Huangpu Bridge）是中国广东省广州市境内一座连接黄埔区和番禺区的过江通道，位于珠江南北干流、狮子洋以西水域之上，属于广澳高速公路的组成部分，也是广州绕城高速公路东环段的一部分。',''),
		('cb008','武汉长江二桥','1995','180+400+180','124.02','H','箱形','砼','砼','武汉长江二桥（The Second Yangtze River Bridge in Wuhan）是中国湖北省武汉市境内连接汉口与武昌区的过江通道，为武汉市区中部城市主干道路的组成部分。',''),
		('cb009','润扬长江公路大桥北汊斜拉桥','2004','176+406+176','146.9','倒Y','箱形','砼','钢','润扬长江公路大桥（Runyang Bridge），简称润扬大桥，是中国江苏省境内一座连接镇江市和扬州市的桥梁工程，是江苏“四纵四横四联”高速公路网中主骨架和跨长江通道规划的重要组成部分。',''),
		('cb010','嘉绍大桥','2013','270+428+428+428+428+428+270','170.0','独柱','箱形','砼','钢','嘉绍大桥（Jiashao Bridge）是中国浙江省境内连接嘉兴市海宁市与绍兴市上虞区的过江通道，位于中国浙江省杭州湾海域内，是常台高速公路（国家高速G1522）的组成部分。',''),
		('cb011','四川宜宾长江大桥','2008','184+460+184','113.1','H','分离式箱形','砼','钢','宜宾长江大桥（Yibin Yangtze River Bridge），是中国四川省宜宾市境内连接翠屏区与叙州区的过江通道，位于长江水道之上，是宜宾—叙永公路（国道G547）的组成部分',''),
		('cb012','重庆长寿长江大桥','2007','207+460+207','115.0','H','箱形','砼','钢','长寿长江大桥于重庆市东部，连接涪陵、万州、云阳等三峡库区腹心地带，大桥为钢索斜拉桥，全长1.2公里，主跨450米，双向四车道，桥面宽20.5米，',''),
		('cb013','荆沙长江大桥','2000','200+500+200','139.15','H','箱形','砼','砼','荆州长江大桥（Jingzhou Yangtze River Bridge），是中国湖北省荆州市境内连接沙市区与公安县的过江通道，位于长江水道之上，是中国湖北省”九五 期间交通重点建设项目，也是接合207国道跨越长江的咽喉工程。',''),
		('cb014','安庆长江大桥','2004','215+510+215','184.781','钻石','箱形','砼','钢','安庆长江大桥（Anqing Yangtze River Bridge）是中国安徽省境内连接池州市东至县和安庆市宜秀区的过江通道，位于长江水道之上，为上海—重庆高速公路（国家高速G50）的组成部分，是长江上第三十五座桥梁。',''),
		('cb015','斯堪桑蒂特桥','1991','240+530+240','152.0','A','箱形','砼','钢','斯卡恩松德大桥（挪威语：Skarnsundet bru或Skarnsundbrua）是一座1010米（3，310英尺）长的砼斜拉桥，横跨挪威特伦德拉格郡因德罗伊市。 1991年完工后，它取代了Vangshylla-Kjerringvik渡轮，使莫斯维克和莱克斯维克市的社区更容易进入因赫里德的中心地区。这座桥是特隆赫姆峡湾唯一的公路交叉口，位于挪威县道755号沿线。',''),
		('cb016','安蒂雷翁桥','2004','286+560+560+560+286','160.0','倒Y','箱形','砼','钢','里翁-安提里翁大桥，又称Charilaos Trikoupis大桥是希腊的一座跨越科林斯湾的桥梁。它连接希腊大陆西部的安提里翁与伯罗奔尼撒半岛西北上帕特雷附近的里翁。',''),
		('cb017','舟山连岛桃夭门大桥','2006','146+580+146','151.0','A','箱形','砼','钢','桃夭门大桥，是舟山大陆连岛工程中的第三座桥梁，横跨桃夭门水道，连接富翅岛和册子岛，是一座双塔双索面混合式斜拉桥。',''),
		('cb018','上海徐浦大桥','1996','202+590+202','221.0','A','箱形','砼','叠合','徐浦大桥（Xupu Bridge）是中国上海市境内连接徐汇区与浦东新区的过江通道，位于黄浦江水道之上，为上海外环高速公路组成部分之一。',''),
		('cb019','上海杨浦大桥','1993','283+602+287','208.0','倒Y','箱形','砼','叠合','杨浦大桥（Yangpu Bridge）是中国上海市境内连接杨浦区与浦东区的过江通道，位于黄浦江水道之上，为上海内环高速架路组成部分之一。',''),
		('cb020','武汉长江三桥','2000','230+618+230','174.75','A','箱形','砼','钢','武汉白沙洲大桥是一座位于中国湖北省境内，全长3589米，桥面宽26.5米，于2000年9月9日正式通车，由双塔双索面钢箱梁桥与预应力混泥土箱梁组合而成的斜拉桥。',''),
		('cb021','南京长江第二大桥','2001','305+628+305','195.41','倒Y','箱形','砼','钢','南京八卦洲长江大桥，简称八卦洲大桥，原称南京长江第二大桥，是中国江苏省南京市境内一座跨长江斜拉桥，是中国国家“九五”重点建设项目',''),
		('cb022','南京长江第三大桥','2006','320+648+320','215.0','A','箱形','钢','钢','南京大胜关长江大桥，简称大胜关大桥，原称南京长江第三大桥 ，是中国江苏省南京市境内一座连接浦口区绿水湾南端和雨花台区大胜关的跨江大桥，南与南京绕城高速公路相接，北与宁合高速公路相连，是中国第一座钢塔斜拉桥，也是世界第一座弧线形钢塔斜拉桥。',''),
		('cb023','上海闵浦大桥','2009','252+708+252','210.0','H','桁架','砼','砼','闵浦大桥（Minpu Bridge）是中国上海市境内连接闵行区与浦东新区的过江通道，位于黄浦江水道之上，为上海外环高速公路组成部分之一。',''),
		('cb024','上海长江大桥（崇明）','2008','350+730+350','216.0','独柱','分离式箱形','砼','钢','上海长江大桥（Shanghai Yangtze River Bridge）是中国上海市崇明区境内的跨海大桥，位于长江入海口之上，是上海崇明越江通道重要组成部分之一。',''),
		('cb025','荆岳长江公路大桥','2010','398+816+230','265.5','H','箱形','砼','钢','荆岳大桥（Jingyue Bridge）是连接中国湖北省荆州市与湖南省岳阳市的过江通道，位于长江水道之上，是首座连接湖北、湖南两省的长江大桥，也是连接“武汉城市圈”和“长株潭城市群”经济发展的纽带。',''),
		('cb026','诺曼底海峡大桥','1995','672+856+672','215.0','倒Y','箱形','砼','混合','诺曼底大桥，由M.Virlogeux设计，建于1994年。它是一座与当地景观完美协调的斜拉桥，以其细长的结构和典雅的造型而著称。诺曼底大桥被授予“20世纪世界最美的桥梁”。',''),
		('cb027','多多罗大桥','1999','270+890+320','216.6','钻石','箱形','砼','混合','多多罗大桥（Tatara Bridge）是位于日本濑户内海的斜拉桥，连接广岛县的生口岛及爱媛县的大三岛之间。',''),
		('cb028','湖北鄂东长江大桥','2005','375+926+375','236.5','钻石','分离式箱形','砼','混合','鄂东长江大桥（E’dong Yangtze River Bridge）是中国湖北省境内连接黄石市和黄冈市的过江通道，位于长江水道之上，为大庆—广州高速公路（国家高速G45）、上海—重庆高速公路（国家高速G50）重要构成部分，也是黄石市境内第二座长江大桥。',''),
		('cb029','昂船洲大桥','2003','289+1018+289','298.0','独柱','分离式箱形','砼','钢','2009年12月20日上午7时，世界上最长的斜拉桥之一的香港昂船洲大桥正式通车。昂船洲大桥全长1.6公里，为双向三线高架斜拉桥，是香港八号公路干线的主要组成部分。大桥由香港葵涌货运码头入口，横跨蓝巴勒海峡，向西伸延至青衣岛，主跨度为1018米 ，是世界上最长的斜拉桥之一。',''),
		('cb030','苏通大桥','2008','500+1088+500','300.4','A','箱形','砼','钢','苏通长江公路大桥（Su-Tong Yangtze River Highway Bridge），简称苏通大桥，位于中国江苏省境内，是国家高速沈阳－海口高速公路（G15）跨越长江的重要枢纽','')

GO


-- 这里创建视图，用来存放主跨和塔高，用于匹配桥型
CREATE VIEW ViewForMainSpan
AS
	SELECT bridge.bridgeID, a.mainSpan, bridge.towerHeight, bridgeName
	FROM (	-- 这里是用来从跨径组合中分词获取主跨
			SELECT bridgeID, MAX(CAST(value AS DECIMAL(7,2))) mainSpan
			FROM bridge
			CROSS APPLY string_split(span,'+')
			GROUP BY bridgeID ) a, bridge
	WHERE a.bridgeID = bridge.bridgeID
GO

SELECT * FROM ViewForMainSpan

GO
-- 这里是用来匹配相似桥型的表值函数，传入参数为
--     1. @temp_mainSpan: 用户指定的主跨，INT
--     2. @temp_towerHeight: 用户指定的桥面以上塔高，DECIMAL(10,3)
-- 返回值为按照相似度排名的已有桥梁的编号列
CREATE FUNCTION matchingBridge(@temp_mainSpan INT, @temp_towerHeight DECIMAL(10, 3))
RETURNS TABLE
AS
RETURN
	SELECT TOP 10 bridgeID, bridgeName
	FROM ViewForMainSpan
	ORDER BY ABS(mainSpan-@temp_mainSpan) + ABS(towerHeight - @temp_towerHeight) * 0.25
GO

-- 测试
SELECT * FROM dbo.matchingBridge(1100, 300)
GO


-- 这里是用来返回某一个用户已存入 bridgeModel 表中的行数，传入参数为用户编号 userID
-- 返回值为一个数，INT
CREATE PROC modelNum
@temp_userID VARCHAR(10),
@temp_modelNum INT OUT
AS
	SELECT @temp_modelNum = COUNT(modelID)
	FROM bridgeModel
	WHERE userID = @temp_userID
GO
-- 测试
DECLARE @temp_userID VARCHAR(10)
DECLARE @temp_modelNum INT
SET @temp_userID = 'NanxiChen'
EXEC modelNum @temp_userID, @temp_modelNum OUT
PRINT @temp_modelNum
GO



-- 这里是用来返回所有已存入 bridgeModel 表中的行数，不传入参数
-- 返回值为一个数，INT
CREATE PROC modelNumAll
@temp_modelNum INT OUT
AS
	SELECT @temp_modelNum = MAX(CAST(right(modelID, 4) AS INT))
	FROM bridgeModel
GO
-- 测试
DECLARE @temp_modelNum INT
EXEC modelNumALL @temp_modelNum OUT
PRINT @temp_modelNum
GO


SELECT TOP 10 bridgeID, bridgeName
FROM bridge
ORDER BY ABS(mainSpan-500) + ABS(towerHeight - 200) * 0.25


SELECT span FROM bridge



