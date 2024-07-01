/*==============================================================*/
/* DBMS name:      PostgreSQL 14.x                              */
/* Created on:     6/30/2024 11:26:16 PM                        */
/*==============================================================*/

drop table if EXISTS reise_teilnehmer cascade;
drop table if EXISTS Reise cascade;
drop table if EXISTS Reiseziel cascade;
drop table if EXISTS teilnehmer cascade;
drop index if exists REISE_PK;
drop index if exists REISE_REISEZIEL_FK;
drop index if exists REISEZIEL_PK;
drop index if exists REISE_TEILNEHMER_FK2;
drop index if exists REISE_TEILNEHMER_FK;
drop index if exists REISE_TEILNEHMER_PK;
drop index if exists TEILNEHMER_PK;



/*==============================================================*/
/* Table: Reise                                                 */
/*==============================================================*/
create table Reise (
   r_id                 serial              not null,
   r_name               varchar(254),
   r_beschreibung       varchar(254),
   r_bild               varchar(254),
   r_startDate          timestamp,
   r_endDate            timestamp,
   constraint PK_REISE primary key (r_id)
);

/*==============================================================*/
/* Index: REISE_PK                                              */
/*==============================================================*/
create unique index REISE_PK on Reise (
r_id
);

/*==============================================================*/
/* Table: Reiseziel                                             */
/*==============================================================*/
create table Reiseziel (
   r_id                 integer              not null,
   rz_id                serial              not null,
   rz_name              varchar(254),
   rz_beschreibung      varchar(254),
   rz_bild              varchar(254),
   constraint PK_REISEZIEL primary key (r_id, rz_id)
);

/*==============================================================*/
/* Index: REISEZIEL_PK                                          */
/*==============================================================*/
create unique index REISEZIEL_PK on Reiseziel (
r_id,
rz_id
);

/*==============================================================*/
/* Index: REISE_REISEZIEL_FK                                    */
/*==============================================================*/
create  index REISE_REISEZIEL_FK on Reiseziel (
r_id
);

/*==============================================================*/
/* Table: reise_teilnehmer                                      */
/*==============================================================*/
create table reise_teilnehmer (
   r_id                 integer              not null,
   t_username           varchar(254)         not null,
   constraint PK_REISE_TEILNEHMER primary key (r_id, t_username)
);

/*==============================================================*/
/* Index: REISE_TEILNEHMER_PK                                   */
/*==============================================================*/
create unique index REISE_TEILNEHMER_PK on reise_teilnehmer (
r_id,
t_username
);

/*==============================================================*/
/* Index: REISE_TEILNEHMER_FK                                   */
/*==============================================================*/
create  index REISE_TEILNEHMER_FK on reise_teilnehmer (
r_id
);

/*==============================================================*/
/* Index: REISE_TEILNEHMER_FK2                                  */
/*==============================================================*/
create  index REISE_TEILNEHMER_FK2 on reise_teilnehmer (
t_username
);

/*==============================================================*/
/* Table: teilnehmer                                            */
/*==============================================================*/
create table teilnehmer (
   t_username           varchar(254)         not null,
   constraint PK_TEILNEHMER primary key (t_username)
);

/*==============================================================*/
/* Index: TEILNEHMER_PK                                         */
/*==============================================================*/
create unique index TEILNEHMER_PK on teilnehmer (
t_username
);

alter table Reiseziel
   add constraint FK_REISEZIE_REISE_REI_REISE foreign key (r_id)
      references Reise (r_id)
      on delete restrict on update restrict;

alter table reise_teilnehmer
   add constraint FK_REISE_TE_REISE_TEI_REISE foreign key (r_id)
      references Reise (r_id)
      on delete restrict on update restrict;

alter table reise_teilnehmer
   add constraint FK_REISE_TE_REISE_TEI_TEILNEHM foreign key (t_username)
      references teilnehmer (t_username)
      on delete restrict on update restrict;



/* Insert data into the teilnehmer table */
INSERT INTO teilnehmer (t_username) VALUES 
('john_doe'),
('jane_smith'),
('alice_jones');

/* Insert data into the Reise table */
INSERT INTO Reise (r_name, r_beschreibung, r_bild, r_startDate, r_endDate) VALUES 
('Berlin Tour', 'A tour through the city of Berlin', 'berlin.png', '2024-07-01 09:00:00', '2024-07-07 18:00:00'),
('Munich Adventure', 'Explore the city of Munich', 'munich.png', '2024-07-10 09:00:00', '2024-07-15 18:00:00'),
('Hamburg Highlights', 'Discover the highlights of Hamburg', 'hamburg.png', '2024-08-01 09:00:00', '2024-08-05 18:00:00');

/* Insert data into the Reiseziel table */
INSERT INTO Reiseziel (r_id, rz_name, rz_beschreibung, rz_bild) VALUES 
(1, 'Brandenburg Gate', 'A famous landmark in Berlin', 'brandenburg_gate.png'),
(1, 'Berlin Wall', 'Historic site of the Berlin Wall', 'berlin_wall.png'),
(2, 'Marienplatz', 'Central square in Munich', 'marienplatz.png'),
(2, 'English Garden', 'Large public park in Munich', 'english_garden.png'),
(3, 'Miniatur Wunderland', 'World''s largest model railway', 'miniatur_wunderland.png'),
(3, 'Hamburg Harbor', 'Largest port in Germany', 'hamburg_harbor.png');

/* Insert data into the reise_teilnehmer table */
INSERT INTO reise_teilnehmer (r_id, t_username) VALUES 
(1, 'john_doe'),
(1, 'jane_smith'),
(2, 'alice_jones'),
(3, 'john_doe');



