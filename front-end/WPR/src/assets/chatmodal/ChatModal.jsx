// ChatModal.js
import React from 'react';
import './ChatModal.css'; // Zorg ervoor dat je CSS-stijlen hebt

const ChatModal = ({ onClose }) => {
    return (
        <div className="chat-modal">
            <button onClick={onClose}>Sluit Chat</button>
            <p>coming soon</p>
        </div>
    );
};

export default ChatModal;
