CREATE TABLE IF NOT EXISTS People (
	Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	FirstName TEXT NOT NULL,
	LastName TEXT NOT NULL,
	AddressId INTEGER NOT NULL,

	FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);