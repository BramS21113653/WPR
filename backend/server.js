// server.js

const express = require('express');
const { WebSocketServer } = require('ws');
const http = require('http');

const app = express();
const server = http.createServer(app);
const wss = new WebSocketServer({ server });

const clients = new Map();

wss.on('connection', (ws, req) => {
  const userId = new URL(req.url, `http://${req.headers.host}`).searchParams.get('userId');
  clients.set(userId, ws);

  ws.on('message', (message) => {
    console.log('Ontvangen bericht:', message);

    // Stuur het bericht naar alle verbonden clients
    clients.forEach((client) => {
      if (client !== ws) {
        client.send(message);
      }
    });
  });

  ws.on('close', () => {
    clients.delete(userId);
    console.log('Client verbinding gesloten');
  });
});

const PORT = process.env.PORT || 3001;
server.listen(PORT, () => {
  console.log(`Server luistert op port ${PORT}`);
});
