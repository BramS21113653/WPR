import React from 'react';
import Navbar from './assets/navbar/Navbar';
import Footer from './assets/footer/Footer';
import { useState } from 'react'
import './App.css'

function App() {
 const [count, setCount] = useState(0)

 return (
   <>
     <Navbar />
     <div>
        <li><a href="/ervaringsdeskundigen-portal">Ervaringsdeskundigen Portal</a></li>
        <li><a href="/bedrijvenportal">Bedrijvenportal</a></li>
        <li><a href="/beheerdersportal">Beheerdersportal</a></li>
     </div>
     <Footer />
   </>
 )
}

export default App;