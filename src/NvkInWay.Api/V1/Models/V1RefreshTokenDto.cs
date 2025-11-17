using Microsoft.AspNetCore.Mvc;

namespace NvkInWay.Api.V1.Models;

public class V1RefreshTokenDto
{
    [FromHeader(Name = "X_Device_Id")]
    public required string DeviceId { get; set; }
    
    [FromHeader(Name = "X_Refresh_Token")]
    public required string RefreshToken { get; set; }
    
    [FromHeader(Name = "Authorization")]
    public required string AccessToken { get; set; }
}