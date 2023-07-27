using Serilog;
namespace CQRSAndMediatRDemo
{
    public class LogInit
    {
        public static void Init(int leve, string mes)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .File("log.txt")
                .CreateLogger();

            switch (leve)
            {
                case 1:
                    Log.Warning(mes);
                    break;
                case 2:
                    Log.Error(mes);
                    break;
                default:
                    Log.Information(mes);
                    break;
            }
            Log.CloseAndFlush();
        }
    }
}
