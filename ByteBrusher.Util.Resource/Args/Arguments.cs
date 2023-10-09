using ByteBrusher.Util.Arguments;
using CommandLine;

namespace ByteBrusher.Util.Resource.Args
{
    public static class Arguments
    {
        public static CliOptions Handle(string[] args)
        {
            CliOptions options = new CliOptions();
            Parser.Default.ParseArguments<CliOptions>(args)
.WithParsed<CliOptions>(o =>
{
    //if (!string.IsNullOrEmpty(o.path))
    //{
    //    Console.WriteLine($"Path to be used: {o.path}");

    //}
    //if (!string.IsNullOrEmpty(o.deleteFlag))
    //{
    //    //if (o.deleteFlag == "yes" || o.deleteFlag == "true" || o.deleteFlag == "y")
    //    //{

    //    //}
    //}
    //if (!string.IsNullOrEmpty(o.includeDocuments))
    //{
    //    if (o.includeDocuments == "yes" || o.includeDocuments == "true" || o.includeDocuments == "y")
    //    {

    //    }
    //}
    //if (!string.IsNullOrEmpty(o.includeVideos))
    //{
    //    if (o.includeVideos == "yes" || o.includeVideos == "true" || o.includeVideos == "y")
    //    {

    //    }
    //}


});
            return options;
        }
    }
}
