namespace CommandsSample
{
    class Program
    {
        static void Main(string[] args) {
            new Server().Run(args);
            new Client().Run(args);
        }
    }
}
