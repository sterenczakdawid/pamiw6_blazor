using System.Net.Http.Json;

using MoviesPWA.Shared.Models;

namespace MoviesPWA.Shared.Services
{
    public class MovieService(HttpClient httpClient)
    {
        private readonly string baseApiUrl = "http://localhost:8080";
        private readonly HttpClient _httpClient = httpClient;
        public async Task<ServiceResponse<Page<Movie>>> GetMovies(int pageNumber = 0, int size = 5)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseApiUrl}/api/v1/movies/all2?page={pageNumber}&size={size}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"HTTP request failed. Status code: {response.StatusCode}");
                    return new ServiceResponse<Page<Movie>>
                    {
                        isSuccess = false,
                        message = "HTTP request failed"
                    };
                }

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Page<Movie>>>();
                        if (result == null)
                {
                    Console.WriteLine("Failed to deserialize response");
                    return new ServiceResponse<Page<Movie>>
                    {
                        isSuccess = false,
                        message = "Failed to deserialize response"
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
                return new ServiceResponse<Page<Movie>>
                {
                    isSuccess = false,
                    message = "Network error"
                };
            }
        }
    }
}