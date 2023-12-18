import React from 'react';
import './Inloggen.css';
import { useForm } from "react-hook-form";

const Inloggen = () => {
 const { register, handleSubmit, formState: { errors } } = useForm();
 
 const onSubmit = (data) => {
   // Handle form submission
 };

 return (
   <div className="login">
     <h1>Inloggen</h1>
     <form onSubmit={handleSubmit(onSubmit)}>
       <label>
         <p>Gebruikersnaam</p>
         <input type="text" {...register("gebruikersnaam", { required: true })} />
         {errors.gebruikersnaam && <span>This field is required</span>}
       </label>
       <label>
         <p>Wachtwoord</p>
         <input type="wachtwoord" {...register("wachtwoord", { required: true })} />
         {errors.wachtwoord && <span>This field is required</span>}
       </label>
       <div>
         <button type="submit">Submit</button>
       </div>
     </form>
   </div>
 )}

export default Inloggen;

