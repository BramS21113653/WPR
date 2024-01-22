import React, { useState, useEffect, useRef } from 'react';

const ChatComponentBusinessUser = ({ researchId, businessUserId, handleClose }) => {
 const [messages, setMessages] = useState([]);
 const [newMessage, setNewMessage] = useState('');
 const socket = useRef(null);

 useEffect(() => {
    const token = localStorage.getItem('jwtToken');
    const userId = localStorage.getItem('userId');

    if (!userId || !businessUserId) {
      console.error("Gebruikers-ID of businessUserId niet gevonden");
      return;
    }

    socket.current = new WebSocket(`wss://localhost:3001/chat?userId=${userId}&researchId=${researchId}&businessUserId=${businessUserId}`);

    socket.current.onopen = () => {
      console.log('WebSocket verbonden');
    };

    socket.current.onmessage = (event) => {
      const message = JSON.parse(event.data);
      setMessages(prevMessages => [...prevMessages, message]);
    };

    socket.current.onerror = (error) => {
      console.error('WebSocket-fout:', error);
    };

    socket.current.onclose = () => {
      console.log('WebSocket verbinding gesloten');
    };

    return () => {
      if (socket.current) {
        socket.current.close();
      }
    };
 }, [researchId, businessUserId]);

 const handleSendMessage = () => {
    if (!socket.current) {
        console.error('Geen WebSocket-verbinding');
        return;
    }

    const messageData = {
        type: 'message',
        content: newMessage,
        senderId: localStorage.getItem('userId'),
        researchId: researchId,  // Ensure this is the correct research ID
        businessUserId: businessUserId
    };

    try {
        socket.current.send(JSON.stringify(messageData));
        setNewMessage(''); // Clear the input field after sending
    } catch (error) {
        console.error('Error sending message:', error);
    }
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

export default ChatComponentBusinessUser;
