
# Chat usando ASP.Net Core com Azure SignalR

Este é um projeto de chat desenvolvido utilizando ASP.Net Core e Azure SignalR. O objetivo deste projeto é criar um chat em tempo real onde os usuários podem se comunicar entre si. Além disso, o projeto também implementa a capacidade de enviar mensagens privadas entre usuários.

## Funcionalidades Principais

- **Chat em Tempo Real:** Os usuários podem enviar e receber mensagens em tempo real, sem a necessidade de atualizar a página.
  
- **Mensagens Privadas:** Os usuários podem enviar mensagens privadas para outros usuários conectados.

## Tecnologias Utilizadas

- **ASP.Net Core:** O projeto é construído utilizando ASP.Net Core, um framework da Microsoft para o desenvolvimento de aplicativos web e APIs.

- **Azure SignalR:** O Azure SignalR é uma solução de mensagens em tempo real oferecida pela Microsoft Azure. Ele fornece conectividade em tempo real para aplicativos web, permitindo a criação de aplicativos com funcionalidades de chat, jogos multiplayer, notificações em tempo real, entre outros.

- **C#:** A linguagem de programação utilizada para desenvolver o backend do projeto é o C#.

## Como Funciona

O projeto consiste em um servidor ASP.Net Core que utiliza o Azure SignalR para comunicação em tempo real entre os clientes. Cada cliente conectado recebe um ConnectionId exclusivo atribuído pelo Azure SignalR.

Quando um cliente se conecta, seu ConnectionId é armazenado em um cache de conexões no servidor. Isso permite que outros usuários enviem mensagens privadas para esse cliente específico, fornecendo seu ConnectionId.

Além disso, o projeto inclui uma interface web simples onde os usuários podem enviar mensagens para todos os participantes do chat ou enviar mensagens privadas para usuários específicos.

## Como Executar o Projeto

1. Certifique-se de ter o SDK do .NET Core instalado em sua máquina. Você pode encontrá-lo [aqui](https://dotnet.microsoft.com/download).

2. Clone este repositório em sua máquina local.

3. Navegue até o diretório do projeto e execute o comando `dotnet run` para iniciar o servidor.

4. Abra um navegador da web e acesse `http://localhost:` para interagir com o chat.
