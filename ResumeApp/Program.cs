using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Session desteği ekle
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// DbContext'i servislere ekleyelim (sadece bir kez ekliyoruz)
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Service kayıtları - bunlar da app.Build()'den önce olmalı
// Chat servisleri
builder.Services.AddScoped<IChatMessageService, ChatMessageManager>();
builder.Services.AddScoped<IChatMessageDal, EfChatMessageDal>();
builder.Services.AddScoped<IChatbotService, ChatbotService>();

// Resume servisleri
builder.Services.AddScoped<IResumeService, ResumeManager>();
builder.Services.AddScoped<IResumeDal, EfResumeDal>();

// AI ve Matching servisleri
builder.Services.AddScoped<IAIService, AIService>();
builder.Services.AddScoped<IMatchingService, MatchingService>();

// Job Posting servisleri
builder.Services.AddScoped<IJobPostingService, JobPostingManager>();
builder.Services.AddScoped<IJobPostingDal, EfJobPostingDal>();

// Tüm servis kayıtlarından SONRA app.Build() çağrılmalı
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

// Session middleware'ini ekle
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();