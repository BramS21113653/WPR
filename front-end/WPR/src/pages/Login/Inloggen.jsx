import React from 'react';
import './Inloggen.css';
import { useForm } from "react-hook-form";

const Inloggen = () => {
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
      console.log(responseData); // Of doe iets met de ontvangen gegevens, zoals het opslaan van de token

      // Voer verdere acties uit, zoals redirect naar een andere pagina of update gebruikerstaat
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
