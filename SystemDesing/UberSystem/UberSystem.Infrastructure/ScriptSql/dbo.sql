-- Active: 1725802893650@@127.0.0.1@1433@UberSystemDb@dbo
CREATE table trips(
    id BIGINT not null ,
    customerId BIGINT,
    driverId BIGINT,
    paymentId BIGINT,
    status char(1),
    sourceLatitude float,
    sourceLongitude float,
    destinationLatitude float,
    destinationLongitude float,
    createAt TIMESTAMP,
    CONSTRAINT [PK_Trips] PRIMARY KEY CLUSTERED(
        id asc
    ) 
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
);

CREATE table cabs (
    id BIGINT not null ,
    driverId BIGINT,
    type char(1),
    regNo VARCHAR(50),
    CONSTRAINT [PK_Cabs] PRIMARY KEY CLUSTERED(
        id asc
    ) 
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
);

CREATE table customers(
    id BIGINT not null ,
    name nvarchar (100),
    email VARCHAR(50),
    createAt TIMESTAMP,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED(
        id asc
    ) 
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
);
CREATE table ratings(
    id BIGINT not null,
    customerId BIGINT,
    driverId BIGINT,
    tripId BIGINT,
    rating INT,
    feedback nvarchar,
    CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED(
        id asc
    ) 
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
);

CREATE Table payments (
    id BIGINT not null ,
    tripId BIGINT,
    method CHAR(1),
    amount float,
    createAt TIMESTAMP,
     CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED(
        id asc
    ) 
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
);
CREATE Table drivers(
    id BIGINT not null,
    name nvarchar(100),
    cabId BIGINT,
    email VARCHAR(50),
    dob date ,
    locationLatitude float,
    locationLongitude float,
    createAt TIMESTAMP,
     CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED(
        id asc
    ) 
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
);

--Nhom 1:
-- Service Payment 

--Nhom 2:


-- NHom 3
