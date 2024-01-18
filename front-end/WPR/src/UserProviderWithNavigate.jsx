// UserProviderWithNavigate.jsx
import React from 'react';
import { useNavigate } from 'react-router-dom';
import { UserProvider } from './UserContext';

const UserProviderWithNavigate = ({ children }) => {
  const navigate = useNavigate();

  return (
    <UserProvider navigate={navigate}>
      {children}
    </UserProvider>
  );
};

export default UserProviderWithNavigate;
