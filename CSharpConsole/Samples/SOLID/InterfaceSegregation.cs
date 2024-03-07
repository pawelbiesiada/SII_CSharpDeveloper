namespace CSharpConsole.Samples.SOLID
{
    internal interface IParser
    {
        string ParseWord(byte[] stream);
        string ParseRdf(byte[] stream);
        string ParseJson(byte[] stream);
    }

    internal interface IWordParser
    {
        string ParseWord(byte[] stream);
    }
    internal interface IPdfParser
    {
        string ParsePdf(byte[] stream);
    }
    internal interface IJsonParser
    {
        string ParseJson(byte[] stream);
    }
}