import React, { useContext } from 'react';
import './Inloggen.css';
import { useForm } from "react-hook-form";
import { UserContext } from '../../UserContext'; // Importeer de UserContext

const Inloggen = () => {
  const { setUser } = useContext(UserContext); // Gebruik de setUser functie van UserContext
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
      localStorage.setItem('jwtToken', responseData.token); // Sla de JWT-token op in localStorage
      setUser({ isLoggedIn: true, user: responseData.user }); // Update de gebruikersstatus in de context

      // Voer verdere acties uit, zoals redirect naar een dashboard of hoofdpagina
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
