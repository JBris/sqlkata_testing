using System.Diagnostics;
using SqlKata.Execution;
using SqlKata.Compilers;

public abstract class DBService {
    protected QueryFactory query;

    public void CreateTable(string table, string cols) {
        DropTable(table);
        query.Statement($"CREATE TABLE IF NOT EXISTS {table}({cols});");
    }

    public void DropTable(string table)
    {
        query.Statement($"DROP TABLE IF EXISTS {table};");
    }
}