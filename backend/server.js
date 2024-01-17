// const express = require('express');
// const { createServer } = require('http');
// const { Server } = require('ws');
// const cors = require('cors');

// const app = express();

// const corsOptions = {
//  origin: ["http://accessibility.steenkamp.eu", "https://localhost:3000", "https://localhost:5173", "http://localhost:5173", "https://localhost:5174", "http://localhost:5174"], // replace with your website's origin
//  methods: ['GET', 'POST'], // replace with your required methods
//  allowedHeaders: ['Content-Type', 'Authorization'], // replace with your required headers
// };

// // Use the cors middleware with custom options
// app.use(cors(corsOptions));

// const server = createServer(app);
// const wss = new Server({ server });

// const clients = new Map();

// wss.on('connection', (ws, req) => {
//  const userId = new URL(req.url, `http://${req.headers.host}`).searchParams.get('userId');
//  clients.set(userId, ws);

//  ws.on('message', (message) => {
//    console.log('Received message:', message);

//    // Send the message to all connected clients
//    clients.forEach((client) => {
//      if (client !== ws) {
//        client.send(message);
//      }
//    });
//  });

//  ws.on('close', () => {
//    clients.delete(userId);
//    console.log('Client connection closed');
//  });
// });

// const PORT = process.env.PORT || 3001;
// server.listen(PORT, () => {
//  console.log(`Server listening on port ${PORT}`);
// });



// const { ChatController } = require('./ChatController');
// const express = require('express');
// const { createServer } = require('http');
// const { Server } = require('ws');
// const cors = require('cors');
// const { AppContext } = require('./AppContext'); // Import your AppContext class

// const app = express();

// const corsOptions = {
//  origin: ["http://accessibility.steenkamp.eu", "https://localhost:3000", "https://localhost:5173", "http://localhost:5173", "https://localhost:5174", "http://localhost:5174"], 
//  methods: ['GET', 'POST'], 
//  allowedHeaders: ['Content-Type', 'Authorization'], 
// };

// app.use(cors(corsOptions));

// const server = createServer(app);
// const wss = new Server({ server });

// const clients = new Map();

// wss.on('connection', (ws, req) => {
//  const userId = new URL(req.url, `http://${req.headers.host}`).searchParams.get('userId');
//  clients.set(userId, ws);

//  ws.on('message', async (message) => {
//   console.log('Received message:', message);

//   // Parse the message into a JavaScript object
//   const parsedMessage = JSON.parse(message);

//   // Create a new ChatMessage instance
//   const newMessage = new ChatMessage();
//   newMessage.ChatId = parsedMessage.ChatId;
//   newMessage.SenderId = parsedMessage.SenderId;
//   newMessage.Content = parsedMessage.Content;

//   // Get the current time and assign it to the Timestamp property
//   newMessage.Timestamp = new Date();

//   // Save the new message to the database
//   const dbContext = new AppContext(); // Create a new instance of AppContext
//   dbContext.ChatMessages.add(newMessage); // Add the new message to the ChatMessages DbSet
//   await dbContext.saveChanges(); // Save the changes to the database

//   // Send the message to all connected clients
//   clients.forEach((client) => {
//     if (client !== ws) {
//       client.send(message);
//     }
//   });
//  });

//  ws.on('close', () => {
//   clients.delete(userId);
//   console.log('Client connection closed');
//  });
// });

// const PORT = process.env.PORT || 3001;
// server.listen(PORT, () => {
//  console.log(`Server listening on port ${PORT}`);
// });


// const express = require('express');
// const { createServer } = require('http');
// const { Server } = require('ws');
// const cors = require('cors');
// const axios = require('axios'); // Add axios for HTTP requests

// const app = express();
// app.use(cors());

// const server = createServer(app);
// const wss = new Server({ server });

// const clients = new Map();

// wss.on('connection', (ws, req) => {
//   const userId = new URL(req.url, `http://${req.headers.host}`).searchParams.get('userId');
//   clients.set(userId, ws);

//   ws.on('message', async (message) => {
//     console.log('Received message:', message);
//     const messageData = JSON.parse(message);

//     try {
//       // Post the message to the backend API
//       await axios.post('http://localhost:5000/chat/send', messageData);

//       // Broadcast the message to all connected clients
//       clients.forEach((client) => {
//         if (client !== ws) {
//           client.send(message);
//         }
//       });
//     } catch (error) {
//       console.error('Error sending message:', error);
//     }
//   });

//   ws.on('close', () => {
//     clients.delete(userId);
//     console.log('Client connection closed');
//   });
// });

// const PORT = process.env.PORT || 3001;
// server.listen(PORT, () => {
//   console.log(`Server listening on port ${PORT}`);
// });





const fs = require('fs');
const https = require('https');
const express = require('express');
const { Server } = require('ws');
const cors = require('cors');
const axios = require('axios');
const path = require('path');

const app = express();
app.use(cors());

// Read SSL certificate files
const key = fs.readFileSync(path.join(__dirname, 'localhost-key.pem'));
const cert = fs.readFileSync(path.join(__dirname, 'localhost.pem'));

// Create HTTPS server
const server = https.createServer({ key, cert }, app);

// WebSocket server
const wss = new Server({ server });

wss.on('connection', (ws, req) => {
    const userId = new URL(req.url, `https://${req.headers.host}`).searchParams.get('userId');
    console.log(`Client connected: ${userId}`);

    ws.on('message', async (message) => {
        console.log('Received message:', message);
        const messageData = JSON.parse(message);

        try {
            // Post the message to the backend API
            const response = await axios.post('https://localhost:5001/chat/send', messageData, {
                httpsAgent: new https.Agent({  
                    rejectUnauthorized: false // This bypasses SSL certificate errors (only for development)
                })
            });

            console.log('Message sent to API:', response.data);

            // Broadcast the message to all connected clients
            wss.clients.forEach(client => {
                if (client !== ws && client.readyState === WebSocket.OPEN) {
                    client.send(message);
                }
            });
        } catch (error) {
            console.error('Error sending message:', error);
        }
    });

    ws.on('close', () => {
        console.log(`Client disconnected: ${userId}`);
    });
});

const PORT = process.env.PORT || 3001;
server.listen(PORT, () => {
    console.log(`HTTPS and WebSocket Server listening on port ${PORT}`);
});

