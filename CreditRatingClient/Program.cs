// See https://aka.ms/new-console-template for more information
using CreditRatingService;
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");


// The port number(5001) must match the port of the gRPC server.
var channel = GrpcChannel.ForAddress("https://localhost:7139");
var client = new CreditRatingCheck.CreditRatingCheckClient(channel);
var creditRequest = new CreditRequest { CustomerId = "id0201", Credit = 7000 };
var reply = await client.CheckCreditRequestAsync(creditRequest);

Console.WriteLine($"Credit for customer {creditRequest.CustomerId} {(reply.IsAccepted ? "approved" : "rejected")}!");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();