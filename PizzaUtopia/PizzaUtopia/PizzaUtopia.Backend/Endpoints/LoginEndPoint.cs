using Microsoft.EntityFrameworkCore;
using PizzaUtopia.Backend.Context;
using PizzaUtopia.Backend.Dto;

namespace PizzaUtopia.Backend.Endpoints

{
    public class LoginEndPoint(PizzaUtopiaDbContext dbContext)
    {
        public async Task<string> Login(LoginDataDto loginData)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginData.Email && u.PasswordHash == loginData.Password);

            if (user == null)
            {
                return "Niepoprawne dane logowania";
            }
            else
            {
                return "Zalogowano";
            }
        }
    }
}
