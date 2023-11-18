namespace MoviesPWA.Shared.Models
{
  public class ServiceResponse<T>
  {
    public T? data { get; set; }
    public bool isSuccess { get; set; }
    public string? message { get; set; }
  }
}