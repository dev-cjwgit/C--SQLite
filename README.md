VisualStudio2019
실행 폴더 기준으로
/x86/SQLite.Interop.dll
/SQLiteComponent.dll
/System.Data.SQLite.dll
파일이 필수적으로 존재해야함.

솔루션에서 "추가" - "기존 프로젝트" 후 "SQLiteComponent"의 SQLiteComponent.csproj 추가.
사용하려는 Main 솔루션의 "참조" 우클릭 "참초추가" 후 "SQLiteComponent" 클릭후 확인
SQLite sql = new SQLite(Environment.CurrentDirectory,"default"); // folder path와 생성할 파일이름지정.
// path 맨 끝에 \가 없도록 주의

sql.OpenDataBase() // SQL파일을 염(DB Server Connect과 비슷)
sql.CreateDataBase() // SQL파일을 생성함(DB생성과 비슷)
sql.ExecuteSQL() // SQL 명령문을 실행
List<Dictionary<string, object>> list = sql.GetData(); // 명령문으로 실행한 SQL 데이터를 받아옴


응용으로
while (!sql.OpenDataBase())
            {
                while(!sql.CreateDataBase());
등 순환을 이용하여 처리 가능.