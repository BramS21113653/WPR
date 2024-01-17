import React, { useState, useEffect } from 'react';
import { API_BASE_URL } from '../../apiConfig';

const Onderzoeken = () => {
  const [onderzoeken, setOnderzoeken] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchResearches = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/Research`);
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        setOnderzoeken(data);
      } catch (error) {
        console.error("Error fetching data: ", error);
      } finally {
        setLoading(false);
      }
    };

    fetchResearches();
  }, []);

  return (
    <div className="main-content">
      <h1>Onderzoeken</h1>
      {loading ? (
        <p>Laden...</p>
      ) : (
        onderzoeken.map(onderzoek => (
          <div key={onderzoek.id} className="onderzoek-item">
            <h2>{onderzoek.title}</h2>
            <p>{onderzoek.description}</p>
            {onderzoek.imageData && 
              <img src={`data:image/jpeg;base64,${onderzoek.imageData}`} alt={onderzoek.title} />
            }
            <p>Locatie: {onderzoek.locationOnline}</p>
            <p>Type: {onderzoek.researchType}</p>
            <p>Status: {onderzoek.status}</p>
            {/* Add more details as needed */}
          </div>
        ))
      )}
    </div>
  );
};

export default Onderzoeken;
