import React, { useContext } from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { UserContext } from './UserContext';

const PrivateRoute = () => {
 const { user, loading } = useContext(UserContext);

 if (loading) {
  return null; // Or a loading spinner
 }

 return user.isLoggedIn ? <Outlet /> : <Navigate to="/inloggen" />;
};

export default PrivateRoute;
