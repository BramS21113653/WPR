// ChatComponent.js
import React, { useState, useEffect } from 'react';

const ChatComponent = ({ researchId, handleClose }) => {
  const [messages, setMessages] = useState([]);
  const [newMessage, setNewMessage] = useState('');
  const [socket, setSocket] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem('jwtToken');
    const userId = localStorage.getItem('userId');

    if (!userId) {
      console.error("Gebruikers-ID niet gevonden");
      return;
    }

    const ws = new WebSocket(`ws://localhost:3001/chat?userId=${userId}&researchId=${researchId}`);

    ws.onopen = () => {
      console.log('WebSocket verbonden');
    };

    ws.onmessage = (event) => {
      const message = JSON.parse(event.data);
      setMessages((prevMessages) => [...prevMessages, message]);
    };

    ws.onerror = (error) => {
      console.error('WebSocket-fout:', error);
    };

    ws.onclose = () => {
      console.log('WebSocket verbinding gesloten');
    };

    setSocket(ws);

    return () => {
      ws.close();
    };
  }, [researchId]);

  const handleSendMessage = async () => {
    if (!socket) {
      console.error('Geen WebSocket-verbinding');
      return;
    }

    const messageData = {
      type: 'message',
      content: newMessage,
      senderId: localStorage.getItem('userId'),
      researchId: researchId
    };

    socket.send(JSON.stringify(messageData));
    setNewMessage('');
  };

  return (
    <div style={{ border: '1px solid gray', padding: '10px', margin: '10px' }}>
      <div style={{ height: '300px', overflowY: 'scroll', marginBottom: '10px' }}>
        {messages.map((message, index) => (
          <div key={index} style={{ marginBottom: '10px' }}>
            <strong>{message.senderId === localStorage.getItem('userId') ? 'Jij' : 'Ander'}: </strong>
            <span>{message.content}</span>
          </div>
        ))}
      </div>
      <div>
        <input
          type="text"
          value={newMessage}
          onChange={(e) => setNewMessage(e.target.value)}
          style={{ width: '80%', marginRight: '10px' }}
        />
        <button onClick={handleSendMessage}>Verzend</button>
      </div>
      <button onClick={handleClose} style={{ marginTop: '10px' }}>
        Sluit Chat
      </button>
    </div>
  );
};

export default ChatComponent;
