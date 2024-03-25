using Microsoft.AspNetCore.Builder;
using StudentBio;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<StudentBioWebTestModule>();

public partial class Program
{
}
