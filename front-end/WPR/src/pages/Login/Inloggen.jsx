import React, { useContext } from 'react';
import { useForm } from "react-hook-form";
import { UserContext } from '../../UserContext';
import { useNavigate } from 'react-router-dom'; 

const Inloggen = () => {
 const { setUser } = useContext(UserContext);
 const navigate = useNavigate();
 const { register, handleSubmit, formState: { errors } } = useForm();

 const onSubmit = async (data) => {
   try {
     const response = await fetch('https://localhost:5001/ApplicationUser/authenticate', {
       method: 'POST',
       headers: {
         'Content-Type': 'application/json',
       },
       body: JSON.stringify({
         Username: data.gebruikersnaam,
         Password: data.wachtwoord,
       }),
     });

     if (!response.ok) {
       throw new Error('Inloggen mislukt.');
     }

     const responseData = await response.json();
     localStorage.setItem('jwtToken', responseData.token); // Store the JWT token in localStorage
     setUser({ isLoggedIn: true, userInfo: responseData.user }); // Update the user status in the context

     navigate('/'); // Redirect to the homepage after successful login
   } catch (error) {
     alert(error.message);
   }
 };

 return (
   <div className="login main-content">
     <h1>Inloggen</h1>
     <form onSubmit={handleSubmit(onSubmit)}>
       <label>
         <p>Gebruikersnaam</p>
         <input type="text" {...register("gebruikersnaam", { required: true })} />
         {errors.gebruikersnaam && <span>Dit veld is verplicht</span>}
       </label>
       <label>
         <p>Wachtwoord</p>
         <input type="password" {...register("wachtwoord", { required: true })} />
         {errors.wachtwoord && <span>Dit veld is verplicht</span>}
       </label>
       <div>
         <button type="submit">Inloggen</button>
       </div>
     </form>
   </div>
 );
}

export default Inloggen;
