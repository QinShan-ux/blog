namespace Blog.Service.Dto.Plan;

public class GetPlanInfoDto
{
    public string Plan { get; set; } = string.Empty;
    public List<string> InspirationList { get; set; } = new List<string>();
    public List<string> Trouble         { get; set; } = new List<string>();

    public string SuccessTag { get; set; } = string.Empty;
    public DateTime     CreateTime      { get; set; }
    public DateTime     SuccessTime     { get; set; }
}