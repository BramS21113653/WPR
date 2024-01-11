import React, { useState, useContext } from 'react';
import { AppBar, Toolbar, IconButton, Drawer, List, ListItem, ListItemText, useTheme, useMediaQuery } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import LogoutIcon from '@mui/icons-material/ExitToApp';
import LoginIcon from '@mui/icons-material/AccountCircle';
import RegisterIcon from '@mui/icons-material/PersonAdd';
import { Link } from 'react-router-dom';
import logo from '../LOGO.png'; 
import './Navbar.scss';
import { UserContext } from '../../UserContext';
import { useNavigate } from 'react-router-dom';

const Navbar = () => {
 const [drawerOpen, setDrawerOpen] = useState(false);
 const theme = useTheme();
 const isMobile = useMediaQuery(theme.breakpoints.down('md'));
 const { user, setUser } = useContext(UserContext);
 const navigate = useNavigate();

 const handleDrawerOpen = () => {
     setDrawerOpen(true);
 };

 const handleDrawerClose = () => {
     setDrawerOpen(false);
 };

 const handleLogout = () => {
     localStorage.removeItem('jwtToken');
     setUser({ isLoggedIn: false, userInfo: null });
     navigate('/'); // Redirect naar de homepage na uitloggen
 };

 const drawerList = () => (
     <List>
         {['Over Ons', 'Nieuws', 'Contact', 'Portal', 'Onderzoeken'].map((text, index) => (
             <ListItem button key={text} component={Link} to={`/${text.toLowerCase().replace(/\s+/g, '-')}`} onClick={handleDrawerClose}>
               <ListItemText primary={text} />
             </ListItem>
         ))}
     </List>
 );

 return (
     <AppBar position="static" sx={{ backgroundColor: '#111329' }}>
         <Toolbar>
             <Link to="/" className="logo">
               <img src={logo} alt="Logo" />
             </Link>
             {isMobile ? (
               <>
                  <IconButton edge="start" color="inherit" aria-label="menu" sx={{ ml: 'auto' }} onClick={handleDrawerOpen}>
                      <MenuIcon />
                  </IconButton>
                  <Drawer anchor="right" open={drawerOpen} onClose={handleDrawerClose}>
                      {drawerList()}
                  </Drawer>
               </>
             ) : (
               <List sx={{ display: 'flex', marginLeft: 'auto' }}>
                  {['Over Ons', 'Nieuws', 'Contact', 'Portal', 'Onderzoeken'].map((text, index) => (
                      <ListItem key={text} component={Link} to={`/${text.toLowerCase().replace(/\s+/g, '-')}`} className="nav-item">
                          <ListItemText primary={text} sx={{ color: '#FFFFFF', textDecoration: 'none' }} />
                      </ListItem>
                  ))}
               </List>
             )}
             {user.isLoggedIn ? (
               <IconButton edge="end" color="inherit" aria-label="logout" onClick={handleLogout}>
                  <LogoutIcon />
               </IconButton>
             ) : (
               <>
                  <IconButton edge="end" color="inherit" aria-label="login" component={Link} to="/inloggen">
                      <LoginIcon />
                  </IconButton>
                  <IconButton edge="end" color="inherit" aria-label="register" component={Link} to="/registreren">
                      <RegisterIcon />
                  </IconButton>
               </>
             )}
         </Toolbar>
     </AppBar>
 );
};

export default Navbar;
