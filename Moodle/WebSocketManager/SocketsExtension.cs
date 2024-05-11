using Microsoft.AspNetCore.WebSockets;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;

namespace Moodle.WebSocketManager
{
    public static class SocketsExtension
    {
        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddTransient<Connection>();
            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if(type.GetTypeInfo().BaseType == typeof(SocketHandler))    services.AddSingleton(type);   
            }

            return services;
        }

        public static IApplicationBuilder MapSockets(this IApplicationBuilder app, PathString path, SocketHandler socket)
        {
            return app.Map(path, (x) => x.UseMiddleware<SocketMiddleware>(socket));
        }
    }
}
