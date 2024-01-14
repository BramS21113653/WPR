import React, { createContext, useState, useEffect } from 'react';
import { API_BASE_URL } from './../apiConfig';

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
 const [user, setUser] = useState({
 isLoggedIn: false,
 userInfo: null,
 });
 const [loading, setLoading] = useState(true);

 useEffect(() => {
 const initializeAuthState = async () => {
   const token = localStorage.getItem('jwtToken');
   console.log("Token:", token); // Debug log
   if (token) {
     // Fetch user info based on token
     try {
       const response = await fetch(`${API_BASE_URL}/ApplicationUser/userinfo`, {
         headers: { Authorization: `Bearer ${token}` },
       });
       if (response.ok) {
         const userInfo = await response.json();
         setUser({ isLoggedIn: true, userInfo });
         console.log("User State Updated:", { isLoggedIn: true, userInfo }); //debugging.....
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

 return (
 <UserContext.Provider value={{ user, setUser, loading }}>
   {children}
 </UserContext.Provider>
 );
};
