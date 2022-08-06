using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Section7_Security.Server.Data;
using Section7_Security.Server.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);




//new ---User Role--- code ends here


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => { options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();



//************ CLaim/Role based authorization *********************

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
    {
        //we added user-claim/role to both "ID-token and access-token" 
        options.IdentityResources["openid"].UserClaims.Add("role");
        options.ApiResources.Single().UserClaims.Add("role");
    });
//prevent default mapping of roles...?
System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

//************ END *********************



builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// ***********************new ---User claim/Role--- code starts from here***************************************
void CreateUser()
{
    Console.WriteLine("fun called");

    //get user manager class in a variable, default class of users is 'ApplicationUser'
    var userManager = app.Services.GetRequiredService<UserManager<ApplicationUser>>();
    string email = "lubna@gmail.com";
    string securePassword = "lubna123";

    //first try to find user in DB
    Task<ApplicationUser> adminUser = userManager.FindByEmailAsync(email);
    adminUser.Wait();

    if (adminUser.Result == null)
    {
        var admin = new ApplicationUser();
        admin.Email = email;
        admin.UserName = email;
        //create user if not found-------------
        Task<IdentityResult> newUser = userManager.CreateAsync(admin, securePassword);
        newUser.Wait();
    }
    var createAdminUser = userManager.FindByEmailAsync(email);      ///now again finding after adding
    createAdminUser.Wait();
    userManager.AddClaimAsync(createAdminUser.Result,
        new System.Security.Claims.Claim("role", "Admin")).Wait();  //added claim to founded user

}
// *********************** END ***************************************

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();



app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

CreateUser();
app.Run();






