IF NOT EXISTS(SELECT * FROM sys.tables WHERE name = 'TradeInfo')
BEGIN
	CREATE TABLE TradeInfo(
		Id uniqueidentifier NOT NULL Primary key,
		PairCode nvarchar(max),
		Amount decimal(10, 2),
		BuyPrice decimal(10, 2),
		CellPrice decimal(10, 2),
		StartDate datetime,
		CloseDate datetime,
		StatusId int,
		PositionId int
	)
END