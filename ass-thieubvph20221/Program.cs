using ass_thieubvph20221.Services;
using ass_thieubvph20221.Services.iservices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IGiayService, giayService>();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(60);
    // Định hình Session này tồn tại trong 30 giây
}); // Thêm cái này để dùng Session

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
