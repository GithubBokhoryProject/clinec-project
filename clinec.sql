create database clinec;
use clinec;
--- create table Doctors
create table Doctors
(
id_doc int primary key,
Name_doc nvarchar(50)not null,
phone nvarchar(20),
Address nvarchar(50)
);
--- create table patients
create table patients
(
id_patient int primary key,
Name_patient nvarchar(50)not null,
phone nvarchar(20),
Address nvarchar(50),
Date_and_time_of_Detection datetime default getdate(),
type_of_Detection nvarchar(15)not null,
the_money_wase_paid bit,
);
--- create table Department
create table Department
(
id_dep int primary key,
Name_dep nvarchar(30)not null,
salary_of_Detection money
);
--- create table page of Detection
create table page_of_Detection
(
id_page int primary key,
symptoms_of_the_disease nvarchar(50),
Analyzes_and_Radiology nvarchar(60),
Diagnosis_Detection nvarchar(60),
the_cure nvarchar(100),
amount_of_cure nvarchar(20)
);
------------------------------------------------------------------
-- relation Doctors and Department
alter table Doctors
add dep_id int not null;
alter table Doctors
add constraint fk_1
foreign key(dep_id)references Department(id_dep);

-- rename table pations to patients
exec sp_rename 'pations','patients';
-- relation patient and Department
alter table patients
add dep_id int not null;
alter table patients
add constraint fk_2
foreign key(dep_id)references Department(id_dep);
-- relation Doctors and patient
alter table page_of_Detection
add doc_id int not null,patient_id int not null;
alter table page_of_Detection
add constraint fk_3
foreign key(doc_id)references Doctors(id_doc);
alter table page_of_Detection
add constraint fk_4
foreign key(patient_id)references patients(id_patient);
----------------------------------------------------------------------
-- Enter Data to table Department
select*from Department
insert into Department
values(1,'children',40);
insert into Department
values(2,'women and obstetrics',80);
insert into Department
values(3,'eyes',100);
insert into Department
values(4,'Nose and ear',50);
-- Enter Data to table Doctors
select*from Doctors
insert into Doctors
values(1,'Ahmed','0115894763','tnta',3);
insert into Doctors
values(2,'Eslam','01204054160','qulubya',1);
insert into Doctors
values(3,'Mohamed','01077956432','el_shrouk',4);
insert into Doctors
values(4,'Omar','0123698755','Giza',2);
-- Enter Data to table patients
select*from patients
insert into patients
values(1,'Ali','012545896','tanta',GETDATE(),'eyes',1,1);
insert into patients
values(2,'amira','01155655556','cairo',GETDATE(),'childeren',0,3);
insert into patients
values(3,'hasan','0105585422','loxur',GETDATE(),'women',1,4);
insert into patients
values(4,'mona','01255548482','alx',GETDATE(),'eyes',1,2);
insert into patients
values(5,'slma','0125487545','usa',GETDATE(),'Nose and ear',1,1);
insert into patients
values(6,'khaled','0118488785','elharam',GETDATE(),'women',0,1);
insert into patients
values(7,'sayed','0125121260','giza',GETDATE(),'eyes',1,2);
-- Enter Data to table page of Detection
select*from page_of_Detection
insert into page_of_Detection
values(1,'عضة كلب','لايوجد','سعار','cfamole flomox500','3 مرات قبل الاكل',1,2);
insert into page_of_Detection
values(2,'زكام','لا يوجد','نزلة برد','Azelast','مرتين يوميا',2,3);
insert into page_of_Detection
values(3,'صداع','لا يوجد','ضعف نظر','prozelen','مرة يوميا',4,2);
insert into page_of_Detection
values(4,'وجع بطن','صونار','نزله معويه حااده','frafero','مره كل يوم صباحا',4,4);
insert into page_of_Detection
values(5,'متابعة حمل','صونار','نقص بروتين','جلوكوز','5 محاليل اسبوعيا',4,1);


