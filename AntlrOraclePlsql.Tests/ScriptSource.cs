using System;
using System.Collections.Generic;
using System.Text;

namespace AntlrOraclePlsql.Tests
{
    class ScriptSource
    {
        public const string DebugPrint =
@"declare
  type tRec is record (name tnum); 
  type tbRec is table of tRec;
  type trecholder is record (list tbRec);
  vList tbRec := tbrec(); 
  vHolder tRecHolder; 
begin 
  vList.extend; 
  vList(1).name := tnum();
  vList(1).name.extend;
  
  vholder.List := vList; 
  vHolder.List(1).name.extend;
end;";

        public const string CaseCollectionsExtend =
@"declare
  type tRec is record (name tnum); 
  type tbRec is table of tRec;
  type trecholder is record (list tbRec);
  vList tbRec := tbrec(); 
  vHolder tRecHolder; 
begin 
  vList.extend; 
  vList(1).name := tnum();
  vList(1).name.extend;
  
  vholder.List := vList; 
  vHolder.List(1).name.extend;
end;";

        public const string CasePragmaExceptionInit =
@"create or replace package body mypackage as
  MyException Exception;
  pragma exception_init(MyException, -1234);
end;";

        public const string CaseValuesRowType =
@"declare
  vRowType testtable%rowtype;
begin
  vRowType.A := 1;
  insert into testtable values vRowType;
end;";

        public const string CaseMemberOf =
@"declare
  vList tNum := tNum(1, 2);
  vN number := 1;
begin
  select 1 into vN from dual where vn not member of vList;
end;";

        public const string CaseIntoArray =
@"declare 
  type tItem is record(name varchar2(20), value number);
  type tList is table of tItem;
  vList tList := tList();
begin
  vList.extend(1);
  vlist(1) := tItem('AA', 123);
  select 2 into vList(1).Value from dual;
end;";

        public const string CaseSimpleForest =
@"declare
  vXml xmltype;
  vB varchar2(20) := 'b';
begin
  select xmlforest('a' a, vB b, 'c' as c) into vXml from dual;
  dbms_output.put_line(vXml.getclobval);
end;";

        public const string CaseThreeDot =
@"declare 
  type tPerson is record (name varchar2(20), age number);
  type tPersonExt is record (person tPerson, info varchar2(100)); 
  vPerson tPerson;
  vPersonExt tPersonExt;
  vVal varchar2(20);
begin
  vPerson := tPerson('UserName', '55');
  vPersonExt := tPersonExt(vPerson, 'UserInfo');
  select 'NewName' into vPersonExt.person.name from dual;
  dbms_output.put_line(vPersonExt.person.name);
end;";
    }
}
