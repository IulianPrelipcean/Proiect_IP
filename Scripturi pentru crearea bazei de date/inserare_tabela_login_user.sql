insert into login (user_tip,pass,rol,cnp)  values ('administratie','administratie','administrator',''); 
insert into login (user_tip,pass,rol,cnp)  values ('dss','management','manager',''); 
insert into login (user_tip,pass,rol,cnp)  values ('Florea Mihai', 'administratie','administrator','1460913400088');
insert into login (user_tip,pass,rol,cnp)  values ('Carmen Stavarache', 'administratie','administrator','2781001330012');
insert into login (user_tip,pass,rol,cnp)  values ('Isachi Daniela', 'administratie','administrator','2730421440012');
insert into login (user_tip,pass,rol,cnp)  values ('Istrate Anca', 'administratie','administrator','2751224550012');
insert into login (user_tip,pass,rol,cnp)  values ('Petria Ioan', 'administratie','administrator','1620613400032');
insert into login (user_tip,pass,rol,cnp)  values ('Morosanu Zana', 'administratie','administrator','2790111660012');
insert into login (user_tip,pass,rol,cnp)  values ('Teodorescu Simona', 'administratie','administrator','2730802770012');
insert into login (user_tip,pass,rol,cnp)  values ('Hirja Petronela', 'administratie','administrator','2740504880012');
insert into login (user_tip,pass,rol,cnp)  values ('Curalariu Corina', 'administratie','administrator','2730121990012');
insert into login (user_tip,pass,rol,cnp)  values ('Teodorescu Constantin', 'administratie','administrator','1531028197506');
insert into login (user_tip,pass,rol,cnp)  values ('Gherghel Angelica', 'administratie','administrator','2770618440112');
insert into login (user_tip,pass,rol,cnp)  values ('Morosanu Anisoara', 'administratie','administrator','2700621440212');


insert into user_tables values ('CAMERE');
insert into user_tables values ('CAMINE');
insert into user_tables values ('CONDUCERE');
insert into user_tables values ('DATE_STUDENTI');
insert into user_tables values ('DOSARE');
insert into user_tables values ('LOGIN');
insert into user_tables values ('REGISTRE');
insert into user_tables values ('STUDENTI');

commit work;

select * from login;