namespace sensorupdate
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;

    public class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        /// <summary>
        /// a the
        /// </summary>
        private static void Run()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://165.88.202.71/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    bool running = false;

                    do
                    {
                        var response =httpClient.PostAsJsonAsync("sensors/laundry/0", running.ToString()).Result;
                        response = httpClient.PostAsJsonAsync("sensors/laundry/1", running.ToString()).Result;

                        Thread.Sleep(TimeSpan.FromMinutes(5));

                        running = !running;
                    }
                    while (!Console.KeyAvailable);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
