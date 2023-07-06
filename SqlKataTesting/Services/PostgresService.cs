using SqlKata.Execution;
using SqlKata.Compilers;
using Npgsql;

namespace SqlKataTesting.Services;

public class PostgresService : DBService, IPostgresService {
    public PostgresService() {
        var connString = "Server=127.0.0.1;Port=5432;User Id=user;Password=pass;Database=default";
        var connection = new NpgsqlConnection(connString);
        var compiler = new PostgresCompiler();
        query = new QueryFactory(connection, compiler);
    }

    public void Create() {
        CreateTable("\"Users\"", "\"Id\" float(8),\"CountryId\" float(8)");
        var cols = new List<String>();
        cols.Add("Id");
        cols.Add("CountryId");

        var rows = new List<List<Object>>();
        var row = new List<Object>();
        row.Add(1);
        row.Add(5);
        rows.Add(row);

        row = new List<Object>();
        row.Add(2);
        row.Add(3);
        rows.Add(row);

        var affected = query.Query("Users").Insert(cols, rows);
    }   

    public void Delete() {
        int affected = query.Query("Users").Where("Id", 1).Delete();
    }   
}