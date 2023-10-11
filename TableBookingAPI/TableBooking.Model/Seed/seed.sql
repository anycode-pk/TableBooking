ALTER ROLE "TableBookingUser" SET search_path = public;

-- seed Restaurants records
INSERT INTO "Restaurants" ("Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "ImageURL", "Price", "Rating")
VALUES ('UNO', '21:00:00', 'Description of UNO.', 'Śniadeckich 10b/2', '12:00:00', 'Pizza', null, 1, 5);
INSERT INTO "Restaurants" ("Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "ImageURL", "Price", "Rating")
VALUES ('Mozaika', '22:15:00', 'Description of Mozaika restaurant.', 'Ratuszowska 10', '15:00:00', 'Generic restaurant', null, 3, 4);
INSERT INTO "Restaurants" ("Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "ImageURL", "Price", "Rating")
VALUES ('NieNaŻarty', '24:15:00', 'Description of NieNaŻarty.', 'Zwycięstwa 20/2', '13:30:00', 'Burger', null, 3, 3);
INSERT INTO "Restaurants" ("Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "ImageURL", "Price", "Rating")
VALUES ('Heaven', '20:00:00', 'Description of Heaven.', 'Staszewskiego 2', '12:00:00', 'Pizza', null, 2, 2);
INSERT INTO "Restaurants" ("Name", "CloseTime", "Description", "Location", "OpenTime", "Type", "ImageURL", "Price", "Rating")
VALUES ('Green', '24:00:00', 'Description of Green restaurant.', 'Fałata 5/5', '14:30:00', 'Generic restaurant', null, 2, 1);

-- seed Table records
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (1, 1);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (2, 1);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (3, 2);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (4, 2);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (4, 3);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (3, 3);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (2, 4);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (1, 4);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (4, 5);
INSERT INTO "Tables" ("NumberOfSeats", "RestaurantId") VALUES (3, 5);

-- seed Users records
INSERT INTO "AppUser" (
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

INSERT INTO "AppUser" (
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
INSERT INTO "Bookings" VALUES ('1','2030-01-01 14:30:00+00', 5, 1, 'id1');
INSERT INTO "Bookings" VALUES ('2','2050-05-07 20:15:00+00', 3, 2, 'id2');

