using System.Configuration;
using System.Data;
using System.Windows;

namespace DEMO_WPF.NET8
{
    // to scaffolding context use "dotnet ef dbcontext scaffold "Server=DESKTOP-7CAOH5E\SQL;Database=ServiceHard;Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models"
    public partial class App : Application
    {
        public static bool IsAdmin {  get; set; } = false;
    }

}
