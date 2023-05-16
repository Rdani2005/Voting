using Microsoft.EntityFrameworkCore;
using VotingBackend.Data;
using VotingBackend.Repos.PoliticalMemberRepo;
using VotingBackend.Repos.PoliticalPartyRepo;
using VotingBackend.Repos.SpecialtyRepo;
using VotingBackend.Repos.SupportUserRepo;
using VotingBackend.Repos.VoteRepo;
using VotingBackend.Repos.VoterRepo;
using VotingBackend.Repos.YearRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
if (builder.Environment.IsProduction())
{
    Console.WriteLine("--> Using SQL Server Database, Production Environment");
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("PlatformsConn")
    ));
}
else
{
    Console.WriteLine("--> Using In Memory Database, Dev Environment");
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
}

// SQL Inyections
builder.Services.AddScoped<IVoterRepo, VoterRepo>();
builder.Services.AddScoped<IYearRepo, YearRepo>();
builder.Services.AddScoped<IVoteRepo, VoteRepo>();
builder.Services.AddScoped<ISupportUserRepo, SupporUserRepo>();
builder.Services.AddScoped<ISpecialtyRepo, SpecialtyRepo>();
builder.Services.AddScoped<IPoliticalRepo, PoliticalRepo>();
builder.Services.AddScoped<IPoliticalMemberRepo, MemberRepo>();
// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


if (builder.Environment.IsDevelopment())
{
    // CORS
    builder.Services.AddCors(
        options =>
        {
            options.AddPolicy("Policy", app =>
            {
                app.AllowAnyHeader();
                app.AllowAnyOrigin();
                app.AllowAnyMethod();
            });
        }
    );
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Policy");
}

// // app.UseHttpsRedirection();
PrepDb.PrepPopulation(app, app.Environment.IsProduction());
app.UseAuthorization();

app.MapControllers();

app.Run();

