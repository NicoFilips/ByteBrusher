using ByteBrusher.Records.CmdOptions;
using CommandLine;

namespace ByteBrusher.Util.Resource.Args
{
    public static class Arguments
    {
        public static ArgsA(string[] args)
        {

            Parser.Default.ParseArguments<Options>(args)
.WithParsed<Options>(o =>
{
    if (!string.IsNullOrEmpty(o.path))
    {
        Console.WriteLine($"Path to be used: {o.path}");
        _pathToCleanUp += o.path;
    }
    if (!string.IsNullOrEmpty(o.deleteFlag))
    {
        if (o.deleteFlag == "yes" || o.deleteFlag == "true" || o.deleteFlag == "y")
        {
            _deleteFlag = true;
        }
    }
    if (!string.IsNullOrEmpty(o.includeDocuments))
    {
        if (o.includeDocuments == "yes" || o.includeDocuments == "true" || o.includeDocuments == "y")
        {
            _includeDocuments = true;
        }
    }
    if (!string.IsNullOrEmpty(o.includeVideos))
    {
        if (o.includeVideos == "yes" || o.includeVideos == "true" || o.includeVideos == "y")
        {
            _includeVideos = true;
        }
    }


});
        }
    }
}
