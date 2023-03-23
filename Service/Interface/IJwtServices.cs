namespace Service.Interface
{
    public interface IJwtServices
    {
        public string GetToken(int id);
        public int GetUserIdFromToken();
    }
}
