// Navbar.jsx
import React, { useState } from 'react';
import { AppBar, Toolbar, IconButton, Drawer, List, ListItem, ListItemText, useTheme, useMediaQuery } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import { Link } from 'react-router-dom';
import logo from '../LOGO.png'; // Adjust the path as needed
import './Navbar.scss';

const Navbar = () => {
    const [drawerOpen, setDrawerOpen] = useState(false);
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down('md'));

    const handleDrawerOpen = () => {
        setDrawerOpen(true);
    };

    const handleDrawerClose = () => {
        setDrawerOpen(false);
    };

    const drawerList = () => (
        <List>
            {['Over Ons', 'Nieuws', 'Contact', 'Portal', 'Onderzoeken', 'Inloggen', 'Registreren'].map((text, index) => (
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
                        {['Over Ons', 'Nieuws', 'Contact', 'Portal', 'Onderzoeken', 'Inloggen', 'Registreren'].map((text, index) => (
                            <ListItem key={text} component={Link} to={`/${text.toLowerCase().replace(/\s+/g, '-')}`} className="nav-item">
                                <ListItemText primary={text} sx={{ color: '#FFFFFF', textDecoration: 'none' }} />
                            </ListItem>
                        ))}
                    </List>
                )}
            </Toolbar>
        </AppBar>
    );
};

export default Navbar;
