ALTER ROLE "TableBookingUser" SET search_path = public;

-- seed Restaurants records
INSERT INTO "Restaurants" ("Id","Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "PrimaryImageURL","SecondaryImageURL", "Price", "Rating", "Phone")
VALUES ('a7f7be1c-adae-40df-b315-f772857936d5', 'UNO', '21:00:00', 'Description of UNO.', 'Śniadeckich 10b/2', '12:00:00', 'Pizza', null,null, 1, 5, 123-456-789);
INSERT INTO "Restaurants" ("Id","Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "PrimaryImageURL","SecondaryImageURL", "Price", "Rating", "Phone")
VALUES ('bfa8ba14-e4ef-4f13-a4a9-4b1d29d2f8ba','Mozaika', '22:15:00', 'Description of Mozaika restaurant.', 'Ratuszowska 10', '15:00:00', 'Generic restaurant', null,null, 3, 4, 41-334-219);
INSERT INTO "Restaurants" ("Id","Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "PrimaryImageURL","SecondaryImageURL", "Price", "Rating", "Phone")
VALUES ('a50c6651-c1b4-497f-b8db-e101da537692','NieNaŻarty', '24:15:00', 'Description of NieNaŻarty.', 'Zwycięstwa 20/2', '13:30:00', 'Burger', null, null, 3, 3, 432-123-543);
INSERT INTO "Restaurants" ("Id","Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "PrimaryImageURL","SecondaryImageURL", "Price", "Rating", "Phone")
VALUES ('207989de-6d2b-416a-9634-c45870cd9f4f','Heaven', '20:00:00', 'Description of Heaven.', 'Staszewskiego 2', '12:00:00', 'Pizza', null,null, 2, 2, 164-231-324);
INSERT INTO "Restaurants" ("Id","Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "PrimaryImageURL","SecondaryImageURL", "Price", "Rating", "Phone")
VALUES ('123e1a20-6801-4a5e-a327-ecc5cb2bd906','Green', '24:00:00', 'Description of Green restaurant.', 'Fałata 5/5', '14:30:00', 'Generic restaurant', null,null, 2, 1, 357-877-667);

-- seed Table records
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('123e1a20-6801-4a5e-a327-ecc5cb2bd906',1, 1);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('b3bb2638-b51c-4689-a772-0a154b6afa1c',2, 1);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('baafacef-4f85-461a-b6cb-ba887dc54401',3, 2);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('a5bf5296-d15b-4e28-89aa-b75bfac13289',4, 2);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('3eb2eb68-a47e-47cd-8a22-06c20197a0b3',4, 3);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('8deccd28-fdf3-42ec-86f3-9dd7fe743af5',3, 3);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('c748ee60-a136-4161-b6ce-60205e311a36',2, 4);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('423d89b6-1d72-479c-87e2-f573c61c611a',1, 4);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('840fffa7-ba45-4f44-a139-d794dcc4c647',4, 5);
INSERT INTO "Tables" ("Id","NumberOfSeats", "RestaurantId") VALUES ('d3f5aa07-4803-4008-8fed-7fa6a4de5fe6',8, 5);

-- seed Users records
INSERT INTO "Users" (
    "Id",
    "RefreshToken",
    "RefreshTokenExpiryTime",
    "UserName",
    "NormalizedUserName",
    "Email",
    "NormalizedEmail",
    "EmailConfirmed",
    "PasswordHash",
    "SecurityStamp",
    "ConcurrencyStamp",
    "PhoneNumber",
    "PhoneNumberConfirmed",
    "TwoFactorEnabled",
    "LockoutEnd",
    "LockoutEnabled",
    "AccessFailedCount"
) VALUES (
    'id1',
    'refreshtoken1',
    '2023-11-12 00:00:00+00'::timestamptz, -- Note the casting to timestamptz
    'user uno',
    'normalized user uno name',
    'email1',
    'normalized_email1',
    TRUE, -- Use TRUE for boolean values
    'hashpasswd1',
    'securitystamp1',
    'concurrencystamp1',
    '123-456-789',
    FALSE,
    FALSE,
    '2023-10-12 14:30:00+00'::timestamptz,
    TRUE,
    0
);

INSERT INTO "Users" (
    "Id",
    "RefreshToken",
    "RefreshTokenExpiryTime",
    "UserName",
    "NormalizedUserName",
    "Email",
    "NormalizedEmail",
    "EmailConfirmed",
    "PasswordHash",
    "SecurityStamp",
    "ConcurrencyStamp",
    "PhoneNumber",
    "PhoneNumberConfirmed",
    "TwoFactorEnabled",
    "LockoutEnd",
    "LockoutEnabled",
    "AccessFailedCount"
) VALUES (
    'id2',
    'refreshtoken2',
    '2023-11-12 00:00:00+00'::timestamptz, -- Note the casting to timestamptz
    'user nienazarty',
    'normalized user nienazarty name',
    'email2',
    'normalized_email2',
    TRUE, -- Use TRUE for boolean values
    'hashpasswd2',
    'securitystamp2',
    'concurrencystamp2',
    '123-333-789',
    TRUE,
    TRUE,
    '2023-10-12 14:30:00+00'::timestamptz,
    TRUE,
    2
);

-- seed Bookings records
INSERT INTO "Bookings" VALUES ('fc9663f0-08b1-4c52-afe4-1d446b11017f','2030-01-01 14:30:00+00', 5, 'e8213e4a-c336-4345-b93e-26231379acda' , 'userid1', 'appuserid1');
INSERT INTO "Bookings" VALUES ('c4c4a1c0-3cb4-445e-ba81-311a6b939b4a','2050-05-07 20:15:00+00', 3, 'c52fd4e3-1e46-4c38-84cc-d686800b425c','userid2', 'appuserid2');