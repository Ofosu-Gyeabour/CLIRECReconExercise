select count(*) from t24prd.fbnk_account where recid between '196030000000000.000000' and '196329999999999.999999';

--query for STMT_ENTRY
select recid "RECID",EXTRACTVALUE(xmlrecord,'/row/c3/text()') "Amt", 
EXTRACTVALUE(xmlrecord, '/row/c11/text()') "ValueDate", EXTRACTVALUE(xmlrecord,'/row/c25/text()') "BookingDate", 
EXTRACTVALUE(xmlrecord,'/row/c1/text()') "AccountNo", EXTRACTVALUE(xmlrecord,'/row/c23/text()') "TransRef",
EXTRACTVALUE(xmlrecord,'/row/c6/text()') "Narration", xmlrecord  
FROM t24prd.FBNK_STMT_ENTRY 
where recid between '196030000000000.000000' and '196329999999999.999999';

--fetch next 4 rows only;

--query for FBNK_ACCOUNT. File is updated once a day so there is no date to use
select recid "Account",EXTRACTVALUE(xmlrecord,'/row/c23/text()') "AccountBalance" from t24prd.FBNK_ACCOUNT
fetch next 4 rows only;

select count(*) from t24prd.fbnk_account;

select count(*) "Total" from t24prd.stmt_entry where recid between '196030000000000.000000' and '196329999999999.999999';
