namespace MoviesPWA.Shared.Models;

public class Movie
{
  public int Id{get; set;}
  public string Title {get; set;}
  public Director Director{get; set;}
  public int YearOfRelease{get; set;}

  public Movie(){}
}