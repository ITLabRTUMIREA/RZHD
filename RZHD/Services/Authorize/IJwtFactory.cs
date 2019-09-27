namespace RZHD.Services.Authorize
{
    public interface IJwtFactory
    {
        string GenerateAccessToken(int userId);
    }
}
