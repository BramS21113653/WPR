import React, { useContext } from 'react';
import { useForm } from "react-hook-form";
import { UserContext } from '../../UserContext';
import { useNavigate } from 'react-router-dom'; 
import { API_BASE_URL } from '../../../apiConfig';

const Inloggen = () => {
 const { setUser } = useContext(UserContext);
 const navigate = useNavigate();
 const { register, handleSubmit, formState: { errors } } = useForm();

 const onSubmit = async (data) => {
   try {
      const response = await fetch(`${API_BASE_URL}/ApplicationUser/authenticate`, {
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
     localStorage.setItem('jwtToken', responseData.token);
     localStorage.setItem('userId', responseData.user.id); // Zorg ervoor dat de ID correct wordt opgeslagen
     setUser({ isLoggedIn: true, userInfo: responseData.user });

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
