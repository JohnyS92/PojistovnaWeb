using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PojistovnaWebApp.Data;
using PojistovnaWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    // Smazání stávající databáze
    context.Database.EnsureDeleted();

    // Založení nové databáze
    var wasCreated = context.Database.EnsureCreated();


    if (wasCreated)
    { 
    RoleManager<IdentityRole> spravceRoli = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    UserManager<IdentityUser> spravceUzivatelu = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    IdentityUser uzivatel = new IdentityUser("neco@neco");
    await spravceUzivatelu.CreateAsync(uzivatel, "QWer1234*");

    await spravceRoli.CreateAsync(new IdentityRole("admin"));
    await spravceUzivatelu.AddToRoleAsync(uzivatel, "admin");
    }

    var seznamPojisteniList = new List<SeznamPojisteni>();
    for (int i = 0; i < 11; i++)
    {
        var novaPojisteni = new SeznamPojisteni()
        {
            Cena = (1000 * i).ToString(), // Pøevedeme int na string
            NazevPojisteni = "Pojisteni" + i,
            Perex = "perex 1" + i,
            PojisteniOd = new DateTime(2022, 1, 1).AddMonths(i).ToString(), // Pøevedeme DateTime na string
            PojisteniDo = new DateTime(2022, 6, 1).AddMonths(i * 3).ToString(), // Pøevedeme DateTime na string
        };
        seznamPojisteniList.Add(novaPojisteni); // Pøidáme nové pojištìní do seznamu
    }
    context.SeznamPojisteni.AddRange(seznamPojisteniList);
    await context.SaveChangesAsync();
}

app.Run();
