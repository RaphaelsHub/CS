using Microsoft.Data.SqlClient;

namespace DB_Entity
{

    // ADO.NET - предоставляет API к релиационным бд (таблицы, строки, столбцы)
    // Обеспечивает добавление, обновления, обработку данных
    // 2 состовляющии ADO.NET 
    // 1)Поставщик данных - забираем данные, получаем доступ
    // 2)Автономная модель - хранение данных на стороне клиента

    // [Primary Key]
    // Таблица "Пользователи": ID (Primary Key)   Имя   Электронная почта

    // [Foreign Key]
    // Таблица "Заказы": Order_ID (Primary Key)   User_ID (Foreign Key)   Дата   Сумма


    //Connecting string:
    //Data Source=(localdb)\MSSQLLocalDB;    источник данных лок сервер базаданных(microsoftSql)
    //Initial Catalog=MSSQL_LocalDB_MarketPlace;  файл нашей бд который мы создали
    //Integrated Security=True;  авторизация windows
    //Pooling=False;
    //Encrypt=True;
    //Trust Server Certificate=False

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class ConnectDB
    {
        SqlConnectionStringBuilder str;
        SqlConnection sqlConnection;

        public ConnectDB()
        {
            str = new SqlConnectionStringBuilder()
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "MSSQL_LocalDB_MarketPlace",
                IntegratedSecurity = true,
                Pooling = true
            };

            Console.WriteLine($"ConnectionString: {str.ConnectionString} ");

            using ( sqlConnection = new SqlConnection(str.ConnectionString))
            {
                sqlConnection.StateChange += (s, e) =>
                {
                    Console.WriteLine($"SqlConnectionName = {nameof(sqlConnection)} State: {(s as SqlConnection).State}");
                };

                sqlConnection.Open();
            }

            /*
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            */
        }
    }
}
