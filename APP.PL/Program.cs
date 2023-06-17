using APP.BLL.Interfaces;
using APP.BLL.Services;
using APP.DAL.Interfaces;
using APP.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IClassRoomBLL, ClassRoomBLL>();
builder.Services.AddScoped<IClassRoomDAL, ClassRoomDAL>();

builder.Services.AddScoped<ISubjectBLL, SubjectBLL>();
builder.Services.AddScoped<ISubjectDAL, SubjectDAL>();

builder.Services.AddScoped<ITeacherBLL, TeacherBLL>();
builder.Services.AddScoped<ITeacherDAL, TeacherDAL>();

builder.Services.AddScoped<IStudentBLL, StudentBLL>();
builder.Services.AddScoped<IStudentDAL, StudentDAL>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
            //.SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.Run();

