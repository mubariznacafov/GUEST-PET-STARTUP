CREATE TABLE "customer" (
  "Id" integer PRIMARY KEY,
  "pet_id" integer,
  "name" varchar,
  "surname" varchar,
  "phone" varchar,
  "email" varchar,
  "user_id" integer,
  "birthdate" timestamp,
  "created_at" timestamp,
  "created_by" varchar,
  "updated_at" timestamp,
  "updated_by" varchar
);

CREATE TABLE "pet" (
  "Id" integer PRIMARY KEY,
  "name" varchar,
  "color" varchar,
  "type" tinyint,
  "age" varchar,
  "shelter" varchar,
  "size" integer,
  "hair_length" timestamp,
  "created_at" timestamp,
  "created_by" varchar,
  "updated_at" timestamp,
  "updated_by" varchar
);

ALTER TABLE "customer" ADD FOREIGN KEY ("user_id") REFERENCES "user" ("Id");
ALTER TABLE "customer" ADD FOREIGN KEY ("pet_id") REFERENCES "customer" ("Id");






