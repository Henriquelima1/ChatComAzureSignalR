using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public class TestChatHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> userConnectionMap = new ConcurrentDictionary<string, string>();

    public async Task BroadcastMessage(string name, string message)
    {
        Clients.All.SendAsync("broadcastMessage", name, message);
        Console.WriteLine($"Usuário {name} mandou a mensagem para todos: {message}");
        return;
    }

    public Task Echo(string name, string message) =>
        Clients.Client(Context.ConnectionId)
                .SendAsync("echo", name, $"{message} (echo from server)");

    public async Task Message(string name, string message, string nameDest)
    {
        Console.WriteLine($"Usuário {name} mandou a mensagem para {nameDest}: {message}");
        if (userConnectionMap.TryGetValue(nameDest, out var connectionId))
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", $"Usuário {name} mandou a mensagem: {message}");
        }

        return;
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();

        var connectionId = Context.ConnectionId;

        // Adiciona o ID de conexão ao dicionário
        userConnectionMap.TryAdd(connectionId, connectionId);
        Console.WriteLine($"Usuário se conectou {connectionId}");
        // Notifica o usuário sobre o ID de conexão
        await Clients.Client(connectionId).SendAsync("ReceiveConnectionId", connectionId);
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var connectionId = Context.ConnectionId;

        // Remove o ID de conexão do dicionário ao desconectar
        string removedConnectionId;
        userConnectionMap.TryRemove(connectionId, out removedConnectionId);

        await base.OnDisconnectedAsync(exception);
    }
}
