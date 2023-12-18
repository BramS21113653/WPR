import React from 'react';
import Navbar from './assets/navbar/Navbar';
import Footer from './assets/footer/Footer';
import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
 const [count, setCount] = useState(0)

 return (
   <>
     <Navbar />
     <Footer />
     {/* Other components go here */}
   </>
 )
}

export default App;