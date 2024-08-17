namespace Eon.Com.Application.Configurations.Cors
{
    public static class CorsConfiguration
    {
        /// <summary>
        /// Adiciona a política de CORS ao contêiner de serviços.
        /// </summary>
        /// <param name="services">O contêiner de serviços onde a política de CORS será adicionada.</param>
        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy", builder =>
                {
                    // Define as origens permitidas para a política de CORS.
                    // Substitua "http://localhost:3000/" pela URL da origem permitida.
                    builder.WithOrigins("http://localhost:3000/")
                           .AllowAnyHeader()   // Permite qualquer cabeçalho na solicitação.
                           .AllowAnyMethod();  // Permite qualquer método HTTP (GET, POST, etc.).
                });
            });
        }

        /// <summary>
        /// Configura o middleware de CORS usando a política especificada.
        /// </summary>
        /// <param name="app">O aplicativo onde o middleware de CORS será configurado.</param>
        public static void UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors("ApiCorsPolicy"); // Aplica a política de CORS chamada "ApiCorsPolicy".
        }
    }
}
