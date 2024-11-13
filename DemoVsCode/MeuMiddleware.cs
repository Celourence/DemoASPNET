using System.Diagnostics;
using Serilog;

namespace DemoVsCode
{
    public class TemplateMiddleware
    {
        private readonly RequestDelegate _next;

        public TemplateMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) 
        {
            //Faz Algo antes
            //Chama o próximo middleware no pipeline
            await _next(httpContext);
            //Faz algo depois
        }
    }

    public class LogTempoMiddeware 
    {
        private readonly RequestDelegate _next;

        public LogTempoMiddeware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Faz Algo antes
            var sw = Stopwatch.StartNew();

            //Chama o próximo middleware no pipeline
            await _next(httpContext);

            sw.Stop();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information($"A execução demorou {sw.Elapsed.TotalMilliseconds}ms ({sw.Elapsed.TotalSeconds} segundos)");
            //Faz algo depois
        }
    }

    public static class SerilogExtensions
    {
        public static void AddSerilog(this WebApplicationBuilder builder) 
        {
            builder.Host.UseSerilog();
        }
    }

    public static class LogTempoMiddewareExtensions
    {
        public static void UseLogTempo(this WebApplication app)
        {
            app.UseMiddleware<LogTempoMiddeware>();
        }
    }
}

