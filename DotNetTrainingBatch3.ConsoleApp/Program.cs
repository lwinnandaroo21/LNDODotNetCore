// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EFCoreExamples;
using DotNetTrainingBatch3.ConsoleApp.HttpClientExamples;
using DotNetTrainingBatch3.ConsoleApp.RefitExamples;
using DotNetTrainingBatch3.ConsoleApp.RestClientExamples;

Console.WriteLine("Hello, World!");

//F5 -> Run

//Ctrl + K, C ->Disable
//Ctrl + K, U -> Enable

//Ctrl + .
//F9 -> Break Point
//Shift + F5 -> Stop

#region Read

//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = ".";
//sqlConnectionStringBuilder.InitialCatalog = "TestDb";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "sa@123";

//string query = "select * from tbl_blog";
//SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//sqlConnection.Open();

//SqlCommand cmd = new SqlCommand(query, sqlConnection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);

//DataTable dt = new DataTable();
//adapter.Fill(dt);


//sqlConnection.Close();

////DataSet
////DataTable
////DataRow
////DataColumn

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);


//}

#endregion

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(1);


//adoDotNetExample.Create("test title", "test author", "test content");
//adoDotNetExample.Update(11,"test title 2", "test author 2", "test content 2");
//adoDotNetExample.Delete(11);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(1);
//dapperExample.Create("test title 1", "test author 1", "test content 1");
//dapperExample.Update(13, "test title 4", "test author 4", "test content 4");
//dapperExample.Delete(13);

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit(1);
//eFCoreExample.Edit(11);
//eFCoreExample.Create("test title 1", "test author 1", "test content 1");
//eFCoreExample.Update(14, "test title 6", "test author 6", "test content 6");
//eFCoreExample.Delete(14);

Console.WriteLine("Waiting api");
Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//RestClientExample restClientExample = new RestClientExample();
//await restClientExample.Run();


RefitExample refitExample = new RefitExample();
await refitExample.Run();
// hello

//Console.ReadLine();
Console.ReadKey();