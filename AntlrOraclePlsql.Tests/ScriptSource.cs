using System;
using System.Collections.Generic;
using System.Text;

namespace AntlrOraclePlsql.Tests
{
    class ScriptSource
    {
        public const string DebugPrint =
@"declare 
  type tItem is record(name varchar2(20), value number);
  type tList is table of tItem;
  vList tList := tList();
  vN number := 1;
begin
  vList.extend(1);
  vlist(1) := tItem('AA', 123);
  select 2 into vList(vn).Value from dual;
  dbms_output.put_line(vList(1).Value);
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
