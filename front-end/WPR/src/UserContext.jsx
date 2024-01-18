import React, { createContext, useState, useEffect } from 'react';
import { API_BASE_URL } from './../apiConfig';

export const UserContext = createContext();

export const UserProvider = ({ children, navigate }) => {
  const [user, setUser] = useState({
    isLoggedIn: false,
    userInfo: null,
  });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const initializeAuthState = async () => {
      setLoading(true);
      const token = localStorage.getItem('jwtToken');
      console.log("Token:", token); // Debug log

      if (token) {
        try {
          const response = await fetch(`${API_BASE_URL}/ApplicationUser/userinfo`, {
            headers: { Authorization: `Bearer ${token}` },
          });
          if (response.ok) {
            const userInfo = await response.json();
            setUser({ isLoggedIn: true, userInfo });
            console.log("User State Updated:", { isLoggedIn: true, userInfo }); // Debugging...
          }
        } catch (error) {
          console.error('Error fetching user info:', error);
        } finally {
          setLoading(false);
        }
      } else {
        setLoading(false);
      }
    };

    initializeAuthState();
  }, []);

  const handleLogout = () => {
    localStorage.removeItem('jwtToken');
    setUser({ isLoggedIn: false, userInfo: null });
    navigate && navigate('/'); // Use navigate if it's provided
  };

  return (
    <UserContext.Provider value={{ user, setUser, handleLogout, loading }}>
      {children}
    </UserContext.Provider>
  );
};
