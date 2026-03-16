namespace InstaFollow_Checker.Application.DTO
{
    public class DashboardDto
    {
        public int Followers { get; set; }

        public int Following { get; set; }

        public int NotFollowingBack { get; set; } = 0;
    }
}
