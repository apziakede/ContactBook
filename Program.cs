using ContactBook.Configurations;
using ContactBook.Data;
using DbUp;
using DbUp.Engine;
using DbUp.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<DbContext, AppDbContext>();
GlobalSettings.ConStr = builder.Configuration.GetConnectionString("DefaultConnection");
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

void TableMigrationScript()
{
    string? conStr = builder.Configuration.GetConnectionString("DefaultConnection");
    EnsureDatabase.For.SqlDatabase(conStr);
    var upgrader = DeployChanges.To.SqlDatabase(conStr)
        .WithScriptsFromFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SqlScripts", "SqlTables"))
        .WithTransactionPerScript()
       .JournalTo(new NullJournal()) 
        .LogToConsole()
        .Build();
    upgrader.PerformUpgrade();
}

void StoredProcMigrationScript()
{
    string? conStr = builder.Configuration.GetConnectionString("DefaultConnection");
    EnsureDatabase.For.SqlDatabase(conStr);
    var upgrader = DeployChanges.To.SqlDatabase(conStr)
        .WithScriptsFromFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SqlScripts", "SqlProcs"))
        .WithTransactionPerScript()
      .JournalTo(new NullJournal()) 
        .LogToConsole()
        .Build();
    upgrader.PerformUpgrade();
}
TableMigrationScript();
StoredProcMigrationScript();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
