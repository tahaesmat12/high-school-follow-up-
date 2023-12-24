using hight_school_follow_up.Properties.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBcontext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("connectionDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "ParentRegister",
    pattern: "Parent/Register",
    defaults: new { controller = "Parent", action = "Register" }
);

app.MapControllerRoute(
    name: "TeacherAddingStudent",
    pattern: "Teacher/Addstudent",
    defaults: new { controller = "Teacher", action = "Addstudent" }
);

app.MapControllerRoute(
    name: "TeacherDeleting ",
    pattern: "Teacher/deletestudent",
    defaults: new { controller = "Teacher", action = "deletestudent" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Parent}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "login",
        pattern: "Parent/Login",
        defaults: new { controller = "Parent", action = "Login" });

    endpoints.MapControllerRoute(
        name: "SearchStudent",
        pattern: "Parent/SearchStudent",
        defaults: new { controller = "Parent", action = "SearchStudent" });

    endpoints.MapControllerRoute(
        name: "DisplayStudentDetails",
        pattern: "Parent/DisplayStudentDetails",
        defaults: new { controller = "Parent", action = "DisplayStudentDetails" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Parent}/{action=Index}/{id?}");
});

app.Run();
