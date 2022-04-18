using IO.Swagger.Controllers;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace IO.Swagger
{
    public class Server
    {
        private static readonly string listeningIP = "http://localhost:5003/";
        private static HttpListener httpListener = new HttpListener();
        public static List<User> listOfUsers = new List<User>();
        public void Run()
        {
            Console.WriteLine("Launching server...");
            try
            {
                httpListener = new HttpListener();
                httpListener.Start();
                Console.WriteLine("Server has been started");
                httpListener.Prefixes.Add(listeningIP);
                Console.WriteLine("Server is listening: " + listeningIP);

                while (httpListener.IsListening)
                {
                    var requestContext = httpListener.GetContext();

                    HandleRequest(requestContext);
                }
                httpListener.Close();
                httpListener.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        private void HandleRequest(HttpListenerContext requestContext)
        {
            var request = requestContext.Request;
            DefaultApiController defaultApiController = new DefaultApiController();
            switch(request.Url.LocalPath)
            {
                case "/register":
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            string query = request.Url.Query;
                            query = query.Remove(0, 1); // deleting "?" from query
                            var properties = query.Split("&");

                            ObjectResult result = (ObjectResult)defaultApiController.RegisterPost(
                                Int32.Parse(properties[0].Split('=')[1]),
                                properties[1].Split('=')[1],
                                properties[2].Split('=')[1]
                            );
                            listOfUsers[listOfUsers.Count - 1].HttpContext = requestContext;
                            User user = (User)result.Value;
                            var jsonString = JsonConvert.SerializeObject(user);
                            var stream = requestContext.Response.OutputStream;
                            var bytes = Encoding.UTF8.GetBytes(jsonString);
                            stream.Write(bytes, 0, bytes.Length);
                            requestContext.Response.StatusCode = 200;
                            requestContext.Response.Close();
                            break;
                        case "POST":
                            break;
                    }
                    break;
                case "/announce_bets":
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            var jsonString = JsonConvert.SerializeObject(listOfUsers);
                            var stream = requestContext.Response.OutputStream;
                            var bytes = Encoding.UTF8.GetBytes(jsonString);
                            stream.Write(bytes, 0, bytes.Length);
                            requestContext.Response.StatusCode = 200;
                            requestContext.Response.Close();
                            break;
                        case "POST":
                            break;
                    }
                    break;
                case "/making_bet":
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            string query = request.Url.Query;
                            query = query.Remove(0, 1); // deleting "?" from query
                            var properties = query.Split("&");

                            ObjectResult result = (ObjectResult)defaultApiController.MakingBetPost(
                                Int32.Parse(properties[0].Split('=')[1]),
                                Int32.Parse(properties[1].Split('=')[1]),
                                Int32.Parse(properties[2].Split('=')[1])
                            );

                            var jsonString = "";

                            foreach (User u in listOfUsers)
                            {
                                if (u.HttpContext.Equals(requestContext))
                                {
                                    u.Bet = (Bet)result.Value;
                                    jsonString = JsonConvert.SerializeObject(u);

                                }
                            }

                            var stream = requestContext.Response.OutputStream;
                            var bytes = Encoding.UTF8.GetBytes(jsonString);
                            stream.Write(bytes, 0, bytes.Length);
                            requestContext.Response.StatusCode = 200;
                            requestContext.Response.Close();
                            break;
                        case "POST":
                            
                            break;
                    }
                    break;
                case "/drawing":
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            var result = (ObjectResult)defaultApiController.DrawingGet();
                            var jsonString = JsonConvert.SerializeObject(result.Value);
                            var stream = requestContext.Response.OutputStream;
                            var bytes = Encoding.UTF8.GetBytes(jsonString);
                            stream.Write(bytes, 0, bytes.Length);
                            requestContext.Response.StatusCode = 200;
                            requestContext.Response.Close();
                            break;
                        case "POST":
                            break;
                    }
                    break;
                case "/winning_number":
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            var jsonString = JsonConvert.SerializeObject(RollRoulette());
                            var stream = requestContext.Response.OutputStream;
                            var bytes = Encoding.UTF8.GetBytes(jsonString);
                            stream.Write(bytes, 0, bytes.Length);
                            requestContext.Response.StatusCode = 200;
                            requestContext.Response.Close();
                            break;
                        case "POST":
                            break;
                    }
                    break;
                case "/disconnect":
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            break;
                        case "POST":
                            break;
                    }
                    break;
            }
        }

        private byte RollRoulette()
        {
            Random rnd = new Random();
            return (byte)rnd.Next(0, 37);
        }
    }
}
