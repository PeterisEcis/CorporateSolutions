using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Admin", "User" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var admin = new IdentityUser
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com"
        };

        string adminPassword = "1234";
        var adminUser = await userManager.FindByEmailAsync(admin.Email);

        if (adminUser == null)
        {
            var createAdminUser = await userManager.CreateAsync(admin, adminPassword);
            if (createAdminUser.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
