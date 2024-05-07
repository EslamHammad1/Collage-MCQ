using CollageV2.DataEF;
using CollageV2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

var CS = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();


builder.Services.AddDbContext<CollageContext>(options =>
{
    options.UseSqlServer(CS);
});
builder.Services.AddScoped<IStudentService, StudentService>();

//___________________________

//todo:check Jwt

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudiance"],
        IssuerSigningKey =
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

/// swagger buttom 
builder.Services.AddSwaggerGen(Options =>
{
    Options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Missing person",
        Version = "v1",
        Description = "{\r\n  \"userName\": \"Eslam_Hammad\",\r\n  \"password\": \"Eslam1234@\"\r\n}",

        Contact = new OpenApiContact
        {
            Name = "Eslam Hammad",
            Email = "eslamhammadxz13@gmail.com\r\n",
            Url = new Uri("https://www.linkedin.com/in/eslamhamma74/")

        }
    });
    Options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    Options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                    },
                    Name ="Bearer",
                    In = ParameterLocation.Header
                    },
                    new List<string>()

                    }
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(c => c.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
