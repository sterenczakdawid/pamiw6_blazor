using System.Net.Http.Json;
using System.Text.Json;
using MoviesPWA.Shared.Models;

namespace MoviesPWA.Shared.Services
{
    public class MovieService(HttpClient httpClient)
    {
        private readonly string baseApiUrl = "http://localhost:8080";
        private readonly HttpClient _httpClient = httpClient;
        public async Task<ServiceResponse<Page<Movie>>> GetMovies(int pageNumber = 0, int size = 4)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseApiUrl}/api/v1/movies/all?page={pageNumber}&size={size}");
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

        public async Task<ServiceResponse<Movie>> DeleteMovie(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{baseApiUrl}/api/v1/movies/delete/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"HTTP request failed. Status code: {response.StatusCode}");
                    return new ServiceResponse<Movie>
                    {
                        isSuccess = false,
                        message = "HTTP request failed"
                    };
                }

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
                return new ServiceResponse<Movie>
                {
                    isSuccess = false,
                    message = "Network error"
                };
            }
        }

        public async Task<ServiceResponse<Movie>> AddMovie(Movie movie)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{baseApiUrl}/api/v1/movies/add", movie);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"HTTP request failed. Status code: {response.StatusCode}");
                    return new ServiceResponse<Movie>
                    {
                        isSuccess = false,
                        message = "HTTP request failed"
                    };
                }

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
                return new ServiceResponse<Movie>
                {
                    isSuccess = false,
                    message = "Network error"
                };
            }
        }

        public async Task<ServiceResponse<Movie>> UpdateMovie(Movie movie)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{baseApiUrl}/api/v1/movies/update", movie);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"HTTP request failed. Status code: {response.StatusCode}");
                    return new ServiceResponse<Movie>
                    {
                        isSuccess = false,
                        message = "HTTP request failed"
                    };
                }

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
                return new ServiceResponse<Movie>
                {
                    isSuccess = false,
                    message = "Network error"
                };
            }
        }

        public async Task<ServiceResponse<Movie>> GetMovieById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseApiUrl}/api/v1/movies/{id}");
                if (!response.IsSuccessStatusCode)
                return new ServiceResponse<Movie>()
                {
                    isSuccess = false,
                    message = "HTTP request failed"
                };

                var json = await response.Content.ReadAsStringAsync();
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Movie>>();

                return result;
            }
            catch (Exception)
            {
                return new ServiceResponse<Movie>
                {
                isSuccess = false,
                message = "Network error"
                };
            }
        }

    }
}