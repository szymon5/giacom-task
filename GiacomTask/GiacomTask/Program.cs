using GiacomTask.Models;
using GiacomTask.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Name=ConnectionStrings:DefaultConnection"));
var app = builder.Build();

app.MapGet("/AddTestCall", (ApplicationDbContext context) =>
{
    context.CallDetails.Add(new CallDetail()
    {
        CallerID = 441215598896,
        Recipient = "448000096481",
        CallDate = DateOnly.Parse("2016-08-16"),
        EndTime = TimeOnly.Parse("14:21:33"),
        Duration = 43,
        Cost = 0,
        Reference = "C5DA9724701EEBBA95CA2CC5617BA93E4",
        Currency = "GBP"
    });
    context.SaveChanges();

    return context.CallDetails.ToList();
});
app.Run();
