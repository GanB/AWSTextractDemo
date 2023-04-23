using Amazon;
using AWSTextractDemo;

namespace AWSTextractDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            const string bucketname = @"gb65-demo-textract-001";
            var region = RegionEndpoint.USEast2;

            Console.WriteLine("Path to file location:");
            var filename = Console.ReadLine();

            Console.WriteLine("Analysis Type:");
            var analysisType = Console.ReadLine();

            await TextractDriver(bucketname, region, filename, analysisType);

            Console.ReadLine();

        }

        private static async Task TextractDriver(string bucketname, RegionEndpoint region, string filename, string analysisType)
        {
            //if (args.Length == 2)
            //{
                //var filename = args[0];
                //var analysisType = (args.Length > 1) ? args[1] : "text";

                TextractHelper helper = new TextractHelper(bucketname, region);

                switch (analysisType)
                {
                    case "id":
                        await helper.AnalyzeID(filename);
                        Environment.Exit(1);
                        break;
                    case "text":
                        await helper.AnalyzeText(filename);
                        Environment.Exit(1);
                        break;
                    case "table":
                        await helper.AnalyzeTable(filename);
                        Environment.Exit(1);
                        break;
                case "form":
                    await helper.AnalyzeForm(filename);
                    Environment.Exit(1);
                    break;
            }
            //}

            Console.WriteLine("?Invalid parameter - command line format: dotnet run -- <file> text|data|table");
        }
    }
}