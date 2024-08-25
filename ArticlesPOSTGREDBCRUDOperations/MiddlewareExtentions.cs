namespace ArticlesPOSTGREDBCRUDOperations
{
    public static partial class MiddlewareExtentions
    {
        public static WebApplication UseCustomMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Articles API v1"));
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting()
                .UseAuthorization()
                .UseEndpoints(r =>
                {
                    r.MapDefaultControllerRoute();
                });
            //app.UseAuthorization();

            return app;
        }
    }
}
