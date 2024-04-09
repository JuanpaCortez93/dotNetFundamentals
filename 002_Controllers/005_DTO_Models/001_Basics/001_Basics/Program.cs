using _001_Basics.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddHttpClient<IPostService, PostService>(
    client => {
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");
});


builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddHttpClient<ICommentsService, CommentsService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrlComments"]);
});

builder.Services.AddScoped<IToDosService, ToDosService>();
builder.Services.AddHttpClient<IToDosService, ToDosService>(client => client.BaseAddress = new Uri(builder.Configuration["BaseUrlTodos"]));

builder.Services.AddScoped<IAlbumsService, AlbumsService>();
builder.Services.AddHttpClient<IAlbumsService, AlbumsService>(client => client.BaseAddress = new Uri(builder.Configuration["BaseUrlAlbums"]));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
