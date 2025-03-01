using VladPC.DAL;
using VladPC.BLL.DTO;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var db = new VladPcdbContext())
        {
            db.Users.Select(i => i).ToList();
        }
    }
}