namespace ArticlesPOSTGREDBCRUDOperations
{
    public static partial class MiddlewareExtentionscs
    {
        public static WebApplication UseCustomMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting()
                .UseEndpoints(r =>
                {
                    r.MapDefaultControllerRoute();
                });
            app.UseAuthorization();

            return app;
        }
    }
}
