// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.HW03.ConsoleApp.AdoNetExamples;
using DotNetBath14MTZO.HW03.ConsoleApp.DapperExamples;
using DotNetBath14MTZO.HW03.ConsoleApp.EfCoreExamples;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoNetExample = new AdoDotNetExample();
//adoNetExample.Read();
//adoNetExample.Edit("F6C147D4-99F2-44E2-8094-57CBFC409C89");
//adoNetExample.Create("Title", "Autor", "Content");
//adoNetExample.Update("FCD058EA-2718-46A6-8E02-FEBC317AD8CF","Test","Author","Content 111");
//adoNetExample.Delete("FCD058EA-2718-46A6-8E02-FEBC317AD8CF");

//Dapper

DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit("7BF6274E-37BA-422B-BB2C-BDB21DB41913");
//dapperExample.Create("Tilte", "Author", "Content");
//dapperExample.Update("7BF6274E-37BA-422B-BB2C-BDB21DB41913", "Blog Title 9", "Blog Author 9", "Blog Content 9");
//dapperExample.Delete("C8D60DDA-7F76-4184-B07E-3B5C665D4F37");

//Ef Core

EfCoreExample efCoreExample = new EfCoreExample();
//efCoreExample.Read();
//efCoreExample.Edit("9874F4B0-8725-4288-B6C8-B1CCA5DC21C7");
//efCoreExample.Edit("");
//efCoreExample.Create("Blog Title 11", "Blog Author 11", "Blog Content 11");
//efCoreExample.Update("887BE5D2-3D4B-4263-907A-9A0F93E528EF", "11", "12", "14");
efCoreExample.Delete("887BE5D2-3D4B-4263-907A-9A0F93E528EF");


Console.WriteLine();

